using System;
using System.Linq;
using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default.Events
{
    public class TerraFest : Event
    {
        public override string DisplayName => "N TerraFest";

        public override string Description => "Increased boss experience gain and NPCs sell unusual items.";

        public override bool ShouldUpdate() => (DateTime.Now.Month - 1) % 3 == 1 && DateTime.Now.Day >= 8 && DateTime.Now.Day < 22;

        public override void Update()
        {
            int npc = Main.npc.Count(t => t.active && t.boss);

            if (npc > 0)
            {
                /* TODO: vvv
                 * Procs.BaseExpPercent += 5 + 3 * (npc - 1);
                 * Procs.ClassExpPercent += 3 + 2 * (npc - 1);
                 */
            }
        }
    }
}
