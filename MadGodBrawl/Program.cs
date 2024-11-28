using Engine.Core.Components;
using Engine.Core.Systems;
using Raylib_cs;
using static Raylib_cs.Raylib;
using Engine.Core;
using System.Runtime.CompilerServices;
using Transform = Engine.Core.Components.Transform;
using System.Numerics;

namespace Engine
{
    internal class TransformSystem : BaseSystem<Core.Components.Transform> { };
    internal class Sprite2DSystem : BaseSystem<Sprite2D> { };
    internal class AnimatedSprite2DSystem : BaseSystem<AnimatedSprite2D> { };

    internal class Program
    {
        internal static float deltaTime; // Keep in mind that deltaTime will always have a one frame delay, due to how its calculated.

        internal static readonly int ScreenH = 1200;
        internal static readonly int ScreenW = 1600;

        internal static Camera2D camera;

        internal static Player player;

        public static void Main()
        {
            //This must be the first thing that happens, otherwise the sprites and the like will be unable to draw properly.
            InitWindow(ScreenW, ScreenH, "RotMG Clone");

            Initialize();

            while (!WindowShouldClose())
            {
                deltaTime = GetFrameTime();

                //Transform and things that change anything about an entity must be done before drawing.
                TransformSystem.Update(deltaTime);

                //Anything that would mess with the camera should be done before the draw call.
                Draw();
            }

            CloseWindow();
        }

        public static void Initialize()
        {
            SetTargetFPS(144);
            player = new Player();

            camera = new();

            var player_t = player.GetComponent<Transform>();
            var player_spr = player.GetComponent<AnimatedSprite2D>();

            camera.Target = new Vector2(player_t.position.X + player_spr.frameRec.Width/2, player_t.position.Y + player_spr.frameRec.Height/2);
            camera.Offset = new Vector2(ScreenW / 2, ScreenH / 2);
            camera.Rotation = 0.0f;
            camera.Zoom = 4.0f;
        }

        //This exists to kind of pull the drawing stuff outside of the main loop, so it's a bit easier to comprehend.
        public static void Draw()
        {
            BeginDrawing();
            ClearBackground(Color.Gray);

            //Start working within world space.
            BeginMode2D(camera);

            //Sprites need to be updated last, after the begindrawing call.
            //This goes for everything that is done for the visual things, like drawn models, shaders etc.
            Sprite2DSystem.Update(deltaTime);
            AnimatedSprite2DSystem.Update(deltaTime);

            /*DrawRectangle((int)camera.Target.X, -500, 1, (int)(ScreenH * 4), Color.Green);
            DrawLine(
                (int)(-ScreenW * 10),
                (int)camera.Target.Y,
                (int)(ScreenW * 10),
                (int)camera.Target.Y,
                Color.Green
            );*/

            //Anything after this happens in screen space, instead of the world space.
            EndMode2D();

            DrawFPS(20, 20);

            EndDrawing();
        }
    }
}