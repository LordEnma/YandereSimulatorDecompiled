using System;
using UnityEngine;

// Token: 0x020002FD RID: 765
public static class TaskGlobals
{
	// Token: 0x060017A9 RID: 6057 RVA: 0x000E2CA8 File Offset: 0x000E0EA8
	public static bool GetGuitarPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_" + photoID.ToString());
	}

	// Token: 0x060017AA RID: 6058 RVA: 0x000E2CE0 File Offset: 0x000E0EE0
	public static void SetGuitarPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_" + text, value);
	}

	// Token: 0x060017AB RID: 6059 RVA: 0x000E2D3C File Offset: 0x000E0F3C
	public static int[] KeysOfGuitarPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_");
	}

	// Token: 0x060017AC RID: 6060 RVA: 0x000E2D6C File Offset: 0x000E0F6C
	public static bool GetKittenPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_" + photoID.ToString());
	}

	// Token: 0x060017AD RID: 6061 RVA: 0x000E2DA4 File Offset: 0x000E0FA4
	public static void SetKittenPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_" + text, value);
	}

	// Token: 0x060017AE RID: 6062 RVA: 0x000E2E00 File Offset: 0x000E1000
	public static int[] KeysOfKittenPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_");
	}

	// Token: 0x060017AF RID: 6063 RVA: 0x000E2E30 File Offset: 0x000E1030
	public static bool GetHorudaPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_" + photoID.ToString());
	}

	// Token: 0x060017B0 RID: 6064 RVA: 0x000E2E68 File Offset: 0x000E1068
	public static void SetHorudaPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_" + text, value);
	}

	// Token: 0x060017B1 RID: 6065 RVA: 0x000E2EC4 File Offset: 0x000E10C4
	public static int[] KeysOfHorudaPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_");
	}

	// Token: 0x060017B2 RID: 6066 RVA: 0x000E2EF4 File Offset: 0x000E10F4
	public static int GetTaskStatus(int taskID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_" + taskID.ToString());
	}

	// Token: 0x060017B3 RID: 6067 RVA: 0x000E2F2C File Offset: 0x000E112C
	public static void SetTaskStatus(int taskID, int value)
	{
		string text = taskID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_" + text, value);
	}

	// Token: 0x060017B4 RID: 6068 RVA: 0x000E2F88 File Offset: 0x000E1188
	public static int[] KeysOfTaskStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_");
	}

	// Token: 0x060017B5 RID: 6069 RVA: 0x000E2FB8 File Offset: 0x000E11B8
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_", TaskGlobals.KeysOfGuitarPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_", TaskGlobals.KeysOfKittenPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_", TaskGlobals.KeysOfHorudaPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_", TaskGlobals.KeysOfTaskStatus());
	}

	// Token: 0x040022CF RID: 8911
	private const string Str_GuitarPhoto = "GuitarPhoto_";

	// Token: 0x040022D0 RID: 8912
	private const string Str_KittenPhoto = "KittenPhoto_";

	// Token: 0x040022D1 RID: 8913
	private const string Str_HorudaPhoto = "HorudaPhoto_";

	// Token: 0x040022D2 RID: 8914
	private const string Str_TaskStatus = "TaskStatus_";
}
