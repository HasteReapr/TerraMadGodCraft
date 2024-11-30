using Engine.Core;
using Engine.Core.Components;
using Transform = Engine.Core.Components.Transform;

namespace Engine.World.Tiles
{
    internal class GrassTile : Entity
    {
        internal GrassTile()
        {
            Transform trans = new Transform();
            AddComponent(trans);

            Sprite2D sprite = new Sprite2D(ResourceManager.LoadOrRetrieveTexture("Textures/Tiles/Grass/Grass_1_Middle.png", "GrassTile"));
            AddComponent(sprite);
        }
        
    }
}