using System;
using UnityEngine;

// Token: 0x02000303 RID: 771
public static class CounselorGlobals
{
	// Token: 0x1700045C RID: 1116
	// (get) Token: 0x060017F7 RID: 6135 RVA: 0x000E482C File Offset: 0x000E2A2C
	// (set) Token: 0x060017F8 RID: 6136 RVA: 0x000E485C File Offset: 0x000E2A5C
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

	// Token: 0x1700045D RID: 1117
	// (get) Token: 0x060017F9 RID: 6137 RVA: 0x000E488C File Offset: 0x000E2A8C
	// (set) Token: 0x060017FA RID: 6138 RVA: 0x000E48BC File Offset: 0x000E2ABC
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

	// Token: 0x1700045E RID: 1118
	// (get) Token: 0x060017FB RID: 6139 RVA: 0x000E48EC File Offset: 0x000E2AEC
	// (set) Token: 0x060017FC RID: 6140 RVA: 0x000E491C File Offset: 0x000E2B1C
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

	// Token: 0x1700045F RID: 1119
	// (get) Token: 0x060017FD RID: 6141 RVA: 0x000E494C File Offset: 0x000E2B4C
	// (set) Token: 0x060017FE RID: 6142 RVA: 0x000E497C File Offset: 0x000E2B7C
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

	// Token: 0x17000460 RID: 1120
	// (get) Token: 0x060017FF RID: 6143 RVA: 0x000E49AC File Offset: 0x000E2BAC
	// (set) Token: 0x06001800 RID: 6144 RVA: 0x000E49DC File Offset: 0x000E2BDC
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

	// Token: 0x17000461 RID: 1121
	// (get) Token: 0x06001801 RID: 6145 RVA: 0x000E4A0C File Offset: 0x000E2C0C
	// (set) Token: 0x06001802 RID: 6146 RVA: 0x000E4A3C File Offset: 0x000E2C3C
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

	// Token: 0x17000462 RID: 1122
	// (get) Token: 0x06001803 RID: 6147 RVA: 0x000E4A6C File Offset: 0x000E2C6C
	// (set) Token: 0x06001804 RID: 6148 RVA: 0x000E4A9C File Offset: 0x000E2C9C
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

	// Token: 0x17000463 RID: 1123
	// (get) Token: 0x06001805 RID: 6149 RVA: 0x000E4ACC File Offset: 0x000E2CCC
	// (set) Token: 0x06001806 RID: 6150 RVA: 0x000E4AFC File Offset: 0x000E2CFC
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

	// Token: 0x17000464 RID: 1124
	// (get) Token: 0x06001807 RID: 6151 RVA: 0x000E4B2C File Offset: 0x000E2D2C
	// (set) Token: 0x06001808 RID: 6152 RVA: 0x000E4B5C File Offset: 0x000E2D5C
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

	// Token: 0x17000465 RID: 1125
	// (get) Token: 0x06001809 RID: 6153 RVA: 0x000E4B8C File Offset: 0x000E2D8C
	// (set) Token: 0x0600180A RID: 6154 RVA: 0x000E4BBC File Offset: 0x000E2DBC
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

	// Token: 0x17000466 RID: 1126
	// (get) Token: 0x0600180B RID: 6155 RVA: 0x000E4BEC File Offset: 0x000E2DEC
	// (set) Token: 0x0600180C RID: 6156 RVA: 0x000E4C1C File Offset: 0x000E2E1C
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

	// Token: 0x17000467 RID: 1127
	// (get) Token: 0x0600180D RID: 6157 RVA: 0x000E4C4C File Offset: 0x000E2E4C
	// (set) Token: 0x0600180E RID: 6158 RVA: 0x000E4C7C File Offset: 0x000E2E7C
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

	// Token: 0x17000468 RID: 1128
	// (get) Token: 0x0600180F RID: 6159 RVA: 0x000E4CAC File Offset: 0x000E2EAC
	// (set) Token: 0x06001810 RID: 6160 RVA: 0x000E4CDC File Offset: 0x000E2EDC
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

