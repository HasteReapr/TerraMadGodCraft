using Raylib_cs;
using Engine.Core;
using Engine.Core.Components;
using System.Numerics;

using Transform = Engine.Core.Components.Transform;

namespace Engine
{
    internal class Player : Entity
    {
        //The player needs to be drawn, read the inputs from the player, translate said inputs into movement.
        //The player also needs to be on a draw layer that is high enough to not be drawn over by everything, but lower than things like clouds.
        internal Player()
        {
            Transform trans = new Transform();
            trans.position = new Vector2(Program.ScreenW/2, Program.ScreenH/2);
            AddComponent(trans);

            AnimatedSprite2D sprite = new AnimatedSprite2D(Raylib.LoadTexture("Textures/Player/Player_Anim/Player-Idle.png"), 6, 3, 3);
            AddComponent(sprite);

            InputBank inputBank = new InputBank();
            AddComponent(inputBank);
        }
    }
}