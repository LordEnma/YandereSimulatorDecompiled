using System;
using UnityEngine;

// Token: 0x020002FF RID: 767
public static class YancordGlobals
{
	// Token: 0x17000474 RID: 1140
	// (get) Token: 0x06001804 RID: 6148 RVA: 0x000E2F88 File Offset: 0x000E1188
	// (set) Token: 0x06001805 RID: 6149 RVA: 0x000E2FB8 File Offset: 0x000E11B8
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

	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x06001806 RID: 6150 RVA: 0x000E2FE8 File Offset: 0x000E11E8
	// (set) Token: 0x06001807 RID: 6151 RVA: 0x000E3018 File Offset: 0x000E1218
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

	// Token: 0x06001808 RID: 6152 RVA: 0x000E3048 File Offset: 0x000E1248
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x040022C7 RID: 8903
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x040022C8 RID: 8904
	private const string Str_CurrentConversation = "CurrentConversation";
}
