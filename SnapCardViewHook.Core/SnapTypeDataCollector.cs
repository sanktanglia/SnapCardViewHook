using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using IL2CppApi.Wrappers;
// ReSharper disable InconsistentNaming

namespace SnapCardViewHook.Core
{
    public static class SnapTypeDataCollector
    {
        public delegate IntPtr CardDefList_Find_delegate_(int cardDef);

        [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
        public delegate void CardView_Initialize_delegate_(
            IntPtr thisPr, IntPtr cardDef, int cost, int power, int rarity,
            IntPtr borderDefId, IntPtr artVariantDefId, IntPtr surfaceEffectDefId,
            IntPtr cardRevealEffectDefId, int cardRevealEffectType, bool showRevealEffectOnStart,
            int logoEffectId, int cardBackDefId, bool isMorph);

        private static class Constants
        {
            public const string Dll_SecondDinner_CubeDef = "SecondDinner.CubeDef.dll";
            public const string Namespace_CubeDef = "CubeDef";

            public const string Dll_App_View = "App.View.dll";
            public const string Namespace_CubeUnity_App_View = "CubeUnity.App.View";
        }

        public static IL2CppFieldInfoWrapper[] CardDefId_Fields { get; private set; }
        public static IntPtr CardDefList_Find_methodPtr { get; private set; }
        public static IL2CppFieldInfoWrapper[] ArtVariantDef_Id_Fields { get; private set; }
        public static IL2CppFieldInfoWrapper[] SurfaceEffectDef_Id_Fields { get; private set; }
        public static IL2CppFieldInfoWrapper[] CardRevealEffectDef_Id_Fields { get; private set; }
        public static CardDefList_Find_delegate_ CardDefList_Find { get; private set; }
        public static int CardDef_Name_Field_Offset { get; private set; }
        public static CardView_Initialize_delegate_ CardViewInitializeOriginal { get; private set; }

        public static CardView_Initialize_delegate_ CardViewInitOverride { get; set; }


        public static bool Loaded { get; private set; }

        private static CardView_Initialize_delegate_ _detour_CardView_Initialize_delegate;


        public static void EnsureLoaded()
        {
            if (Loaded)
                return;

            CollectAllRequiredTypeData();
            Loaded = true;
        }

        private static void CollectAllRequiredTypeData()
        {
            var assemblies = IL2CppApi.IL2CppDumper.GetLoadedAssemblies();

            Collect_CardDefId(assemblies);
            Collect_CardDefList(assemblies);
            Collect_ArtVariantDef(assemblies);
            Collect_SurfaceEffectDef(assemblies);
            Collect_CardRevealEffectDef(assemblies);
            Collect_CardView(assemblies);
            Collect_CardDef(assemblies);
        }

        private static IL2CppClassWrapper GetIL2CppClass(IL2CppImageWrapper[] assemblies, string assemblyName, string typeNameSpace, string typeName)
        {
            var assembly = assemblies.FirstOrDefault(a => a.Name == assemblyName);

            var @class =
                assembly?
                    .GetClasses()
                    .FirstOrDefault(c => c.Namespace == typeNameSpace && c.Name == typeName);

            if (@class == null)
                return null;

            return @class;
        }

        private static void ThrowIL2CppTypeError(string name)
        {
            throw new Exception($"L2CppApi type error, could not locate type '{name}'");
        }

        private static void ThrowIL2CppMethodError(string name)
        {
            throw new Exception($"L2CppApi type error, could not locate method '{name}'");
        }

        private static IL2CppClassWrapper TryGetIL2CppClass(IL2CppImageWrapper[] assemblies, string assemblyName,
            string @namespace, string typeName)
        {
            var @class = GetIL2CppClass(assemblies, assemblyName, @namespace, typeName);

            if (@class == null)
            {
                ThrowIL2CppTypeError($"{@namespace}.{typeName}");
                return null;
            }

            return @class;
        }


        private static void Collect_CardDefId(IL2CppImageWrapper[] assemblies)
        {
            var cardDefIdClass = TryGetIL2CppClass(assemblies, Constants.Dll_SecondDinner_CubeDef, Constants.Namespace_CubeDef, "CardDefId");

            // enum type
            // enum definitions are stored as fields inside the class
            CardDefId_Fields = cardDefIdClass.GetFields();
        }

        private static void Collect_CardDefList(IL2CppImageWrapper[] assemblies)
        {
            const string className = "CardDefList";
            const string methodName = "Find";

            var cardDefListClass = TryGetIL2CppClass(assemblies, Constants.Dll_SecondDinner_CubeDef, Constants.Namespace_CubeDef, className);
            var method = cardDefListClass.GetMethods().FirstOrDefault(m => m.Name == methodName);

            if (method == null)
            {
                ThrowIL2CppMethodError($"{className}::{methodName}");
                return;
            }
            
            CardDefList_Find_methodPtr = method.MethodPointer;
            CardDefList_Find = Marshal.GetDelegateForFunctionPointer<CardDefList_Find_delegate_>(CardDefList_Find_methodPtr);
        }

        private static IL2CppFieldInfoWrapper[] GetIdClassFields(IL2CppImageWrapper[] assemblies, string assemblyName,
            string @namespace, string typeName)
        {
            const string class_name_Def_Id = "Id";

            var defClass = TryGetIL2CppClass(assemblies, assemblyName, @namespace, typeName);
            var defClass_Id = defClass.GetNestedTypes().FirstOrDefault(c => c.Name == class_name_Def_Id);

            if (defClass_Id == null)
            {
                ThrowIL2CppTypeError($"{@namespace}.{typeName}.{class_name_Def_Id}");
                return null;
            }

            return defClass_Id.GetFields();
        }

        private static void Collect_ArtVariantDef(IL2CppImageWrapper[] assemblies)
        {
            ArtVariantDef_Id_Fields = 
                GetIdClassFields(assemblies, Constants.Dll_SecondDinner_CubeDef, Constants.Namespace_CubeDef, "ArtVariantDef");
        }

        private static void Collect_SurfaceEffectDef(IL2CppImageWrapper[] assemblies)
        {
            SurfaceEffectDef_Id_Fields =
                GetIdClassFields(assemblies, Constants.Dll_SecondDinner_CubeDef, Constants.Namespace_CubeDef, "SurfaceEffectDef");
        }
        private static void Collect_CardRevealEffectDef(IL2CppImageWrapper[] assemblies)
        {
            CardRevealEffectDef_Id_Fields =
                GetIdClassFields(assemblies, Constants.Dll_SecondDinner_CubeDef, Constants.Namespace_CubeDef, "CardRevealEffectDef");
        }

        private static unsafe void Collect_CardView(IL2CppImageWrapper[] assemblies)
        {
            const string className = "CardView";
            const string methodName = "Initialize";

            var cardViewClass = TryGetIL2CppClass(assemblies, Constants.Dll_App_View, Constants.Namespace_CubeUnity_App_View, className);
            var method = cardViewClass
                .GetMethods()
                .Where(m => m.Name == methodName)
                .OrderByDescending(m => m.ParamCount)
                .FirstOrDefault();

            if (method == null)
            {
                ThrowIL2CppMethodError($"{className}::{methodName}");
                return;
            }

            void* originalPtr;
            // store delegate into class to avoid garbage collection
            // alternatively use GCHandle.Alloc
            var detourDelegate = _detour_CardView_Initialize_delegate = new CardView_Initialize_delegate_(CardView_Initialize_Detour);
            
            if (!HookHelper.CreateHook(
                    (void*)method.MethodPointer,
                    (void*)Marshal.GetFunctionPointerForDelegate(detourDelegate),
                    &originalPtr))
                throw new Exception("CreateHook failed");

            CardViewInitializeOriginal = (CardView_Initialize_delegate_)
                Marshal.GetDelegateForFunctionPointer(new IntPtr(originalPtr), typeof(CardView_Initialize_delegate_));
        }

        private static void Collect_CardDef(IL2CppImageWrapper[] assemblies)
        {
            var cardDefIdClass = TryGetIL2CppClass(assemblies, Constants.Dll_SecondDinner_CubeDef, Constants.Namespace_CubeDef, "CardDef");
            var field = cardDefIdClass.GetFields().FirstOrDefault(f => f.Name == "<Name>k__BackingField");


            if (field == null)
                throw new Exception("CardDef.Name could not be found");

            CardDef_Name_Field_Offset = field.Offset.ToInt32();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CardView_Initialize_Detour(
            IntPtr thisPr, IntPtr cardDef, int cost, int power, int rarity,
            IntPtr borderDefId, IntPtr artVariantDefId, IntPtr surfaceEffectDefId,
            IntPtr cardRevealEffectDefId, int cardRevealEffectType, bool showRevealEffectOnStart,
            int logoEffectId, int cardBackDefId, bool isMorph)
        {

            if (CardViewInitOverride != null)
            {
                CardViewInitOverride(thisPr, cardDef, cost, power, rarity, borderDefId, artVariantDefId,
                    surfaceEffectDefId, cardRevealEffectDefId, cardRevealEffectType, showRevealEffectOnStart,
                    logoEffectId,
                    cardBackDefId, isMorph);
                return;
            }

            CardViewInitializeOriginal(thisPr, cardDef, cost, power, rarity, borderDefId, artVariantDefId,
                surfaceEffectDefId, cardRevealEffectDefId, cardRevealEffectType, showRevealEffectOnStart, logoEffectId,
                cardBackDefId, isMorph);
        }
    }
}
