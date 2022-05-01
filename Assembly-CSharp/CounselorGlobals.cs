using System;
using UnityEngine;

// Token: 0x02000303 RID: 771
public static class CounselorGlobals
{
	// Token: 0x1700045C RID: 1116
	// (get) Token: 0x060017FB RID: 6139 RVA: 0x000E4CFC File Offset: 0x000E2EFC
	// (set) Token: 0x060017FC RID: 6140 RVA: 0x000E4D2C File Offset: 0x000E2F2C
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
	// (get) Token: 0x060017FD RID: 6141 RVA: 0x000E4D5C File Offset: 0x000E2F5C
	// (set) Token: 0x060017FE RID: 6142 RVA: 0x000E4D8C File Offset: 0x000E2F8C
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
	// (get) Token: 0x060017FF RID: 6143 RVA: 0x000E4DBC File Offset: 0x000E2FBC
	// (set) Token: 0x06001800 RID: 6144 RVA: 0x000E4DEC File Offset: 0x000E2FEC
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
	// (get) Token: 0x06001801 RID: 6145 RVA: 0x000E4E1C File Offset: 0x000E301C
	// (set) Token: 0x06001802 RID: 6146 RVA: 0x000E4E4C File Offset: 0x000E304C
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
	// (get) Token: 0x06001803 RID: 6147 RVA: 0x000E4E7C File Offset: 0x000E307C
	// (set) Token: 0x06001804 RID: 6148 RVA: 0x000E4EAC File Offset: 0x000E30AC
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
	// (get) Token: 0x06001805 RID: 6149 RVA: 0x000E4EDC File Offset: 0x000E30DC
	// (set) Token: 0x06001806 RID: 6150 RVA: 0x000E4F0C File Offset: 0x000E310C
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
	// (get) Token: 0x06001807 RID: 6151 RVA: 0x000E4F3C File Offset: 0x000E313C
	// (set) Token: 0x06001808 RID: 6152 RVA: 0x000E4F6C File Offset: 0x000E316C
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
	// (get) Token: 0x06001809 RID: 6153 RVA: 0x000E4F9C File Offset: 0x000E319C
	// (set) Token: 0x0600180A RID: 6154 RVA: 0x000E4FCC File Offset: 0x000E31CC
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
	// (get) Token: 0x0600180B RID: 6155 RVA: 0x000E4FFC File Offset: 0x000E31FC
	// (set) Token: 0x0600180C RID: 6156 RVA: 0x000E502C File Offset: 0x000E322C
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
	// (get) Token: 0x0600180D RID: 6157 RVA: 0x000E505C File Offset: 0x000E325C
	// (set) Token: 0x0600180E RID: 6158 RVA: 0x000E508C File Offset: 0x000E328C
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
	// (get) Token: 0x0600180F RID: 6159 RVA: 0x000E50BC File Offset: 0x000E32BC
	// (set) Token: 0x06001810 RID: 6160 RVA: 0x000E50EC File Offset: 0x000E32EC
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
	// (get) Token: 0x06001811 RID: 6161 RVA: 0x000E511C File Offset: 0x000E331C
	// (set) Token: 0x06001812 RID: 6162 RVA: 0x000E514C File Offset: 0x000E334C
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
	// (get) Token: 0x06001813 RID: 6163 RVA: 0x000E517C File Offset: 0x000E337C
	// (set) Token: 0x06001814 RID: 6164 RVA: 0x000E51AC File Offset: 0x000E33AC
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
	// (get) Token: 0x06001815 RID: 6165 RVA: 0x000E51DC File Offset: 0x000E33DC
	// (set) Token: 0x06001816 RID: 6166 RVA: 0x000E520C File Offset: 0x000E340C
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
	// (get) Token: 0x06001817 RID: 6167 RVA: 0x000E523C File Offset: 0x000E343C
	// (set) Token: 0x06001818 RID: 6168 RVA: 0x000E526C File Offset: 0x000E346C
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
	// (get) Token: 0x06001819 RID: 6169 RVA: 0x000E529C File Offset: 0x000E349C
	// (set) Token: 0x0600181A RID: 6170 RVA: 0x000E52CC File Offset: 0x000E34CC
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
	// (get) Token: 0x0600181B RID: 6171 RVA: 0x000E52FC File Offset: 0x000E34FC
	// (set) Token: 0x0600181C RID: 6172 RVA: 0x000E532C File Offset: 0x000E352C
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
	// (get) Token: 0x0600181D RID: 6173 RVA: 0x000E535C File Offset: 0x000E355C
	// (set) Token: 0x0600181E RID: 6174 RVA: 0x000E538C File Offset: 0x000E358C
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
	// (get) Token: 0x0600181F RID: 6175 RVA: 0x000E53BC File Offset: 0x000E35BC
	// (set) Token: 0x06001820 RID: 6176 RVA: 0x000E53EC File Offset: 0x000E35EC
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
	// (get) Token: 0x06001821 RID: 6177 RVA: 0x000E541C File Offset: 0x000E361C
	// (set) Token: 0x06001822 RID: 6178 RVA: 0x000E544C File Offset: 0x000E364C
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
	// (get) Token: 0x06001823 RID: 6179 RVA: 0x000E547C File Offset: 0x000E367C
	// (set) Token: 0x06001824 RID: 6180 RVA: 0x000E54AC File Offset: 0x000E36AC
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
	// (get) Token: 0x06001825 RID: 6181 RVA: 0x000E54DC File Offset: 0x000E36DC
	// (set) Token: 0x06001826 RID: 6182 RVA: 0x000E550C File Offset: 0x000E370C
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
	// (get) Token: 0x06001827 RID: 6183 RVA: 0x000E553C File Offset: 0x000E373C
	// (set) Token: 0x06001828 RID: 6184 RVA: 0x000E556C File Offset: 0x000E376C
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
	// (get) Token: 0x06001829 RID: 6185 RVA: 0x000E559C File Offset: 0x000E379C
	// (set) Token: 0x0600182A RID: 6186 RVA: 0x000E55CC File Offset: 0x000E37CC
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
	// (get) Token: 0x0600182B RID: 6187 RVA: 0x000E55FC File Offset: 0x000E37FC
	// (set) Token: 0x0600182C RID: 6188 RVA: 0x000E562C File Offset: 0x000E382C
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
	// (get) Token: 0x0600182D RID: 6189 RVA: 0x000E565C File Offset: 0x000E385C
	// (set) Token: 0x0600182E RID: 6190 RVA: 0x000E568C File Offset: 0x000E388C
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
	// (get) Token: 0x0600182F RID: 6191 RVA: 0x000E56BC File Offset: 0x000E38BC
	// (set) Token: 0x06001830 RID: 6192 RVA: 0x000E56EC File Offset: 0x000E38EC
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
	// (get) Token: 0x06001831 RID: 6193 RVA: 0x000E571C File Offset: 0x000E391C
	// (set) Token: 0x06001832 RID: 6194 RVA: 0x000E574C File Offset: 0x000E394C
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
	// (get) Token: 0x06001833 RID: 6195 RVA: 0x000E577C File Offset: 0x000E397C
	// (set) Token: 0x06001834 RID: 6196 RVA: 0x000E57AC File Offset: 0x000E39AC
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

