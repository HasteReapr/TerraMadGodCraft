using Engine.Core.Systems;

namespace Engine.Core.Components
{
    internal class InputBank : Component, IEquatable<InputBank>
    {
        //Input bank is the buffer between the Player's input device to the actual things done in game.
        //The input bank can be used for both the input device locally, and later down the line when multiplayer is added
        // it will serve as the buffer between inputs recieved from the network and the actions the player does.

        internal bool dashPressed;
        internal bool dashDown;
        internal bool sprintPressed;
        internal bool sprintDown;


        public bool Equals(InputBank? other)
        {
            if (other is InputBank)
                return true;
            else
                return false;
        }
    }
}
