using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public static class YancordGlobals
{
	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x0600183A RID: 6202 RVA: 0x000E5EF0 File Offset: 0x000E40F0
	// (set) Token: 0x0600183B RID: 6203 RVA: 0x000E5F20 File Offset: 0x000E4120
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

	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x0600183C RID: 6204 RVA: 0x000E5F50 File Offset: 0x000E4150
	// (set) Token: 0x0600183D RID: 6205 RVA: 0x000E5F80 File Offset: 0x000E4180
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

	// Token: 0x0600183E RID: 6206 RVA: 0x000E5FB0 File Offset: 0x000E41B0
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x0400233B RID: 9019
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x0400233C RID: 9020
	private const string Str_CurrentConversation = "CurrentConversation";
}
