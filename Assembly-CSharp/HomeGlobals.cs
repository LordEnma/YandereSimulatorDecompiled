using System;

// Token: 0x020002F1 RID: 753
public static class HomeGlobals
{
	// Token: 0x170003C0 RID: 960
	// (get) Token: 0x0600160C RID: 5644 RVA: 0x000DBC48 File Offset: 0x000D9E48
	// (set) Token: 0x0600160D RID: 5645 RVA: 0x000DBC78 File Offset: 0x000D9E78
	public static bool LateForSchool
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool", value);
		}
	}

	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x0600160E RID: 5646 RVA: 0x000DBCA8 File Offset: 0x000D9EA8
	// (set) Token: 0x0600160F RID: 5647 RVA: 0x000DBCD8 File Offset: 0x000D9ED8
	public static bool Night
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Night", value);
		}
	}

	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06001610 RID: 5648 RVA: 0x000DBD08 File Offset: 0x000D9F08
	// (set) Token: 0x06001611 RID: 5649 RVA: 0x000DBD38 File Offset: 0x000D9F38
	public static bool StartInBasement
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement", value);
		}
	}

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06001612 RID: 5650 RVA: 0x000DBD68 File Offset: 0x000D9F68
	// (set) Token: 0x06001613 RID: 5651 RVA: 0x000DBD98 File Offset: 0x000D9F98
	public static bool MiyukiDefeated
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated", value);
		}
	}

	// Token: 0x06001614 RID: 5652 RVA: 0x000DBDC8 File Offset: 0x000D9FC8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x040021F8 RID: 8696
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x040021F9 RID: 8697
	private const string Str_Night = "Night";

	// Token: 0x040021FA RID: 8698
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x040021FB RID: 8699
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
