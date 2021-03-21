using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class LuckyDayEvent : Event
    {
        public override string DisplayName => "Good Luck Day";

        public override string Description => "Increased drop rates!";

        public override bool ShouldUpdate()
        {
            switch (IsRunning)
            {
                case true when Main.time == 0d && Main.dayTime:
                    IsRunning = false;
                    break;

                case false when Main.rand.Next(10) == 0 && Main.time == 0d && Main.dayTime:
                    IsRunning = true;
                    break;
            }

            return IsRunning;
        }

        public override void Update()
        {
            /* TODO: vvv
             * Procs.LootPercent += 20;
             */
        }
    }
}
