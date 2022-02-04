using System;

// Token: 0x020002F1 RID: 753
public static class HomeGlobals
{
	// Token: 0x170003BF RID: 959
	// (get) Token: 0x0600160A RID: 5642 RVA: 0x000DBB5C File Offset: 0x000D9D5C
	// (set) Token: 0x0600160B RID: 5643 RVA: 0x000DBB8C File Offset: 0x000D9D8C
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

	// Token: 0x170003C0 RID: 960
	// (get) Token: 0x0600160C RID: 5644 RVA: 0x000DBBBC File Offset: 0x000D9DBC
	// (set) Token: 0x0600160D RID: 5645 RVA: 0x000DBBEC File Offset: 0x000D9DEC
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

	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x0600160E RID: 5646 RVA: 0x000DBC1C File Offset: 0x000D9E1C
	// (set) Token: 0x0600160F RID: 5647 RVA: 0x000DBC4C File Offset: 0x000D9E4C
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

	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06001610 RID: 5648 RVA: 0x000DBC7C File Offset: 0x000D9E7C
	// (set) Token: 0x06001611 RID: 5649 RVA: 0x000DBCAC File Offset: 0x000D9EAC
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

	// Token: 0x06001612 RID: 5650 RVA: 0x000DBCDC File Offset: 0x000D9EDC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x040021F5 RID: 8693
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x040021F6 RID: 8694
	private const string Str_Night = "Night";

	// Token: 0x040021F7 RID: 8695
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x040021F8 RID: 8696
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
