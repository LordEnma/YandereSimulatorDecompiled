using System;
using UnityEngine;

// Token: 0x020002E9 RID: 745
public static class ClassGlobals
{
	// Token: 0x17000370 RID: 880
	// (get) Token: 0x0600151E RID: 5406 RVA: 0x000D798C File Offset: 0x000D5B8C
	// (set) Token: 0x0600151F RID: 5407 RVA: 0x000D79BC File Offset: 0x000D5BBC
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
	// (get) Token: 0x06001520 RID: 5408 RVA: 0x000D79EC File Offset: 0x000D5BEC
	// (set) Token: 0x06001521 RID: 5409 RVA: 0x000D7A1C File Offset: 0x000D5C1C
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
	// (get) Token: 0x06001522 RID: 5410 RVA: 0x000D7A4C File Offset: 0x000D5C4C
	// (set) Token: 0x06001523 RID: 5411 RVA: 0x000D7A7C File Offset: 0x000D5C7C
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
	// (get) Token: 0x06001524 RID: 5412 RVA: 0x000D7AAC File Offset: 0x000D5CAC
	// (set) Token: 0x06001525 RID: 5413 RVA: 0x000D7ADC File Offset: 0x000D5CDC
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
	// (get) Token: 0x06001526 RID: 5414 RVA: 0x000D7B0C File Offset: 0x000D5D0C
	// (set) Token: 0x06001527 RID: 5415 RVA: 0x000D7B3C File Offset: 0x000D5D3C
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
	// (get) Token: 0x06001528 RID: 5416 RVA: 0x000D7B6C File Offset: 0x000D5D6C
	// (set) Token: 0x06001529 RID: 5417 RVA: 0x000D7B9C File Offset: 0x000D5D9C
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
	// (get) Token: 0x0600152A RID: 5418 RVA: 0x000D7BCC File Offset: 0x000D5DCC
	// (set) Token: 0x0600152B RID: 5419 RVA: 0x000D7BFC File Offset: 0x000D5DFC
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
	// (get) Token: 0x0600152C RID: 5420 RVA: 0x000D7C2C File Offset: 0x000D5E2C
	// (set) Token: 0x0600152D RID: 5421 RVA: 0x000D7C5C File Offset: 0x000D5E5C
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
	// (get) Token: 0x0600152E RID: 5422 RVA: 0x000D7C8C File Offset: 0x000D5E8C
	// (set) Token: 0x0600152F RID: 5423 RVA: 0x000D7CBC File Offset: 0x000D5EBC
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
	// (get) Token: 0x06001530 RID: 5424 RVA: 0x000D7CEC File Offset: 0x000D5EEC
	// (set) Token: 0x06001531 RID: 5425 RVA: 0x000D7D1C File Offset: 0x000D5F1C
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
	// (get) Token: 0x06001532 RID: 5426 RVA: 0x000D7D4C File Offset: 0x000D5F4C
	// (set) Token: 0x06001533 RID: 5427 RVA: 0x000D7D7C File Offset: 0x000D5F7C
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
	// (get) Token: 0x06001534 RID: 5428 RVA: 0x000D7DAC File Offset: 0x000D5FAC
	// (set) Token: 0x06001535 RID: 5429 RVA: 0x000D7DDC File Offset: 0x000D5FDC
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
	// (get) Token: 0x06001536 RID: 5430 RVA: 0x000D7E0C File Offset: 0x000D600C
	// (set) Token: 0x06001537 RID: 5431 RVA: 0x000D7E3C File Offset: 0x000D603C
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
	// (get) Token: 0x06001538 RID: 5432 RVA: 0x000D7E6C File Offset: 0x000D606C
	// (set) Token: 0x06001539 RID: 5433 RVA: 0x000D7E9C File Offset: 0x000D609C
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
	// (get) Token: 0x0600153A RID: 5434 RVA: 0x000D7ECC File Offset: 0x000D60CC
	// (set) Token: 0x0600153B RID: 5435 RVA: 0x000D7EFC File Offset: 0x000D60FC
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
	// (get) Token: 0x0600153C RID: 5436 RVA: 0x000D7F2C File Offset: 0x000D612C
	// (set) Token: 0x0600153D RID: 5437 RVA: 0x000D7F5C File Offset: 0x000D615C
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

	// Token: 0x0600153E RID: 5438 RVA: 0x000D7F8C File Offset: 0x000D618C
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

	// Token: 0x04002189 RID: 8585
	private const string Str_Biology = "Biology";

	// Token: 0x0400218A RID: 8586
	private const string Str_BiologyBonus = "BiologyBonus";

	// Token: 0x0400218B RID: 8587
	private const string Str_BiologyGrade = "BiologyGrade";

	// Token: 0x0400218C RID: 8588
	private const string Str_Chemistry = "Chemistry";

	// Token: 0x0400218D RID: 8589
	private const string Str_ChemistryBonus = "ChemistryBonus";

	// Token: 0x0400218E RID: 8590
	private const string Str_ChemistryGrade = "ChemistryGrade";

	// Token: 0x0400218F RID: 8591
	private const string Str_Language = "Language";

	// Token: 0x04002190 RID: 8592
	private const string Str_LanguageBonus = "LanguageBonus";

	// Token: 0x04002191 RID: 8593
	private const string Str_LanguageGrade = "LanguageGrade";

	// Token: 0x04002192 RID: 8594
	private const string Str_Physical = "Physical";

	// Token: 0x04002193 RID: 8595
	private const string Str_PhysicalBonus = "PhysicalBonus";

	// Token: 0x04002194 RID: 8596
	private const string Str_PhysicalGrade = "PhysicalGrade";

	// Token: 0x04002195 RID: 8597
	private const string Str_Psychology = "Psychology";

	// Token: 0x04002196 RID: 8598
	private const string Str_PsychologyBonus = "PsychologyBonus";

	// Token: 0x04002197 RID: 8599
	private const string Str_PsychologyGrade = "PsychologyGrade";

	// Token: 0x04002198 RID: 8600
	private const string Str_BonusStudyPoints = "BonusStudyPoints";
}
