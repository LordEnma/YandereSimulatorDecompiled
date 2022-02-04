using System;
using UnityEngine;

// Token: 0x020002FF RID: 767
public static class CounselorGlobals
{
	// Token: 0x17000458 RID: 1112
	// (get) Token: 0x060017D0 RID: 6096 RVA: 0x000E2C94 File Offset: 0x000E0E94
	// (set) Token: 0x060017D1 RID: 6097 RVA: 0x000E2CC4 File Offset: 0x000E0EC4
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

	// Token: 0x17000459 RID: 1113
	// (get) Token: 0x060017D2 RID: 6098 RVA: 0x000E2CF4 File Offset: 0x000E0EF4
	// (set) Token: 0x060017D3 RID: 6099 RVA: 0x000E2D24 File Offset: 0x000E0F24
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

	// Token: 0x1700045A RID: 1114
	// (get) Token: 0x060017D4 RID: 6100 RVA: 0x000E2D54 File Offset: 0x000E0F54
	// (set) Token: 0x060017D5 RID: 6101 RVA: 0x000E2D84 File Offset: 0x000E0F84
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

	// Token: 0x1700045B RID: 1115
	// (get) Token: 0x060017D6 RID: 6102 RVA: 0x000E2DB4 File Offset: 0x000E0FB4
	// (set) Token: 0x060017D7 RID: 6103 RVA: 0x000E2DE4 File Offset: 0x000E0FE4
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

	// Token: 0x1700045C RID: 1116
	// (get) Token: 0x060017D8 RID: 6104 RVA: 0x000E2E14 File Offset: 0x000E1014
	// (set) Token: 0x060017D9 RID: 6105 RVA: 0x000E2E44 File Offset: 0x000E1044
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

	// Token: 0x1700045D RID: 1117
	// (get) Token: 0x060017DA RID: 6106 RVA: 0x000E2E74 File Offset: 0x000E1074
	// (set) Token: 0x060017DB RID: 6107 RVA: 0x000E2EA4 File Offset: 0x000E10A4
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

	// Token: 0x1700045E RID: 1118
	// (get) Token: 0x060017DC RID: 6108 RVA: 0x000E2ED4 File Offset: 0x000E10D4
	// (set) Token: 0x060017DD RID: 6109 RVA: 0x000E2F04 File Offset: 0x000E1104
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

	// Token: 0x1700045F RID: 1119
	// (get) Token: 0x060017DE RID: 6110 RVA: 0x000E2F34 File Offset: 0x000E1134
	// (set) Token: 0x060017DF RID: 6111 RVA: 0x000E2F64 File Offset: 0x000E1164
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

	// Token: 0x17000460 RID: 1120
	// (get) Token: 0x060017E0 RID: 6112 RVA: 0x000E2F94 File Offset: 0x000E1194
	// (set) Token: 0x060017E1 RID: 6113 RVA: 0x000E2FC4 File Offset: 0x000E11C4
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

	// Token: 0x17000461 RID: 1121
	// (get) Token: 0x060017E2 RID: 6114 RVA: 0x000E2FF4 File Offset: 0x000E11F4
	// (set) Token: 0x060017E3 RID: 6115 RVA: 0x000E3024 File Offset: 0x000E1224
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

	// Token: 0x17000462 RID: 1122
	// (get) Token: 0x060017E4 RID: 6116 RVA: 0x000E3054 File Offset: 0x000E1254
	// (set) Token: 0x060017E5 RID: 6117 RVA: 0x000E3084 File Offset: 0x000E1284
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

	// Token: 0x17000463 RID: 1123
	// (get) Token: 0x060017E6 RID: 6118 RVA: 0x000E30B4 File Offset: 0x000E12B4
	// (set) Token: 0x060017E7 RID: 6119 RVA: 0x000E30E4 File Offset: 0x000E12E4
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

	// Token: 0x17000464 RID: 1124
	// (get) Token: 0x060017E8 RID: 6120 RVA: 0x000E3114 File Offset: 0x000E1314
	// (set) Token: 0x060017E9 RID: 6121 RVA: 0x000E3144 File Offset: 0x000E1344
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

