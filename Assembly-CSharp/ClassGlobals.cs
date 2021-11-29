using System;
using UnityEngine;

// Token: 0x020002E7 RID: 743
public static class ClassGlobals
{
	// Token: 0x17000370 RID: 880
	// (get) Token: 0x06001513 RID: 5395 RVA: 0x000D6B68 File Offset: 0x000D4D68
	// (set) Token: 0x06001514 RID: 5396 RVA: 0x000D6B98 File Offset: 0x000D4D98
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
	// (get) Token: 0x06001515 RID: 5397 RVA: 0x000D6BC8 File Offset: 0x000D4DC8
	// (set) Token: 0x06001516 RID: 5398 RVA: 0x000D6BF8 File Offset: 0x000D4DF8
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
	// (get) Token: 0x06001517 RID: 5399 RVA: 0x000D6C28 File Offset: 0x000D4E28
	// (set) Token: 0x06001518 RID: 5400 RVA: 0x000D6C58 File Offset: 0x000D4E58
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
	// (get) Token: 0x06001519 RID: 5401 RVA: 0x000D6C88 File Offset: 0x000D4E88
	// (set) Token: 0x0600151A RID: 5402 RVA: 0x000D6CB8 File Offset: 0x000D4EB8
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
	// (get) Token: 0x0600151B RID: 5403 RVA: 0x000D6CE8 File Offset: 0x000D4EE8
	// (set) Token: 0x0600151C RID: 5404 RVA: 0x000D6D18 File Offset: 0x000D4F18
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
	// (get) Token: 0x0600151D RID: 5405 RVA: 0x000D6D48 File Offset: 0x000D4F48
	// (set) Token: 0x0600151E RID: 5406 RVA: 0x000D6D78 File Offset: 0x000D4F78
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
	// (get) Token: 0x0600151F RID: 5407 RVA: 0x000D6DA8 File Offset: 0x000D4FA8
	// (set) Token: 0x06001520 RID: 5408 RVA: 0x000D6DD8 File Offset: 0x000D4FD8
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
	// (get) Token: 0x06001521 RID: 5409 RVA: 0x000D6E08 File Offset: 0x000D5008
	// (set) Token: 0x06001522 RID: 5410 RVA: 0x000D6E38 File Offset: 0x000D5038
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
	// (get) Token: 0x06001523 RID: 5411 RVA: 0x000D6E68 File Offset: 0x000D5068
	// (set) Token: 0x06001524 RID: 5412 RVA: 0x000D6E98 File Offset: 0x000D5098
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
	// (get) Token: 0x06001525 RID: 5413 RVA: 0x000D6EC8 File Offset: 0x000D50C8
	// (set) Token: 0x06001526 RID: 5414 RVA: 0x000D6EF8 File Offset: 0x000D50F8
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
	// (get) Token: 0x06001527 RID: 5415 RVA: 0x000D6F28 File Offset: 0x000D5128
	// (set) Token: 0x06001528 RID: 5416 RVA: 0x000D6F58 File Offset: 0x000D5158
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
	// (get) Token: 0x06001529 RID: 5417 RVA: 0x000D6F88 File Offset: 0x000D5188
	// (set) Token: 0x0600152A RID: 5418 RVA: 0x000D6FB8 File Offset: 0x000D51B8
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
	// (get) Token: 0x0600152B RID: 5419 RVA: 0x000D6FE8 File Offset: 0x000D51E8
	// (set) Token: 0x0600152C RID: 5420 RVA: 0x000D7018 File Offset: 0x000D5218
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
	// (get) Token: 0x0600152D RID: 5421 RVA: 0x000D7048 File Offset: 0x000D5248
	// (set) Token: 0x0600152E RID: 5422 RVA: 0x000D7078 File Offset: 0x000D5278
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
	// (get) Token: 0x0600152F RID: 5423 RVA: 0x000D70A8 File Offset: 0x000D52A8
	// (set) Token: 0x06001530 RID: 5424 RVA: 0x000D70D8 File Offset: 0x000D52D8
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
	// (get) Token: 0x06001531 RID: 5425 RVA: 0x000D7108 File Offset: 0x000D5308
	// (set) Token: 0x06001532 RID: 5426 RVA: 0x000D7138 File Offset: 0x000D5338
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

	// Token: 0x06001533 RID: 5427 RVA: 0x000D7168 File Offset: 0x000D5368
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

	// Token: 0x0400215F RID: 8543
	private const string Str_Biology = "Biology";

	// Token: 0x04002160 RID: 8544
	private const string Str_BiologyBonus = "BiologyBonus";

	// Token: 0x04002161 RID: 8545
	private const string Str_BiologyGrade = "BiologyGrade";

	// Token: 0x04002162 RID: 8546
	private const string Str_Chemistry = "Chemistry";

	// Token: 0x04002163 RID: 8547
	private const string Str_ChemistryBonus = "ChemistryBonus";

	// Token: 0x04002164 RID: 8548
	private const string Str_ChemistryGrade = "ChemistryGrade";

	// Token: 0x04002165 RID: 8549
	private const string Str_Language = "Language";

	// Token: 0x04002166 RID: 8550
	private const string Str_LanguageBonus = "LanguageBonus";

	// Token: 0x04002167 RID: 8551
	private const string Str_LanguageGrade = "LanguageGrade";

	// Token: 0x04002168 RID: 8552
	private const string Str_Physical = "Physical";

	// Token: 0x04002169 RID: 8553
	private const string Str_PhysicalBonus = "PhysicalBonus";

	// Token: 0x0400216A RID: 8554
	private const string Str_PhysicalGrade = "PhysicalGrade";

	// Token: 0x0400216B RID: 8555
	private const string Str_Psychology = "Psychology";

	// Token: 0x0400216C RID: 8556
	private const string Str_PsychologyBonus = "PsychologyBonus";

	// Token: 0x0400216D RID: 8557
	private const string Str_PsychologyGrade = "PsychologyGrade";

	// Token: 0x0400216E RID: 8558
	private const string Str_BonusStudyPoints = "BonusStudyPoints";
}
