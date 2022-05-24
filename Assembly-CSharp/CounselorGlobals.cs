using System;
using UnityEngine;

// Token: 0x02000304 RID: 772
public static class CounselorGlobals
{
	// Token: 0x1700045D RID: 1117
	// (get) Token: 0x060017FF RID: 6143 RVA: 0x000E51C0 File Offset: 0x000E33C0
	// (set) Token: 0x06001800 RID: 6144 RVA: 0x000E51F0 File Offset: 0x000E33F0
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

	// Token: 0x1700045E RID: 1118
	// (get) Token: 0x06001801 RID: 6145 RVA: 0x000E5220 File Offset: 0x000E3420
	// (set) Token: 0x06001802 RID: 6146 RVA: 0x000E5250 File Offset: 0x000E3450
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

	// Token: 0x1700045F RID: 1119
	// (get) Token: 0x06001803 RID: 6147 RVA: 0x000E5280 File Offset: 0x000E3480
	// (set) Token: 0x06001804 RID: 6148 RVA: 0x000E52B0 File Offset: 0x000E34B0
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

	// Token: 0x17000460 RID: 1120
	// (get) Token: 0x06001805 RID: 6149 RVA: 0x000E52E0 File Offset: 0x000E34E0
	// (set) Token: 0x06001806 RID: 6150 RVA: 0x000E5310 File Offset: 0x000E3510
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

	// Token: 0x17000461 RID: 1121
	// (get) Token: 0x06001807 RID: 6151 RVA: 0x000E5340 File Offset: 0x000E3540
	// (set) Token: 0x06001808 RID: 6152 RVA: 0x000E5370 File Offset: 0x000E3570
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

	// Token: 0x17000462 RID: 1122
	// (get) Token: 0x06001809 RID: 6153 RVA: 0x000E53A0 File Offset: 0x000E35A0
	// (set) Token: 0x0600180A RID: 6154 RVA: 0x000E53D0 File Offset: 0x000E35D0
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

	// Token: 0x17000463 RID: 1123
	// (get) Token: 0x0600180B RID: 6155 RVA: 0x000E5400 File Offset: 0x000E3600
	// (set) Token: 0x0600180C RID: 6156 RVA: 0x000E5430 File Offset: 0x000E3630
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

	// Token: 0x17000464 RID: 1124
	// (get) Token: 0x0600180D RID: 6157 RVA: 0x000E5460 File Offset: 0x000E3660
	// (set) Token: 0x0600180E RID: 6158 RVA: 0x000E5490 File Offset: 0x000E3690
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

	// Token: 0x17000465 RID: 1125
	// (get) Token: 0x0600180F RID: 6159 RVA: 0x000E54C0 File Offset: 0x000E36C0
	// (set) Token: 0x06001810 RID: 6160 RVA: 0x000E54F0 File Offset: 0x000E36F0
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

	// Token: 0x17000466 RID: 1126
	// (get) Token: 0x06001811 RID: 6161 RVA: 0x000E5520 File Offset: 0x000E3720
	// (set) Token: 0x06001812 RID: 6162 RVA: 0x000E5550 File Offset: 0x000E3750
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

	// Token: 0x17000467 RID: 1127
	// (get) Token: 0x06001813 RID: 6163 RVA: 0x000E5580 File Offset: 0x000E3780
	// (set) Token: 0x06001814 RID: 6164 RVA: 0x000E55B0 File Offset: 0x000E37B0
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

	// Token: 0x17000468 RID: 1128
	// (get) Token: 0x06001815 RID: 6165 RVA: 0x000E55E0 File Offset: 0x000E37E0
	// (set) Token: 0x06001816 RID: 6166 RVA: 0x000E5610 File Offset: 0x000E3810
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

	// Token: 0x17000469 RID: 1129
	// (get) Token: 0x06001817 RID: 6167 RVA: 0x000E5640 File Offset: 0x000E3840
	// (set) Token: 0x06001818 RID: 6168 RVA: 0x000E5670 File Offset: 0x000E3870
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

