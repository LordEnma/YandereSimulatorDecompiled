using System;

// Token: 0x020002FF RID: 767
public static class TutorialGlobals
{
	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x060017B6 RID: 6070 RVA: 0x000E2654 File Offset: 0x000E0854
	// (set) Token: 0x060017B7 RID: 6071 RVA: 0x000E2684 File Offset: 0x000E0884
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
	// (get) Token: 0x060017B8 RID: 6072 RVA: 0x000E26B4 File Offset: 0x000E08B4
	// (set) Token: 0x060017B9 RID: 6073 RVA: 0x000E26E4 File Offset: 0x000E08E4
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
	// (get) Token: 0x060017BA RID: 6074 RVA: 0x000E2714 File Offset: 0x000E0914
	// (set) Token: 0x060017BB RID: 6075 RVA: 0x000E2744 File Offset: 0x000E0944
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
	// (get) Token: 0x060017BC RID: 6076 RVA: 0x000E2774 File Offset: 0x000E0974
	// (set) Token: 0x060017BD RID: 6077 RVA: 0x000E27A4 File Offset: 0x000E09A4
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
	// (get) Token: 0x060017BE RID: 6078 RVA: 0x000E27D4 File Offset: 0x000E09D4
	// (set) Token: 0x060017BF RID: 6079 RVA: 0x000E2804 File Offset: 0x000E0A04
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
	// (get) Token: 0x060017C0 RID: 6080 RVA: 0x000E2834 File Offset: 0x000E0A34
	// (set) Token: 0x060017C1 RID: 6081 RVA: 0x000E2864 File Offset: 0x000E0A64
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
	// (get) Token: 0x060017C2 RID: 6082 RVA: 0x000E2894 File Offset: 0x000E0A94
	// (set) Token: 0x060017C3 RID: 6083 RVA: 0x000E28C4 File Offset: 0x000E0AC4
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
	// (get) Token: 0x060017C4 RID: 6084 RVA: 0x000E28F4 File Offset: 0x000E0AF4
	// (set) Token: 0x060017C5 RID: 6085 RVA: 0x000E2924 File Offset: 0x000E0B24
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
	// (get) Token: 0x060017C6 RID: 6086 RVA: 0x000E2954 File Offset: 0x000E0B54
	// (set) Token: 0x060017C7 RID: 6087 RVA: 0x000E2984 File Offset: 0x000E0B84
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
	// (get) Token: 0x060017C8 RID: 6088 RVA: 0x000E29B4 File Offset: 0x000E0BB4
	// (set) Token: 0x060017C9 RID: 6089 RVA: 0x000E29E4 File Offset: 0x000E0BE4
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
	// (get) Token: 0x060017CA RID: 6090 RVA: 0x000E2A14 File Offset: 0x000E0C14
	// (set) Token: 0x060017CB RID: 6091 RVA: 0x000E2A44 File Offset: 0x000E0C44
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
	// (get) Token: 0x060017CC RID: 6092 RVA: 0x000E2A74 File Offset: 0x000E0C74
	// (set) Token: 0x060017CD RID: 6093 RVA: 0x000E2AA4 File Offset: 0x000E0CA4
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
	// (get) Token: 0x060017CE RID: 6094 RVA: 0x000E2AD4 File Offset: 0x000E0CD4
	// (set) Token: 0x060017CF RID: 6095 RVA: 0x000E2B04 File Offset: 0x000E0D04
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
	// (get) Token: 0x060017D0 RID: 6096 RVA: 0x000E2B34 File Offset: 0x000E0D34
	// (set) Token: 0x060017D1 RID: 6097 RVA: 0x000E2B64 File Offset: 0x000E0D64
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
	// (get) Token: 0x060017D2 RID: 6098 RVA: 0x000E2B94 File Offset: 0x000E0D94
	// (set) Token: 0x060017D3 RID: 6099 RVA: 0x000E2BC4 File Offset: 0x000E0DC4
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
	// (get) Token: 0x060017D4 RID: 6100 RVA: 0x000E2BF4 File Offset: 0x000E0DF4
	// (set) Token: 0x060017D5 RID: 6101 RVA: 0x000E2C24 File Offset: 0x000E0E24
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
	// (get) Token: 0x060017D6 RID: 6102 RVA: 0x000E2C54 File Offset: 0x000E0E54
	// (set) Token: 0x060017D7 RID: 6103 RVA: 0x000E2C84 File Offset: 0x000E0E84
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

	// Token: 0x060017D8 RID: 6104 RVA: 0x000E2CB4 File Offset: 0x000E0EB4
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

	// Token: 0x040022B3 RID: 8883
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x040022B4 RID: 8884
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x040022B5 RID: 8885
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x040022B6 RID: 8886
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x040022B7 RID: 8887
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x040022B8 RID: 8888
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x040022B9 RID: 8889
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x040022BA RID: 8890
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x040022BB RID: 8891
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x040022BC RID: 8892
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x040022BD RID: 8893
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x040022BE RID: 8894
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x040022BF RID: 8895
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x040022C0 RID: 8896
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x040022C1 RID: 8897
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x040022C2 RID: 8898
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x040022C3 RID: 8899
	private const string Str_IgnoreRep = "IgnoreClass";
}
