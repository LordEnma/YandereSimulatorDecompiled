using System;
using UnityEngine;

// Token: 0x02000302 RID: 770
public static class YancordGlobals
{
	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x0600181D RID: 6173 RVA: 0x000E4684 File Offset: 0x000E2884
	// (set) Token: 0x0600181E RID: 6174 RVA: 0x000E46B4 File Offset: 0x000E28B4
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
	// (get) Token: 0x0600181F RID: 6175 RVA: 0x000E46E4 File Offset: 0x000E28E4
	// (set) Token: 0x06001820 RID: 6176 RVA: 0x000E4714 File Offset: 0x000E2914
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

	// Token: 0x06001821 RID: 6177 RVA: 0x000E4744 File Offset: 0x000E2944
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x040022F0 RID: 8944
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x040022F1 RID: 8945
	private const string Str_CurrentConversation = "CurrentConversation";
}
