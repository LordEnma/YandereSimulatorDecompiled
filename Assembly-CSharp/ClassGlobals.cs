using System;
using UnityEngine;

// Token: 0x020002EB RID: 747
public static class ClassGlobals
{
	// Token: 0x17000370 RID: 880
	// (get) Token: 0x0600152D RID: 5421 RVA: 0x000D88EC File Offset: 0x000D6AEC
	// (set) Token: 0x0600152E RID: 5422 RVA: 0x000D891C File Offset: 0x000D6B1C
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
	// (get) Token: 0x0600152F RID: 5423 RVA: 0x000D894C File Offset: 0x000D6B4C
	// (set) Token: 0x06001530 RID: 5424 RVA: 0x000D897C File Offset: 0x000D6B7C
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
	// (get) Token: 0x06001531 RID: 5425 RVA: 0x000D89AC File Offset: 0x000D6BAC
	// (set) Token: 0x06001532 RID: 5426 RVA: 0x000D89DC File Offset: 0x000D6BDC
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
	// (get) Token: 0x06001533 RID: 5427 RVA: 0x000D8A0C File Offset: 0x000D6C0C
	// (set) Token: 0x06001534 RID: 5428 RVA: 0x000D8A3C File Offset: 0x000D6C3C
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
	// (get) Token: 0x06001535 RID: 5429 RVA: 0x000D8A6C File Offset: 0x000D6C6C
	// (set) Token: 0x06001536 RID: 5430 RVA: 0x000D8A9C File Offset: 0x000D6C9C
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
	// (get) Token: 0x06001537 RID: 5431 RVA: 0x000D8ACC File Offset: 0x000D6CCC
	// (set) Token: 0x06001538 RID: 5432 RVA: 0x000D8AFC File Offset: 0x000D6CFC
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
	// (get) Token: 0x06001539 RID: 5433 RVA: 0x000D8B2C File Offset: 0x000D6D2C
	// (set) Token: 0x0600153A RID: 5434 RVA: 0x000D8B5C File Offset: 0x000D6D5C
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
	// (get) Token: 0x0600153B RID: 5435 RVA: 0x000D8B8C File Offset: 0x000D6D8C
	// (set) Token: 0x0600153C RID: 5436 RVA: 0x000D8BBC File Offset: 0x000D6DBC
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
	// (get) Token: 0x0600153D RID: 5437 RVA: 0x000D8BEC File Offset: 0x000D6DEC
	// (set) Token: 0x0600153E RID: 5438 RVA: 0x000D8C1C File Offset: 0x000D6E1C
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
	// (get) Token: 0x0600153F RID: 5439 RVA: 0x000D8C4C File Offset: 0x000D6E4C
	// (set) Token: 0x06001540 RID: 5440 RVA: 0x000D8C7C File Offset: 0x000D6E7C
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
	// (get) Token: 0x06001541 RID: 5441 RVA: 0x000D8CAC File Offset: 0x000D6EAC
	// (set) Token: 0x06001542 RID: 5442 RVA: 0x000D8CDC File Offset: 0x000D6EDC
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
	// (get) Token: 0x06001543 RID: 5443 RVA: 0x000D8D0C File Offset: 0x000D6F0C
	// (set) Token: 0x06001544 RID: 5444 RVA: 0x000D8D3C File Offset: 0x000D6F3C
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
	// (get) Token: 0x06001545 RID: 5445 RVA: 0x000D8D6C File Offset: 0x000D6F6C
	// (set) Token: 0x06001546 RID: 5446 RVA: 0x000D8D9C File Offset: 0x000D6F9C
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
	// (get) Token: 0x06001547 RID: 5447 RVA: 0x000D8DCC File Offset: 0x000D6FCC
	// (set) Token: 0x06001548 RID: 5448 RVA: 0x000D8DFC File Offset: 0x000D6FFC
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
	// (get) Token: 0x06001549 RID: 5449 RVA: 0x000D8E2C File Offset: 0x000D702C
	// (set) Token: 0x0600154A RID: 5450 RVA: 0x000D8E5C File Offset: 0x000D705C
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
	// (get) Token: 0x0600154B RID: 5451 RVA: 0x000D8E8C File Offset: 0x000D708C
	// (set) Token: 0x0600154C RID: 5452 RVA: 0x000D8EBC File Offset: 0x000D70BC
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

	// Token: 0x0600154D RID: 5453 RVA: 0x000D8EEC File Offset: 0x000D70EC
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

	// Token: 0x040021A5 RID: 8613
	private const string Str_Biology = "Biology";

	// Token: 0x040021A6 RID: 8614
	private const string Str_BiologyBonus = "BiologyBonus";

	// Token: 0x040021A7 RID: 8615
	private const string Str_BiologyGrade = "BiologyGrade";

	// Token: 0x040021A8 RID: 8616
	private const string Str_Chemistry = "Chemistry";

	// Token: 0x040021A9 RID: 8617
	private const string Str_ChemistryBonus = "ChemistryBonus";

	// Token: 0x040021AA RID: 8618
	private const string Str_ChemistryGrade = "ChemistryGrade";

	// Token: 0x040021AB RID: 8619
	private const string Str_Language = "Language";

	// Token: 0x040021AC RID: 8620
	private const string Str_LanguageBonus = "LanguageBonus";

	// Token: 0x040021AD RID: 8621
	private const string Str_LanguageGrade = "LanguageGrade";

	// Token: 0x040021AE RID: 8622
	private const string Str_Physical = "Physical";

	// Token: 0x040021AF RID: 8623
	private const string Str_PhysicalBonus = "PhysicalBonus";

	// Token: 0x040021B0 RID: 8624
	private const string Str_PhysicalGrade = "PhysicalGrade";

	// Token: 0x040021B1 RID: 8625
	private const string Str_Psychology = "Psychology";

	// Token: 0x040021B2 RID: 8626
	private const string Str_PsychologyBonus = "PsychologyBonus";

	// Token: 0x040021B3 RID: 8627
	private const string Str_PsychologyGrade = "PsychologyGrade";

	// Token: 0x040021B4 RID: 8628
	private const string Str_BonusStudyPoints = "BonusStudyPoints";
}
