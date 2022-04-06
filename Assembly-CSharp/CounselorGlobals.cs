using System;
using UnityEngine;

// Token: 0x02000303 RID: 771
public static class CounselorGlobals
{
	// Token: 0x1700045B RID: 1115
	// (get) Token: 0x060017F3 RID: 6131 RVA: 0x000E45C4 File Offset: 0x000E27C4
	// (set) Token: 0x060017F4 RID: 6132 RVA: 0x000E45F4 File Offset: 0x000E27F4
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
	// (get) Token: 0x060017F5 RID: 6133 RVA: 0x000E4624 File Offset: 0x000E2824
	// (set) Token: 0x060017F6 RID: 6134 RVA: 0x000E4654 File Offset: 0x000E2854
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
	// (get) Token: 0x060017F7 RID: 6135 RVA: 0x000E4684 File Offset: 0x000E2884
	// (set) Token: 0x060017F8 RID: 6136 RVA: 0x000E46B4 File Offset: 0x000E28B4
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
	// (get) Token: 0x060017F9 RID: 6137 RVA: 0x000E46E4 File Offset: 0x000E28E4
	// (set) Token: 0x060017FA RID: 6138 RVA: 0x000E4714 File Offset: 0x000E2914
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
	// (get) Token: 0x060017FB RID: 6139 RVA: 0x000E4744 File Offset: 0x000E2944
	// (set) Token: 0x060017FC RID: 6140 RVA: 0x000E4774 File Offset: 0x000E2974
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
	// (get) Token: 0x060017FD RID: 6141 RVA: 0x000E47A4 File Offset: 0x000E29A4
	// (set) Token: 0x060017FE RID: 6142 RVA: 0x000E47D4 File Offset: 0x000E29D4
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
	// (get) Token: 0x060017FF RID: 6143 RVA: 0x000E4804 File Offset: 0x000E2A04
	// (set) Token: 0x06001800 RID: 6144 RVA: 0x000E4834 File Offset: 0x000E2A34
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
	// (get) Token: 0x06001801 RID: 6145 RVA: 0x000E4864 File Offset: 0x000E2A64
	// (set) Token: 0x06001802 RID: 6146 RVA: 0x000E4894 File Offset: 0x000E2A94
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
	// (get) Token: 0x06001803 RID: 6147 RVA: 0x000E48C4 File Offset: 0x000E2AC4
	// (set) Token: 0x06001804 RID: 6148 RVA: 0x000E48F4 File Offset: 0x000E2AF4
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
	// (get) Token: 0x06001805 RID: 6149 RVA: 0x000E4924 File Offset: 0x000E2B24
	// (set) Token: 0x06001806 RID: 6150 RVA: 0x000E4954 File Offset: 0x000E2B54
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
	// (get) Token: 0x06001807 RID: 6151 RVA: 0x000E4984 File Offset: 0x000E2B84
	// (set) Token: 0x06001808 RID: 6152 RVA: 0x000E49B4 File Offset: 0x000E2BB4
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
	// (get) Token: 0x06001809 RID: 6153 RVA: 0x000E49E4 File Offset: 0x000E2BE4
	// (set) Token: 0x0600180A RID: 6154 RVA: 0x000E4A14 File Offset: 0x000E2C14
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
	// (get) Token: 0x0600180B RID: 6155 RVA: 0x000E4A44 File Offset: 0x000E2C44
	// (set) Token: 0x0600180C RID: 6156 RVA: 0x000E4A74 File Offset: 0x000E2C74
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
	// (get) Token: 0x0600180D RID: 6157 RVA: 0x000E4AA4 File Offset: 0x000E2CA4
	// (set) Token: 0x0600180E RID: 6158 RVA: 0x000E4AD4 File Offset: 0x000E2CD4
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
	// (get) Token: 0x0600180F RID: 6159 RVA: 0x000E4B04 File Offset: 0x000E2D04
	// (set) Token: 0x06001810 RID: 6160 RVA: 0x000E4B34 File Offset: 0x000E2D34
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
	// (get) Token: 0x06001811 RID: 6161 RVA: 0x000E4B64 File Offset: 0x000E2D64
	// (set) Token: 0x06001812 RID: 6162 RVA: 0x000E4B94 File Offset: 0x000E2D94
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
	// (get) Token: 0x06001813 RID: 6163 RVA: 0x000E4BC4 File Offset: 0x000E2DC4
	// (set) Token: 0x06001814 RID: 6164 RVA: 0x000E4BF4 File Offset: 0x000E2DF4
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
	// (get) Token: 0x06001815 RID: 6165 RVA: 0x000E4C24 File Offset: 0x000E2E24
	// (set) Token: 0x06001816 RID: 6166 RVA: 0x000E4C54 File Offset: 0x000E2E54
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
	// (get) Token: 0x06001817 RID: 6167 RVA: 0x000E4C84 File Offset: 0x000E2E84
	// (set) Token: 0x06001818 RID: 6168 RVA: 0x000E4CB4 File Offset: 0x000E2EB4
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
	// (get) Token: 0x06001819 RID: 6169 RVA: 0x000E4CE4 File Offset: 0x000E2EE4
	// (set) Token: 0x0600181A RID: 6170 RVA: 0x000E4D14 File Offset: 0x000E2F14
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
	// (get) Token: 0x0600181B RID: 6171 RVA: 0x000E4D44 File Offset: 0x000E2F44
	// (set) Token: 0x0600181C RID: 6172 RVA: 0x000E4D74 File Offset: 0x000E2F74
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
	// (get) Token: 0x0600181D RID: 6173 RVA: 0x000E4DA4 File Offset: 0x000E2FA4
	// (set) Token: 0x0600181E RID: 6174 RVA: 0x000E4DD4 File Offset: 0x000E2FD4
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
	// (get) Token: 0x0600181F RID: 6175 RVA: 0x000E4E04 File Offset: 0x000E3004
	// (set) Token: 0x06001820 RID: 6176 RVA: 0x000E4E34 File Offset: 0x000E3034
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
	// (get) Token: 0x06001821 RID: 6177 RVA: 0x000E4E64 File Offset: 0x000E3064
	// (set) Token: 0x06001822 RID: 6178 RVA: 0x000E4E94 File Offset: 0x000E3094
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
	// (get) Token: 0x06001823 RID: 6179 RVA: 0x000E4EC4 File Offset: 0x000E30C4
	// (set) Token: 0x06001824 RID: 6180 RVA: 0x000E4EF4 File Offset: 0x000E30F4
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
	// (get) Token: 0x06001825 RID: 6181 RVA: 0x000E4F24 File Offset: 0x000E3124
	// (set) Token: 0x06001826 RID: 6182 RVA: 0x000E4F54 File Offset: 0x000E3154
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
	// (get) Token: 0x06001827 RID: 6183 RVA: 0x000E4F84 File Offset: 0x000E3184
	// (set) Token: 0x06001828 RID: 6184 RVA: 0x000E4FB4 File Offset: 0x000E31B4
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
	// (get) Token: 0x06001829 RID: 6185 RVA: 0x000E4FE4 File Offset: 0x000E31E4
	// (set) Token: 0x0600182A RID: 6186 RVA: 0x000E5014 File Offset: 0x000E3214
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
	// (get) Token: 0x0600182B RID: 6187 RVA: 0x000E5044 File Offset: 0x000E3244
	// (set) Token: 0x0600182C RID: 6188 RVA: 0x000E5074 File Offset: 0x000E3274
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

