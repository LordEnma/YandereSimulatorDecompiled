using System;
using UnityEngine;

// Token: 0x020002EB RID: 747
public static class ClassGlobals
{
	// Token: 0x17000370 RID: 880
	// (get) Token: 0x06001530 RID: 5424 RVA: 0x000D908C File Offset: 0x000D728C
	// (set) Token: 0x06001531 RID: 5425 RVA: 0x000D90BC File Offset: 0x000D72BC
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
	// (get) Token: 0x06001532 RID: 5426 RVA: 0x000D90EC File Offset: 0x000D72EC
	// (set) Token: 0x06001533 RID: 5427 RVA: 0x000D911C File Offset: 0x000D731C
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
	// (get) Token: 0x06001534 RID: 5428 RVA: 0x000D914C File Offset: 0x000D734C
	// (set) Token: 0x06001535 RID: 5429 RVA: 0x000D917C File Offset: 0x000D737C
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
	// (get) Token: 0x06001536 RID: 5430 RVA: 0x000D91AC File Offset: 0x000D73AC
	// (set) Token: 0x06001537 RID: 5431 RVA: 0x000D91DC File Offset: 0x000D73DC
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
	// (get) Token: 0x06001538 RID: 5432 RVA: 0x000D920C File Offset: 0x000D740C
	// (set) Token: 0x06001539 RID: 5433 RVA: 0x000D923C File Offset: 0x000D743C
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
	// (get) Token: 0x0600153A RID: 5434 RVA: 0x000D926C File Offset: 0x000D746C
	// (set) Token: 0x0600153B RID: 5435 RVA: 0x000D929C File Offset: 0x000D749C
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
	// (get) Token: 0x0600153C RID: 5436 RVA: 0x000D92CC File Offset: 0x000D74CC
	// (set) Token: 0x0600153D RID: 5437 RVA: 0x000D92FC File Offset: 0x000D74FC
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
	// (get) Token: 0x0600153E RID: 5438 RVA: 0x000D932C File Offset: 0x000D752C
	// (set) Token: 0x0600153F RID: 5439 RVA: 0x000D935C File Offset: 0x000D755C
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
	// (get) Token: 0x06001540 RID: 5440 RVA: 0x000D938C File Offset: 0x000D758C
	// (set) Token: 0x06001541 RID: 5441 RVA: 0x000D93BC File Offset: 0x000D75BC
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
	// (get) Token: 0x06001542 RID: 5442 RVA: 0x000D93EC File Offset: 0x000D75EC
	// (set) Token: 0x06001543 RID: 5443 RVA: 0x000D941C File Offset: 0x000D761C
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
	// (get) Token: 0x06001544 RID: 5444 RVA: 0x000D944C File Offset: 0x000D764C
	// (set) Token: 0x06001545 RID: 5445 RVA: 0x000D947C File Offset: 0x000D767C
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
	// (get) Token: 0x06001546 RID: 5446 RVA: 0x000D94AC File Offset: 0x000D76AC
	// (set) Token: 0x06001547 RID: 5447 RVA: 0x000D94DC File Offset: 0x000D76DC
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
	// (get) Token: 0x06001548 RID: 5448 RVA: 0x000D950C File Offset: 0x000D770C
	// (set) Token: 0x06001549 RID: 5449 RVA: 0x000D953C File Offset: 0x000D773C
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
	// (get) Token: 0x0600154A RID: 5450 RVA: 0x000D956C File Offset: 0x000D776C
	// (set) Token: 0x0600154B RID: 5451 RVA: 0x000D959C File Offset: 0x000D779C
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
	// (get) Token: 0x0600154C RID: 5452 RVA: 0x000D95CC File Offset: 0x000D77CC
	// (set) Token: 0x0600154D RID: 5453 RVA: 0x000D95FC File Offset: 0x000D77FC
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
	// (get) Token: 0x0600154E RID: 5454 RVA: 0x000D962C File Offset: 0x000D782C
	// (set) Token: 0x0600154F RID: 5455 RVA: 0x000D965C File Offset: 0x000D785C
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

	// Token: 0x06001550 RID: 5456 RVA: 0x000D968C File Offset: 0x000D788C
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

	// Token: 0x040021C9 RID: 8649
	private const string Str_Biology = "Biology";

	// Token: 0x040021CA RID: 8650
	private const string Str_BiologyBonus = "BiologyBonus";

	// Token: 0x040021CB RID: 8651
	private const string Str_BiologyGrade = "BiologyGrade";

	// Token: 0x040021CC RID: 8652
	private const string Str_Chemistry = "Chemistry";

	// Token: 0x040021CD RID: 8653
	private const string Str_ChemistryBonus = "ChemistryBonus";

	// Token: 0x040021CE RID: 8654
	private const string Str_ChemistryGrade = "ChemistryGrade";

	// Token: 0x040021CF RID: 8655
	private const string Str_Language = "Language";

	// Token: 0x040021D0 RID: 8656
	private const string Str_LanguageBonus = "LanguageBonus";

	// Token: 0x040021D1 RID: 8657
	private const string Str_LanguageGrade = "LanguageGrade";

	// Token: 0x040021D2 RID: 8658
	private const string Str_Physical = "Physical";

	// Token: 0x040021D3 RID: 8659
	private const string Str_PhysicalBonus = "PhysicalBonus";

	// Token: 0x040021D4 RID: 8660
	private const string Str_PhysicalGrade = "PhysicalGrade";

	// Token: 0x040021D5 RID: 8661
	private const string Str_Psychology = "Psychology";

	// Token: 0x040021D6 RID: 8662
	private const string Str_PsychologyBonus = "PsychologyBonus";

	// Token: 0x040021D7 RID: 8663
	private const string Str_PsychologyGrade = "PsychologyGrade";

	// Token: 0x040021D8 RID: 8664
	private const string Str_BonusStudyPoints = "BonusStudyPoints";
}
