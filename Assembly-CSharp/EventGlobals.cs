using System;

// Token: 0x020002EF RID: 751
public static class EventGlobals
{
	// Token: 0x1700038C RID: 908
	// (get) Token: 0x0600159B RID: 5531 RVA: 0x000D9BF4 File Offset: 0x000D7DF4
	// (set) Token: 0x0600159C RID: 5532 RVA: 0x000D9C24 File Offset: 0x000D7E24
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
	// (get) Token: 0x0600159D RID: 5533 RVA: 0x000D9C54 File Offset: 0x000D7E54
	// (set) Token: 0x0600159E RID: 5534 RVA: 0x000D9C84 File Offset: 0x000D7E84
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
	// (get) Token: 0x0600159F RID: 5535 RVA: 0x000D9CB4 File Offset: 0x000D7EB4
	// (set) Token: 0x060015A0 RID: 5536 RVA: 0x000D9CE4 File Offset: 0x000D7EE4
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
	// (get) Token: 0x060015A1 RID: 5537 RVA: 0x000D9D14 File Offset: 0x000D7F14
	// (set) Token: 0x060015A2 RID: 5538 RVA: 0x000D9D44 File Offset: 0x000D7F44
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
	// (get) Token: 0x060015A3 RID: 5539 RVA: 0x000D9D74 File Offset: 0x000D7F74
	// (set) Token: 0x060015A4 RID: 5540 RVA: 0x000D9DA4 File Offset: 0x000D7FA4
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
	// (get) Token: 0x060015A5 RID: 5541 RVA: 0x000D9DD4 File Offset: 0x000D7FD4
	// (set) Token: 0x060015A6 RID: 5542 RVA: 0x000D9E04 File Offset: 0x000D8004
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
	// (get) Token: 0x060015A7 RID: 5543 RVA: 0x000D9E34 File Offset: 0x000D8034
	// (set) Token: 0x060015A8 RID: 5544 RVA: 0x000D9E64 File Offset: 0x000D8064
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
	// (get) Token: 0x060015A9 RID: 5545 RVA: 0x000D9E94 File Offset: 0x000D8094
	// (set) Token: 0x060015AA RID: 5546 RVA: 0x000D9EC4 File Offset: 0x000D80C4
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
	// (get) Token: 0x060015AB RID: 5547 RVA: 0x000D9EF4 File Offset: 0x000D80F4
	// (set) Token: 0x060015AC RID: 5548 RVA: 0x000D9F24 File Offset: 0x000D8124
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
	// (get) Token: 0x060015AD RID: 5549 RVA: 0x000D9F54 File Offset: 0x000D8154
	// (set) Token: 0x060015AE RID: 5550 RVA: 0x000D9F84 File Offset: 0x000D8184
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

	// Token: 0x060015AF RID: 5551 RVA: 0x000D9FB4 File Offset: 0x000D81B4
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

	// Token: 0x040021B7 RID: 8631
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x040021B8 RID: 8632
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x040021B9 RID: 8633
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x040021BA RID: 8634
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x040021BB RID: 8635
	private const string Str_Event1 = "Event1";

	// Token: 0x040021BC RID: 8636
	private const string Str_Event2 = "Event2";

	// Token: 0x040021BD RID: 8637
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x040021BE RID: 8638
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x040021BF RID: 8639
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x040021C0 RID: 8640
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
