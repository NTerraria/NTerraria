using System;
using System.Collections.Generic;
using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class WeDoALittleBitOfTrollingEvent : Event
    {
        public override string DisplayName => "Bossvania";

        public override string Description => "Bosses will spawn during a Blood Moon.";

        public override bool ShouldUpdate() => DateTime.Now.DayOfWeek == DayOfWeek.Wednesday;

        public override void Update()
        {
            if (Main.bloodMoon)
            {
                Main.SceneMetrics.EvilTileCount = 200;
                Main.SceneMetrics.BloodTileCount = 200;
            }

            if ((Main.dedServ || !Main.dedServ && Main.hasFocus) && Main.netMode != 1 && Main.bloodMoon &&
                !Main.dayTime && Main.time <= 16200d && Main.rand.Next(50) == 0)
            {
                List<int> list = new List<int>();

                for (int i = 0; i < 255; i++)
                {
                    if (i < 200 && Main.npc[i].active && Main.npc[i].boss)
                        return;

                    if (Main.player[i].active)
                        list.Add(i);
                }

                if (list.Count == 0)
                    return;

                // TODO: boss values in a struct system
            }
        }
    }
}
