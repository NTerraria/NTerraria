using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class EclipseEvent : Event
    {
        public override string DisplayName => "Eclipse";

        public override string Description => "Dangerous creatures of horror roam the land.";

        public override string ShortDescription => "Increased EXP gain.";

        public override bool ShouldUpdate() => Main.eclipse;

        public override void Update()
        {
            /* TODO: vvv
             * Procs.BaseExpPercent += 25;
             */
        }
    }
}
