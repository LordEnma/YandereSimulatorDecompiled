using System;

// Token: 0x02000300 RID: 768
public static class TutorialGlobals
{
	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x060017BF RID: 6079 RVA: 0x000E2F38 File Offset: 0x000E1138
	// (set) Token: 0x060017C0 RID: 6080 RVA: 0x000E2F68 File Offset: 0x000E1168
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

	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x060017C1 RID: 6081 RVA: 0x000E2F98 File Offset: 0x000E1198
	// (set) Token: 0x060017C2 RID: 6082 RVA: 0x000E2FC8 File Offset: 0x000E11C8
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

	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x060017C3 RID: 6083 RVA: 0x000E2FF8 File Offset: 0x000E11F8
	// (set) Token: 0x060017C4 RID: 6084 RVA: 0x000E3028 File Offset: 0x000E1228
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

	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x060017C5 RID: 6085 RVA: 0x000E3058 File Offset: 0x000E1258
	// (set) Token: 0x060017C6 RID: 6086 RVA: 0x000E3088 File Offset: 0x000E1288
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

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x060017C7 RID: 6087 RVA: 0x000E30B8 File Offset: 0x000E12B8
	// (set) Token: 0x060017C8 RID: 6088 RVA: 0x000E30E8 File Offset: 0x000E12E8
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

	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x060017C9 RID: 6089 RVA: 0x000E3118 File Offset: 0x000E1318
	// (set) Token: 0x060017CA RID: 6090 RVA: 0x000E3148 File Offset: 0x000E1348
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

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x060017CB RID: 6091 RVA: 0x000E3178 File Offset: 0x000E1378
	// (set) Token: 0x060017CC RID: 6092 RVA: 0x000E31A8 File Offset: 0x000E13A8
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

	// Token: 0x17000450 RID: 1104
	// (get) Token: 0x060017CD RID: 6093 RVA: 0x000E31D8 File Offset: 0x000E13D8
	// (set) Token: 0x060017CE RID: 6094 RVA: 0x000E3208 File Offset: 0x000E1408
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

	// Token: 0x17000451 RID: 1105
	// (get) Token: 0x060017CF RID: 6095 RVA: 0x000E3238 File Offset: 0x000E1438
	// (set) Token: 0x060017D0 RID: 6096 RVA: 0x000E3268 File Offset: 0x000E1468
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

	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x060017D1 RID: 6097 RVA: 0x000E3298 File Offset: 0x000E1498
	// (set) Token: 0x060017D2 RID: 6098 RVA: 0x000E32C8 File Offset: 0x000E14C8
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

	// Token: 0x17000453 RID: 1107
	// (get) Token: 0x060017D3 RID: 6099 RVA: 0x000E32F8 File Offset: 0x000E14F8
	// (set) Token: 0x060017D4 RID: 6100 RVA: 0x000E3328 File Offset: 0x000E1528
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

	// Token: 0x17000454 RID: 1108
	// (get) Token: 0x060017D5 RID: 6101 RVA: 0x000E3358 File Offset: 0x000E1558
	// (set) Token: 0x060017D6 RID: 6102 RVA: 0x000E3388 File Offset: 0x000E1588
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

	// Token: 0x17000455 RID: 1109
	// (get) Token: 0x060017D7 RID: 6103 RVA: 0x000E33B8 File Offset: 0x000E15B8
	// (set) Token: 0x060017D8 RID: 6104 RVA: 0x000E33E8 File Offset: 0x000E15E8
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

	// Token: 0x17000456 RID: 1110
	// (get) Token: 0x060017D9 RID: 6105 RVA: 0x000E3418 File Offset: 0x000E1618
	// (set) Token: 0x060017DA RID: 6106 RVA: 0x000E3448 File Offset: 0x000E1648
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

	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x060017DB RID: 6107 RVA: 0x000E3478 File Offset: 0x000E1678
	// (set) Token: 0x060017DC RID: 6108 RVA: 0x000E34A8 File Offset: 0x000E16A8
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

	// Token: 0x17000458 RID: 1112
	// (get) Token: 0x060017DD RID: 6109 RVA: 0x000E34D8 File Offset: 0x000E16D8
	// (set) Token: 0x060017DE RID: 6110 RVA: 0x000E3508 File Offset: 0x000E1708
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

	// Token: 0x17000459 RID: 1113
	// (get) Token: 0x060017DF RID: 6111 RVA: 0x000E3538 File Offset: 0x000E1738
	// (set) Token: 0x060017E0 RID: 6112 RVA: 0x000E3568 File Offset: 0x000E1768
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

	// Token: 0x060017E1 RID: 6113 RVA: 0x000E3598 File Offset: 0x000E1798
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

	// Token: 0x040022C2 RID: 8898
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x040022C3 RID: 8899
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x040022C4 RID: 8900
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x040022C5 RID: 8901
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x040022C6 RID: 8902
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x040022C7 RID: 8903
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x040022C8 RID: 8904
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x040022C9 RID: 8905
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x040022CA RID: 8906
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x040022CB RID: 8907
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x040022CC RID: 8908
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x040022CD RID: 8909
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x040022CE RID: 8910
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x040022CF RID: 8911
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x040022D0 RID: 8912
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x040022D1 RID: 8913
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x040022D2 RID: 8914
	private const string Str_IgnoreRep = "IgnoreClass";
}
