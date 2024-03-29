﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.CS.TabletopUI;
using Assets.TabletopUi;
using UnityEngine;
using BepInEx.Configuration;
using System.IO;

namespace CultistTimejump
{
    [BepInEx.BepInPlugin("net.robophreddev.CultistSimulator.CultistTimejump", "CultistTimejump", "1.0.1")]
    public class CultistTimejumpPlugin : BepInEx.BaseUnityPlugin
    {
        private ConfigEntry<KeyboardShortcut> SkipTimeKey;

        private TabletopTokenContainer TabletopTokenContainer
        {
            get
            {
                {
                    var tabletopManager = Registry.Get<TabletopManager>();
                    if (tabletopManager == null)
                    {
                        this.Logger.LogError("Could not fetch TabletopManager");
                    }

                    return tabletopManager._tabletop;
                }
            }
        }

        private Heart Heart
        {
            get
            {
                var heartGo = GameObject.Find("Heart");
                if (heartGo == null)
                {
                    this.Logger.LogError("Could not fetch Heart game object.");
                }

                var heart = heartGo.GetComponent<Heart>();

                if (heart == null)
                {
                    this.Logger.LogError("Could not get heart from Heart game object.");
                }

                return heart;
            }
        }


        void Start()
        {
            SkipTimeKey = Config.Bind(new ConfigDefinition("Hotkeys", "SkipTimeKey"), new KeyboardShortcut(KeyCode.F));
            if (!File.Exists(Config.ConfigFilePath))
            {
                Config.Save();
            }

            this.Logger.LogInfo("CultistTimejump initialized.");
        }

        void Update()
        {
            if (SkipTimeKey.Value.IsDown())
            {
                this.JumpToNextSituationEvent();
            }
        }

        void JumpToNextSituationEvent()
        {
            var ongoingSituations =
                from situation in this.GetAllSituations()
                where this.IsSituationOngoing(situation)
                orderby situation.SituationController.SituationClock.TimeRemaining
                select situation;

            var nextSituationToElapse = ongoingSituations.FirstOrDefault();
            if (nextSituationToElapse == null)
            {
                // No situations available
                return;
            }

            var timeRemaining = nextSituationToElapse.SituationController.SituationClock.TimeRemaining;

            // I am not sure what unit the interval is in compared to TimeRemaining.
            // The Heart class has a 'usualInterval' variable set to 0.05, which is used as the interval every beat.
            //  On fast speed, this is multiplied by 3.

            // Going to assume this wants an interval in seconds for now.
            var heart = this.Heart;
            if (heart == null)
            {
                // Cant find the heart controller, so we cannot do anything.
                return;
            }

            heart.FastForward(timeRemaining);

            // Force magnet slots to trigger
            var outstandingSlotsToFill = Reflection.GetPrivateField<HashSet<TokenAndSlot>>(heart, "outstandingSlotsToFill");
            outstandingSlotsToFill = Registry.Get<TabletopManager>().FillTheseSlotsWithFreeStacks(outstandingSlotsToFill);
            Reflection.SetPrivateField(heart, "outstandingSlotsToFill", outstandingSlotsToFill);
        }

        IEnumerable<SituationToken> GetAllSituations()
        {
            foreach (var token in TabletopTokenContainer.GetTokens())
            {
                var situationToken = token as SituationToken;
                if (situationToken != null)
                {
                    yield return situationToken;
                }
            }
        }

        bool IsSituationOngoing(SituationToken situationToken)
        {
            var state = situationToken.SituationController.SituationClock.State;
            if (state == SituationState.Ongoing || state == SituationState.FreshlyStarted)
            {
                return true;
            }
            return false;
        }
    }
}