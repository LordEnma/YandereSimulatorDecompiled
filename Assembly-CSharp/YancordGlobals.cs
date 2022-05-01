using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
public static class YancordGlobals
{
	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x06001836 RID: 6198 RVA: 0x000E5BA8 File Offset: 0x000E3DA8
	// (set) Token: 0x06001837 RID: 6199 RVA: 0x000E5BD8 File Offset: 0x000E3DD8
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

	// Token: 0x1700047A RID: 1146
	// (get) Token: 0x06001838 RID: 6200 RVA: 0x000E5C08 File Offset: 0x000E3E08
	// (set) Token: 0x06001839 RID: 6201 RVA: 0x000E5C38 File Offset: 0x000E3E38
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

	// Token: 0x0600183A RID: 6202 RVA: 0x000E5C68 File Offset: 0x000E3E68
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x04002331 RID: 9009
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x04002332 RID: 9010
	private const string Str_CurrentConversation = "CurrentConversation";
}