	// Token: 0x17000465 RID: 1125
	// (get) Token: 0x060017EA RID: 6122 RVA: 0x000E3174 File Offset: 0x000E1374
	// (set) Token: 0x060017EB RID: 6123 RVA: 0x000E31A4 File Offset: 0x000E13A4
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

	// Token: 0x17000466 RID: 1126
	// (get) Token: 0x060017EC RID: 6124 RVA: 0x000E31D4 File Offset: 0x000E13D4
	// (set) Token: 0x060017ED RID: 6125 RVA: 0x000E3204 File Offset: 0x000E1404
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

	// Token: 0x17000467 RID: 1127
	// (get) Token: 0x060017EE RID: 6126 RVA: 0x000E3234 File Offset: 0x000E1434
	// (set) Token: 0x060017EF RID: 6127 RVA: 0x000E3264 File Offset: 0x000E1464
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

	// Token: 0x17000468 RID: 1128
	// (get) Token: 0x060017F0 RID: 6128 RVA: 0x000E3294 File Offset: 0x000E1494
	// (set) Token: 0x060017F1 RID: 6129 RVA: 0x000E32C4 File Offset: 0x000E14C4
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

	// Token: 0x17000469 RID: 1129
	// (get) Token: 0x060017F2 RID: 6130 RVA: 0x000E32F4 File Offset: 0x000E14F4
	// (set) Token: 0x060017F3 RID: 6131 RVA: 0x000E3324 File Offset: 0x000E1524
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

	// Token: 0x1700046A RID: 1130
	// (get) Token: 0x060017F4 RID: 6132 RVA: 0x000E3354 File Offset: 0x000E1554
	// (set) Token: 0x060017F5 RID: 6133 RVA: 0x000E3384 File Offset: 0x000E1584
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

	// Token: 0x1700046B RID: 1131
	// (get) Token: 0x060017F6 RID: 6134 RVA: 0x000E33B4 File Offset: 0x000E15B4
	// (set) Token: 0x060017F7 RID: 6135 RVA: 0x000E33E4 File Offset: 0x000E15E4
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

	// Token: 0x1700046C RID: 1132
	// (get) Token: 0x060017F8 RID: 6136 RVA: 0x000E3414 File Offset: 0x000E1614
	// (set) Token: 0x060017F9 RID: 6137 RVA: 0x000E3444 File Offset: 0x000E1644
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

	// Token: 0x1700046D RID: 1133
	// (get) Token: 0x060017FA RID: 6138 RVA: 0x000E3474 File Offset: 0x000E1674
	// (set) Token: 0x060017FB RID: 6139 RVA: 0x000E34A4 File Offset: 0x000E16A4
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

	// Token: 0x1700046E RID: 1134
	// (get) Token: 0x060017FC RID: 6140 RVA: 0x000E34D4 File Offset: 0x000E16D4
	// (set) Token: 0x060017FD RID: 6141 RVA: 0x000E3504 File Offset: 0x000E1704
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

	// Token: 0x1700046F RID: 1135
	// (get) Token: 0x060017FE RID: 6142 RVA: 0x000E3534 File Offset: 0x000E1734
	// (set) Token: 0x060017FF RID: 6143 RVA: 0x000E3564 File Offset: 0x000E1764
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

	// Token: 0x17000470 RID: 1136
	// (get) Token: 0x06001800 RID: 6144 RVA: 0x000E3594 File Offset: 0x000E1794
	// (set) Token: 0x06001801 RID: 6145 RVA: 0x000E35C4 File Offset: 0x000E17C4
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

	// Token: 0x17000471 RID: 1137
	// (get) Token: 0x06001802 RID: 6146 RVA: 0x000E35F4 File Offset: 0x000E17F4
	// (set) Token: 0x06001803 RID: 6147 RVA: 0x000E3624 File Offset: 0x000E1824
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

	// Token: 0x17000472 RID: 1138
	// (get) Token: 0x06001804 RID: 6148 RVA: 0x000E3654 File Offset: 0x000E1854
	// (set) Token: 0x06001805 RID: 6149 RVA: 0x000E3684 File Offset: 0x000E1884
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

