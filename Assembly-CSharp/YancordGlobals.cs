using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
public static class YancordGlobals
{
	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x06001832 RID: 6194 RVA: 0x000E56D8 File Offset: 0x000E38D8
	// (set) Token: 0x06001833 RID: 6195 RVA: 0x000E5708 File Offset: 0x000E3908
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
	// (get) Token: 0x06001834 RID: 6196 RVA: 0x000E5738 File Offset: 0x000E3938
	// (set) Token: 0x06001835 RID: 6197 RVA: 0x000E5768 File Offset: 0x000E3968
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

	// Token: 0x06001836 RID: 6198 RVA: 0x000E5798 File Offset: 0x000E3998
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JoinedYancord");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CurrentConversation");
	}

	// Token: 0x04002328 RID: 9000
	private const string Str_JoinedYancord = "JoinedYancord";

	// Token: 0x04002329 RID: 9001
	private const string Str_CurrentConversation = "CurrentConversation";
}
