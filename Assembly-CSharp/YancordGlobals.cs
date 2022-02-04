using System;
using UnityEngine;

// Token: 0x02000300 RID: 768
public static class YancordGlobals
{
	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x0600180B RID: 6155 RVA: 0x000E3B40 File Offset: 0x000E1D40
	// (set) Token: 0x0600180C RID: 6156 RVA: 0x000E3B70 File Offset: 0x000E1D70
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
	// (get) Token: 0x0600180D RID: 6157 RVA: 0x000E3BA0 File Offset: 0x000E1DA0
	// (set) Token: 0x0600180E RID: 6158 RVA: 0x000E3BD0 File Offset: 0x000E1DD0
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

	// Token: 0x0600180F RID: 6159 RVA: 0x000E3C00 File Offset: 0x000E1E00
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x040022D8 RID: 8920
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x040022D9 RID: 8921
	private const string Str_CurrentConversation = "CurrentConversation";
}
