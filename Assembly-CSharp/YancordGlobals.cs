using System;
using UnityEngine;

// Token: 0x02000300 RID: 768
public static class YancordGlobals
{
	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x0600180A RID: 6154 RVA: 0x000E366C File Offset: 0x000E186C
	// (set) Token: 0x0600180B RID: 6155 RVA: 0x000E369C File Offset: 0x000E189C
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
	// (get) Token: 0x0600180C RID: 6156 RVA: 0x000E36CC File Offset: 0x000E18CC
	// (set) Token: 0x0600180D RID: 6157 RVA: 0x000E36FC File Offset: 0x000E18FC
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

	// Token: 0x0600180E RID: 6158 RVA: 0x000E372C File Offset: 0x000E192C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x040022D2 RID: 8914
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x040022D3 RID: 8915
	private const string Str_CurrentConversation = "CurrentConversation";
}
