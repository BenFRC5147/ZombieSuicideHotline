﻿using System.ComponentModel;
using Exiled.API.Interfaces;
using System.Collections.Generic;

namespace ZombieSuicideHotline
{
    public class Config : IConfig {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("A list of classes that should beable to call the suicide hotline and what precent of their health is done")]
        public Dictionary<string, float> HotlineCalls { get; set; } = new Dictionary<string, float>
        {
            {
                "Scp0492", 0.5f
            },
        };
    }
}
