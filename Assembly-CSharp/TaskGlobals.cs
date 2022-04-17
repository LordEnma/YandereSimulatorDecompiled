using System;
using UnityEngine;

// Token: 0x020002FF RID: 767
public static class TaskGlobals
{
	// Token: 0x060017BE RID: 6078 RVA: 0x000E39CC File Offset: 0x000E1BCC
	public static bool GetGuitarPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_" + photoID.ToString());
	}

	// Token: 0x060017BF RID: 6079 RVA: 0x000E3A04 File Offset: 0x000E1C04
	public static void SetGuitarPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_" + text, value);
	}

	// Token: 0x060017C0 RID: 6080 RVA: 0x000E3A60 File Offset: 0x000E1C60
	public static int[] KeysOfGuitarPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_");
	}

	// Token: 0x060017C1 RID: 6081 RVA: 0x000E3A90 File Offset: 0x000E1C90
	public static bool GetKittenPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_" + photoID.ToString());
	}

	// Token: 0x060017C2 RID: 6082 RVA: 0x000E3AC8 File Offset: 0x000E1CC8
	public static void SetKittenPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_" + text, value);
	}

	// Token: 0x060017C3 RID: 6083 RVA: 0x000E3B24 File Offset: 0x000E1D24
	public static int[] KeysOfKittenPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_");
	}

	// Token: 0x060017C4 RID: 6084 RVA: 0x000E3B54 File Offset: 0x000E1D54
	public static bool GetHorudaPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_" + photoID.ToString());
	}

	// Token: 0x060017C5 RID: 6085 RVA: 0x000E3B8C File Offset: 0x000E1D8C
	public static void SetHorudaPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_" + text, value);
	}

	// Token: 0x060017C6 RID: 6086 RVA: 0x000E3BE8 File Offset: 0x000E1DE8
	public static int[] KeysOfHorudaPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_");
	}

	// Token: 0x060017C7 RID: 6087 RVA: 0x000E3C18 File Offset: 0x000E1E18
	public static int GetTaskStatus(int taskID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_" + taskID.ToString());
	}

	// Token: 0x060017C8 RID: 6088 RVA: 0x000E3C50 File Offset: 0x000E1E50
	public static void SetTaskStatus(int taskID, int value)
	{
		string text = taskID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_" + text, value);
	}

	// Token: 0x060017C9 RID: 6089 RVA: 0x000E3CAC File Offset: 0x000E1EAC
	public static int[] KeysOfTaskStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_");
	}

	// Token: 0x060017CA RID: 6090 RVA: 0x000E3CDC File Offset: 0x000E1EDC
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_", TaskGlobals.KeysOfGuitarPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_", TaskGlobals.KeysOfKittenPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_", TaskGlobals.KeysOfHorudaPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_", TaskGlobals.KeysOfTaskStatus());
	}

	// Token: 0x040022F3 RID: 8947
	private const string Str_GuitarPhoto = "GuitarPhoto_";

	// Token: 0x040022F4 RID: 8948
	private const string Str_KittenPhoto = "KittenPhoto_";

	// Token: 0x040022F5 RID: 8949
	private const string Str_HorudaPhoto = "HorudaPhoto_";

	// Token: 0x040022F6 RID: 8950
	private const string Str_TaskStatus = "TaskStatus_";
}
