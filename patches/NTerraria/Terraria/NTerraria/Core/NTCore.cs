using Terraria.NTerraria.API;

namespace Terraria.NTerraria.Core
{
    public static class NTCore
    {
        internal static void Update()
        {
            Loader.UpdateEvents();
        }
    }
}