	// Token: 0x0600182D RID: 6189 RVA: 0x000E50A4 File Offset: 0x000E32A4
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

	// Token: 0x04002308 RID: 8968
	private const string Str_DelinquentPunishments = "DelinquentPunishments";

	// Token: 0x04002309 RID: 8969
	private const string Str_CounselorPunishments = "CounselorPunishments";

	// Token: 0x0400230A RID: 8970
	private const string Str_CounselorVisits = "CounselorVisits";

	// Token: 0x0400230B RID: 8971
	private const string Str_CounselorTape = "CounselorTape";

	// Token: 0x0400230C RID: 8972
	private const string Str_ApologiesUsed = "ApologiesUsed";

	// Token: 0x0400230D RID: 8973
	private const string Str_WeaponsBanned = "WeaponsBanned";

	// Token: 0x0400230E RID: 8974
	private const string Str_BloodVisits = "BloodVisits";

	// Token: 0x0400230F RID: 8975
	private const string Str_InsanityVisits = "InsanityVisits";

	// Token: 0x04002310 RID: 8976
	private const string Str_LewdVisits = "LewdVisits";

	// Token: 0x04002311 RID: 8977
	private const string Str_TheftVisits = "TheftVisits";

	// Token: 0x04002312 RID: 8978
	private const string Str_TrespassVisits = "TrespassVisits";

	// Token: 0x04002313 RID: 8979
	private const string Str_WeaponVisits = "WeaponVisits";

	// Token: 0x04002314 RID: 8980
	private const string Str_BloodExcuseUsed = "BloodExcuseUsed";

	// Token: 0x04002315 RID: 8981
	private const string Str_InsanityExcuseUsed = "InsanityExcuseUsed";

	// Token: 0x04002316 RID: 8982
	private const string Str_LewdExcuseUsed = "LewdExcuseUsed";

	// Token: 0x04002317 RID: 8983
	private const string Str_TheftExcuseUsed = "TheftExcuseUsed";

	// Token: 0x04002318 RID: 8984
	private const string Str_TrespassExcuseUsed = "TrespassExcuseUsed";

	// Token: 0x04002319 RID: 8985
	private const string Str_WeaponExcuseUsed = "WeaponExcuseUsed";

	// Token: 0x0400231A RID: 8986
	private const string Str_BloodBlameUsed = "BloodBlameUsed";

	// Token: 0x0400231B RID: 8987
	private const string Str_InsanityBlameUsed = "InsanityBlameUsed";

	// Token: 0x0400231C RID: 8988
	private const string Str_LewdBlameUsed = "LewdBlameUsed";

	// Token: 0x0400231D RID: 8989
	private const string Str_TheftBlameUsed = "TheftBlameUsed";

	// Token: 0x0400231E RID: 8990
	private const string Str_TrespassBlameUsed = "TrespassBlameUsed";

	// Token: 0x0400231F RID: 8991
	private const string Str_WeaponBlameUsed = "WeaponBlameUsed";

	// Token: 0x04002320 RID: 8992
	private const string Str_ReportedAlcohol = "ReportedAlcohol";

	// Token: 0x04002321 RID: 8993
	private const string Str_ReportedCigarettes = "ReportedCigarettes";

	// Token: 0x04002322 RID: 8994
	private const string Str_ReportedCondoms = "ReportedCondoms";

	// Token: 0x04002323 RID: 8995
	private const string Str_ReportedTheft = "ReportedTheft";

	// Token: 0x04002324 RID: 8996
	private const string Str_ReportedCheating = "ReportedCheating";
}
