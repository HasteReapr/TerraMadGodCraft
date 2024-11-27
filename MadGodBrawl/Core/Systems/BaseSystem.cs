using Engine.Core.Components;

namespace Engine.Core.Systems
{
    internal class BaseSystem<T> where T : Component
    {
        protected static List<T> components = new List<T>();

        public static void Register(T component)
        {
            components.Add(component);
        }

        public static void Update(float deltaTime)
        {
            foreach (T component in components)
            {
                component.Update(deltaTime);
            }
        }
    }
}
