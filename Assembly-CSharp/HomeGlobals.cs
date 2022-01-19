using System;

// Token: 0x020002F1 RID: 753
public static class HomeGlobals
{
	// Token: 0x170003BF RID: 959
	// (get) Token: 0x06001609 RID: 5641 RVA: 0x000DB688 File Offset: 0x000D9888
	// (set) Token: 0x0600160A RID: 5642 RVA: 0x000DB6B8 File Offset: 0x000D98B8
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
	// (get) Token: 0x0600160B RID: 5643 RVA: 0x000DB6E8 File Offset: 0x000D98E8
	// (set) Token: 0x0600160C RID: 5644 RVA: 0x000DB718 File Offset: 0x000D9918
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
	// (get) Token: 0x0600160D RID: 5645 RVA: 0x000DB748 File Offset: 0x000D9948
	// (set) Token: 0x0600160E RID: 5646 RVA: 0x000DB778 File Offset: 0x000D9978
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
	// (get) Token: 0x0600160F RID: 5647 RVA: 0x000DB7A8 File Offset: 0x000D99A8
	// (set) Token: 0x06001610 RID: 5648 RVA: 0x000DB7D8 File Offset: 0x000D99D8
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

	// Token: 0x06001611 RID: 5649 RVA: 0x000DB808 File Offset: 0x000D9A08
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x040021EF RID: 8687
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x040021F0 RID: 8688
	private const string Str_Night = "Night";

	// Token: 0x040021F1 RID: 8689
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x040021F2 RID: 8690
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
