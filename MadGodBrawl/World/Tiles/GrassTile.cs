using Engine.Core;
using Engine.Core.Components;
using Raylib_cs;
using System.Diagnostics;
using System.Numerics;
using static Raylib_cs.Raylib;
using Transform = Engine.Core.Components.Transform;

namespace Engine.World.Tiles
{
    internal class GrassTile : Entity
    {
        internal GrassTile()
        {
            Transform trans = new Transform();
            trans.position = new Vector2(Program.ScreenW/2, Program.ScreenH/2);
            AddComponent(trans);

            Sprite2D sprite = new Sprite2D(Raylib.LoadTexture("Textures/Player/Player_Anim/Player-Idle.png"));
            AddComponent(sprite);
        }
        
    }
}