	// Token: 0x06001835 RID: 6197 RVA: 0x000E57DC File Offset: 0x000E39DC
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

	// Token: 0x04002314 RID: 8980
	private const string Str_DelinquentPunishments = "DelinquentPunishments";

	// Token: 0x04002315 RID: 8981
	private const string Str_CounselorPunishments = "CounselorPunishments";

	// Token: 0x04002316 RID: 8982
	private const string Str_CounselorVisits = "CounselorVisits";

	// Token: 0x04002317 RID: 8983
	private const string Str_CounselorTape = "CounselorTape";

	// Token: 0x04002318 RID: 8984
	private const string Str_ApologiesUsed = "ApologiesUsed";

	// Token: 0x04002319 RID: 8985
	private const string Str_WeaponsBanned = "WeaponsBanned";

	// Token: 0x0400231A RID: 8986
	private const string Str_BloodVisits = "BloodVisits";

	// Token: 0x0400231B RID: 8987
	private const string Str_InsanityVisits = "InsanityVisits";

	// Token: 0x0400231C RID: 8988
	private const string Str_LewdVisits = "LewdVisits";

	// Token: 0x0400231D RID: 8989
	private const string Str_TheftVisits = "TheftVisits";

	// Token: 0x0400231E RID: 8990
	private const string Str_TrespassVisits = "TrespassVisits";

	// Token: 0x0400231F RID: 8991
	private const string Str_WeaponVisits = "WeaponVisits";

	// Token: 0x04002320 RID: 8992
	private const string Str_BloodExcuseUsed = "BloodExcuseUsed";

	// Token: 0x04002321 RID: 8993
	private const string Str_InsanityExcuseUsed = "InsanityExcuseUsed";

	// Token: 0x04002322 RID: 8994
	private const string Str_LewdExcuseUsed = "LewdExcuseUsed";

	// Token: 0x04002323 RID: 8995
	private const string Str_TheftExcuseUsed = "TheftExcuseUsed";

	// Token: 0x04002324 RID: 8996
	private const string Str_TrespassExcuseUsed = "TrespassExcuseUsed";

	// Token: 0x04002325 RID: 8997
	private const string Str_WeaponExcuseUsed = "WeaponExcuseUsed";

	// Token: 0x04002326 RID: 8998
	private const string Str_BloodBlameUsed = "BloodBlameUsed";

	// Token: 0x04002327 RID: 8999
	private const string Str_InsanityBlameUsed = "InsanityBlameUsed";

	// Token: 0x04002328 RID: 9000
	private const string Str_LewdBlameUsed = "LewdBlameUsed";

	// Token: 0x04002329 RID: 9001
	private const string Str_TheftBlameUsed = "TheftBlameUsed";

	// Token: 0x0400232A RID: 9002
	private const string Str_TrespassBlameUsed = "TrespassBlameUsed";

	// Token: 0x0400232B RID: 9003
	private const string Str_WeaponBlameUsed = "WeaponBlameUsed";

	// Token: 0x0400232C RID: 9004
	private const string Str_ReportedAlcohol = "ReportedAlcohol";

	// Token: 0x0400232D RID: 9005
	private const string Str_ReportedCigarettes = "ReportedCigarettes";

	// Token: 0x0400232E RID: 9006
	private const string Str_ReportedCondoms = "ReportedCondoms";

	// Token: 0x0400232F RID: 9007
	private const string Str_ReportedTheft = "ReportedTheft";

	// Token: 0x04002330 RID: 9008
	private const string Str_ReportedCheating = "ReportedCheating";
}