	// Token: 0x17000469 RID: 1129
	// (get) Token: 0x06001811 RID: 6161 RVA: 0x000E4D0C File Offset: 0x000E2F0C
	// (set) Token: 0x06001812 RID: 6162 RVA: 0x000E4D3C File Offset: 0x000E2F3C
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

	// Token: 0x1700046A RID: 1130
	// (get) Token: 0x06001813 RID: 6163 RVA: 0x000E4D6C File Offset: 0x000E2F6C
	// (set) Token: 0x06001814 RID: 6164 RVA: 0x000E4D9C File Offset: 0x000E2F9C
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

	// Token: 0x1700046B RID: 1131
	// (get) Token: 0x06001815 RID: 6165 RVA: 0x000E4DCC File Offset: 0x000E2FCC
	// (set) Token: 0x06001816 RID: 6166 RVA: 0x000E4DFC File Offset: 0x000E2FFC
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

	// Token: 0x1700046C RID: 1132
	// (get) Token: 0x06001817 RID: 6167 RVA: 0x000E4E2C File Offset: 0x000E302C
	// (set) Token: 0x06001818 RID: 6168 RVA: 0x000E4E5C File Offset: 0x000E305C
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

	// Token: 0x1700046D RID: 1133
	// (get) Token: 0x06001819 RID: 6169 RVA: 0x000E4E8C File Offset: 0x000E308C
	// (set) Token: 0x0600181A RID: 6170 RVA: 0x000E4EBC File Offset: 0x000E30BC
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

	// Token: 0x1700046E RID: 1134
	// (get) Token: 0x0600181B RID: 6171 RVA: 0x000E4EEC File Offset: 0x000E30EC
	// (set) Token: 0x0600181C RID: 6172 RVA: 0x000E4F1C File Offset: 0x000E311C
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

	// Token: 0x1700046F RID: 1135
	// (get) Token: 0x0600181D RID: 6173 RVA: 0x000E4F4C File Offset: 0x000E314C
	// (set) Token: 0x0600181E RID: 6174 RVA: 0x000E4F7C File Offset: 0x000E317C
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

	// Token: 0x17000470 RID: 1136
	// (get) Token: 0x0600181F RID: 6175 RVA: 0x000E4FAC File Offset: 0x000E31AC
	// (set) Token: 0x06001820 RID: 6176 RVA: 0x000E4FDC File Offset: 0x000E31DC
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

	// Token: 0x17000471 RID: 1137
	// (get) Token: 0x06001821 RID: 6177 RVA: 0x000E500C File Offset: 0x000E320C
	// (set) Token: 0x06001822 RID: 6178 RVA: 0x000E503C File Offset: 0x000E323C
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

	// Token: 0x17000472 RID: 1138
	// (get) Token: 0x06001823 RID: 6179 RVA: 0x000E506C File Offset: 0x000E326C
	// (set) Token: 0x06001824 RID: 6180 RVA: 0x000E509C File Offset: 0x000E329C
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

	// Token: 0x17000473 RID: 1139
	// (get) Token: 0x06001825 RID: 6181 RVA: 0x000E50CC File Offset: 0x000E32CC
	// (set) Token: 0x06001826 RID: 6182 RVA: 0x000E50FC File Offset: 0x000E32FC
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

	// Token: 0x17000474 RID: 1140
	// (get) Token: 0x06001827 RID: 6183 RVA: 0x000E512C File Offset: 0x000E332C
	// (set) Token: 0x06001828 RID: 6184 RVA: 0x000E515C File Offset: 0x000E335C
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

	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x06001829 RID: 6185 RVA: 0x000E518C File Offset: 0x000E338C
	// (set) Token: 0x0600182A RID: 6186 RVA: 0x000E51BC File Offset: 0x000E33BC
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

	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x0600182B RID: 6187 RVA: 0x000E51EC File Offset: 0x000E33EC
	// (set) Token: 0x0600182C RID: 6188 RVA: 0x000E521C File Offset: 0x000E341C
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

	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x0600182D RID: 6189 RVA: 0x000E524C File Offset: 0x000E344C
	// (set) Token: 0x0600182E RID: 6190 RVA: 0x000E527C File Offset: 0x000E347C
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

	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x0600182F RID: 6191 RVA: 0x000E52AC File Offset: 0x000E34AC
	// (set) Token: 0x06001830 RID: 6192 RVA: 0x000E52DC File Offset: 0x000E34DC
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

