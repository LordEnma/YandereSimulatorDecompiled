using System;
using UnityEngine;

// Token: 0x02000301 RID: 769
public static class CounselorGlobals
{
	// Token: 0x1700045B RID: 1115
	// (get) Token: 0x060017E7 RID: 6119 RVA: 0x000E3FB4 File Offset: 0x000E21B4
	// (set) Token: 0x060017E8 RID: 6120 RVA: 0x000E3FE4 File Offset: 0x000E21E4
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

	// Token: 0x1700045C RID: 1116
	// (get) Token: 0x060017E9 RID: 6121 RVA: 0x000E4014 File Offset: 0x000E2214
	// (set) Token: 0x060017EA RID: 6122 RVA: 0x000E4044 File Offset: 0x000E2244
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

	// Token: 0x1700045D RID: 1117
	// (get) Token: 0x060017EB RID: 6123 RVA: 0x000E4074 File Offset: 0x000E2274
	// (set) Token: 0x060017EC RID: 6124 RVA: 0x000E40A4 File Offset: 0x000E22A4
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

	// Token: 0x1700045E RID: 1118
	// (get) Token: 0x060017ED RID: 6125 RVA: 0x000E40D4 File Offset: 0x000E22D4
	// (set) Token: 0x060017EE RID: 6126 RVA: 0x000E4104 File Offset: 0x000E2304
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

	// Token: 0x1700045F RID: 1119
	// (get) Token: 0x060017EF RID: 6127 RVA: 0x000E4134 File Offset: 0x000E2334
	// (set) Token: 0x060017F0 RID: 6128 RVA: 0x000E4164 File Offset: 0x000E2364
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

	// Token: 0x17000460 RID: 1120
	// (get) Token: 0x060017F1 RID: 6129 RVA: 0x000E4194 File Offset: 0x000E2394
	// (set) Token: 0x060017F2 RID: 6130 RVA: 0x000E41C4 File Offset: 0x000E23C4
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

	// Token: 0x17000461 RID: 1121
	// (get) Token: 0x060017F3 RID: 6131 RVA: 0x000E41F4 File Offset: 0x000E23F4
	// (set) Token: 0x060017F4 RID: 6132 RVA: 0x000E4224 File Offset: 0x000E2424
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

	// Token: 0x17000462 RID: 1122
	// (get) Token: 0x060017F5 RID: 6133 RVA: 0x000E4254 File Offset: 0x000E2454
	// (set) Token: 0x060017F6 RID: 6134 RVA: 0x000E4284 File Offset: 0x000E2484
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

	// Token: 0x17000463 RID: 1123
	// (get) Token: 0x060017F7 RID: 6135 RVA: 0x000E42B4 File Offset: 0x000E24B4
	// (set) Token: 0x060017F8 RID: 6136 RVA: 0x000E42E4 File Offset: 0x000E24E4
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

	// Token: 0x17000464 RID: 1124
	// (get) Token: 0x060017F9 RID: 6137 RVA: 0x000E4314 File Offset: 0x000E2514
	// (set) Token: 0x060017FA RID: 6138 RVA: 0x000E4344 File Offset: 0x000E2544
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

	// Token: 0x17000465 RID: 1125
	// (get) Token: 0x060017FB RID: 6139 RVA: 0x000E4374 File Offset: 0x000E2574
	// (set) Token: 0x060017FC RID: 6140 RVA: 0x000E43A4 File Offset: 0x000E25A4
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

	// Token: 0x17000466 RID: 1126
	// (get) Token: 0x060017FD RID: 6141 RVA: 0x000E43D4 File Offset: 0x000E25D4
	// (set) Token: 0x060017FE RID: 6142 RVA: 0x000E4404 File Offset: 0x000E2604
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

	// Token: 0x17000467 RID: 1127
	// (get) Token: 0x060017FF RID: 6143 RVA: 0x000E4434 File Offset: 0x000E2634
	// (set) Token: 0x06001800 RID: 6144 RVA: 0x000E4464 File Offset: 0x000E2664
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

