using System;

// Token: 0x020002FE RID: 766
public static class TutorialGlobals
{
	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x060017AF RID: 6063 RVA: 0x000E24E0 File Offset: 0x000E06E0
	// (set) Token: 0x060017B0 RID: 6064 RVA: 0x000E2510 File Offset: 0x000E0710
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

	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x060017B1 RID: 6065 RVA: 0x000E2540 File Offset: 0x000E0740
	// (set) Token: 0x060017B2 RID: 6066 RVA: 0x000E2570 File Offset: 0x000E0770
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

	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x060017B3 RID: 6067 RVA: 0x000E25A0 File Offset: 0x000E07A0
	// (set) Token: 0x060017B4 RID: 6068 RVA: 0x000E25D0 File Offset: 0x000E07D0
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

	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x060017B5 RID: 6069 RVA: 0x000E2600 File Offset: 0x000E0800
	// (set) Token: 0x060017B6 RID: 6070 RVA: 0x000E2630 File Offset: 0x000E0830
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

	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x060017B7 RID: 6071 RVA: 0x000E2660 File Offset: 0x000E0860
	// (set) Token: 0x060017B8 RID: 6072 RVA: 0x000E2690 File Offset: 0x000E0890
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

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x060017B9 RID: 6073 RVA: 0x000E26C0 File Offset: 0x000E08C0
	// (set) Token: 0x060017BA RID: 6074 RVA: 0x000E26F0 File Offset: 0x000E08F0
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

	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x060017BB RID: 6075 RVA: 0x000E2720 File Offset: 0x000E0920
	// (set) Token: 0x060017BC RID: 6076 RVA: 0x000E2750 File Offset: 0x000E0950
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

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x060017BD RID: 6077 RVA: 0x000E2780 File Offset: 0x000E0980
	// (set) Token: 0x060017BE RID: 6078 RVA: 0x000E27B0 File Offset: 0x000E09B0
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

	// Token: 0x17000450 RID: 1104
	// (get) Token: 0x060017BF RID: 6079 RVA: 0x000E27E0 File Offset: 0x000E09E0
	// (set) Token: 0x060017C0 RID: 6080 RVA: 0x000E2810 File Offset: 0x000E0A10
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

	// Token: 0x17000451 RID: 1105
	// (get) Token: 0x060017C1 RID: 6081 RVA: 0x000E2840 File Offset: 0x000E0A40
	// (set) Token: 0x060017C2 RID: 6082 RVA: 0x000E2870 File Offset: 0x000E0A70
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

	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x060017C3 RID: 6083 RVA: 0x000E28A0 File Offset: 0x000E0AA0
	// (set) Token: 0x060017C4 RID: 6084 RVA: 0x000E28D0 File Offset: 0x000E0AD0
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

	// Token: 0x17000453 RID: 1107
	// (get) Token: 0x060017C5 RID: 6085 RVA: 0x000E2900 File Offset: 0x000E0B00
	// (set) Token: 0x060017C6 RID: 6086 RVA: 0x000E2930 File Offset: 0x000E0B30
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

	// Token: 0x17000454 RID: 1108
	// (get) Token: 0x060017C7 RID: 6087 RVA: 0x000E2960 File Offset: 0x000E0B60
	// (set) Token: 0x060017C8 RID: 6088 RVA: 0x000E2990 File Offset: 0x000E0B90
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

	// Token: 0x17000455 RID: 1109
	// (get) Token: 0x060017C9 RID: 6089 RVA: 0x000E29C0 File Offset: 0x000E0BC0
	// (set) Token: 0x060017CA RID: 6090 RVA: 0x000E29F0 File Offset: 0x000E0BF0
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

	// Token: 0x17000456 RID: 1110
	// (get) Token: 0x060017CB RID: 6091 RVA: 0x000E2A20 File Offset: 0x000E0C20
	// (set) Token: 0x060017CC RID: 6092 RVA: 0x000E2A50 File Offset: 0x000E0C50
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

	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x060017CD RID: 6093 RVA: 0x000E2A80 File Offset: 0x000E0C80
	// (set) Token: 0x060017CE RID: 6094 RVA: 0x000E2AB0 File Offset: 0x000E0CB0
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

	// Token: 0x17000458 RID: 1112
	// (get) Token: 0x060017CF RID: 6095 RVA: 0x000E2AE0 File Offset: 0x000E0CE0
	// (set) Token: 0x060017D0 RID: 6096 RVA: 0x000E2B10 File Offset: 0x000E0D10
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

	// Token: 0x060017D1 RID: 6097 RVA: 0x000E2B40 File Offset: 0x000E0D40
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

	// Token: 0x040022AD RID: 8877
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x040022AE RID: 8878
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x040022AF RID: 8879
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x040022B0 RID: 8880
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x040022B1 RID: 8881
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x040022B2 RID: 8882
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x040022B3 RID: 8883
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x040022B4 RID: 8884
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x040022B5 RID: 8885
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x040022B6 RID: 8886
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x040022B7 RID: 8887
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x040022B8 RID: 8888
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x040022B9 RID: 8889
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x040022BA RID: 8890
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x040022BB RID: 8891
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x040022BC RID: 8892
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x040022BD RID: 8893
	private const string Str_IgnoreRep = "IgnoreClass";
}
