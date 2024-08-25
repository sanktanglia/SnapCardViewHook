using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SnapCardViewHook.Core.IL2Cpp
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct IL2CppList
    {
        [FieldOffset(0x10)]
        public IL2CppArray* Array;
        [FieldOffset(0x18)]
        public int Size;
    }
}
