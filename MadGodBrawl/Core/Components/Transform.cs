using Engine;
using System.Numerics;

namespace Engine.Core.Components
{
    internal class Transform : Component, IEquatable<Transform>
    {
        internal Vector2 position = Vector2.Zero;
        internal Vector2 scale = Vector2.Zero;
        internal float layer = 0;
        internal float rotation = 0;

        public Transform()
        {
            TransformSystem.Register(this);
        }

        public bool Equals(Transform? other)
        {
            if (other is Transform)
                return true;
            else
                return false;
        }
    }
}
