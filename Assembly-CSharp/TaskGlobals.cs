using System;
using UnityEngine;

// Token: 0x020002FF RID: 767
public static class TaskGlobals
{
	// Token: 0x060017C2 RID: 6082 RVA: 0x000E3E9C File Offset: 0x000E209C
	public static bool GetGuitarPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_" + photoID.ToString());
	}

	// Token: 0x060017C3 RID: 6083 RVA: 0x000E3ED4 File Offset: 0x000E20D4
	public static void SetGuitarPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_" + text, value);
	}

	// Token: 0x060017C4 RID: 6084 RVA: 0x000E3F30 File Offset: 0x000E2130
	public static int[] KeysOfGuitarPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_");
	}

	// Token: 0x060017C5 RID: 6085 RVA: 0x000E3F60 File Offset: 0x000E2160
	public static bool GetKittenPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_" + photoID.ToString());
	}

	// Token: 0x060017C6 RID: 6086 RVA: 0x000E3F98 File Offset: 0x000E2198
	public static void SetKittenPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_" + text, value);
	}

	// Token: 0x060017C7 RID: 6087 RVA: 0x000E3FF4 File Offset: 0x000E21F4
	public static int[] KeysOfKittenPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_");
	}

	// Token: 0x060017C8 RID: 6088 RVA: 0x000E4024 File Offset: 0x000E2224
	public static bool GetHorudaPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_" + photoID.ToString());
	}

	// Token: 0x060017C9 RID: 6089 RVA: 0x000E405C File Offset: 0x000E225C
	public static void SetHorudaPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_" + text, value);
	}

	// Token: 0x060017CA RID: 6090 RVA: 0x000E40B8 File Offset: 0x000E22B8
	public static int[] KeysOfHorudaPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_");
	}

	// Token: 0x060017CB RID: 6091 RVA: 0x000E40E8 File Offset: 0x000E22E8
	public static int GetTaskStatus(int taskID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_" + taskID.ToString());
	}

	// Token: 0x060017CC RID: 6092 RVA: 0x000E4120 File Offset: 0x000E2320
	public static void SetTaskStatus(int taskID, int value)
	{
		string text = taskID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_" + text, value);
	}

	// Token: 0x060017CD RID: 6093 RVA: 0x000E417C File Offset: 0x000E237C
	public static int[] KeysOfTaskStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_");
	}

	// Token: 0x060017CE RID: 6094 RVA: 0x000E41AC File Offset: 0x000E23AC
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_", TaskGlobals.KeysOfGuitarPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_", TaskGlobals.KeysOfKittenPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_", TaskGlobals.KeysOfHorudaPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_", TaskGlobals.KeysOfTaskStatus());
	}

	// Token: 0x040022FC RID: 8956
	private const string Str_GuitarPhoto = "GuitarPhoto_";

	// Token: 0x040022FD RID: 8957
	private const string Str_KittenPhoto = "KittenPhoto_";

	// Token: 0x040022FE RID: 8958
	private const string Str_HorudaPhoto = "HorudaPhoto_";

	// Token: 0x040022FF RID: 8959
	private const string Str_TaskStatus = "TaskStatus_";
}
