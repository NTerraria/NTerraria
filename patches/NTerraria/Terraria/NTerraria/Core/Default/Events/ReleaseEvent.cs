using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    // TODO: Add date here!
    public class ReleaseEvent : Event
    {
        public override string DisplayName => "Release Celebration";

        public override string Description => "Increased experience and loot gain for everyone!";

        public override bool ShouldUpdate() => base.ShouldUpdate();

        public override void Update()
        {
            /* TODO:
             * Procs.BaseExpPercent += 20;
             * Procs.ClassExpPercent += 20;
             * Procs.LootPercent += 20;
             */
        }
    }
}
