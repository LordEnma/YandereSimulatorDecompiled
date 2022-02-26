using System;
using UnityEngine;

// Token: 0x02000301 RID: 769
public static class CounselorGlobals
{
	// Token: 0x1700045A RID: 1114
	// (get) Token: 0x060017E2 RID: 6114 RVA: 0x000E37D8 File Offset: 0x000E19D8
	// (set) Token: 0x060017E3 RID: 6115 RVA: 0x000E3808 File Offset: 0x000E1A08
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

	// Token: 0x1700045B RID: 1115
	// (get) Token: 0x060017E4 RID: 6116 RVA: 0x000E3838 File Offset: 0x000E1A38
	// (set) Token: 0x060017E5 RID: 6117 RVA: 0x000E3868 File Offset: 0x000E1A68
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

	// Token: 0x1700045C RID: 1116
	// (get) Token: 0x060017E6 RID: 6118 RVA: 0x000E3898 File Offset: 0x000E1A98
	// (set) Token: 0x060017E7 RID: 6119 RVA: 0x000E38C8 File Offset: 0x000E1AC8
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

	// Token: 0x1700045D RID: 1117
	// (get) Token: 0x060017E8 RID: 6120 RVA: 0x000E38F8 File Offset: 0x000E1AF8
	// (set) Token: 0x060017E9 RID: 6121 RVA: 0x000E3928 File Offset: 0x000E1B28
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

	// Token: 0x1700045E RID: 1118
	// (get) Token: 0x060017EA RID: 6122 RVA: 0x000E3958 File Offset: 0x000E1B58
	// (set) Token: 0x060017EB RID: 6123 RVA: 0x000E3988 File Offset: 0x000E1B88
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

	// Token: 0x1700045F RID: 1119
	// (get) Token: 0x060017EC RID: 6124 RVA: 0x000E39B8 File Offset: 0x000E1BB8
	// (set) Token: 0x060017ED RID: 6125 RVA: 0x000E39E8 File Offset: 0x000E1BE8
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

	// Token: 0x17000460 RID: 1120
	// (get) Token: 0x060017EE RID: 6126 RVA: 0x000E3A18 File Offset: 0x000E1C18
	// (set) Token: 0x060017EF RID: 6127 RVA: 0x000E3A48 File Offset: 0x000E1C48
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

	// Token: 0x17000461 RID: 1121
	// (get) Token: 0x060017F0 RID: 6128 RVA: 0x000E3A78 File Offset: 0x000E1C78
	// (set) Token: 0x060017F1 RID: 6129 RVA: 0x000E3AA8 File Offset: 0x000E1CA8
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

	// Token: 0x17000462 RID: 1122
	// (get) Token: 0x060017F2 RID: 6130 RVA: 0x000E3AD8 File Offset: 0x000E1CD8
	// (set) Token: 0x060017F3 RID: 6131 RVA: 0x000E3B08 File Offset: 0x000E1D08
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

	// Token: 0x17000463 RID: 1123
	// (get) Token: 0x060017F4 RID: 6132 RVA: 0x000E3B38 File Offset: 0x000E1D38
	// (set) Token: 0x060017F5 RID: 6133 RVA: 0x000E3B68 File Offset: 0x000E1D68
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

	// Token: 0x17000464 RID: 1124
	// (get) Token: 0x060017F6 RID: 6134 RVA: 0x000E3B98 File Offset: 0x000E1D98
	// (set) Token: 0x060017F7 RID: 6135 RVA: 0x000E3BC8 File Offset: 0x000E1DC8
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

	// Token: 0x17000465 RID: 1125
	// (get) Token: 0x060017F8 RID: 6136 RVA: 0x000E3BF8 File Offset: 0x000E1DF8
	// (set) Token: 0x060017F9 RID: 6137 RVA: 0x000E3C28 File Offset: 0x000E1E28
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

	// Token: 0x17000466 RID: 1126
	// (get) Token: 0x060017FA RID: 6138 RVA: 0x000E3C58 File Offset: 0x000E1E58
	// (set) Token: 0x060017FB RID: 6139 RVA: 0x000E3C88 File Offset: 0x000E1E88
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

