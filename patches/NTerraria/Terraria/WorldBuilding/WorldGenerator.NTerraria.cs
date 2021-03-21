namespace Terraria.WorldBuilding
{
    public partial class WorldGenerator
    {
        public void Remove(string passName)
        {
            for (int i = 0; i < _passes.Count; i++)
            {
                if (_passes[i].Name != passName)
                    continue;

                _totalLoadWeight -= _passes[i].Weight;
                _passes.RemoveAt(i);
                i--;
            }
        }
    }
}
