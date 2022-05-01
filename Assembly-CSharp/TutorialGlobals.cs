using System;

// Token: 0x02000302 RID: 770
public static class TutorialGlobals
{
	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x060017D8 RID: 6104 RVA: 0x000E445C File Offset: 0x000E265C
	// (set) Token: 0x060017D9 RID: 6105 RVA: 0x000E448C File Offset: 0x000E268C
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
	// (get) Token: 0x060017DA RID: 6106 RVA: 0x000E44BC File Offset: 0x000E26BC
	// (set) Token: 0x060017DB RID: 6107 RVA: 0x000E44EC File Offset: 0x000E26EC
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
	// (get) Token: 0x060017DC RID: 6108 RVA: 0x000E451C File Offset: 0x000E271C
	// (set) Token: 0x060017DD RID: 6109 RVA: 0x000E454C File Offset: 0x000E274C
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
	// (get) Token: 0x060017DE RID: 6110 RVA: 0x000E457C File Offset: 0x000E277C
	// (set) Token: 0x060017DF RID: 6111 RVA: 0x000E45AC File Offset: 0x000E27AC
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
	// (get) Token: 0x060017E0 RID: 6112 RVA: 0x000E45DC File Offset: 0x000E27DC
	// (set) Token: 0x060017E1 RID: 6113 RVA: 0x000E460C File Offset: 0x000E280C
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
	// (get) Token: 0x060017E2 RID: 6114 RVA: 0x000E463C File Offset: 0x000E283C
	// (set) Token: 0x060017E3 RID: 6115 RVA: 0x000E466C File Offset: 0x000E286C
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
	// (get) Token: 0x060017E4 RID: 6116 RVA: 0x000E469C File Offset: 0x000E289C
	// (set) Token: 0x060017E5 RID: 6117 RVA: 0x000E46CC File Offset: 0x000E28CC
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
	// (get) Token: 0x060017E6 RID: 6118 RVA: 0x000E46FC File Offset: 0x000E28FC
	// (set) Token: 0x060017E7 RID: 6119 RVA: 0x000E472C File Offset: 0x000E292C
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
	// (get) Token: 0x060017E8 RID: 6120 RVA: 0x000E475C File Offset: 0x000E295C
	// (set) Token: 0x060017E9 RID: 6121 RVA: 0x000E478C File Offset: 0x000E298C
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
	// (get) Token: 0x060017EA RID: 6122 RVA: 0x000E47BC File Offset: 0x000E29BC
	// (set) Token: 0x060017EB RID: 6123 RVA: 0x000E47EC File Offset: 0x000E29EC
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
	// (get) Token: 0x060017EC RID: 6124 RVA: 0x000E481C File Offset: 0x000E2A1C
	// (set) Token: 0x060017ED RID: 6125 RVA: 0x000E484C File Offset: 0x000E2A4C
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
	// (get) Token: 0x060017EE RID: 6126 RVA: 0x000E487C File Offset: 0x000E2A7C
	// (set) Token: 0x060017EF RID: 6127 RVA: 0x000E48AC File Offset: 0x000E2AAC
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
	// (get) Token: 0x060017F0 RID: 6128 RVA: 0x000E48DC File Offset: 0x000E2ADC
	// (set) Token: 0x060017F1 RID: 6129 RVA: 0x000E490C File Offset: 0x000E2B0C
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
	// (get) Token: 0x060017F2 RID: 6130 RVA: 0x000E493C File Offset: 0x000E2B3C
	// (set) Token: 0x060017F3 RID: 6131 RVA: 0x000E496C File Offset: 0x000E2B6C
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
	// (get) Token: 0x060017F4 RID: 6132 RVA: 0x000E499C File Offset: 0x000E2B9C
	// (set) Token: 0x060017F5 RID: 6133 RVA: 0x000E49CC File Offset: 0x000E2BCC
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
	// (get) Token: 0x060017F6 RID: 6134 RVA: 0x000E49FC File Offset: 0x000E2BFC
	// (set) Token: 0x060017F7 RID: 6135 RVA: 0x000E4A2C File Offset: 0x000E2C2C
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
	// (get) Token: 0x060017F8 RID: 6136 RVA: 0x000E4A5C File Offset: 0x000E2C5C
	// (set) Token: 0x060017F9 RID: 6137 RVA: 0x000E4A8C File Offset: 0x000E2C8C
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

	// Token: 0x060017FA RID: 6138 RVA: 0x000E4ABC File Offset: 0x000E2CBC
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
