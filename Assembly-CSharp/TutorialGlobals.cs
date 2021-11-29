using System;

// Token: 0x020002FC RID: 764
public static class TutorialGlobals
{
	// Token: 0x17000446 RID: 1094
	// (get) Token: 0x0600179F RID: 6047 RVA: 0x000E107C File Offset: 0x000DF27C
	// (set) Token: 0x060017A0 RID: 6048 RVA: 0x000E10AC File Offset: 0x000DF2AC
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

	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x060017A1 RID: 6049 RVA: 0x000E10DC File Offset: 0x000DF2DC
	// (set) Token: 0x060017A2 RID: 6050 RVA: 0x000E110C File Offset: 0x000DF30C
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

	// Token: 0x17000448 RID: 1096
	// (get) Token: 0x060017A3 RID: 6051 RVA: 0x000E113C File Offset: 0x000DF33C
	// (set) Token: 0x060017A4 RID: 6052 RVA: 0x000E116C File Offset: 0x000DF36C
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

	// Token: 0x17000449 RID: 1097
	// (get) Token: 0x060017A5 RID: 6053 RVA: 0x000E119C File Offset: 0x000DF39C
	// (set) Token: 0x060017A6 RID: 6054 RVA: 0x000E11CC File Offset: 0x000DF3CC
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

	// Token: 0x1700044A RID: 1098
	// (get) Token: 0x060017A7 RID: 6055 RVA: 0x000E11FC File Offset: 0x000DF3FC
	// (set) Token: 0x060017A8 RID: 6056 RVA: 0x000E122C File Offset: 0x000DF42C
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

	// Token: 0x1700044B RID: 1099
	// (get) Token: 0x060017A9 RID: 6057 RVA: 0x000E125C File Offset: 0x000DF45C
	// (set) Token: 0x060017AA RID: 6058 RVA: 0x000E128C File Offset: 0x000DF48C
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

	// Token: 0x1700044C RID: 1100
	// (get) Token: 0x060017AB RID: 6059 RVA: 0x000E12BC File Offset: 0x000DF4BC
	// (set) Token: 0x060017AC RID: 6060 RVA: 0x000E12EC File Offset: 0x000DF4EC
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

	// Token: 0x1700044D RID: 1101
	// (get) Token: 0x060017AD RID: 6061 RVA: 0x000E131C File Offset: 0x000DF51C
	// (set) Token: 0x060017AE RID: 6062 RVA: 0x000E134C File Offset: 0x000DF54C
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

	// Token: 0x1700044E RID: 1102
	// (get) Token: 0x060017AF RID: 6063 RVA: 0x000E137C File Offset: 0x000DF57C
	// (set) Token: 0x060017B0 RID: 6064 RVA: 0x000E13AC File Offset: 0x000DF5AC
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

	// Token: 0x1700044F RID: 1103
	// (get) Token: 0x060017B1 RID: 6065 RVA: 0x000E13DC File Offset: 0x000DF5DC
	// (set) Token: 0x060017B2 RID: 6066 RVA: 0x000E140C File Offset: 0x000DF60C
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

	// Token: 0x17000450 RID: 1104
	// (get) Token: 0x060017B3 RID: 6067 RVA: 0x000E143C File Offset: 0x000DF63C
	// (set) Token: 0x060017B4 RID: 6068 RVA: 0x000E146C File Offset: 0x000DF66C
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

	// Token: 0x17000451 RID: 1105
	// (get) Token: 0x060017B5 RID: 6069 RVA: 0x000E149C File Offset: 0x000DF69C
	// (set) Token: 0x060017B6 RID: 6070 RVA: 0x000E14CC File Offset: 0x000DF6CC
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

	// Token: 0x17000452 RID: 1106
	// (get) Token: 0x060017B7 RID: 6071 RVA: 0x000E14FC File Offset: 0x000DF6FC
	// (set) Token: 0x060017B8 RID: 6072 RVA: 0x000E152C File Offset: 0x000DF72C
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

	// Token: 0x17000453 RID: 1107
	// (get) Token: 0x060017B9 RID: 6073 RVA: 0x000E155C File Offset: 0x000DF75C
	// (set) Token: 0x060017BA RID: 6074 RVA: 0x000E158C File Offset: 0x000DF78C
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

	// Token: 0x17000454 RID: 1108
	// (get) Token: 0x060017BB RID: 6075 RVA: 0x000E15BC File Offset: 0x000DF7BC
	// (set) Token: 0x060017BC RID: 6076 RVA: 0x000E15EC File Offset: 0x000DF7EC
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

	// Token: 0x17000455 RID: 1109
	// (get) Token: 0x060017BD RID: 6077 RVA: 0x000E161C File Offset: 0x000DF81C
	// (set) Token: 0x060017BE RID: 6078 RVA: 0x000E164C File Offset: 0x000DF84C
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

	// Token: 0x17000456 RID: 1110
	// (get) Token: 0x060017BF RID: 6079 RVA: 0x000E167C File Offset: 0x000DF87C
	// (set) Token: 0x060017C0 RID: 6080 RVA: 0x000E16AC File Offset: 0x000DF8AC
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

	// Token: 0x060017C1 RID: 6081 RVA: 0x000E16DC File Offset: 0x000DF8DC
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

	// Token: 0x04002279 RID: 8825
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x0400227A RID: 8826
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x0400227B RID: 8827
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x0400227C RID: 8828
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x0400227D RID: 8829
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x0400227E RID: 8830
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x0400227F RID: 8831
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x04002280 RID: 8832
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x04002281 RID: 8833
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x04002282 RID: 8834
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x04002283 RID: 8835
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x04002284 RID: 8836
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x04002285 RID: 8837
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x04002286 RID: 8838
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x04002287 RID: 8839
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x04002288 RID: 8840
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x04002289 RID: 8841
	private const string Str_IgnoreRep = "IgnoreClass";
}
