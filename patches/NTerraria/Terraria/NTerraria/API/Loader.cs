using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Terraria.NTerraria.API.Abstraction;

namespace Terraria.NTerraria.API
{
    public static class Loader
    {
        public static string ModsPath => Main.SavePath + Path.DirectorySeparatorChar + "NTMods";

        internal static List<Mod> mods;

        internal static List<Event> events;

        public static ReadOnlyCollection<Mod> Mods => mods.AsReadOnly();

        private static IEnumerable<string> GetMods() => Directory.GetFiles(ModsPath, "*.dll", SearchOption.TopDirectoryOnly);

        internal static void LoadMods()
        {
            List<string> modPaths = GetMods().ToList();
            List<Mod> registeredMods = new List<Mod>();

            foreach (string modPath in modPaths)
            {
                Mod mod = null;
                Assembly modAssembly = Assembly.LoadFile(modPath);

                foreach (Type type in modAssembly.GetTypes().Where(x => !x.IsAbstract && x.GetConstructor(new Type[0]) != null && x.IsSubclassOf(typeof(Mod))))
                    if (!type.IsAbstract && type.GetConstructor(new Type[0]) != null && type.IsSubclassOf(typeof(Mod)))
                    {
                        if (mod != null)
                            throw new Exception();

                        string name = type.Name;
                        mod = Activator.CreateInstance(type) as Mod;

                        if (mod == null)
                            throw new Exception();

                        mod.Assembly = modAssembly;
                        mod.Autoload(ref name); // Don't bother checking for its return value. It will *always* return true. :)
                        mod.Name = name;
                        registeredMods.Add(mod);
                    }
            }

            mods = registeredMods;
        }

        private static void LoadLoadables()
        {
            foreach (Mod mod in mods)
            {
                mod.Load();

                foreach (Type type in mod.Assembly.GetTypes().Where(x => !x.IsAbstract && x.GetConstructor(new Type[0]) != null && !x.IsSubclassOf(typeof(Mod))))
                {
                    if (type.IsSubclassOf(typeof(Event)))
                    {
                        Event @event = Activator.CreateInstance(type) as Event;
                        @event?.Load();
                        events.Add(@event);
                    }
                }
            }
        }
    }
}