	// Token: 0x17000468 RID: 1128
	// (get) Token: 0x06001801 RID: 6145 RVA: 0x000E4494 File Offset: 0x000E2694
	// (set) Token: 0x06001802 RID: 6146 RVA: 0x000E44C4 File Offset: 0x000E26C4
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

	// Token: 0x17000469 RID: 1129
	// (get) Token: 0x06001803 RID: 6147 RVA: 0x000E44F4 File Offset: 0x000E26F4
	// (set) Token: 0x06001804 RID: 6148 RVA: 0x000E4524 File Offset: 0x000E2724
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

	// Token: 0x1700046A RID: 1130
	// (get) Token: 0x06001805 RID: 6149 RVA: 0x000E4554 File Offset: 0x000E2754
	// (set) Token: 0x06001806 RID: 6150 RVA: 0x000E4584 File Offset: 0x000E2784
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

	// Token: 0x1700046B RID: 1131
	// (get) Token: 0x06001807 RID: 6151 RVA: 0x000E45B4 File Offset: 0x000E27B4
	// (set) Token: 0x06001808 RID: 6152 RVA: 0x000E45E4 File Offset: 0x000E27E4
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

	// Token: 0x1700046C RID: 1132
	// (get) Token: 0x06001809 RID: 6153 RVA: 0x000E4614 File Offset: 0x000E2814
	// (set) Token: 0x0600180A RID: 6154 RVA: 0x000E4644 File Offset: 0x000E2844
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

	// Token: 0x1700046D RID: 1133
	// (get) Token: 0x0600180B RID: 6155 RVA: 0x000E4674 File Offset: 0x000E2874
	// (set) Token: 0x0600180C RID: 6156 RVA: 0x000E46A4 File Offset: 0x000E28A4
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

	// Token: 0x1700046E RID: 1134
	// (get) Token: 0x0600180D RID: 6157 RVA: 0x000E46D4 File Offset: 0x000E28D4
	// (set) Token: 0x0600180E RID: 6158 RVA: 0x000E4704 File Offset: 0x000E2904
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

	// Token: 0x1700046F RID: 1135
	// (get) Token: 0x0600180F RID: 6159 RVA: 0x000E4734 File Offset: 0x000E2934
	// (set) Token: 0x06001810 RID: 6160 RVA: 0x000E4764 File Offset: 0x000E2964
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

	// Token: 0x17000470 RID: 1136
	// (get) Token: 0x06001811 RID: 6161 RVA: 0x000E4794 File Offset: 0x000E2994
	// (set) Token: 0x06001812 RID: 6162 RVA: 0x000E47C4 File Offset: 0x000E29C4
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

	// Token: 0x17000471 RID: 1137
	// (get) Token: 0x06001813 RID: 6163 RVA: 0x000E47F4 File Offset: 0x000E29F4
	// (set) Token: 0x06001814 RID: 6164 RVA: 0x000E4824 File Offset: 0x000E2A24
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

	// Token: 0x17000472 RID: 1138
	// (get) Token: 0x06001815 RID: 6165 RVA: 0x000E4854 File Offset: 0x000E2A54
	// (set) Token: 0x06001816 RID: 6166 RVA: 0x000E4884 File Offset: 0x000E2A84
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

	// Token: 0x17000473 RID: 1139
	// (get) Token: 0x06001817 RID: 6167 RVA: 0x000E48B4 File Offset: 0x000E2AB4
	// (set) Token: 0x06001818 RID: 6168 RVA: 0x000E48E4 File Offset: 0x000E2AE4
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

	// Token: 0x17000474 RID: 1140
	// (get) Token: 0x06001819 RID: 6169 RVA: 0x000E4914 File Offset: 0x000E2B14
	// (set) Token: 0x0600181A RID: 6170 RVA: 0x000E4944 File Offset: 0x000E2B44
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

	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x0600181B RID: 6171 RVA: 0x000E4974 File Offset: 0x000E2B74
	// (set) Token: 0x0600181C RID: 6172 RVA: 0x000E49A4 File Offset: 0x000E2BA4
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

	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x0600181D RID: 6173 RVA: 0x000E49D4 File Offset: 0x000E2BD4
	// (set) Token: 0x0600181E RID: 6174 RVA: 0x000E4A04 File Offset: 0x000E2C04
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

	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x0600181F RID: 6175 RVA: 0x000E4A34 File Offset: 0x000E2C34
	// (set) Token: 0x06001820 RID: 6176 RVA: 0x000E4A64 File Offset: 0x000E2C64
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