	// Token: 0x06001831 RID: 6193 RVA: 0x000E530C File Offset: 0x000E350C
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

	// Token: 0x0400230B RID: 8971
	private const string Str_DelinquentPunishments = "DelinquentPunishments";

	// Token: 0x0400230C RID: 8972
	private const string Str_CounselorPunishments = "CounselorPunishments";

	// Token: 0x0400230D RID: 8973
	private const string Str_CounselorVisits = "CounselorVisits";

	// Token: 0x0400230E RID: 8974
	private const string Str_CounselorTape = "CounselorTape";

	// Token: 0x0400230F RID: 8975
	private const string Str_ApologiesUsed = "ApologiesUsed";

	// Token: 0x04002310 RID: 8976
	private const string Str_WeaponsBanned = "WeaponsBanned";

	// Token: 0x04002311 RID: 8977
	private const string Str_BloodVisits = "BloodVisits";

	// Token: 0x04002312 RID: 8978
	private const string Str_InsanityVisits = "InsanityVisits";

	// Token: 0x04002313 RID: 8979
	private const string Str_LewdVisits = "LewdVisits";

	// Token: 0x04002314 RID: 8980
	private const string Str_TheftVisits = "TheftVisits";

	// Token: 0x04002315 RID: 8981
	private const string Str_TrespassVisits = "TrespassVisits";

	// Token: 0x04002316 RID: 8982
	private const string Str_WeaponVisits = "WeaponVisits";

	// Token: 0x04002317 RID: 8983
	private const string Str_BloodExcuseUsed = "BloodExcuseUsed";

	// Token: 0x04002318 RID: 8984
	private const string Str_InsanityExcuseUsed = "InsanityExcuseUsed";

	// Token: 0x04002319 RID: 8985
	private const string Str_LewdExcuseUsed = "LewdExcuseUsed";

	// Token: 0x0400231A RID: 8986
	private const string Str_TheftExcuseUsed = "TheftExcuseUsed";

	// Token: 0x0400231B RID: 8987
	private const string Str_TrespassExcuseUsed = "TrespassExcuseUsed";

	// Token: 0x0400231C RID: 8988
	private const string Str_WeaponExcuseUsed = "WeaponExcuseUsed";

	// Token: 0x0400231D RID: 8989
	private const string Str_BloodBlameUsed = "BloodBlameUsed";

	// Token: 0x0400231E RID: 8990
	private const string Str_InsanityBlameUsed = "InsanityBlameUsed";

	// Token: 0x0400231F RID: 8991
	private const string Str_LewdBlameUsed = "LewdBlameUsed";

	// Token: 0x04002320 RID: 8992
	private const string Str_TheftBlameUsed = "TheftBlameUsed";

	// Token: 0x04002321 RID: 8993
	private const string Str_TrespassBlameUsed = "TrespassBlameUsed";

	// Token: 0x04002322 RID: 8994
	private const string Str_WeaponBlameUsed = "WeaponBlameUsed";

	// Token: 0x04002323 RID: 8995
	private const string Str_ReportedAlcohol = "ReportedAlcohol";

	// Token: 0x04002324 RID: 8996
	private const string Str_ReportedCigarettes = "ReportedCigarettes";

	// Token: 0x04002325 RID: 8997
	private const string Str_ReportedCondoms = "ReportedCondoms";

	// Token: 0x04002326 RID: 8998
	private const string Str_ReportedTheft = "ReportedTheft";

	// Token: 0x04002327 RID: 8999
	private const string Str_ReportedCheating = "ReportedCheating";
}
