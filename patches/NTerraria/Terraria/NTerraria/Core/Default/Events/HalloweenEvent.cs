using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class HalloweenEvent : Event
    {
        public override string DisplayName => "Happy Halloween";

        public override string Description => "Increased experience gain.";

        public override bool ShouldUpdate() => Main.halloween;

        public override void Update()
        {
            /* TODO: vvv
             * Procs.BaseExpPercent += 25;
             * Procs.ClassExpPercent += 20;
             */
        }
    }
}