	// Token: 0x17000473 RID: 1139
	// (get) Token: 0x06001806 RID: 6150 RVA: 0x000E36B4 File Offset: 0x000E18B4
	// (set) Token: 0x06001807 RID: 6151 RVA: 0x000E36E4 File Offset: 0x000E18E4
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

	// Token: 0x17000474 RID: 1140
	// (get) Token: 0x06001808 RID: 6152 RVA: 0x000E3714 File Offset: 0x000E1914
	// (set) Token: 0x06001809 RID: 6153 RVA: 0x000E3744 File Offset: 0x000E1944
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

	// Token: 0x0600180A RID: 6154 RVA: 0x000E3774 File Offset: 0x000E1974
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

	// Token: 0x040022BB RID: 8891
	private const string Str_DelinquentPunishments = "DelinquentPunishments";

	// Token: 0x040022BC RID: 8892
	private const string Str_CounselorPunishments = "CounselorPunishments";

	// Token: 0x040022BD RID: 8893
	private const string Str_CounselorVisits = "CounselorVisits";

	// Token: 0x040022BE RID: 8894
	private const string Str_CounselorTape = "CounselorTape";

	// Token: 0x040022BF RID: 8895
	private const string Str_ApologiesUsed = "ApologiesUsed";

	// Token: 0x040022C0 RID: 8896
	private const string Str_WeaponsBanned = "WeaponsBanned";

	// Token: 0x040022C1 RID: 8897
	private const string Str_BloodVisits = "BloodVisits";

	// Token: 0x040022C2 RID: 8898
	private const string Str_InsanityVisits = "InsanityVisits";

	// Token: 0x040022C3 RID: 8899
	private const string Str_LewdVisits = "LewdVisits";

	// Token: 0x040022C4 RID: 8900
	private const string Str_TheftVisits = "TheftVisits";

	// Token: 0x040022C5 RID: 8901
	private const string Str_TrespassVisits = "TrespassVisits";

	// Token: 0x040022C6 RID: 8902
	private const string Str_WeaponVisits = "WeaponVisits";

	// Token: 0x040022C7 RID: 8903
	private const string Str_BloodExcuseUsed = "BloodExcuseUsed";

	// Token: 0x040022C8 RID: 8904
	private const string Str_InsanityExcuseUsed = "InsanityExcuseUsed";

	// Token: 0x040022C9 RID: 8905
	private const string Str_LewdExcuseUsed = "LewdExcuseUsed";

	// Token: 0x040022CA RID: 8906
	private const string Str_TheftExcuseUsed = "TheftExcuseUsed";

	// Token: 0x040022CB RID: 8907
	private const string Str_TrespassExcuseUsed = "TrespassExcuseUsed";

	// Token: 0x040022CC RID: 8908
	private const string Str_WeaponExcuseUsed = "WeaponExcuseUsed";

	// Token: 0x040022CD RID: 8909
	private const string Str_BloodBlameUsed = "BloodBlameUsed";

	// Token: 0x040022CE RID: 8910
	private const string Str_InsanityBlameUsed = "InsanityBlameUsed";

	// Token: 0x040022CF RID: 8911
	private const string Str_LewdBlameUsed = "LewdBlameUsed";

	// Token: 0x040022D0 RID: 8912
	private const string Str_TheftBlameUsed = "TheftBlameUsed";

	// Token: 0x040022D1 RID: 8913
	private const string Str_TrespassBlameUsed = "TrespassBlameUsed";

	// Token: 0x040022D2 RID: 8914
	private const string Str_WeaponBlameUsed = "WeaponBlameUsed";

	// Token: 0x040022D3 RID: 8915
	private const string Str_ReportedAlcohol = "ReportedAlcohol";

	// Token: 0x040022D4 RID: 8916
	private const string Str_ReportedCigarettes = "ReportedCigarettes";

	// Token: 0x040022D5 RID: 8917
	private const string Str_ReportedCondoms = "ReportedCondoms";

	// Token: 0x040022D6 RID: 8918
	private const string Str_ReportedTheft = "ReportedTheft";

	// Token: 0x040022D7 RID: 8919
	private const string Str_ReportedCheating = "ReportedCheating";
}
