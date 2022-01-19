using System;
using UnityEngine;

// Token: 0x020002FB RID: 763
public static class TaskGlobals
{
	// Token: 0x06001796 RID: 6038 RVA: 0x000E1960 File Offset: 0x000DFB60
	public static bool GetGuitarPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_" + photoID.ToString());
	}

	// Token: 0x06001797 RID: 6039 RVA: 0x000E1998 File Offset: 0x000DFB98
	public static void SetGuitarPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_" + text, value);
	}

	// Token: 0x06001798 RID: 6040 RVA: 0x000E19F4 File Offset: 0x000DFBF4
	public static int[] KeysOfGuitarPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_");
	}

	// Token: 0x06001799 RID: 6041 RVA: 0x000E1A24 File Offset: 0x000DFC24
	public static bool GetKittenPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_" + photoID.ToString());
	}

	// Token: 0x0600179A RID: 6042 RVA: 0x000E1A5C File Offset: 0x000DFC5C
	public static void SetKittenPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_" + text, value);
	}

	// Token: 0x0600179B RID: 6043 RVA: 0x000E1AB8 File Offset: 0x000DFCB8
	public static int[] KeysOfKittenPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_");
	}

	// Token: 0x0600179C RID: 6044 RVA: 0x000E1AE8 File Offset: 0x000DFCE8
	public static bool GetHorudaPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_" + photoID.ToString());
	}

	// Token: 0x0600179D RID: 6045 RVA: 0x000E1B20 File Offset: 0x000DFD20
	public static void SetHorudaPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_" + text, value);
	}

	// Token: 0x0600179E RID: 6046 RVA: 0x000E1B7C File Offset: 0x000DFD7C
	public static int[] KeysOfHorudaPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_");
	}

	// Token: 0x0600179F RID: 6047 RVA: 0x000E1BAC File Offset: 0x000DFDAC
	public static int GetTaskStatus(int taskID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_" + taskID.ToString());
	}

	// Token: 0x060017A0 RID: 6048 RVA: 0x000E1BE4 File Offset: 0x000DFDE4
	public static void SetTaskStatus(int taskID, int value)
	{
		string text = taskID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_" + text, value);
	}

	// Token: 0x060017A1 RID: 6049 RVA: 0x000E1C40 File Offset: 0x000DFE40
	public static int[] KeysOfTaskStatus()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_");
	}

	// Token: 0x060017A2 RID: 6050 RVA: 0x000E1C70 File Offset: 0x000DFE70
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GuitarPhoto_", TaskGlobals.KeysOfGuitarPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_KittenPhoto_", TaskGlobals.KeysOfKittenPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_HorudaPhoto_", TaskGlobals.KeysOfHorudaPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_TaskStatus_", TaskGlobals.KeysOfTaskStatus());
	}

	// Token: 0x0400229D RID: 8861
	private const string Str_GuitarPhoto = "GuitarPhoto_";

	// Token: 0x0400229E RID: 8862
	private const string Str_KittenPhoto = "KittenPhoto_";

	// Token: 0x0400229F RID: 8863
	private const string Str_HorudaPhoto = "HorudaPhoto_";

	// Token: 0x040022A0 RID: 8864
	private const string Str_TaskStatus = "TaskStatus_";
}
