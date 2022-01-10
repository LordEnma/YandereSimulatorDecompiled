using System;

// Token: 0x020002FE RID: 766
public static class TutorialGlobals
{
	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x060017AC RID: 6060 RVA: 0x000E1E34 File Offset: 0x000E0034
	// (set) Token: 0x060017AD RID: 6061 RVA: 0x000E1E64 File Offset: 0x000E0064
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

	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x060017AE RID: 6062 RVA: 0x000E1E94 File Offset: 0x000E0094
	// (set) Token: 0x060017AF RID: 6063 RVA: 0x000E1EC4 File Offset: 0x000E00C4
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

	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x060017B0 RID: 6064 RVA: 0x000E1EF4 File Offset: 0x000E00F4
	// (set) Token: 0x060017B1 RID: 6065 RVA: 0x000E1F24 File Offset: 0x000E0124
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

	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x060017B2 RID: 6066 RVA: 0x000E1F54 File Offset: 0x000E0154
	// (set) Token: 0x060017B3 RID: 6067 RVA: 0x000E1F84 File Offset: 0x000E0184
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

	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x060017B4 RID: 6068 RVA: 0x000E1FB4 File Offset: 0x000E01B4
	// (set) Token: 0x060017B5 RID: 6069 RVA: 0x000E1FE4 File Offset: 0x000E01E4
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

	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x060017B6 RID: 6070 RVA: 0x000E2014 File Offset: 0x000E0214
	// (set) Token: 0x060017B7 RID: 6071 RVA: 0x000E2044 File Offset: 0x000E0244
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

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x060017B8 RID: 6072 RVA: 0x000E2074 File Offset: 0x000E0274
	// (set) Token: 0x060017B9 RID: 6073 RVA: 0x000E20A4 File Offset: 0x000E02A4
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

	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x060017BA RID: 6074 RVA: 0x000E20D4 File Offset: 0x000E02D4
	// (set) Token: 0x060017BB RID: 6075 RVA: 0x000E2104 File Offset: 0x000E0304
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

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x060017BC RID: 6076 RVA: 0x000E2134 File Offset: 0x000E0334
	// (set) Token: 0x060017BD RID: 6077 RVA: 0x000E2164 File Offset: 0x000E0364
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

	// Token: 0x17000450 RID: 1104
	// (get) Token: 0x060017BE RID: 6078 RVA: 0x000E2194 File Offset: 0x000E0394
	// (set) Token: 0x060017BF RID: 6079 RVA: 0x000E21C4 File Offset: 0x000E03C4
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

	// Token: 0x17000451 RID: 1105
	// (get) Token: 0x060017C0 RID: 6080 RVA: 0x000E21F4 File Offset: 0x000E03F4
	// (set) Token: 0x060017C1 RID: 6081 RVA: 0x000E2224 File Offset: 0x000E0424
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

	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x060017C2 RID: 6082 RVA: 0x000E2254 File Offset: 0x000E0454
	// (set) Token: 0x060017C3 RID: 6083 RVA: 0x000E2284 File Offset: 0x000E0484
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

	// Token: 0x17000453 RID: 1107
	// (get) Token: 0x060017C4 RID: 6084 RVA: 0x000E22B4 File Offset: 0x000E04B4
	// (set) Token: 0x060017C5 RID: 6085 RVA: 0x000E22E4 File Offset: 0x000E04E4
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

	// Token: 0x17000454 RID: 1108
	// (get) Token: 0x060017C6 RID: 6086 RVA: 0x000E2314 File Offset: 0x000E0514
	// (set) Token: 0x060017C7 RID: 6087 RVA: 0x000E2344 File Offset: 0x000E0544
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

	// Token: 0x17000455 RID: 1109
	// (get) Token: 0x060017C8 RID: 6088 RVA: 0x000E2374 File Offset: 0x000E0574
	// (set) Token: 0x060017C9 RID: 6089 RVA: 0x000E23A4 File Offset: 0x000E05A4
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

	// Token: 0x17000456 RID: 1110
	// (get) Token: 0x060017CA RID: 6090 RVA: 0x000E23D4 File Offset: 0x000E05D4
	// (set) Token: 0x060017CB RID: 6091 RVA: 0x000E2404 File Offset: 0x000E0604
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

	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x060017CC RID: 6092 RVA: 0x000E2434 File Offset: 0x000E0634
	// (set) Token: 0x060017CD RID: 6093 RVA: 0x000E2464 File Offset: 0x000E0664
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

	// Token: 0x060017CE RID: 6094 RVA: 0x000E2494 File Offset: 0x000E0694
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

	// Token: 0x040022A1 RID: 8865
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x040022A2 RID: 8866
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x040022A3 RID: 8867
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x040022A4 RID: 8868
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x040022A5 RID: 8869
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x040022A6 RID: 8870
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x040022A7 RID: 8871
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x040022A8 RID: 8872
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x040022A9 RID: 8873
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x040022AA RID: 8874
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x040022AB RID: 8875
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x040022AC RID: 8876
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x040022AD RID: 8877
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x040022AE RID: 8878
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x040022AF RID: 8879
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x040022B0 RID: 8880
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x040022B1 RID: 8881
	private const string Str_IgnoreRep = "IgnoreClass";
}
