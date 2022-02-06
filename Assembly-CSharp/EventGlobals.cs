using System;

// Token: 0x020002EF RID: 751
public static class EventGlobals
{
	// Token: 0x1700038C RID: 908
	// (get) Token: 0x0600159C RID: 5532 RVA: 0x000DA268 File Offset: 0x000D8468
	// (set) Token: 0x0600159D RID: 5533 RVA: 0x000DA298 File Offset: 0x000D8498
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
	// (get) Token: 0x0600159E RID: 5534 RVA: 0x000DA2C8 File Offset: 0x000D84C8
	// (set) Token: 0x0600159F RID: 5535 RVA: 0x000DA2F8 File Offset: 0x000D84F8
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
	// (get) Token: 0x060015A0 RID: 5536 RVA: 0x000DA328 File Offset: 0x000D8528
	// (set) Token: 0x060015A1 RID: 5537 RVA: 0x000DA358 File Offset: 0x000D8558
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
	// (get) Token: 0x060015A2 RID: 5538 RVA: 0x000DA388 File Offset: 0x000D8588
	// (set) Token: 0x060015A3 RID: 5539 RVA: 0x000DA3B8 File Offset: 0x000D85B8
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
	// (get) Token: 0x060015A4 RID: 5540 RVA: 0x000DA3E8 File Offset: 0x000D85E8
	// (set) Token: 0x060015A5 RID: 5541 RVA: 0x000DA418 File Offset: 0x000D8618
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
	// (get) Token: 0x060015A6 RID: 5542 RVA: 0x000DA448 File Offset: 0x000D8648
	// (set) Token: 0x060015A7 RID: 5543 RVA: 0x000DA478 File Offset: 0x000D8678
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
	// (get) Token: 0x060015A8 RID: 5544 RVA: 0x000DA4A8 File Offset: 0x000D86A8
	// (set) Token: 0x060015A9 RID: 5545 RVA: 0x000DA4D8 File Offset: 0x000D86D8
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
	// (get) Token: 0x060015AA RID: 5546 RVA: 0x000DA508 File Offset: 0x000D8708
	// (set) Token: 0x060015AB RID: 5547 RVA: 0x000DA538 File Offset: 0x000D8738
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
	// (get) Token: 0x060015AC RID: 5548 RVA: 0x000DA568 File Offset: 0x000D8768
	// (set) Token: 0x060015AD RID: 5549 RVA: 0x000DA598 File Offset: 0x000D8798
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
	// (get) Token: 0x060015AE RID: 5550 RVA: 0x000DA5C8 File Offset: 0x000D87C8
	// (set) Token: 0x060015AF RID: 5551 RVA: 0x000DA5F8 File Offset: 0x000D87F8
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

	// Token: 0x060015B0 RID: 5552 RVA: 0x000DA628 File Offset: 0x000D8828
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

	// Token: 0x040021C2 RID: 8642
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x040021C3 RID: 8643
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x040021C4 RID: 8644
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x040021C5 RID: 8645
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x040021C6 RID: 8646
	private const string Str_Event1 = "Event1";

	// Token: 0x040021C7 RID: 8647
	private const string Str_Event2 = "Event2";

	// Token: 0x040021C8 RID: 8648
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x040021C9 RID: 8649
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x040021CA RID: 8650
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x040021CB RID: 8651
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
