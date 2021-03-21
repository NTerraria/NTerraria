using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class ChristmasEvent : Event
    {
        public override string DisplayName => "Merry Christmas";

        public override string Description => "Increased experience gain. Happy holidays!";

        public override bool ShouldUpdate() => Main.xMas;

        public override void Update()
        {
            /* TODO: vvv
             * Procs.BaseExpPercent += 25;
             * Procs.ClassExpPercent += 20;
             */
        }
    }
}
