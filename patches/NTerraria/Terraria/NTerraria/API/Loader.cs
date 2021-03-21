using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Terraria.NTerraria.Core.Default;

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
            Directory.CreateDirectory(ModsPath);
            List<string> modPaths = GetMods().ToList();
            mods = new List<Mod>
            {
                new DefaultMod()
            };

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
                        mods.Add(mod);
                    }
            }

            LoadLoadables();
        }

        private static void LoadLoadables()
        {
            events = new List<Event>();

            if (mods is null)
                throw new Exception();

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

        public static void UpdateEvents()
        {
            foreach (Event @event in events)
                if (@event.ShouldUpdate())
                {
                    @event.Update();
                    @event.IsRunning = true;
                }
                else
                    @event.IsRunning = false;
        }
    }
}
