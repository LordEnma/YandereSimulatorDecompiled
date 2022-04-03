using System;

// Token: 0x02000301 RID: 769
public static class TutorialGlobals
{
	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x060017CA RID: 6090 RVA: 0x000E3C14 File Offset: 0x000E1E14
	// (set) Token: 0x060017CB RID: 6091 RVA: 0x000E3C44 File Offset: 0x000E1E44
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
	// (get) Token: 0x060017CC RID: 6092 RVA: 0x000E3C74 File Offset: 0x000E1E74
	// (set) Token: 0x060017CD RID: 6093 RVA: 0x000E3CA4 File Offset: 0x000E1EA4
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
	// (get) Token: 0x060017CE RID: 6094 RVA: 0x000E3CD4 File Offset: 0x000E1ED4
	// (set) Token: 0x060017CF RID: 6095 RVA: 0x000E3D04 File Offset: 0x000E1F04
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
	// (get) Token: 0x060017D0 RID: 6096 RVA: 0x000E3D34 File Offset: 0x000E1F34
	// (set) Token: 0x060017D1 RID: 6097 RVA: 0x000E3D64 File Offset: 0x000E1F64
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
	// (get) Token: 0x060017D2 RID: 6098 RVA: 0x000E3D94 File Offset: 0x000E1F94
	// (set) Token: 0x060017D3 RID: 6099 RVA: 0x000E3DC4 File Offset: 0x000E1FC4
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
	// (get) Token: 0x060017D4 RID: 6100 RVA: 0x000E3DF4 File Offset: 0x000E1FF4
	// (set) Token: 0x060017D5 RID: 6101 RVA: 0x000E3E24 File Offset: 0x000E2024
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
	// (get) Token: 0x060017D6 RID: 6102 RVA: 0x000E3E54 File Offset: 0x000E2054
	// (set) Token: 0x060017D7 RID: 6103 RVA: 0x000E3E84 File Offset: 0x000E2084
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
	// (get) Token: 0x060017D8 RID: 6104 RVA: 0x000E3EB4 File Offset: 0x000E20B4
	// (set) Token: 0x060017D9 RID: 6105 RVA: 0x000E3EE4 File Offset: 0x000E20E4
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
	// (get) Token: 0x060017DA RID: 6106 RVA: 0x000E3F14 File Offset: 0x000E2114
	// (set) Token: 0x060017DB RID: 6107 RVA: 0x000E3F44 File Offset: 0x000E2144
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
	// (get) Token: 0x060017DC RID: 6108 RVA: 0x000E3F74 File Offset: 0x000E2174
	// (set) Token: 0x060017DD RID: 6109 RVA: 0x000E3FA4 File Offset: 0x000E21A4
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
	// (get) Token: 0x060017DE RID: 6110 RVA: 0x000E3FD4 File Offset: 0x000E21D4
	// (set) Token: 0x060017DF RID: 6111 RVA: 0x000E4004 File Offset: 0x000E2204
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
	// (get) Token: 0x060017E0 RID: 6112 RVA: 0x000E4034 File Offset: 0x000E2234
	// (set) Token: 0x060017E1 RID: 6113 RVA: 0x000E4064 File Offset: 0x000E2264
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
	// (get) Token: 0x060017E2 RID: 6114 RVA: 0x000E4094 File Offset: 0x000E2294
	// (set) Token: 0x060017E3 RID: 6115 RVA: 0x000E40C4 File Offset: 0x000E22C4
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
	// (get) Token: 0x060017E4 RID: 6116 RVA: 0x000E40F4 File Offset: 0x000E22F4
	// (set) Token: 0x060017E5 RID: 6117 RVA: 0x000E4124 File Offset: 0x000E2324
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
	// (get) Token: 0x060017E6 RID: 6118 RVA: 0x000E4154 File Offset: 0x000E2354
	// (set) Token: 0x060017E7 RID: 6119 RVA: 0x000E4184 File Offset: 0x000E2384
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
	// (get) Token: 0x060017E8 RID: 6120 RVA: 0x000E41B4 File Offset: 0x000E23B4
	// (set) Token: 0x060017E9 RID: 6121 RVA: 0x000E41E4 File Offset: 0x000E23E4
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
	// (get) Token: 0x060017EA RID: 6122 RVA: 0x000E4214 File Offset: 0x000E2414
	// (set) Token: 0x060017EB RID: 6123 RVA: 0x000E4244 File Offset: 0x000E2444
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

	// Token: 0x060017EC RID: 6124 RVA: 0x000E4274 File Offset: 0x000E2474
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

	// Token: 0x040022F5 RID: 8949
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x040022F6 RID: 8950
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x040022F7 RID: 8951
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x040022F8 RID: 8952
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x040022F9 RID: 8953
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x040022FA RID: 8954
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x040022FB RID: 8955
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x040022FC RID: 8956
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x040022FD RID: 8957
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x040022FE RID: 8958
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x040022FF RID: 8959
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x04002300 RID: 8960
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x04002301 RID: 8961
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x04002302 RID: 8962
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x04002303 RID: 8963
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x04002304 RID: 8964
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x04002305 RID: 8965
	private const string Str_IgnoreRep = "IgnoreClass";
}