	// Token: 0x06001821 RID: 6177 RVA: 0x000E4A94 File Offset: 0x000E2C94
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

	// Token: 0x040022F8 RID: 8952
	private const string Str_DelinquentPunishments = "DelinquentPunishments";

	// Token: 0x040022F9 RID: 8953
	private const string Str_CounselorPunishments = "CounselorPunishments";

	// Token: 0x040022FA RID: 8954
	private const string Str_CounselorVisits = "CounselorVisits";

	// Token: 0x040022FB RID: 8955
	private const string Str_CounselorTape = "CounselorTape";

	// Token: 0x040022FC RID: 8956
	private const string Str_ApologiesUsed = "ApologiesUsed";

	// Token: 0x040022FD RID: 8957
	private const string Str_WeaponsBanned = "WeaponsBanned";

	// Token: 0x040022FE RID: 8958
	private const string Str_BloodVisits = "BloodVisits";

	// Token: 0x040022FF RID: 8959
	private const string Str_InsanityVisits = "InsanityVisits";

	// Token: 0x04002300 RID: 8960
	private const string Str_LewdVisits = "LewdVisits";

	// Token: 0x04002301 RID: 8961
	private const string Str_TheftVisits = "TheftVisits";

	// Token: 0x04002302 RID: 8962
	private const string Str_TrespassVisits = "TrespassVisits";

	// Token: 0x04002303 RID: 8963
	private const string Str_WeaponVisits = "WeaponVisits";

	// Token: 0x04002304 RID: 8964
	private const string Str_BloodExcuseUsed = "BloodExcuseUsed";

	// Token: 0x04002305 RID: 8965
	private const string Str_InsanityExcuseUsed = "InsanityExcuseUsed";

	// Token: 0x04002306 RID: 8966
	private const string Str_LewdExcuseUsed = "LewdExcuseUsed";

	// Token: 0x04002307 RID: 8967
	private const string Str_TheftExcuseUsed = "TheftExcuseUsed";

	// Token: 0x04002308 RID: 8968
	private const string Str_TrespassExcuseUsed = "TrespassExcuseUsed";

	// Token: 0x04002309 RID: 8969
	private const string Str_WeaponExcuseUsed = "WeaponExcuseUsed";

	// Token: 0x0400230A RID: 8970
	private const string Str_BloodBlameUsed = "BloodBlameUsed";

	// Token: 0x0400230B RID: 8971
	private const string Str_InsanityBlameUsed = "InsanityBlameUsed";

	// Token: 0x0400230C RID: 8972
	private const string Str_LewdBlameUsed = "LewdBlameUsed";

	// Token: 0x0400230D RID: 8973
	private const string Str_TheftBlameUsed = "TheftBlameUsed";

	// Token: 0x0400230E RID: 8974
	private const string Str_TrespassBlameUsed = "TrespassBlameUsed";

	// Token: 0x0400230F RID: 8975
	private const string Str_WeaponBlameUsed = "WeaponBlameUsed";

	// Token: 0x04002310 RID: 8976
	private const string Str_ReportedAlcohol = "ReportedAlcohol";

	// Token: 0x04002311 RID: 8977
	private const string Str_ReportedCigarettes = "ReportedCigarettes";

	// Token: 0x04002312 RID: 8978
	private const string Str_ReportedCondoms = "ReportedCondoms";

	// Token: 0x04002313 RID: 8979
	private const string Str_ReportedTheft = "ReportedTheft";

	// Token: 0x04002314 RID: 8980
	private const string Str_ReportedCheating = "ReportedCheating";
}
