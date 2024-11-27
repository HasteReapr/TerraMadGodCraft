using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Core;

namespace Engine.Core.Components
{
    internal class Component
    {
        internal Entity entity;

        internal virtual void Update(float DeltaTime) { }
    }
}
