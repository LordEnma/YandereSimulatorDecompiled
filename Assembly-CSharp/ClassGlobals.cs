using System;
using UnityEngine;

// Token: 0x020002E9 RID: 745
public static class ClassGlobals
{
	// Token: 0x17000370 RID: 880
	// (get) Token: 0x0600151F RID: 5407 RVA: 0x000D7DA8 File Offset: 0x000D5FA8
	// (set) Token: 0x06001520 RID: 5408 RVA: 0x000D7DD8 File Offset: 0x000D5FD8
	public static int Biology
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Biology");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Biology", value);
		}
	}

	// Token: 0x17000371 RID: 881
	// (get) Token: 0x06001521 RID: 5409 RVA: 0x000D7E08 File Offset: 0x000D6008
	// (set) Token: 0x06001522 RID: 5410 RVA: 0x000D7E38 File Offset: 0x000D6038
	public static int BiologyBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyBonus", value);
		}
	}

	// Token: 0x17000372 RID: 882
	// (get) Token: 0x06001523 RID: 5411 RVA: 0x000D7E68 File Offset: 0x000D6068
	// (set) Token: 0x06001524 RID: 5412 RVA: 0x000D7E98 File Offset: 0x000D6098
	public static int BiologyGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyGrade", value);
		}
	}

	// Token: 0x17000373 RID: 883
	// (get) Token: 0x06001525 RID: 5413 RVA: 0x000D7EC8 File Offset: 0x000D60C8
	// (set) Token: 0x06001526 RID: 5414 RVA: 0x000D7EF8 File Offset: 0x000D60F8
	public static int Chemistry
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Chemistry");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Chemistry", value);
		}
	}

	// Token: 0x17000374 RID: 884
	// (get) Token: 0x06001527 RID: 5415 RVA: 0x000D7F28 File Offset: 0x000D6128
	// (set) Token: 0x06001528 RID: 5416 RVA: 0x000D7F58 File Offset: 0x000D6158
	public static int ChemistryBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryBonus", value);
		}
	}

	// Token: 0x17000375 RID: 885
	// (get) Token: 0x06001529 RID: 5417 RVA: 0x000D7F88 File Offset: 0x000D6188
	// (set) Token: 0x0600152A RID: 5418 RVA: 0x000D7FB8 File Offset: 0x000D61B8
	public static int ChemistryGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryGrade", value);
		}
	}

	// Token: 0x17000376 RID: 886
	// (get) Token: 0x0600152B RID: 5419 RVA: 0x000D7FE8 File Offset: 0x000D61E8
	// (set) Token: 0x0600152C RID: 5420 RVA: 0x000D8018 File Offset: 0x000D6218
	public static int Language
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Language");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Language", value);
		}
	}

	// Token: 0x17000377 RID: 887
	// (get) Token: 0x0600152D RID: 5421 RVA: 0x000D8048 File Offset: 0x000D6248
	// (set) Token: 0x0600152E RID: 5422 RVA: 0x000D8078 File Offset: 0x000D6278
	public static int LanguageBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageBonus", value);
		}
	}

	// Token: 0x17000378 RID: 888
	// (get) Token: 0x0600152F RID: 5423 RVA: 0x000D80A8 File Offset: 0x000D62A8
	// (set) Token: 0x06001530 RID: 5424 RVA: 0x000D80D8 File Offset: 0x000D62D8
	public static int LanguageGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageGrade", value);
		}
	}

	// Token: 0x17000379 RID: 889
	// (get) Token: 0x06001531 RID: 5425 RVA: 0x000D8108 File Offset: 0x000D6308
	// (set) Token: 0x06001532 RID: 5426 RVA: 0x000D8138 File Offset: 0x000D6338
	public static int Physical
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Physical");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Physical", value);
		}
	}

	// Token: 0x1700037A RID: 890
	// (get) Token: 0x06001533 RID: 5427 RVA: 0x000D8168 File Offset: 0x000D6368
	// (set) Token: 0x06001534 RID: 5428 RVA: 0x000D8198 File Offset: 0x000D6398
	public static int PhysicalBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalBonus", value);
		}
	}

	// Token: 0x1700037B RID: 891
	// (get) Token: 0x06001535 RID: 5429 RVA: 0x000D81C8 File Offset: 0x000D63C8
	// (set) Token: 0x06001536 RID: 5430 RVA: 0x000D81F8 File Offset: 0x000D63F8
	public static int PhysicalGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalGrade", value);
		}
	}

	// Token: 0x1700037C RID: 892
	// (get) Token: 0x06001537 RID: 5431 RVA: 0x000D8228 File Offset: 0x000D6428
	// (set) Token: 0x06001538 RID: 5432 RVA: 0x000D8258 File Offset: 0x000D6458
	public static int Psychology
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Psychology");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Psychology", value);
		}
	}

	// Token: 0x1700037D RID: 893
	// (get) Token: 0x06001539 RID: 5433 RVA: 0x000D8288 File Offset: 0x000D6488
	// (set) Token: 0x0600153A RID: 5434 RVA: 0x000D82B8 File Offset: 0x000D64B8
	public static int PsychologyBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyBonus", value);
		}
	}

	// Token: 0x1700037E RID: 894
	// (get) Token: 0x0600153B RID: 5435 RVA: 0x000D82E8 File Offset: 0x000D64E8
	// (set) Token: 0x0600153C RID: 5436 RVA: 0x000D8318 File Offset: 0x000D6518
	public static int PsychologyGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyGrade", value);
		}
	}

	// Token: 0x1700037F RID: 895
	// (get) Token: 0x0600153D RID: 5437 RVA: 0x000D8348 File Offset: 0x000D6548
	// (set) Token: 0x0600153E RID: 5438 RVA: 0x000D8378 File Offset: 0x000D6578
	public static int BonusStudyPoints
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BonusStudyPoints");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BonusStudyPoints", value);
		}
	}

	// Token: 0x0600153F RID: 5439 RVA: 0x000D83A8 File Offset: 0x000D65A8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Biology");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BiologyBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BiologyGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Chemistry");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Language");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LanguageBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LanguageGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Physical");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Psychology");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BonusStudyPoints");
	}

	// Token: 0x0400218E RID: 8590
	private const string Str_Biology = "Biology";

	// Token: 0x0400218F RID: 8591
	private const string Str_BiologyBonus = "BiologyBonus";

	// Token: 0x04002190 RID: 8592
	private const string Str_BiologyGrade = "BiologyGrade";

	// Token: 0x04002191 RID: 8593
	private const string Str_Chemistry = "Chemistry";

	// Token: 0x04002192 RID: 8594
	private const string Str_ChemistryBonus = "ChemistryBonus";

	// Token: 0x04002193 RID: 8595
	private const string Str_ChemistryGrade = "ChemistryGrade";

	// Token: 0x04002194 RID: 8596
	private const string Str_Language = "Language";

	// Token: 0x04002195 RID: 8597
	private const string Str_LanguageBonus = "LanguageBonus";

	// Token: 0x04002196 RID: 8598
	private const string Str_LanguageGrade = "LanguageGrade";

	// Token: 0x04002197 RID: 8599
	private const string Str_Physical = "Physical";

	// Token: 0x04002198 RID: 8600
	private const string Str_PhysicalBonus = "PhysicalBonus";

	// Token: 0x04002199 RID: 8601
	private const string Str_PhysicalGrade = "PhysicalGrade";

	// Token: 0x0400219A RID: 8602
	private const string Str_Psychology = "Psychology";

	// Token: 0x0400219B RID: 8603
	private const string Str_PsychologyBonus = "PsychologyBonus";

	// Token: 0x0400219C RID: 8604
	private const string Str_PsychologyGrade = "PsychologyGrade";

	// Token: 0x0400219D RID: 8605
	private const string Str_BonusStudyPoints = "BonusStudyPoints";
}
