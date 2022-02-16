using System;

// Token: 0x020002F2 RID: 754
public static class HomeGlobals
{
	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x06001613 RID: 5651 RVA: 0x000DBDBC File Offset: 0x000D9FBC
	// (set) Token: 0x06001614 RID: 5652 RVA: 0x000DBDEC File Offset: 0x000D9FEC
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

	// Token: 0x170003C2 RID: 962
	// (get) Token: 0x06001615 RID: 5653 RVA: 0x000DBE1C File Offset: 0x000DA01C
	// (set) Token: 0x06001616 RID: 5654 RVA: 0x000DBE4C File Offset: 0x000DA04C
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

	// Token: 0x170003C3 RID: 963
	// (get) Token: 0x06001617 RID: 5655 RVA: 0x000DBE7C File Offset: 0x000DA07C
	// (set) Token: 0x06001618 RID: 5656 RVA: 0x000DBEAC File Offset: 0x000DA0AC
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

	// Token: 0x170003C4 RID: 964
	// (get) Token: 0x06001619 RID: 5657 RVA: 0x000DBEDC File Offset: 0x000DA0DC
	// (set) Token: 0x0600161A RID: 5658 RVA: 0x000DBF0C File Offset: 0x000DA10C
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

	// Token: 0x0600161B RID: 5659 RVA: 0x000DBF3C File Offset: 0x000DA13C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
	}

	// Token: 0x040021FE RID: 8702
	private const string Str_LateForSchool = "LateForSchool";

	// Token: 0x040021FF RID: 8703
	private const string Str_Night = "Night";

	// Token: 0x04002200 RID: 8704
	private const string Str_StartInBasement = "StartInBasement";

	// Token: 0x04002201 RID: 8705
	private const string Str_MiyukiDefeated = "MiyukiDefeated";
}
