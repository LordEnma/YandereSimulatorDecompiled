using System;

// Token: 0x020002FE RID: 766
public static class TutorialGlobals
{
	// Token: 0x17000447 RID: 1095
	// (get) Token: 0x060017AD RID: 6061 RVA: 0x000E233C File Offset: 0x000E053C
	// (set) Token: 0x060017AE RID: 6062 RVA: 0x000E236C File Offset: 0x000E056C
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
	// (get) Token: 0x060017AF RID: 6063 RVA: 0x000E239C File Offset: 0x000E059C
	// (set) Token: 0x060017B0 RID: 6064 RVA: 0x000E23CC File Offset: 0x000E05CC
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
	// (get) Token: 0x060017B1 RID: 6065 RVA: 0x000E23FC File Offset: 0x000E05FC
	// (set) Token: 0x060017B2 RID: 6066 RVA: 0x000E242C File Offset: 0x000E062C
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
	// (get) Token: 0x060017B3 RID: 6067 RVA: 0x000E245C File Offset: 0x000E065C
	// (set) Token: 0x060017B4 RID: 6068 RVA: 0x000E248C File Offset: 0x000E068C
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
	// (get) Token: 0x060017B5 RID: 6069 RVA: 0x000E24BC File Offset: 0x000E06BC
	// (set) Token: 0x060017B6 RID: 6070 RVA: 0x000E24EC File Offset: 0x000E06EC
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
	// (get) Token: 0x060017B7 RID: 6071 RVA: 0x000E251C File Offset: 0x000E071C
	// (set) Token: 0x060017B8 RID: 6072 RVA: 0x000E254C File Offset: 0x000E074C
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
	// (get) Token: 0x060017B9 RID: 6073 RVA: 0x000E257C File Offset: 0x000E077C
	// (set) Token: 0x060017BA RID: 6074 RVA: 0x000E25AC File Offset: 0x000E07AC
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
	// (get) Token: 0x060017BB RID: 6075 RVA: 0x000E25DC File Offset: 0x000E07DC
	// (set) Token: 0x060017BC RID: 6076 RVA: 0x000E260C File Offset: 0x000E080C
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
	// (get) Token: 0x060017BD RID: 6077 RVA: 0x000E263C File Offset: 0x000E083C
	// (set) Token: 0x060017BE RID: 6078 RVA: 0x000E266C File Offset: 0x000E086C
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
	// (get) Token: 0x060017BF RID: 6079 RVA: 0x000E269C File Offset: 0x000E089C
	// (set) Token: 0x060017C0 RID: 6080 RVA: 0x000E26CC File Offset: 0x000E08CC
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
	// (get) Token: 0x060017C1 RID: 6081 RVA: 0x000E26FC File Offset: 0x000E08FC
	// (set) Token: 0x060017C2 RID: 6082 RVA: 0x000E272C File Offset: 0x000E092C
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
	// (get) Token: 0x060017C3 RID: 6083 RVA: 0x000E275C File Offset: 0x000E095C
	// (set) Token: 0x060017C4 RID: 6084 RVA: 0x000E278C File Offset: 0x000E098C
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
	// (get) Token: 0x060017C5 RID: 6085 RVA: 0x000E27BC File Offset: 0x000E09BC
	// (set) Token: 0x060017C6 RID: 6086 RVA: 0x000E27EC File Offset: 0x000E09EC
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
	// (get) Token: 0x060017C7 RID: 6087 RVA: 0x000E281C File Offset: 0x000E0A1C
	// (set) Token: 0x060017C8 RID: 6088 RVA: 0x000E284C File Offset: 0x000E0A4C
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
	// (get) Token: 0x060017C9 RID: 6089 RVA: 0x000E287C File Offset: 0x000E0A7C
	// (set) Token: 0x060017CA RID: 6090 RVA: 0x000E28AC File Offset: 0x000E0AAC
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
	// (get) Token: 0x060017CB RID: 6091 RVA: 0x000E28DC File Offset: 0x000E0ADC
	// (set) Token: 0x060017CC RID: 6092 RVA: 0x000E290C File Offset: 0x000E0B0C
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
	// (get) Token: 0x060017CD RID: 6093 RVA: 0x000E293C File Offset: 0x000E0B3C
	// (set) Token: 0x060017CE RID: 6094 RVA: 0x000E296C File Offset: 0x000E0B6C
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

	// Token: 0x060017CF RID: 6095 RVA: 0x000E299C File Offset: 0x000E0B9C
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

	// Token: 0x040022A9 RID: 8873
	private const string Str_IgnoreClothing = "IgnoreClothing";

	// Token: 0x040022AA RID: 8874
	private const string Str_IgnoreCouncil = "IgnoreCouncil";

	// Token: 0x040022AB RID: 8875
	private const string Str_IgnoreTeacher = "IgnoreTeacher";

	// Token: 0x040022AC RID: 8876
	private const string Str_IgnoreLocker = "IgnoreLocker";

	// Token: 0x040022AD RID: 8877
	private const string Str_IgnorePolice = "IgnorePolice";

	// Token: 0x040022AE RID: 8878
	private const string Str_IgnoreSanity = "IgnoreSanity";

	// Token: 0x040022AF RID: 8879
	private const string Str_IgnoreSenpai = "IgnoreSenpai";

	// Token: 0x040022B0 RID: 8880
	private const string Str_IgnoreVision = "IgnoreVision";

	// Token: 0x040022B1 RID: 8881
	private const string Str_IgnoreWeapon = "IgnoreWeapon";

	// Token: 0x040022B2 RID: 8882
	private const string Str_IgnoreBlood = "IgnoreBlood";

	// Token: 0x040022B3 RID: 8883
	private const string Str_IgnoreClass = "IgnoreClass";

	// Token: 0x040022B4 RID: 8884
	private const string Str_IgnoreMoney = "IgnoreMoney";

	// Token: 0x040022B5 RID: 8885
	private const string Str_IgnorePhoto = "IgnorePhoto";

	// Token: 0x040022B6 RID: 8886
	private const string Str_IgnoreClub = "IgnoreClub";

	// Token: 0x040022B7 RID: 8887
	private const string Str_IgnoreInfo = "IgnoreInfo";

	// Token: 0x040022B8 RID: 8888
	private const string Str_IgnorePool = "IgnorePool";

	// Token: 0x040022B9 RID: 8889
	private const string Str_IgnoreRep = "IgnoreClass";
}
