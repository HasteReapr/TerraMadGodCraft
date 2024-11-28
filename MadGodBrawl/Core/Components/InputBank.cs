using Engine.Core.Systems;
using Raylib_cs;
using System.Reflection.Metadata;

namespace Engine.Core.Components
{
    internal class InputBank : Component, IEquatable<InputBank>
    {
        //Input bank is the buffer between the Player's input device to the actual things done in game.
        //The input bank can be used for both the input device locally, and later down the line when multiplayer is added
        // it will serve as the buffer between inputs recieved from the network and the actions the player does.

        [Flags] 
        internal enum INPUTS {
            KB_NULL = 0,
            KB_UP = (1 << 0),
            KB_DOWN = (1 << 1),
            KB_LEFT = (1 << 2),
            KB_RIGHT = (1 << 3),
            KB_DASH = (1 << 4),
            KB_SPRINT = (1 << 5),
        }

        INPUTS inputReader;

        internal InputBank()
        {
            inputReader = new INPUTS();
        }

        internal override void Update(float DeltaTime)
        {
            //We use this to determine what inputs are being pressed, or held down etc.
            ReadInputs();
            //After we read the inputs, we go through and figure out what to do with them.
            Transform t = entity.GetComponent<Transform>();

            if ((inputReader & INPUTS.KB_RIGHT) != 0)
                t.position.X += 2;

            if ((inputReader & INPUTS.KB_LEFT) != 0)
                t.position.X -= 2;
            
            if ((inputReader & INPUTS.KB_UP) != 0)
                t.position.Y -= 2;
            
            if ((inputReader & INPUTS.KB_DOWN) != 0)
                t.position.Y += 2;

            //For now we are just going to simply add to the Player's Transform component, this is very bad and we will need to add a proper motor later.
        }

        private void ReadInputs()
        {
            //Expand this at some point so it isn't hard coded, so it will work with controllers and stuff
            inputReader = 0;
            if (Raylib.IsKeyDown(KeyboardKey.D))
                inputReader = inputReader | INPUTS.KB_RIGHT;
            //Left
            if (Raylib.IsKeyDown(KeyboardKey.A))
                inputReader = inputReader | INPUTS.KB_LEFT;
            //Up
            if (Raylib.IsKeyDown(KeyboardKey.W))
                inputReader = inputReader | INPUTS.KB_UP;
            //Down
            if (Raylib.IsKeyDown(KeyboardKey.S))
                inputReader = inputReader | INPUTS.KB_DOWN;
            //Dash
            if (Raylib.IsKeyDown(KeyboardKey.Space))
                inputReader = inputReader | INPUTS.KB_DASH;
            //Sprint
            if (Raylib.IsKeyDown(KeyboardKey.LeftShift))
                inputReader = inputReader | INPUTS.KB_SPRINT;
        }

        public bool Equals(InputBank? other)
        {
            if (other is InputBank)
                return true;
            else
                return false;
        }
    }
}