	// Token: 0x17000467 RID: 1127
	// (get) Token: 0x060017FC RID: 6140 RVA: 0x000E3CB8 File Offset: 0x000E1EB8
	// (set) Token: 0x060017FD RID: 6141 RVA: 0x000E3CE8 File Offset: 0x000E1EE8
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

	// Token: 0x17000468 RID: 1128
	// (get) Token: 0x060017FE RID: 6142 RVA: 0x000E3D18 File Offset: 0x000E1F18
	// (set) Token: 0x060017FF RID: 6143 RVA: 0x000E3D48 File Offset: 0x000E1F48
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

	// Token: 0x17000469 RID: 1129
	// (get) Token: 0x06001800 RID: 6144 RVA: 0x000E3D78 File Offset: 0x000E1F78
	// (set) Token: 0x06001801 RID: 6145 RVA: 0x000E3DA8 File Offset: 0x000E1FA8
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

	// Token: 0x1700046A RID: 1130
	// (get) Token: 0x06001802 RID: 6146 RVA: 0x000E3DD8 File Offset: 0x000E1FD8
	// (set) Token: 0x06001803 RID: 6147 RVA: 0x000E3E08 File Offset: 0x000E2008
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

	// Token: 0x1700046B RID: 1131
	// (get) Token: 0x06001804 RID: 6148 RVA: 0x000E3E38 File Offset: 0x000E2038
	// (set) Token: 0x06001805 RID: 6149 RVA: 0x000E3E68 File Offset: 0x000E2068
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

	// Token: 0x1700046C RID: 1132
	// (get) Token: 0x06001806 RID: 6150 RVA: 0x000E3E98 File Offset: 0x000E2098
	// (set) Token: 0x06001807 RID: 6151 RVA: 0x000E3EC8 File Offset: 0x000E20C8
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

	// Token: 0x1700046D RID: 1133
	// (get) Token: 0x06001808 RID: 6152 RVA: 0x000E3EF8 File Offset: 0x000E20F8
	// (set) Token: 0x06001809 RID: 6153 RVA: 0x000E3F28 File Offset: 0x000E2128
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

	// Token: 0x1700046E RID: 1134
	// (get) Token: 0x0600180A RID: 6154 RVA: 0x000E3F58 File Offset: 0x000E2158
	// (set) Token: 0x0600180B RID: 6155 RVA: 0x000E3F88 File Offset: 0x000E2188
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

	// Token: 0x1700046F RID: 1135
	// (get) Token: 0x0600180C RID: 6156 RVA: 0x000E3FB8 File Offset: 0x000E21B8
	// (set) Token: 0x0600180D RID: 6157 RVA: 0x000E3FE8 File Offset: 0x000E21E8
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

	// Token: 0x17000470 RID: 1136
	// (get) Token: 0x0600180E RID: 6158 RVA: 0x000E4018 File Offset: 0x000E2218
	// (set) Token: 0x0600180F RID: 6159 RVA: 0x000E4048 File Offset: 0x000E2248
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

	// Token: 0x17000471 RID: 1137
	// (get) Token: 0x06001810 RID: 6160 RVA: 0x000E4078 File Offset: 0x000E2278
	// (set) Token: 0x06001811 RID: 6161 RVA: 0x000E40A8 File Offset: 0x000E22A8
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

	// Token: 0x17000472 RID: 1138
	// (get) Token: 0x06001812 RID: 6162 RVA: 0x000E40D8 File Offset: 0x000E22D8
	// (set) Token: 0x06001813 RID: 6163 RVA: 0x000E4108 File Offset: 0x000E2308
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

	// Token: 0x17000473 RID: 1139
	// (get) Token: 0x06001814 RID: 6164 RVA: 0x000E4138 File Offset: 0x000E2338
	// (set) Token: 0x06001815 RID: 6165 RVA: 0x000E4168 File Offset: 0x000E2368
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