	// Token: 0x1700046A RID: 1130
	// (get) Token: 0x06001819 RID: 6169 RVA: 0x000E56A0 File Offset: 0x000E38A0
	// (set) Token: 0x0600181A RID: 6170 RVA: 0x000E56D0 File Offset: 0x000E38D0
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

	// Token: 0x1700046B RID: 1131
	// (get) Token: 0x0600181B RID: 6171 RVA: 0x000E5700 File Offset: 0x000E3900
	// (set) Token: 0x0600181C RID: 6172 RVA: 0x000E5730 File Offset: 0x000E3930
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

	// Token: 0x1700046C RID: 1132
	// (get) Token: 0x0600181D RID: 6173 RVA: 0x000E5760 File Offset: 0x000E3960
	// (set) Token: 0x0600181E RID: 6174 RVA: 0x000E5790 File Offset: 0x000E3990
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

	// Token: 0x1700046D RID: 1133
	// (get) Token: 0x0600181F RID: 6175 RVA: 0x000E57C0 File Offset: 0x000E39C0
	// (set) Token: 0x06001820 RID: 6176 RVA: 0x000E57F0 File Offset: 0x000E39F0
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

	// Token: 0x1700046E RID: 1134
	// (get) Token: 0x06001821 RID: 6177 RVA: 0x000E5820 File Offset: 0x000E3A20
	// (set) Token: 0x06001822 RID: 6178 RVA: 0x000E5850 File Offset: 0x000E3A50
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

	// Token: 0x1700046F RID: 1135
	// (get) Token: 0x06001823 RID: 6179 RVA: 0x000E5880 File Offset: 0x000E3A80
	// (set) Token: 0x06001824 RID: 6180 RVA: 0x000E58B0 File Offset: 0x000E3AB0
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

	// Token: 0x17000470 RID: 1136
	// (get) Token: 0x06001825 RID: 6181 RVA: 0x000E58E0 File Offset: 0x000E3AE0
	// (set) Token: 0x06001826 RID: 6182 RVA: 0x000E5910 File Offset: 0x000E3B10
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

	// Token: 0x17000471 RID: 1137
	// (get) Token: 0x06001827 RID: 6183 RVA: 0x000E5940 File Offset: 0x000E3B40
	// (set) Token: 0x06001828 RID: 6184 RVA: 0x000E5970 File Offset: 0x000E3B70
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

	// Token: 0x17000472 RID: 1138
	// (get) Token: 0x06001829 RID: 6185 RVA: 0x000E59A0 File Offset: 0x000E3BA0
	// (set) Token: 0x0600182A RID: 6186 RVA: 0x000E59D0 File Offset: 0x000E3BD0
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

	// Token: 0x17000473 RID: 1139
	// (get) Token: 0x0600182B RID: 6187 RVA: 0x000E5A00 File Offset: 0x000E3C00
	// (set) Token: 0x0600182C RID: 6188 RVA: 0x000E5A30 File Offset: 0x000E3C30
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

	// Token: 0x17000474 RID: 1140
	// (get) Token: 0x0600182D RID: 6189 RVA: 0x000E5A60 File Offset: 0x000E3C60
	// (set) Token: 0x0600182E RID: 6190 RVA: 0x000E5A90 File Offset: 0x000E3C90
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

	// Token: 0x17000475 RID: 1141
	// (get) Token: 0x0600182F RID: 6191 RVA: 0x000E5AC0 File Offset: 0x000E3CC0
	// (set) Token: 0x06001830 RID: 6192 RVA: 0x000E5AF0 File Offset: 0x000E3CF0
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

	// Token: 0x17000476 RID: 1142
	// (get) Token: 0x06001831 RID: 6193 RVA: 0x000E5B20 File Offset: 0x000E3D20
	// (set) Token: 0x06001832 RID: 6194 RVA: 0x000E5B50 File Offset: 0x000E3D50
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

	// Token: 0x17000477 RID: 1143
	// (get) Token: 0x06001833 RID: 6195 RVA: 0x000E5B80 File Offset: 0x000E3D80
	// (set) Token: 0x06001834 RID: 6196 RVA: 0x000E5BB0 File Offset: 0x000E3DB0
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

