using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SnapCardViewHook.Core.IL2Cpp
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct unsafe_ptr_ref
    {
        [FieldOffset(0)]
        internal void* ptr;

        public unsafe_ptr_ref(void* p)
        {
            ptr = p;
        }

        public unsafe_ptr_ref(IntPtr p)
        {
            ptr = p.ToPointer();
        }

        public static unsafe implicit operator unsafe_ptr_ref(void* ptr)
        {
            return new unsafe_ptr_ref(ptr);
        }

        public static unsafe implicit operator unsafe_ptr_ref(IntPtr ptr)
        {
            return new unsafe_ptr_ref(ptr);
        }
    }

    [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Unicode)]
    public unsafe struct IL2CppString
    {
        public void* klass;
        public void* monitor;
        public int length;
        public fixed char chars[1];
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct IL2CppStringRef
    {
        [FieldOffset(0)]
        private readonly unsafe_ptr_ref container;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe string GetObject()
        {
            var obj = container.ptr;

            if (obj == null)
                return null;

            var str = (IL2CppString*)obj;

            return new string(str->chars, 0, str->length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public IL2CppStringRef(unsafe_ptr_ref container)
        {
            this.container = container;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe IL2CppStringRef(void* obj) : this(new unsafe_ptr_ref(obj))
        {
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe implicit operator void*(IL2CppStringRef r)
        {
            return r.container.ptr;
        }
    }
}
