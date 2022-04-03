using System;
using UnityEngine;

// Token: 0x020002FE RID: 766
public static class TaskGlobals
{
	// Token: 0x060017B4 RID: 6068 RVA: 0x000E3654 File Offset: 0x000E1854
	public static bool GetGuitarPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_" + photoID.ToString());
	}

	// Token: 0x060017B5 RID: 6069 RVA: 0x000E368C File Offset: 0x000E188C
	public static void SetGuitarPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_" + text, value);
	}

	// Token: 0x060017B6 RID: 6070 RVA: 0x000E36E8 File Offset: 0x000E18E8
	public static int[] KeysOfGuitarPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_");
	}

	// Token: 0x060017B7 RID: 6071 RVA: 0x000E3718 File Offset: 0x000E1918
	public static bool GetKittenPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_" + photoID.ToString());
	}

	// Token: 0x060017B8 RID: 6072 RVA: 0x000E3750 File Offset: 0x000E1950
	public static void SetKittenPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_" + text, value);
	}

	// Token: 0x060017B9 RID: 6073 RVA: 0x000E37AC File Offset: 0x000E19AC
	public static int[] KeysOfKittenPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_");
	}

	// Token: 0x060017BA RID: 6074 RVA: 0x000E37DC File Offset: 0x000E19DC
	public static bool GetHorudaPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_" + photoID.ToString());
	}

	// Token: 0x060017BB RID: 6075 RVA: 0x000E3814 File Offset: 0x000E1A14
	public static void SetHorudaPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_" + text, value);
	}

	// Token: 0x060017BC RID: 6076 RVA: 0x000E3870 File Offset: 0x000E1A70
	public static int[] KeysOfHorudaPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_");
	}

	// Token: 0x060017BD RID: 6077 RVA: 0x000E38A0 File Offset: 0x000E1AA0
	public static int GetTaskStatus(int taskID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_" + taskID.ToString());
	}

	// Token: 0x060017BE RID: 6078 RVA: 0x000E38D8 File Offset: 0x000E1AD8
	public static void SetTaskStatus(int taskID, int value)
	{
		string text = taskID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_" + text, value);
	}

	// Token: 0x060017BF RID: 6079 RVA: 0x000E3934 File Offset: 0x000E1B34
	public static int[] KeysOfTaskStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_");
	}

	// Token: 0x060017C0 RID: 6080 RVA: 0x000E3964 File Offset: 0x000E1B64
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_", TaskGlobals.KeysOfGuitarPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_", TaskGlobals.KeysOfKittenPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_", TaskGlobals.KeysOfHorudaPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_", TaskGlobals.KeysOfTaskStatus());
	}

	// Token: 0x040022EE RID: 8942
	private const string Str_GuitarPhoto = "GuitarPhoto_";

	// Token: 0x040022EF RID: 8943
	private const string Str_KittenPhoto = "KittenPhoto_";

	// Token: 0x040022F0 RID: 8944
	private const string Str_HorudaPhoto = "HorudaPhoto_";

	// Token: 0x040022F1 RID: 8945
	private const string Str_TaskStatus = "TaskStatus_";
}
