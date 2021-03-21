using System;
using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class BlackFridayEvent : Event
    {
        public override string DisplayName => "Black Friday";

        public override string Description => "Mass shop discounts.";

        public override bool ShouldUpdate() => DateTime.Now.DayOfWeek == DayOfWeek.Friday;
    }
}
