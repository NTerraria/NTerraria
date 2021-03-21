using System;
using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class TerrariaBirthdayEvent : Event
    {
        public override string DisplayName => "Terraria Birthday Celebration";

        public override string Description => "Today is Terraria's launch day. 50% increased experience gain and drop rates.";

        public override string ShortDescription => "Increased experience gain and drop rates.";

        public override bool ShouldUpdate() => DateTime.Now.Day >= 9 && DateTime.Now.Day <= 16 && DateTime.Now.Month == 4;

        public override void Update()
        {
            /* TODO: vvv
             * Procs.BaseExpPercent += 50;
             * Procs.ClassExpPercent += 50;
             * Procs.LootPercent += 50;
             */
        }
    }
}
