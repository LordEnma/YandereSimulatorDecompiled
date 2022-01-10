using System;
using UnityEngine;

// Token: 0x02000300 RID: 768
public static class YancordGlobals
{
	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x0600180A RID: 6154 RVA: 0x000E3580 File Offset: 0x000E1780
	// (set) Token: 0x0600180B RID: 6155 RVA: 0x000E35B0 File Offset: 0x000E17B0
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
	// (get) Token: 0x0600180C RID: 6156 RVA: 0x000E35E0 File Offset: 0x000E17E0
	// (set) Token: 0x0600180D RID: 6157 RVA: 0x000E3610 File Offset: 0x000E1810
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

	// Token: 0x0600180E RID: 6158 RVA: 0x000E3640 File Offset: 0x000E1840
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x040022CF RID: 8911
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x040022D0 RID: 8912
	private const string Str_CurrentConversation = "CurrentConversation";
}
