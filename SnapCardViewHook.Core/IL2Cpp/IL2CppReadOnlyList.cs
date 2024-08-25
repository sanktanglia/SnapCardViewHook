using System.Runtime.InteropServices;

namespace SnapCardViewHook.Core.IL2Cpp
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct IL2CppReadOnlyList
    {
        [FieldOffset(0x10)]
        public IL2CppList* List;
    }
}
