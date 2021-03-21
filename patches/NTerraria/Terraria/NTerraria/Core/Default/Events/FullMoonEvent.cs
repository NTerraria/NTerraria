using Terraria.Enums;
using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class FullMoonEvent : Event
    {
        public override string DisplayName => "Full Moon";

        public override string Description => "Increased werewolf spawnrate.";

        public override bool ShouldUpdate() => Main.GetMoonPhase() == MoonPhase.Full && Main.hardMode;
    }
}
