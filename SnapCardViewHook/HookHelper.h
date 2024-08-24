#pragma once

#include "../MinHook/include/MinHook.h"

public ref class HookHelper
{
public:
	static HookHelper()
	{
		MH_Initialize();
	}

	static bool CreateHook(void* target, void* detour, void** pOriginal)
	{
		return !(MH_CreateHook(target, detour, pOriginal) || MH_EnableHook(target) || MH_ApplyQueued());
	}
};

