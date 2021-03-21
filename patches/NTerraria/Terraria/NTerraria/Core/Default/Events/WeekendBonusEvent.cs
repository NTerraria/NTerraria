using System;
using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class WeekendBonusEvent : Event
    {
        public override string DisplayName => "Weekend Bonus";

        public override string Description => "Trainer during weekends is considerably more rewarding.";

        public override string ShortDescription => "End-of-the-week bonus experience.";

        public override bool ShouldUpdate() => DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;

        public override void Update()
        {
            /* TODO: vvv
            Procs.BaseExpPercent += 50;
            Procs.ClassExpPercent += 50;
            Procs.LootPercent += 20;
             */
        }
    }
}
