using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class RainEvent : Event
    {
        public override string DisplayName => "It's Raining";

        public override string Description => "Minor experience gain increase.";

        public override bool ShouldUpdate() => Main.raining;

        public override void Update()
        {
            /* TODO: vvv
             * Procs.BaseExpPercent += 20;
             * Procs.ClassExpPercent += 20;
             */
        }
    }
}
