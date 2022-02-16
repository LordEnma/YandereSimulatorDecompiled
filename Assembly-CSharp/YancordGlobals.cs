using System;
using UnityEngine;

// Token: 0x02000301 RID: 769
public static class YancordGlobals
{
	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x06001814 RID: 6164 RVA: 0x000E3DA0 File Offset: 0x000E1FA0
	// (set) Token: 0x06001815 RID: 6165 RVA: 0x000E3DD0 File Offset: 0x000E1FD0
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

	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x06001816 RID: 6166 RVA: 0x000E3E00 File Offset: 0x000E2000
	// (set) Token: 0x06001817 RID: 6167 RVA: 0x000E3E30 File Offset: 0x000E2030
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

	// Token: 0x06001818 RID: 6168 RVA: 0x000E3E60 File Offset: 0x000E2060
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x040022E1 RID: 8929
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x040022E2 RID: 8930
	private const string Str_CurrentConversation = "CurrentConversation";
}
