using SnapCardViewHook.Core.IL2Cpp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnapCardViewHook.Core.Wrappers
{
    internal unsafe class CardDefWrapper : MonoObjectWrapper
    {
        public CardDefWrapper(IntPtr ptr) : base(ptr)
        {
        }

        public CardDefWrapper(void* ptr) : base(ptr)
        {
        }

        public string Name
        {
            get
            {
                var strPtr = *(void**)(Ptr + SnapTypeDataCollector.CardDef_Name_Field_Offset);

                if (strPtr == null)
                    return null;

                return new IL2CppStringRef(strPtr).GetObject();
            }
        }
    }
}
