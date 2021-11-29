using System;
using UnityEngine;

// Token: 0x020002FE RID: 766
public static class YancordGlobals
{
	// Token: 0x17000474 RID: 1140
	// (get) Token: 0x060017FD RID: 6141 RVA: 0x000E27C8 File Offset: 0x000E09C8
	// (set) Token: 0x060017FE RID: 6142 RVA: 0x000E27F8 File Offset: 0x000E09F8
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
	// (get) Token: 0x060017FF RID: 6143 RVA: 0x000E2828 File Offset: 0x000E0A28
	// (set) Token: 0x06001800 RID: 6144 RVA: 0x000E2858 File Offset: 0x000E0A58
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

	// Token: 0x06001801 RID: 6145 RVA: 0x000E2888 File Offset: 0x000E0A88
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x040022A7 RID: 8871
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x040022A8 RID: 8872
	private const string Str_CurrentConversation = "CurrentConversation";
}
