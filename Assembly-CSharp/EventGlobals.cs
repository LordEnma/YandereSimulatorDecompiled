using System;

// Token: 0x020002EF RID: 751
public static class EventGlobals
{
	// Token: 0x1700038C RID: 908
	// (get) Token: 0x0600159C RID: 5532 RVA: 0x000DA1B4 File Offset: 0x000D83B4
	// (set) Token: 0x0600159D RID: 5533 RVA: 0x000DA1E4 File Offset: 0x000D83E4
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
	// (get) Token: 0x0600159E RID: 5534 RVA: 0x000DA214 File Offset: 0x000D8414
	// (set) Token: 0x0600159F RID: 5535 RVA: 0x000DA244 File Offset: 0x000D8444
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
	// (get) Token: 0x060015A0 RID: 5536 RVA: 0x000DA274 File Offset: 0x000D8474
	// (set) Token: 0x060015A1 RID: 5537 RVA: 0x000DA2A4 File Offset: 0x000D84A4
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
	// (get) Token: 0x060015A2 RID: 5538 RVA: 0x000DA2D4 File Offset: 0x000D84D4
	// (set) Token: 0x060015A3 RID: 5539 RVA: 0x000DA304 File Offset: 0x000D8504
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
	// (get) Token: 0x060015A4 RID: 5540 RVA: 0x000DA334 File Offset: 0x000D8534
	// (set) Token: 0x060015A5 RID: 5541 RVA: 0x000DA364 File Offset: 0x000D8564
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
	// (get) Token: 0x060015A6 RID: 5542 RVA: 0x000DA394 File Offset: 0x000D8594
	// (set) Token: 0x060015A7 RID: 5543 RVA: 0x000DA3C4 File Offset: 0x000D85C4
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
	// (get) Token: 0x060015A8 RID: 5544 RVA: 0x000DA3F4 File Offset: 0x000D85F4
	// (set) Token: 0x060015A9 RID: 5545 RVA: 0x000DA424 File Offset: 0x000D8624
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
	// (get) Token: 0x060015AA RID: 5546 RVA: 0x000DA454 File Offset: 0x000D8654
	// (set) Token: 0x060015AB RID: 5547 RVA: 0x000DA484 File Offset: 0x000D8684
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
	// (get) Token: 0x060015AC RID: 5548 RVA: 0x000DA4B4 File Offset: 0x000D86B4
	// (set) Token: 0x060015AD RID: 5549 RVA: 0x000DA4E4 File Offset: 0x000D86E4
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
	// (get) Token: 0x060015AE RID: 5550 RVA: 0x000DA514 File Offset: 0x000D8714
	// (set) Token: 0x060015AF RID: 5551 RVA: 0x000DA544 File Offset: 0x000D8744
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

	// Token: 0x060015B0 RID: 5552 RVA: 0x000DA574 File Offset: 0x000D8774
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

	// Token: 0x040021C0 RID: 8640
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x040021C1 RID: 8641
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x040021C2 RID: 8642
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x040021C3 RID: 8643
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x040021C4 RID: 8644
	private const string Str_Event1 = "Event1";

	// Token: 0x040021C5 RID: 8645
	private const string Str_Event2 = "Event2";

	// Token: 0x040021C6 RID: 8646
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x040021C7 RID: 8647
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x040021C8 RID: 8648
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x040021C9 RID: 8649
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
