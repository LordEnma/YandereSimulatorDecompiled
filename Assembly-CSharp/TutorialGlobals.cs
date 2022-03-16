using System;

// Token: 0x02000300 RID: 768
public static class TutorialGlobals
{
	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x060017C4 RID: 6084 RVA: 0x000E3714 File Offset: 0x000E1914
	// (set) Token: 0x060017C5 RID: 6085 RVA: 0x000E3744 File Offset: 0x000E1944
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

	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x060017C6 RID: 6086 RVA: 0x000E3774 File Offset: 0x000E1974
	// (set) Token: 0x060017C7 RID: 6087 RVA: 0x000E37A4 File Offset: 0x000E19A4
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

	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x060017C8 RID: 6088 RVA: 0x000E37D4 File Offset: 0x000E19D4
	// (set) Token: 0x060017C9 RID: 6089 RVA: 0x000E3804 File Offset: 0x000E1A04
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

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x060017CA RID: 6090 RVA: 0x000E3834 File Offset: 0x000E1A34
	// (set) Token: 0x060017CB RID: 6091 RVA: 0x000E3864 File Offset: 0x000E1A64
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

	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x060017CC RID: 6092 RVA: 0x000E3894 File Offset: 0x000E1A94
	// (set) Token: 0x060017CD RID: 6093 RVA: 0x000E38C4 File Offset: 0x000E1AC4
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

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x060017CE RID: 6094 RVA: 0x000E38F4 File Offset: 0x000E1AF4
	// (set) Token: 0x060017CF RID: 6095 RVA: 0x000E3924 File Offset: 0x000E1B24
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

	// Token: 0x17000450 RID: 1104
	// (get) Token: 0x060017D0 RID: 6096 RVA: 0x000E3954 File Offset: 0x000E1B54
	// (set) Token: 0x060017D1 RID: 6097 RVA: 0x000E3984 File Offset: 0x000E1B84
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

	// Token: 0x17000451 RID: 1105
	// (get) Token: 0x060017D2 RID: 6098 RVA: 0x000E39B4 File Offset: 0x000E1BB4
	// (set) Token: 0x060017D3 RID: 6099 RVA: 0x000E39E4 File Offset: 0x000E1BE4
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

	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x060017D4 RID: 6100 RVA: 0x000E3A14 File Offset: 0x000E1C14
	// (set) Token: 0x060017D5 RID: 6101 RVA: 0x000E3A44 File Offset: 0x000E1C44
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

	// Token: 0x17000453 RID: 1107
	// (get) Token: 0x060017D6 RID: 6102 RVA: 0x000E3A74 File Offset: 0x000E1C74
	// (set) Token: 0x060017D7 RID: 6103 RVA: 0x000E3AA4 File Offset: 0x000E1CA4
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

	// Token: 0x17000454 RID: 1108
	// (get) Token: 0x060017D8 RID: 6104 RVA: 0x000E3AD4 File Offset: 0x000E1CD4
	// (set) Token: 0x060017D9 RID: 6105 RVA: 0x000E3B04 File Offset: 0x000E1D04
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

	// Token: 0x17000455 RID: 1109
	// (get) Token: 0x060017DA RID: 6106 RVA: 0x000E3B34 File Offset: 0x000E1D34
	// (set) Token: 0x060017DB RID: 6107 RVA: 0x000E3B64 File Offset: 0x000E1D64
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

	// Token: 0x17000456 RID: 1110
	// (get) Token: 0x060017DC RID: 6108 RVA: 0x000E3B94 File Offset: 0x000E1D94
	// (set) Token: 0x060017DD RID: 6109 RVA: 0x000E3BC4 File Offset: 0x000E1DC4
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

	// Token: 0x17000457 RID: 1111
	// (get) Token: 0x060017DE RID: 6110 RVA: 0x000E3BF4 File Offset: 0x000E1DF4
	// (set) Token: 0x060017DF RID: 6111 RVA: 0x000E3C24 File Offset: 0x000E1E24
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

	// Token: 0x17000458 RID: 1112
	// (get) Token: 0x060017E0 RID: 6112 RVA: 0x000E3C54 File Offset: 0x000E1E54
	// (set) Token: 0x060017E1 RID: 6113 RVA: 0x000E3C84 File Offset: 0x000E1E84
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

	// Token: 0x17000459 RID: 1113
	// (get) Token: 0x060017E2 RID: 6114 RVA: 0x000E3CB4 File Offset: 0x000E1EB4
	// (set) Token: 0x060017E3 RID: 6115 RVA: 0x000E3CE4 File Offset: 0x000E1EE4
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

	// Token: 0x1700045A RID: 1114
	// (get) Token: 0x060017E4 RID: 6116 RVA: 0x000E3D14 File Offset: 0x000E1F14
	// (set) Token: 0x060017E5 RID: 6117 RVA: 0x000E3D44 File Offset: 0x000E1F44
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

	// Token: 0x060017E6 RID: 6118 RVA: 0x000E3D74 File Offset: 0x000E1F74
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

	// Token: 0x040022E7 RID: 8935
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x040022E8 RID: 8936
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x040022E9 RID: 8937
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x040022EA RID: 8938
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x040022EB RID: 8939
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x040022EC RID: 8940
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x040022ED RID: 8941
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x040022EE RID: 8942
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x040022EF RID: 8943
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x040022F0 RID: 8944
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x040022F1 RID: 8945
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x040022F2 RID: 8946
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x040022F3 RID: 8947
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x040022F4 RID: 8948
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x040022F5 RID: 8949
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x040022F6 RID: 8950
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x040022F7 RID: 8951
	private const string Str_IgnoreRep = "IgnoreClass";
}
