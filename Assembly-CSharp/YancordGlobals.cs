using System;
using UnityEngine;

// Token: 0x02000300 RID: 768
public static class YancordGlobals
{
	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x0600180D RID: 6157 RVA: 0x000E3C2C File Offset: 0x000E1E2C
	// (set) Token: 0x0600180E RID: 6158 RVA: 0x000E3C5C File Offset: 0x000E1E5C
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

	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x0600180F RID: 6159 RVA: 0x000E3C8C File Offset: 0x000E1E8C
	// (set) Token: 0x06001810 RID: 6160 RVA: 0x000E3CBC File Offset: 0x000E1EBC
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

	// Token: 0x06001811 RID: 6161 RVA: 0x000E3CEC File Offset: 0x000E1EEC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x040022DB RID: 8923
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x040022DC RID: 8924
	private const string Str_CurrentConversation = "CurrentConversation";
}
