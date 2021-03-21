using System;
using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core.Default
{
    public sealed class DefaultMod : Mod
    {
        internal DefaultMod()
        {
            Name = "Terraria";
            Assembly = typeof(Main).Assembly;
        }
    }
}