	// Token: 0x17000478 RID: 1144
	// (get) Token: 0x06001835 RID: 6197 RVA: 0x000E5BE0 File Offset: 0x000E3DE0
	// (set) Token: 0x06001836 RID: 6198 RVA: 0x000E5C10 File Offset: 0x000E3E10
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

	// Token: 0x17000479 RID: 1145
	// (get) Token: 0x06001837 RID: 6199 RVA: 0x000E5C40 File Offset: 0x000E3E40
	// (set) Token: 0x06001838 RID: 6200 RVA: 0x000E5C70 File Offset: 0x000E3E70
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

	// Token: 0x06001839 RID: 6201 RVA: 0x000E5CA0 File Offset: 0x000E3EA0
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

	// Token: 0x0400231F RID: 8991
	private const string Str_DelinquentPunishments = "DelinquentPunishments";

	// Token: 0x04002320 RID: 8992
	private const string Str_CounselorPunishments = "CounselorPunishments";

	// Token: 0x04002321 RID: 8993
	private const string Str_CounselorVisits = "CounselorVisits";

	// Token: 0x04002322 RID: 8994
	private const string Str_CounselorTape = "CounselorTape";

	// Token: 0x04002323 RID: 8995
	private const string Str_ApologiesUsed = "ApologiesUsed";

	// Token: 0x04002324 RID: 8996
	private const string Str_WeaponsBanned = "WeaponsBanned";

	// Token: 0x04002325 RID: 8997
	private const string Str_BloodVisits = "BloodVisits";

	// Token: 0x04002326 RID: 8998
	private const string Str_InsanityVisits = "InsanityVisits";

	// Token: 0x04002327 RID: 8999
	private const string Str_LewdVisits = "LewdVisits";

	// Token: 0x04002328 RID: 9000
	private const string Str_TheftVisits = "TheftVisits";

	// Token: 0x04002329 RID: 9001
	private const string Str_TrespassVisits = "TrespassVisits";

	// Token: 0x0400232A RID: 9002
	private const string Str_WeaponVisits = "WeaponVisits";

	// Token: 0x0400232B RID: 9003
	private const string Str_BloodExcuseUsed = "BloodExcuseUsed";

	// Token: 0x0400232C RID: 9004
	private const string Str_InsanityExcuseUsed = "InsanityExcuseUsed";

	// Token: 0x0400232D RID: 9005
	private const string Str_LewdExcuseUsed = "LewdExcuseUsed";

	// Token: 0x0400232E RID: 9006
	private const string Str_TheftExcuseUsed = "TheftExcuseUsed";

	// Token: 0x0400232F RID: 9007
	private const string Str_TrespassExcuseUsed = "TrespassExcuseUsed";

	// Token: 0x04002330 RID: 9008
	private const string Str_WeaponExcuseUsed = "WeaponExcuseUsed";

	// Token: 0x04002331 RID: 9009
	private const string Str_BloodBlameUsed = "BloodBlameUsed";

	// Token: 0x04002332 RID: 9010
	private const string Str_InsanityBlameUsed = "InsanityBlameUsed";

	// Token: 0x04002333 RID: 9011
	private const string Str_LewdBlameUsed = "LewdBlameUsed";

	// Token: 0x04002334 RID: 9012
	private const string Str_TheftBlameUsed = "TheftBlameUsed";

	// Token: 0x04002335 RID: 9013
	private const string Str_TrespassBlameUsed = "TrespassBlameUsed";

	// Token: 0x04002336 RID: 9014
	private const string Str_WeaponBlameUsed = "WeaponBlameUsed";

	// Token: 0x04002337 RID: 9015
	private const string Str_ReportedAlcohol = "ReportedAlcohol";

	// Token: 0x04002338 RID: 9016
	private const string Str_ReportedCigarettes = "ReportedCigarettes";

	// Token: 0x04002339 RID: 9017
	private const string Str_ReportedCondoms = "ReportedCondoms";

	// Token: 0x0400233A RID: 9018
	private const string Str_ReportedTheft = "ReportedTheft";

	// Token: 0x0400233B RID: 9019
	private const string Str_ReportedCheating = "ReportedCheating";
}
