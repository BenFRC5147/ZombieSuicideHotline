﻿using System.ComponentModel;
using Exiled.API.Interfaces;
using System.Collections.Generic;

namespace ZombieSuicideHotline
{
    public class Config : IConfig {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

		[Description("Enable or disable SCP-049 using .recall to teleport zombies back.")]
		public bool AllowRecall { get; set; } = false;

		[Description("Enable or disable SCP-173 using .vent to teleport to another SCP.")]
		public bool AllowVent { get; set; } = false;

		[Description("Enable or disable respawning players who ragequit the game after being killed by SCP-049.")]
		public bool RespawnZombieRagequits { get; set; } = false;

		[Description("How long between each use of .recall?")]
		public float RecallCooldown { get; set; } = 20f;

        [Description("How long between each use of .vent?")]
        public float VentCooldown { get; set; } = 40f;

        [Description("A list of classes that should be able to call the suicide hotline and what percent of their health is removed.")]
        public Dictionary<string, float> HotlineCalls { get; set; } = new Dictionary<string, float>
        {
			{
				"Scp049", -1f
			},
			{
                "Scp0492", 0f
            },
			{
				"Scp096", -1f
			},
			{
				"Scp106", -1f
			},
			{
				"Scp173", -1f
			},
			{
				"Scp93953", -1f
			},
			{
				"Scp93989", -1f
			},
		};
    }
}
