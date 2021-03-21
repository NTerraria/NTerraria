using Microsoft.Xna.Framework;

namespace Terraria.NTerraria.Core.Worlds
{
    public static class CastleWorld
    {
        public static int CastleSizeX => (int)(Main.rightWorld - Main.leftWorld) / 16;

        public static int CastleSizeY => (int)(Main.bottomWorld - Main.topWorld) / 16;

        public static int RoomSizeX => Main.screenWidth / 16;

        public static int RoomSizeY => Main.screenHeight / 16;

        public static int MaxRoomsX => CastleSizeX / (Main.screenWidth / 16);

        public static int MaxRoomsY => CastleSizeY / (Main.screenHeight / 16);

        public static byte[,] CastleRooms = new byte[MaxRoomsX, MaxRoomsY];

        public static void GenerateCastleWorld()
        {
            Main.statusText = "Starting Castle Generation";
            Point CastleStartPosition = new Point(Main.maxTilesX / 2, Main.maxTilesY / 2);
            // TODO: Unfinished N Terraria code, not my fault - Stevie
        }
	}
}
