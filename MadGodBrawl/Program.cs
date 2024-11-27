using Engine.Core.Components;
using Engine.Core.Systems;
using Raylib_cs;
using Engine.Core;
using System.Runtime.CompilerServices;

namespace Engine
{
    internal class TransformSystem : BaseSystem<Core.Components.Transform> { };
    internal class Sprite2DSystem : BaseSystem<Core.Components.Sprite2D> { };

    internal class Program
    {
        internal static List<Entity> scene;
        internal static float deltaTime; // Keep in mind that deltaTime will always have a one frame delay, due to how its calculated.

        internal static readonly int ScreenH = 1200;
        internal static readonly int ScreenW = 1600;

        internal static Player player;

        public static void Main()
        {
            Initialize();

            while (!Raylib.WindowShouldClose())
            {
                deltaTime = Raylib.GetFrameTime();

                //Transform and things that change anything about an entity must be done before drawing.
                TransformSystem.Update(deltaTime);

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Gray);

                //Sprites need to be updated last, after the begindrawing call.
                //This goes for everything that is done for the visual things, like drawn models, shaders etc.
                Sprite2DSystem.Update(deltaTime);


                Raylib.DrawFPS(20, 20);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        public static void Initialize()
        {
            Raylib.InitWindow(ScreenW, ScreenH, "RotMG Clone");
            scene = new List<Entity>();
            player = new Player();
        }
    }
}