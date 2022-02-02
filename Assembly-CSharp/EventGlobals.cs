using System;

// Token: 0x020002EF RID: 751
public static class EventGlobals
{
	// Token: 0x1700038C RID: 908
	// (get) Token: 0x0600159C RID: 5532 RVA: 0x000DA0FC File Offset: 0x000D82FC
	// (set) Token: 0x0600159D RID: 5533 RVA: 0x000DA12C File Offset: 0x000D832C
	public static bool BefriendConversation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BefriendConversation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BefriendConversation", value);
		}
	}

	// Token: 0x1700038D RID: 909
	// (get) Token: 0x0600159E RID: 5534 RVA: 0x000DA15C File Offset: 0x000D835C
	// (set) Token: 0x0600159F RID: 5535 RVA: 0x000DA18C File Offset: 0x000D838C
	public static bool StalkerConversation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StalkerConversation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StalkerConversation", value);
		}
	}

	// Token: 0x1700038E RID: 910
	// (get) Token: 0x060015A0 RID: 5536 RVA: 0x000DA1BC File Offset: 0x000D83BC
	// (set) Token: 0x060015A1 RID: 5537 RVA: 0x000DA1EC File Offset: 0x000D83EC
	public static bool KidnapConversation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_KidnapConversation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_KidnapConversation", value);
		}
	}

	// Token: 0x1700038F RID: 911
	// (get) Token: 0x060015A2 RID: 5538 RVA: 0x000DA21C File Offset: 0x000D841C
	// (set) Token: 0x060015A3 RID: 5539 RVA: 0x000DA24C File Offset: 0x000D844C
	public static bool OsanaConversation
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaConversation");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaConversation", value);
		}
	}

	// Token: 0x17000390 RID: 912
	// (get) Token: 0x060015A4 RID: 5540 RVA: 0x000DA27C File Offset: 0x000D847C
	// (set) Token: 0x060015A5 RID: 5541 RVA: 0x000DA2AC File Offset: 0x000D84AC
	public static bool OsanaEvent1
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent1");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent1", value);
		}
	}

	// Token: 0x17000391 RID: 913
	// (get) Token: 0x060015A6 RID: 5542 RVA: 0x000DA2DC File Offset: 0x000D84DC
	// (set) Token: 0x060015A7 RID: 5543 RVA: 0x000DA30C File Offset: 0x000D850C
	public static bool OsanaEvent2
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent2");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent2", value);
		}
	}

	// Token: 0x17000392 RID: 914
	// (get) Token: 0x060015A8 RID: 5544 RVA: 0x000DA33C File Offset: 0x000D853C
	// (set) Token: 0x060015A9 RID: 5545 RVA: 0x000DA36C File Offset: 0x000D856C
	public static bool Event1
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Event1");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Event1", value);
		}
	}

	// Token: 0x17000393 RID: 915
	// (get) Token: 0x060015AA RID: 5546 RVA: 0x000DA39C File Offset: 0x000D859C
	// (set) Token: 0x060015AB RID: 5547 RVA: 0x000DA3CC File Offset: 0x000D85CC
	public static bool Event2
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Event2");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Event2", value);
		}
	}

	// Token: 0x17000394 RID: 916
	// (get) Token: 0x060015AC RID: 5548 RVA: 0x000DA3FC File Offset: 0x000D85FC
	// (set) Token: 0x060015AD RID: 5549 RVA: 0x000DA42C File Offset: 0x000D862C
	public static bool LivingRoom
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_LivingRoom");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_LivingRoom", value);
		}
	}

	// Token: 0x17000395 RID: 917
	// (get) Token: 0x060015AE RID: 5550 RVA: 0x000DA45C File Offset: 0x000D865C
	// (set) Token: 0x060015AF RID: 5551 RVA: 0x000DA48C File Offset: 0x000D868C
	public static bool LearnedAboutPhotographer
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_LearnedAboutPhotographer");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_LearnedAboutPhotographer", value);
		}
	}

	// Token: 0x060015B0 RID: 5552 RVA: 0x000DA4BC File Offset: 0x000D86BC
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BefriendConversation");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StalkerConversation");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_KidnapConversation");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_OsanaConversation");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent1");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_OsanaEvent2");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Event1");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Event2");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LivingRoom");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LearnedAboutPhotographer");
	}

	// Token: 0x040021BF RID: 8639
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x040021C0 RID: 8640
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x040021C1 RID: 8641
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x040021C2 RID: 8642
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x040021C3 RID: 8643
	private const string Str_Event1 = "Event1";

	// Token: 0x040021C4 RID: 8644
	private const string Str_Event2 = "Event2";

	// Token: 0x040021C5 RID: 8645
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x040021C6 RID: 8646
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x040021C7 RID: 8647
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x040021C8 RID: 8648
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
