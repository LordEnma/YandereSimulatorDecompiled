using System;

// Token: 0x02000303 RID: 771
public static class TutorialGlobals
{
	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x060017DC RID: 6108 RVA: 0x000E4920 File Offset: 0x000E2B20
	// (set) Token: 0x060017DD RID: 6109 RVA: 0x000E4950 File Offset: 0x000E2B50
	public static bool IgnoreClothing
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClothing");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClothing", value);
		}
	}

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x060017DE RID: 6110 RVA: 0x000E4980 File Offset: 0x000E2B80
	// (set) Token: 0x060017DF RID: 6111 RVA: 0x000E49B0 File Offset: 0x000E2BB0
	public static bool IgnoreCouncil
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreCouncil");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreCouncil", value);
		}
	}

	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x060017E0 RID: 6112 RVA: 0x000E49E0 File Offset: 0x000E2BE0
	// (set) Token: 0x060017E1 RID: 6113 RVA: 0x000E4A10 File Offset: 0x000E2C10
	public static bool IgnoreTeacher
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreTeacher");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreTeacher", value);
		}
	}

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x060017E2 RID: 6114 RVA: 0x000E4A40 File Offset: 0x000E2C40
	// (set) Token: 0x060017E3 RID: 6115 RVA: 0x000E4A70 File Offset: 0x000E2C70
	public static bool IgnoreLocker
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreLocker");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreLocker", value);
		}
	}

	// Token: 0x17000450 RID: 1104
	// (get) Token: 0x060017E4 RID: 6116 RVA: 0x000E4AA0 File Offset: 0x000E2CA0
	// (set) Token: 0x060017E5 RID: 6117 RVA: 0x000E4AD0 File Offset: 0x000E2CD0
	public static bool IgnorePolice
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePolice");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePolice", value);
		}
	}

	// Token: 0x17000451 RID: 1105
	// (get) Token: 0x060017E6 RID: 6118 RVA: 0x000E4B00 File Offset: 0x000E2D00
	// (set) Token: 0x060017E7 RID: 6119 RVA: 0x000E4B30 File Offset: 0x000E2D30
	public static bool IgnoreSanity
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSanity");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSanity", value);
		}
	}

	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x060017E8 RID: 6120 RVA: 0x000E4B60 File Offset: 0x000E2D60
	// (set) Token: 0x060017E9 RID: 6121 RVA: 0x000E4B90 File Offset: 0x000E2D90
	public static bool IgnoreSenpai
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSenpai");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSenpai", value);
		}
	}

	// Token: 0x17000453 RID: 1107
	// (get) Token: 0x060017EA RID: 6122 RVA: 0x000E4BC0 File Offset: 0x000E2DC0
	// (set) Token: 0x060017EB RID: 6123 RVA: 0x000E4BF0 File Offset: 0x000E2DF0
	public static bool IgnoreVision
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreVision");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreVision", value);
		}
	}

	// Token: 0x17000454 RID: 1108
	// (get) Token: 0x060017EC RID: 6124 RVA: 0x000E4C20 File Offset: 0x000E2E20
	// (set) Token: 0x060017ED RID: 6125 RVA: 0x000E4C50 File Offset: 0x000E2E50
	public static bool IgnoreWeapon
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreWeapon");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreWeapon", value);
		}
	}

	// Token: 0x17000455 RID: 1109
	// (get) Token: 0x060017EE RID: 6126 RVA: 0x000E4C80 File Offset: 0x000E2E80
	// (set) Token: 0x060017EF RID: 6127 RVA: 0x000E4CB0 File Offset: 0x000E2EB0
	public static bool IgnoreBlood
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreBlood");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreBlood", value);
		}
	}

	// Token: 0x17000456 RID: 1110
	// (get) Token: 0x060017F0 RID: 6128 RVA: 0x000E4CE0 File Offset: 0x000E2EE0
	// (set) Token: 0x060017F1 RID: 6129 RVA: 0x000E4D10 File Offset: 0x000E2F10
	public static bool IgnoreClass
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass", value);
		}
	}

	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x060017F2 RID: 6130 RVA: 0x000E4D40 File Offset: 0x000E2F40
	// (set) Token: 0x060017F3 RID: 6131 RVA: 0x000E4D70 File Offset: 0x000E2F70
	public static bool IgnoreMoney
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreMoney");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreMoney", value);
		}
	}

	// Token: 0x17000458 RID: 1112
	// (get) Token: 0x060017F4 RID: 6132 RVA: 0x000E4DA0 File Offset: 0x000E2FA0
	// (set) Token: 0x060017F5 RID: 6133 RVA: 0x000E4DD0 File Offset: 0x000E2FD0
	public static bool IgnorePhoto
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePhoto");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePhoto", value);
		}
	}

	// Token: 0x17000459 RID: 1113
	// (get) Token: 0x060017F6 RID: 6134 RVA: 0x000E4E00 File Offset: 0x000E3000
	// (set) Token: 0x060017F7 RID: 6135 RVA: 0x000E4E30 File Offset: 0x000E3030
	public static bool IgnoreClub
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClub");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClub", value);
		}
	}

	// Token: 0x1700045A RID: 1114
	// (get) Token: 0x060017F8 RID: 6136 RVA: 0x000E4E60 File Offset: 0x000E3060
	// (set) Token: 0x060017F9 RID: 6137 RVA: 0x000E4E90 File Offset: 0x000E3090
	public static bool IgnoreInfo
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreInfo");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreInfo", value);
		}
	}

	// Token: 0x1700045B RID: 1115
	// (get) Token: 0x060017FA RID: 6138 RVA: 0x000E4EC0 File Offset: 0x000E30C0
	// (set) Token: 0x060017FB RID: 6139 RVA: 0x000E4EF0 File Offset: 0x000E30F0
	public static bool IgnorePool
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePool");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePool", value);
		}
	}

	// Token: 0x1700045C RID: 1116
	// (get) Token: 0x060017FC RID: 6140 RVA: 0x000E4F20 File Offset: 0x000E3120
	// (set) Token: 0x060017FD RID: 6141 RVA: 0x000E4F50 File Offset: 0x000E3150
	public static bool IgnoreRep
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass", value);
		}
	}

	// Token: 0x060017FE RID: 6142 RVA: 0x000E4F80 File Offset: 0x000E3180
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClothing");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreCouncil");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreTeacher");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreLocker");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePolice");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSanity");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreSenpai");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreVision");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreWeapon");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreBlood");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreMoney");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePhoto");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClub");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreInfo");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnorePool");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IgnoreClass");
	}

	// Token: 0x0400230E RID: 8974
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x0400230F RID: 8975
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x04002310 RID: 8976
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x04002311 RID: 8977
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x04002312 RID: 8978
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x04002313 RID: 8979
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x04002314 RID: 8980
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x04002315 RID: 8981
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x04002316 RID: 8982
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x04002317 RID: 8983
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x04002318 RID: 8984
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x04002319 RID: 8985
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x0400231A RID: 8986
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x0400231B RID: 8987
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x0400231C RID: 8988
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x0400231D RID: 8989
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x0400231E RID: 8990
	private const string Str_IgnoreRep = "IgnoreClass";
}
