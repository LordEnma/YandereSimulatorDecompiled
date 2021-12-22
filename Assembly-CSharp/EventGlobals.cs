using System;

// Token: 0x020002EE RID: 750
public static class EventGlobals
{
	// Token: 0x1700038C RID: 908
	// (get) Token: 0x06001597 RID: 5527 RVA: 0x000D967C File Offset: 0x000D787C
	// (set) Token: 0x06001598 RID: 5528 RVA: 0x000D96AC File Offset: 0x000D78AC
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
	// (get) Token: 0x06001599 RID: 5529 RVA: 0x000D96DC File Offset: 0x000D78DC
	// (set) Token: 0x0600159A RID: 5530 RVA: 0x000D970C File Offset: 0x000D790C
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
	// (get) Token: 0x0600159B RID: 5531 RVA: 0x000D973C File Offset: 0x000D793C
	// (set) Token: 0x0600159C RID: 5532 RVA: 0x000D976C File Offset: 0x000D796C
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
	// (get) Token: 0x0600159D RID: 5533 RVA: 0x000D979C File Offset: 0x000D799C
	// (set) Token: 0x0600159E RID: 5534 RVA: 0x000D97CC File Offset: 0x000D79CC
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
	// (get) Token: 0x0600159F RID: 5535 RVA: 0x000D97FC File Offset: 0x000D79FC
	// (set) Token: 0x060015A0 RID: 5536 RVA: 0x000D982C File Offset: 0x000D7A2C
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
	// (get) Token: 0x060015A1 RID: 5537 RVA: 0x000D985C File Offset: 0x000D7A5C
	// (set) Token: 0x060015A2 RID: 5538 RVA: 0x000D988C File Offset: 0x000D7A8C
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
	// (get) Token: 0x060015A3 RID: 5539 RVA: 0x000D98BC File Offset: 0x000D7ABC
	// (set) Token: 0x060015A4 RID: 5540 RVA: 0x000D98EC File Offset: 0x000D7AEC
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
	// (get) Token: 0x060015A5 RID: 5541 RVA: 0x000D991C File Offset: 0x000D7B1C
	// (set) Token: 0x060015A6 RID: 5542 RVA: 0x000D994C File Offset: 0x000D7B4C
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
	// (get) Token: 0x060015A7 RID: 5543 RVA: 0x000D997C File Offset: 0x000D7B7C
	// (set) Token: 0x060015A8 RID: 5544 RVA: 0x000D99AC File Offset: 0x000D7BAC
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
	// (get) Token: 0x060015A9 RID: 5545 RVA: 0x000D99DC File Offset: 0x000D7BDC
	// (set) Token: 0x060015AA RID: 5546 RVA: 0x000D9A0C File Offset: 0x000D7C0C
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

	// Token: 0x060015AB RID: 5547 RVA: 0x000D9A3C File Offset: 0x000D7C3C
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

	// Token: 0x040021B0 RID: 8624
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x040021B1 RID: 8625
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x040021B2 RID: 8626
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x040021B3 RID: 8627
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x040021B4 RID: 8628
	private const string Str_Event1 = "Event1";

	// Token: 0x040021B5 RID: 8629
	private const string Str_Event2 = "Event2";

	// Token: 0x040021B6 RID: 8630
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x040021B7 RID: 8631
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x040021B8 RID: 8632
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x040021B9 RID: 8633
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
