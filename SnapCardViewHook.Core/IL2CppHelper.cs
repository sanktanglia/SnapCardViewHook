using System;
using System.Runtime.InteropServices;

namespace SnapCardViewHook.Core
{
    internal unsafe class IL2CppHelper
    {
        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate void delegate_il2cpp_field_static_get_value(void* field, void* value);

        private static readonly IntPtr GameAssemblyHandle;
        private static readonly delegate_il2cpp_field_static_get_value il2cpp_field_static_get_value;

        private static T MakeApi<T>(string api)
        {
            return Marshal.GetDelegateForFunctionPointer<T>(GetProcAddress(GameAssemblyHandle, api));
        }

        static IL2CppHelper()
        {
            GameAssemblyHandle = GetModuleHandle("GameAssembly.dll");
            il2cpp_field_static_get_value = MakeApi<delegate_il2cpp_field_static_get_value>("il2cpp_field_static_get_value");
        }

        internal static void GetStaticFieldValue(void* field, void* value)
        {
            il2cpp_field_static_get_value(field, value);
        }
    }
}
