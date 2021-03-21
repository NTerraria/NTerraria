using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class BloodMoonEvent : Event
    {
        public override string DisplayName => "Blood Moon";

        public override string Description => "Increased monster aggression and EXP gain.";

        public override bool ShouldUpdate() => Main.bloodMoon;

        public override void Update()
        {
            /* TODO: vvv
             * Procs.BaseExpPercent += 10;
             */
        }
    }
}
