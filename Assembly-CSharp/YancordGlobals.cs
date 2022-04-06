using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
public static class YancordGlobals
{
	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x0600182E RID: 6190 RVA: 0x000E5470 File Offset: 0x000E3670
	// (set) Token: 0x0600182F RID: 6191 RVA: 0x000E54A0 File Offset: 0x000E36A0
	public static bool JoinedYancord
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord", value);
		}
	}

	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x06001830 RID: 6192 RVA: 0x000E54D0 File Offset: 0x000E36D0
	// (set) Token: 0x06001831 RID: 6193 RVA: 0x000E5500 File Offset: 0x000E3700
	public static int CurrentConversation
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation", value);
		}
	}

	// Token: 0x06001832 RID: 6194 RVA: 0x000E5530 File Offset: 0x000E3730
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x04002325 RID: 8997
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x04002326 RID: 8998
	private const string Str_CurrentConversation = "CurrentConversation";
}
