using System;
using System.Runtime.InteropServices;

namespace SnapCardViewHook.Core.IL2Cpp
{
    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public unsafe struct IL2CppArrayBounds
    {
        internal UIntPtr length;
        int lower_bound;
    };

    [StructLayout(LayoutKind.Explicit, Pack = 4, CharSet = CharSet.Unicode)]
    public unsafe struct IL2CppArray
    {
        [FieldOffset(0x18)]
        internal int Count;
        [FieldOffset(0x20)]
        internal void** vector;
    }
}
