using System;

namespace Terraria.NTerraria.Exceptions 
{
    public sealed class ModCountException : Exception
    {
        public enum CountType
        {
            NoMod,
            DuplicateMod
        }

        public CountType type;

        public ModCountException(CountType type) => this.type = type;

        public override string Message
        {
            get
            {
                switch (type)
                {
                    case CountType.NoMod:
                        return "A loaded mod contained no Mod-extending classes!";

                    case CountType.DuplicateMod:
                        return "A loaded mod contained more than one Mod-extending class!";

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        // TODO: Localization
    }
}
