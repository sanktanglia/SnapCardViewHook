using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapCardViewHook.Core.Wrappers
{
    internal abstract unsafe class MonoObjectWrapper
    {
        public IntPtr Ptr { get; private set; }

        protected MonoObjectWrapper(IntPtr ptr)
        {
            Ptr = ptr;
        }

        protected MonoObjectWrapper(void* ptr) : this(new IntPtr(ptr))
        {
        }
    }
}
