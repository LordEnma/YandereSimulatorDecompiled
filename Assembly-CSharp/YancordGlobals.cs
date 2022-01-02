using System;
using UnityEngine;

// Token: 0x020002FF RID: 767
public static class YancordGlobals
{
	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x06001806 RID: 6150 RVA: 0x000E3258 File Offset: 0x000E1458
	// (set) Token: 0x06001807 RID: 6151 RVA: 0x000E3288 File Offset: 0x000E1488
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

	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x06001808 RID: 6152 RVA: 0x000E32B8 File Offset: 0x000E14B8
	// (set) Token: 0x06001809 RID: 6153 RVA: 0x000E32E8 File Offset: 0x000E14E8
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

	// Token: 0x0600180A RID: 6154 RVA: 0x000E3318 File Offset: 0x000E1518
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x040022CB RID: 8907
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x040022CC RID: 8908
	private const string Str_CurrentConversation = "CurrentConversation";
}
