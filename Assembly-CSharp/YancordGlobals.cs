using System;
using UnityEngine;

// Token: 0x02000303 RID: 771
public static class YancordGlobals
{
	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x06001828 RID: 6184 RVA: 0x000E5360 File Offset: 0x000E3560
	// (set) Token: 0x06001829 RID: 6185 RVA: 0x000E5390 File Offset: 0x000E3590
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

	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x0600182A RID: 6186 RVA: 0x000E53C0 File Offset: 0x000E35C0
	// (set) Token: 0x0600182B RID: 6187 RVA: 0x000E53F0 File Offset: 0x000E35F0
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

	// Token: 0x0600182C RID: 6188 RVA: 0x000E5420 File Offset: 0x000E3620
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x04002323 RID: 8995
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x04002324 RID: 8996
	private const string Str_CurrentConversation = "CurrentConversation";
}