	// Token: 0x17000474 RID: 1140
	// (get) Token: 0x06001816 RID: 6166 RVA: 0x000E4198 File Offset: 0x000E2398
	// (set) Token: 0x06001817 RID: 6167 RVA: 0x000E41C8 File Offset: 0x000E23C8
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

	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x06001818 RID: 6168 RVA: 0x000E41F8 File Offset: 0x000E23F8
	// (set) Token: 0x06001819 RID: 6169 RVA: 0x000E4228 File Offset: 0x000E2428
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

	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x0600181A RID: 6170 RVA: 0x000E4258 File Offset: 0x000E2458
	// (set) Token: 0x0600181B RID: 6171 RVA: 0x000E4288 File Offset: 0x000E2488
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

	// Token: 0x0600181C RID: 6172 RVA: 0x000E42B8 File Offset: 0x000E24B8
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

	// Token: 0x040022D3 RID: 8915
	private const string Str_DelinquentPunishments = "DelinquentPunishments";

	// Token: 0x040022D4 RID: 8916
	private const string Str_CounselorPunishments = "CounselorPunishments";

	// Token: 0x040022D5 RID: 8917
	private const string Str_CounselorVisits = "CounselorVisits";

	// Token: 0x040022D6 RID: 8918
	private const string Str_CounselorTape = "CounselorTape";

	// Token: 0x040022D7 RID: 8919
	private const string Str_ApologiesUsed = "ApologiesUsed";

	// Token: 0x040022D8 RID: 8920
	private const string Str_WeaponsBanned = "WeaponsBanned";

	// Token: 0x040022D9 RID: 8921
	private const string Str_BloodVisits = "BloodVisits";

	// Token: 0x040022DA RID: 8922
	private const string Str_InsanityVisits = "InsanityVisits";

	// Token: 0x040022DB RID: 8923
	private const string Str_LewdVisits = "LewdVisits";

	// Token: 0x040022DC RID: 8924
	private const string Str_TheftVisits = "TheftVisits";

	// Token: 0x040022DD RID: 8925
	private const string Str_TrespassVisits = "TrespassVisits";

	// Token: 0x040022DE RID: 8926
	private const string Str_WeaponVisits = "WeaponVisits";

	// Token: 0x040022DF RID: 8927
	private const string Str_BloodExcuseUsed = "BloodExcuseUsed";

	// Token: 0x040022E0 RID: 8928
	private const string Str_InsanityExcuseUsed = "InsanityExcuseUsed";

	// Token: 0x040022E1 RID: 8929
	private const string Str_LewdExcuseUsed = "LewdExcuseUsed";

	// Token: 0x040022E2 RID: 8930
	private const string Str_TheftExcuseUsed = "TheftExcuseUsed";

	// Token: 0x040022E3 RID: 8931
	private const string Str_TrespassExcuseUsed = "TrespassExcuseUsed";

	// Token: 0x040022E4 RID: 8932
	private const string Str_WeaponExcuseUsed = "WeaponExcuseUsed";

	// Token: 0x040022E5 RID: 8933
	private const string Str_BloodBlameUsed = "BloodBlameUsed";

	// Token: 0x040022E6 RID: 8934
	private const string Str_InsanityBlameUsed = "InsanityBlameUsed";

	// Token: 0x040022E7 RID: 8935
	private const string Str_LewdBlameUsed = "LewdBlameUsed";

	// Token: 0x040022E8 RID: 8936
	private const string Str_TheftBlameUsed = "TheftBlameUsed";

	// Token: 0x040022E9 RID: 8937
	private const string Str_TrespassBlameUsed = "TrespassBlameUsed";

	// Token: 0x040022EA RID: 8938
	private const string Str_WeaponBlameUsed = "WeaponBlameUsed";

	// Token: 0x040022EB RID: 8939
	private const string Str_ReportedAlcohol = "ReportedAlcohol";

	// Token: 0x040022EC RID: 8940
	private const string Str_ReportedCigarettes = "ReportedCigarettes";

	// Token: 0x040022ED RID: 8941
	private const string Str_ReportedCondoms = "ReportedCondoms";

	// Token: 0x040022EE RID: 8942
	private const string Str_ReportedTheft = "ReportedTheft";

	// Token: 0x040022EF RID: 8943
	private const string Str_ReportedCheating = "ReportedCheating";
}
