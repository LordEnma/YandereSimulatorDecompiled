using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public static class YancordGlobals
{
	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x0600181D RID: 6173 RVA: 0x000E49B4 File Offset: 0x000E2BB4
	// (set) Token: 0x0600181E RID: 6174 RVA: 0x000E49E4 File Offset: 0x000E2BE4
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
	// (get) Token: 0x0600181F RID: 6175 RVA: 0x000E4A14 File Offset: 0x000E2C14
	// (set) Token: 0x06001820 RID: 6176 RVA: 0x000E4A44 File Offset: 0x000E2C44
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

	// Token: 0x06001821 RID: 6177 RVA: 0x000E4A74 File Offset: 0x000E2C74
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x04002304 RID: 8964
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x04002305 RID: 8965
	private const string Str_CurrentConversation = "CurrentConversation";
}
