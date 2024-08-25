using SnapCardViewHook.Core.IL2Cpp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapCardViewHook.Core.Wrappers
{
    internal unsafe class BorderDefWrapper : MonoObjectWrapper
    {
        public BorderDefWrapper(IntPtr ptr) : base(ptr)
        {
        }

        public BorderDefWrapper(void* ptr) : base(ptr)
        {
        }

        public void* BorderDefId
        {
            get
            {
                var value = *(void**)(Ptr + SnapTypeDataCollector.BorderDef_BorderDefId_Field_Offset);
                return value;
            }
        }

        public string Name
        {
            get
            {
                var strPtr = *(void**)(Ptr + SnapTypeDataCollector.BorderDef_Name_Field_Offset);
                return strPtr == null ? null : new IL2CppStringRef(strPtr).GetObject();
            }
        }
    }
}
