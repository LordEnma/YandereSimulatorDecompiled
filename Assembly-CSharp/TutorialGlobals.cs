using System;

// Token: 0x02000300 RID: 768
public static class TutorialGlobals
{
	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x060017BF RID: 6079 RVA: 0x000E3268 File Offset: 0x000E1468
	// (set) Token: 0x060017C0 RID: 6080 RVA: 0x000E3298 File Offset: 0x000E1498
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
	// (get) Token: 0x060017C1 RID: 6081 RVA: 0x000E32C8 File Offset: 0x000E14C8
	// (set) Token: 0x060017C2 RID: 6082 RVA: 0x000E32F8 File Offset: 0x000E14F8
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
	// (get) Token: 0x060017C3 RID: 6083 RVA: 0x000E3328 File Offset: 0x000E1528
	// (set) Token: 0x060017C4 RID: 6084 RVA: 0x000E3358 File Offset: 0x000E1558
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
	// (get) Token: 0x060017C5 RID: 6085 RVA: 0x000E3388 File Offset: 0x000E1588
	// (set) Token: 0x060017C6 RID: 6086 RVA: 0x000E33B8 File Offset: 0x000E15B8
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
	// (get) Token: 0x060017C7 RID: 6087 RVA: 0x000E33E8 File Offset: 0x000E15E8
	// (set) Token: 0x060017C8 RID: 6088 RVA: 0x000E3418 File Offset: 0x000E1618
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
	// (get) Token: 0x060017C9 RID: 6089 RVA: 0x000E3448 File Offset: 0x000E1648
	// (set) Token: 0x060017CA RID: 6090 RVA: 0x000E3478 File Offset: 0x000E1678
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
	// (get) Token: 0x060017CB RID: 6091 RVA: 0x000E34A8 File Offset: 0x000E16A8
	// (set) Token: 0x060017CC RID: 6092 RVA: 0x000E34D8 File Offset: 0x000E16D8
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
	// (get) Token: 0x060017CD RID: 6093 RVA: 0x000E3508 File Offset: 0x000E1708
	// (set) Token: 0x060017CE RID: 6094 RVA: 0x000E3538 File Offset: 0x000E1738
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
	// (get) Token: 0x060017CF RID: 6095 RVA: 0x000E3568 File Offset: 0x000E1768
	// (set) Token: 0x060017D0 RID: 6096 RVA: 0x000E3598 File Offset: 0x000E1798
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
	// (get) Token: 0x060017D1 RID: 6097 RVA: 0x000E35C8 File Offset: 0x000E17C8
	// (set) Token: 0x060017D2 RID: 6098 RVA: 0x000E35F8 File Offset: 0x000E17F8
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
	// (get) Token: 0x060017D3 RID: 6099 RVA: 0x000E3628 File Offset: 0x000E1828
	// (set) Token: 0x060017D4 RID: 6100 RVA: 0x000E3658 File Offset: 0x000E1858
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
	// (get) Token: 0x060017D5 RID: 6101 RVA: 0x000E3688 File Offset: 0x000E1888
	// (set) Token: 0x060017D6 RID: 6102 RVA: 0x000E36B8 File Offset: 0x000E18B8
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
	// (get) Token: 0x060017D7 RID: 6103 RVA: 0x000E36E8 File Offset: 0x000E18E8
	// (set) Token: 0x060017D8 RID: 6104 RVA: 0x000E3718 File Offset: 0x000E1918
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
	// (get) Token: 0x060017D9 RID: 6105 RVA: 0x000E3748 File Offset: 0x000E1948
	// (set) Token: 0x060017DA RID: 6106 RVA: 0x000E3778 File Offset: 0x000E1978
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
	// (get) Token: 0x060017DB RID: 6107 RVA: 0x000E37A8 File Offset: 0x000E19A8
	// (set) Token: 0x060017DC RID: 6108 RVA: 0x000E37D8 File Offset: 0x000E19D8
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
	// (get) Token: 0x060017DD RID: 6109 RVA: 0x000E3808 File Offset: 0x000E1A08
	// (set) Token: 0x060017DE RID: 6110 RVA: 0x000E3838 File Offset: 0x000E1A38
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
	// (get) Token: 0x060017DF RID: 6111 RVA: 0x000E3868 File Offset: 0x000E1A68
	// (set) Token: 0x060017E0 RID: 6112 RVA: 0x000E3898 File Offset: 0x000E1A98
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

	// Token: 0x060017E1 RID: 6113 RVA: 0x000E38C8 File Offset: 0x000E1AC8
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

	// Token: 0x040022D6 RID: 8918
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x040022D7 RID: 8919
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x040022D8 RID: 8920
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x040022D9 RID: 8921
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x040022DA RID: 8922
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x040022DB RID: 8923
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x040022DC RID: 8924
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x040022DD RID: 8925
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x040022DE RID: 8926
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x040022DF RID: 8927
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x040022E0 RID: 8928
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x040022E1 RID: 8929
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x040022E2 RID: 8930
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x040022E3 RID: 8931
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x040022E4 RID: 8932
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x040022E5 RID: 8933
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x040022E6 RID: 8934
	private const string Str_IgnoreRep = "IgnoreClass";
}
