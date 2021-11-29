using System;
using UnityEngine;

// Token: 0x020002FD RID: 765
public static class CounselorGlobals
{
	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x060017C2 RID: 6082 RVA: 0x000E191C File Offset: 0x000DFB1C
	// (set) Token: 0x060017C3 RID: 6083 RVA: 0x000E194C File Offset: 0x000DFB4C
	public static int DelinquentPunishments
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_DelinquentPunishments");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_DelinquentPunishments", value);
		}
	}

	// Token: 0x17000458 RID: 1112
	// (get) Token: 0x060017C4 RID: 6084 RVA: 0x000E197C File Offset: 0x000DFB7C
	// (set) Token: 0x060017C5 RID: 6085 RVA: 0x000E19AC File Offset: 0x000DFBAC
	public static int CounselorPunishments
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorPunishments");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorPunishments", value);
		}
	}

	// Token: 0x17000459 RID: 1113
	// (get) Token: 0x060017C6 RID: 6086 RVA: 0x000E19DC File Offset: 0x000DFBDC
	// (set) Token: 0x060017C7 RID: 6087 RVA: 0x000E1A0C File Offset: 0x000DFC0C
	public static int CounselorVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorVisits", value);
		}
	}

	// Token: 0x1700045A RID: 1114
	// (get) Token: 0x060017C8 RID: 6088 RVA: 0x000E1A3C File Offset: 0x000DFC3C
	// (set) Token: 0x060017C9 RID: 6089 RVA: 0x000E1A6C File Offset: 0x000DFC6C
	public static int CounselorTape
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorTape");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CounselorTape", value);
		}
	}

	// Token: 0x1700045B RID: 1115
	// (get) Token: 0x060017CA RID: 6090 RVA: 0x000E1A9C File Offset: 0x000DFC9C
	// (set) Token: 0x060017CB RID: 6091 RVA: 0x000E1ACC File Offset: 0x000DFCCC
	public static int ApologiesUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ApologiesUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ApologiesUsed", value);
		}
	}

	// Token: 0x1700045C RID: 1116
	// (get) Token: 0x060017CC RID: 6092 RVA: 0x000E1AFC File Offset: 0x000DFCFC
	// (set) Token: 0x060017CD RID: 6093 RVA: 0x000E1B2C File Offset: 0x000DFD2C
	public static int WeaponsBanned
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponsBanned");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponsBanned", value);
		}
	}

	// Token: 0x1700045D RID: 1117
	// (get) Token: 0x060017CE RID: 6094 RVA: 0x000E1B5C File Offset: 0x000DFD5C
	// (set) Token: 0x060017CF RID: 6095 RVA: 0x000E1B8C File Offset: 0x000DFD8C
	public static int BloodVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodVisits", value);
		}
	}

	// Token: 0x1700045E RID: 1118
	// (get) Token: 0x060017D0 RID: 6096 RVA: 0x000E1BBC File Offset: 0x000DFDBC
	// (set) Token: 0x060017D1 RID: 6097 RVA: 0x000E1BEC File Offset: 0x000DFDEC
	public static int InsanityVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityVisits", value);
		}
	}

	// Token: 0x1700045F RID: 1119
	// (get) Token: 0x060017D2 RID: 6098 RVA: 0x000E1C1C File Offset: 0x000DFE1C
	// (set) Token: 0x060017D3 RID: 6099 RVA: 0x000E1C4C File Offset: 0x000DFE4C
	public static int LewdVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdVisits", value);
		}
	}

	// Token: 0x17000460 RID: 1120
	// (get) Token: 0x060017D4 RID: 6100 RVA: 0x000E1C7C File Offset: 0x000DFE7C
	// (set) Token: 0x060017D5 RID: 6101 RVA: 0x000E1CAC File Offset: 0x000DFEAC
	public static int TheftVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftVisits", value);
		}
	}

	// Token: 0x17000461 RID: 1121
	// (get) Token: 0x060017D6 RID: 6102 RVA: 0x000E1CDC File Offset: 0x000DFEDC
	// (set) Token: 0x060017D7 RID: 6103 RVA: 0x000E1D0C File Offset: 0x000DFF0C
	public static int TrespassVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassVisits", value);
		}
	}

	// Token: 0x17000462 RID: 1122
	// (get) Token: 0x060017D8 RID: 6104 RVA: 0x000E1D3C File Offset: 0x000DFF3C
	// (set) Token: 0x060017D9 RID: 6105 RVA: 0x000E1D6C File Offset: 0x000DFF6C
	public static int WeaponVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponVisits", value);
		}
	}

	// Token: 0x17000463 RID: 1123
	// (get) Token: 0x060017DA RID: 6106 RVA: 0x000E1D9C File Offset: 0x000DFF9C
	// (set) Token: 0x060017DB RID: 6107 RVA: 0x000E1DCC File Offset: 0x000DFFCC
	public static int BloodExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodExcuseUsed", value);
		}
	}

	// Token: 0x17000464 RID: 1124
	// (get) Token: 0x060017DC RID: 6108 RVA: 0x000E1DFC File Offset: 0x000DFFFC
	// (set) Token: 0x060017DD RID: 6109 RVA: 0x000E1E2C File Offset: 0x000E002C
	public static int InsanityExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityExcuseUsed", value);
		}
	}

	// Token: 0x17000465 RID: 1125
	// (get) Token: 0x060017DE RID: 6110 RVA: 0x000E1E5C File Offset: 0x000E005C
	// (set) Token: 0x060017DF RID: 6111 RVA: 0x000E1E8C File Offset: 0x000E008C
	public static int LewdExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdExcuseUsed", value);
		}
	}

	// Token: 0x17000466 RID: 1126
	// (get) Token: 0x060017E0 RID: 6112 RVA: 0x000E1EBC File Offset: 0x000E00BC
	// (set) Token: 0x060017E1 RID: 6113 RVA: 0x000E1EEC File Offset: 0x000E00EC
	public static int TheftExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftExcuseUsed", value);
		}
	}

	// Token: 0x17000467 RID: 1127
	// (get) Token: 0x060017E2 RID: 6114 RVA: 0x000E1F1C File Offset: 0x000E011C
	// (set) Token: 0x060017E3 RID: 6115 RVA: 0x000E1F4C File Offset: 0x000E014C
	public static int TrespassExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassExcuseUsed", value);
		}
	}

	// Token: 0x17000468 RID: 1128
	// (get) Token: 0x060017E4 RID: 6116 RVA: 0x000E1F7C File Offset: 0x000E017C
	// (set) Token: 0x060017E5 RID: 6117 RVA: 0x000E1FAC File Offset: 0x000E01AC
	public static int WeaponExcuseUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponExcuseUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponExcuseUsed", value);
		}
	}

	// Token: 0x17000469 RID: 1129
	// (get) Token: 0x060017E6 RID: 6118 RVA: 0x000E1FDC File Offset: 0x000E01DC
	// (set) Token: 0x060017E7 RID: 6119 RVA: 0x000E200C File Offset: 0x000E020C
	public static int BloodBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodBlameUsed", value);
		}
	}

	// Token: 0x1700046A RID: 1130
	// (get) Token: 0x060017E8 RID: 6120 RVA: 0x000E203C File Offset: 0x000E023C
	// (set) Token: 0x060017E9 RID: 6121 RVA: 0x000E206C File Offset: 0x000E026C
	public static int InsanityBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_InsanityBlameUsed", value);
		}
	}

	// Token: 0x1700046B RID: 1131
	// (get) Token: 0x060017EA RID: 6122 RVA: 0x000E209C File Offset: 0x000E029C
	// (set) Token: 0x060017EB RID: 6123 RVA: 0x000E20CC File Offset: 0x000E02CC
	public static int LewdBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LewdBlameUsed", value);
		}
	}

	// Token: 0x1700046C RID: 1132
	// (get) Token: 0x060017EC RID: 6124 RVA: 0x000E20FC File Offset: 0x000E02FC
	// (set) Token: 0x060017ED RID: 6125 RVA: 0x000E212C File Offset: 0x000E032C
	public static int TheftBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TheftBlameUsed", value);
		}
	}

	// Token: 0x1700046D RID: 1133
	// (get) Token: 0x060017EE RID: 6126 RVA: 0x000E215C File Offset: 0x000E035C
	// (set) Token: 0x060017EF RID: 6127 RVA: 0x000E218C File Offset: 0x000E038C
	public static int TrespassBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_TrespassBlameUsed", value);
		}
	}

	// Token: 0x1700046E RID: 1134
	// (get) Token: 0x060017F0 RID: 6128 RVA: 0x000E21BC File Offset: 0x000E03BC
	// (set) Token: 0x060017F1 RID: 6129 RVA: 0x000E21EC File Offset: 0x000E03EC
	public static int WeaponBlameUsed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponBlameUsed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponBlameUsed", value);
		}
	}

	// Token: 0x1700046F RID: 1135
	// (get) Token: 0x060017F2 RID: 6130 RVA: 0x000E221C File Offset: 0x000E041C
	// (set) Token: 0x060017F3 RID: 6131 RVA: 0x000E224C File Offset: 0x000E044C
	public static bool ReportedAlcohol
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedAlcohol");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedAlcohol", value);
		}
	}

	// Token: 0x17000470 RID: 1136
	// (get) Token: 0x060017F4 RID: 6132 RVA: 0x000E227C File Offset: 0x000E047C
	// (set) Token: 0x060017F5 RID: 6133 RVA: 0x000E22AC File Offset: 0x000E04AC
	public static bool ReportedCigarettes
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCigarettes");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCigarettes", value);
		}
	}

	// Token: 0x17000471 RID: 1137
	// (get) Token: 0x060017F6 RID: 6134 RVA: 0x000E22DC File Offset: 0x000E04DC
	// (set) Token: 0x060017F7 RID: 6135 RVA: 0x000E230C File Offset: 0x000E050C
	public static bool ReportedCondoms
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCondoms");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCondoms", value);
		}
	}

	// Token: 0x17000472 RID: 1138
	// (get) Token: 0x060017F8 RID: 6136 RVA: 0x000E233C File Offset: 0x000E053C
	// (set) Token: 0x060017F9 RID: 6137 RVA: 0x000E236C File Offset: 0x000E056C
	public static bool ReportedTheft
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedTheft");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedTheft", value);
		}
	}

	// Token: 0x17000473 RID: 1139
	// (get) Token: 0x060017FA RID: 6138 RVA: 0x000E239C File Offset: 0x000E059C
	// (set) Token: 0x060017FB RID: 6139 RVA: 0x000E23CC File Offset: 0x000E05CC
	public static bool ReportedCheating
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCheating");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCheating", value);
		}
	}

	// Token: 0x060017FC RID: 6140 RVA: 0x000E23FC File Offset: 0x000E05FC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DelinquentPunishments");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CounselorPunishments");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CounselorVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CounselorTape");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ApologiesUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_WeaponsBanned");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BloodVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InsanityVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LewdVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TheftVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TrespassVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_WeaponVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BloodExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InsanityExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LewdExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TheftExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TrespassExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_WeaponExcuseUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BloodBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InsanityBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LewdBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TheftBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TrespassBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_WeaponBlameUsed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReportedAlcohol");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCigarettes");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCondoms");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReportedTheft");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReportedCheating");
	}

	// Token: 0x0400228A RID: 8842
	private const string Str_DelinquentPunishments = "DelinquentPunishments";

	// Token: 0x0400228B RID: 8843
	private const string Str_CounselorPunishments = "CounselorPunishments";

	// Token: 0x0400228C RID: 8844
	private const string Str_CounselorVisits = "CounselorVisits";

	// Token: 0x0400228D RID: 8845
	private const string Str_CounselorTape = "CounselorTape";

	// Token: 0x0400228E RID: 8846
	private const string Str_ApologiesUsed = "ApologiesUsed";

	// Token: 0x0400228F RID: 8847
	private const string Str_WeaponsBanned = "WeaponsBanned";

	// Token: 0x04002290 RID: 8848
	private const string Str_BloodVisits = "BloodVisits";

	// Token: 0x04002291 RID: 8849
	private const string Str_InsanityVisits = "InsanityVisits";

	// Token: 0x04002292 RID: 8850
	private const string Str_LewdVisits = "LewdVisits";

	// Token: 0x04002293 RID: 8851
	private const string Str_TheftVisits = "TheftVisits";

	// Token: 0x04002294 RID: 8852
	private const string Str_TrespassVisits = "TrespassVisits";

	// Token: 0x04002295 RID: 8853
	private const string Str_WeaponVisits = "WeaponVisits";

	// Token: 0x04002296 RID: 8854
	private const string Str_BloodExcuseUsed = "BloodExcuseUsed";

	// Token: 0x04002297 RID: 8855
	private const string Str_InsanityExcuseUsed = "InsanityExcuseUsed";

	// Token: 0x04002298 RID: 8856
	private const string Str_LewdExcuseUsed = "LewdExcuseUsed";

	// Token: 0x04002299 RID: 8857
	private const string Str_TheftExcuseUsed = "TheftExcuseUsed";

	// Token: 0x0400229A RID: 8858
	private const string Str_TrespassExcuseUsed = "TrespassExcuseUsed";

	// Token: 0x0400229B RID: 8859
	private const string Str_WeaponExcuseUsed = "WeaponExcuseUsed";

	// Token: 0x0400229C RID: 8860
	private const string Str_BloodBlameUsed = "BloodBlameUsed";

	// Token: 0x0400229D RID: 8861
	private const string Str_InsanityBlameUsed = "InsanityBlameUsed";

	// Token: 0x0400229E RID: 8862
	private const string Str_LewdBlameUsed = "LewdBlameUsed";

	// Token: 0x0400229F RID: 8863
	private const string Str_TheftBlameUsed = "TheftBlameUsed";

	// Token: 0x040022A0 RID: 8864
	private const string Str_TrespassBlameUsed = "TrespassBlameUsed";

	// Token: 0x040022A1 RID: 8865
	private const string Str_WeaponBlameUsed = "WeaponBlameUsed";

	// Token: 0x040022A2 RID: 8866
	private const string Str_ReportedAlcohol = "ReportedAlcohol";

	// Token: 0x040022A3 RID: 8867
	private const string Str_ReportedCigarettes = "ReportedCigarettes";

	// Token: 0x040022A4 RID: 8868
	private const string Str_ReportedCondoms = "ReportedCondoms";

	// Token: 0x040022A5 RID: 8869
	private const string Str_ReportedTheft = "ReportedTheft";

	// Token: 0x040022A6 RID: 8870
	private const string Str_ReportedCheating = "ReportedCheating";
}
