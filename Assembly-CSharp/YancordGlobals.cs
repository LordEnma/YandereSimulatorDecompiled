using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public static class YancordGlobals
{
	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x06001822 RID: 6178 RVA: 0x000E4E60 File Offset: 0x000E3060
	// (set) Token: 0x06001823 RID: 6179 RVA: 0x000E4E90 File Offset: 0x000E3090
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
	// (get) Token: 0x06001824 RID: 6180 RVA: 0x000E4EC0 File Offset: 0x000E30C0
	// (set) Token: 0x06001825 RID: 6181 RVA: 0x000E4EF0 File Offset: 0x000E30F0
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

	// Token: 0x06001826 RID: 6182 RVA: 0x000E4F20 File Offset: 0x000E3120
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x04002315 RID: 8981
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x04002316 RID: 8982
	private const string Str_CurrentConversation = "CurrentConversation";
}
