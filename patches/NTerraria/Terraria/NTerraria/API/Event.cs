using System.Linq;

namespace Terraria.NTerraria.API
{
    public abstract class Event
    {
        public static Event GetEvent<TEvent>() where TEvent : Event => Loader.events.First(x => x.GetType() == typeof(TEvent));

        public Mod Mod { get; internal set; }

        public string Name { get; internal set; }

        public abstract string DisplayName { get; }

        public abstract string Description { get; }

        public virtual string ShortDescription => Description;

        public virtual bool Active => IsActive();

        public virtual bool Running => IsRunning();

        public virtual bool Autoload(ref string name) => true;

        public virtual void Load() { }

        public virtual void Update() { }

        public virtual void OnShopCreate() { }

        public virtual bool IsActive() => false;

        public virtual bool IsRunning() => false;
    }
}
