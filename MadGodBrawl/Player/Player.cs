using Raylib_cs;
using Engine.Core;
using Engine.Core.Components;
using Transform = Engine.Core.Components.Transform;
using System.Numerics;

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

            Sprite2D sprite = new Sprite2D();
            //We wanna set the sprite of whatever we are working in here in the initial bit of the info, so the Animator component can grab it.
            sprite.texture = Raylib.LoadTexture("Textures/Player/Player_Anim/Player_Idle_Run_Death_Anim.png");
            AddComponent(sprite);
        }
    }
}