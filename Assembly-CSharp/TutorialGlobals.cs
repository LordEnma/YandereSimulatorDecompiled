using System;

// Token: 0x02000302 RID: 770
public static class TutorialGlobals
{
	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x060017D8 RID: 6104 RVA: 0x000E4428 File Offset: 0x000E2628
	// (set) Token: 0x060017D9 RID: 6105 RVA: 0x000E4458 File Offset: 0x000E2658
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

	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x060017DA RID: 6106 RVA: 0x000E4488 File Offset: 0x000E2688
	// (set) Token: 0x060017DB RID: 6107 RVA: 0x000E44B8 File Offset: 0x000E26B8
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

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x060017DC RID: 6108 RVA: 0x000E44E8 File Offset: 0x000E26E8
	// (set) Token: 0x060017DD RID: 6109 RVA: 0x000E4518 File Offset: 0x000E2718
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

	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x060017DE RID: 6110 RVA: 0x000E4548 File Offset: 0x000E2748
	// (set) Token: 0x060017DF RID: 6111 RVA: 0x000E4578 File Offset: 0x000E2778
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

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x060017E0 RID: 6112 RVA: 0x000E45A8 File Offset: 0x000E27A8
	// (set) Token: 0x060017E1 RID: 6113 RVA: 0x000E45D8 File Offset: 0x000E27D8
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

	// Token: 0x17000450 RID: 1104
	// (get) Token: 0x060017E2 RID: 6114 RVA: 0x000E4608 File Offset: 0x000E2808
	// (set) Token: 0x060017E3 RID: 6115 RVA: 0x000E4638 File Offset: 0x000E2838
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

	// Token: 0x17000451 RID: 1105
	// (get) Token: 0x060017E4 RID: 6116 RVA: 0x000E4668 File Offset: 0x000E2868
	// (set) Token: 0x060017E5 RID: 6117 RVA: 0x000E4698 File Offset: 0x000E2898
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

	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x060017E6 RID: 6118 RVA: 0x000E46C8 File Offset: 0x000E28C8
	// (set) Token: 0x060017E7 RID: 6119 RVA: 0x000E46F8 File Offset: 0x000E28F8
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

	// Token: 0x17000453 RID: 1107
	// (get) Token: 0x060017E8 RID: 6120 RVA: 0x000E4728 File Offset: 0x000E2928
	// (set) Token: 0x060017E9 RID: 6121 RVA: 0x000E4758 File Offset: 0x000E2958
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

	// Token: 0x17000454 RID: 1108
	// (get) Token: 0x060017EA RID: 6122 RVA: 0x000E4788 File Offset: 0x000E2988
	// (set) Token: 0x060017EB RID: 6123 RVA: 0x000E47B8 File Offset: 0x000E29B8
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

	// Token: 0x17000455 RID: 1109
	// (get) Token: 0x060017EC RID: 6124 RVA: 0x000E47E8 File Offset: 0x000E29E8
	// (set) Token: 0x060017ED RID: 6125 RVA: 0x000E4818 File Offset: 0x000E2A18
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

	// Token: 0x17000456 RID: 1110
	// (get) Token: 0x060017EE RID: 6126 RVA: 0x000E4848 File Offset: 0x000E2A48
	// (set) Token: 0x060017EF RID: 6127 RVA: 0x000E4878 File Offset: 0x000E2A78
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

	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x060017F0 RID: 6128 RVA: 0x000E48A8 File Offset: 0x000E2AA8
	// (set) Token: 0x060017F1 RID: 6129 RVA: 0x000E48D8 File Offset: 0x000E2AD8
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

	// Token: 0x17000458 RID: 1112
	// (get) Token: 0x060017F2 RID: 6130 RVA: 0x000E4908 File Offset: 0x000E2B08
	// (set) Token: 0x060017F3 RID: 6131 RVA: 0x000E4938 File Offset: 0x000E2B38
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

	// Token: 0x17000459 RID: 1113
	// (get) Token: 0x060017F4 RID: 6132 RVA: 0x000E4968 File Offset: 0x000E2B68
	// (set) Token: 0x060017F5 RID: 6133 RVA: 0x000E4998 File Offset: 0x000E2B98
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

	// Token: 0x1700045A RID: 1114
	// (get) Token: 0x060017F6 RID: 6134 RVA: 0x000E49C8 File Offset: 0x000E2BC8
	// (set) Token: 0x060017F7 RID: 6135 RVA: 0x000E49F8 File Offset: 0x000E2BF8
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

	// Token: 0x1700045B RID: 1115
	// (get) Token: 0x060017F8 RID: 6136 RVA: 0x000E4A28 File Offset: 0x000E2C28
	// (set) Token: 0x060017F9 RID: 6137 RVA: 0x000E4A58 File Offset: 0x000E2C58
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

	// Token: 0x060017FA RID: 6138 RVA: 0x000E4A88 File Offset: 0x000E2C88
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

	// Token: 0x04002303 RID: 8963
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x04002304 RID: 8964
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x04002305 RID: 8965
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x04002306 RID: 8966
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x04002307 RID: 8967
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x04002308 RID: 8968
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x04002309 RID: 8969
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x0400230A RID: 8970
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x0400230B RID: 8971
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x0400230C RID: 8972
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x0400230D RID: 8973
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x0400230E RID: 8974
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x0400230F RID: 8975
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x04002310 RID: 8976
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x04002311 RID: 8977
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x04002312 RID: 8978
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x04002313 RID: 8979
	private const string Str_IgnoreRep = "IgnoreClass";
}
