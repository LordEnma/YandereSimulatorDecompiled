using System;
using UnityEngine;

// Token: 0x02000305 RID: 773
public static class YancordGlobals
{
	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x0600183A RID: 6202 RVA: 0x000E606C File Offset: 0x000E426C
	// (set) Token: 0x0600183B RID: 6203 RVA: 0x000E609C File Offset: 0x000E429C
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
	// (get) Token: 0x0600183C RID: 6204 RVA: 0x000E60CC File Offset: 0x000E42CC
	// (set) Token: 0x0600183D RID: 6205 RVA: 0x000E60FC File Offset: 0x000E42FC
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

	// Token: 0x0600183E RID: 6206 RVA: 0x000E612C File Offset: 0x000E432C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x0400233C RID: 9020
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x0400233D RID: 9021
	private const string Str_CurrentConversation = "CurrentConversation";
}
