using System.Reflection;

namespace Terraria.NTerraria.API
{
    public class Mod
    {
        public string Name { get; internal set; }

        public Assembly Assembly { get; internal set; }

        /// <summary>
        /// Whether or not to autoload this mod.
        /// </summary>
        public bool Autoload(ref string name)
        {
            ModifyName(ref name);
            return true;
        }

        /// <summary>
        /// Allows you to modify this mod's internal name.
        /// </summary>
        public virtual void ModifyName(ref string name) { }

        /// <summary>
        /// Called when a mod is loaded.
        /// </summary>
        public virtual void Load()
        {
        }
    }
}
