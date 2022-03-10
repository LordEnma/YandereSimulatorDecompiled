using System;

// Token: 0x020002F1 RID: 753
public static class EventGlobals
{
	// Token: 0x1700038D RID: 909
	// (get) Token: 0x060015AC RID: 5548 RVA: 0x000DAFF0 File Offset: 0x000D91F0
	// (set) Token: 0x060015AD RID: 5549 RVA: 0x000DB020 File Offset: 0x000D9220
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

	// Token: 0x1700038E RID: 910
	// (get) Token: 0x060015AE RID: 5550 RVA: 0x000DB050 File Offset: 0x000D9250
	// (set) Token: 0x060015AF RID: 5551 RVA: 0x000DB080 File Offset: 0x000D9280
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

	// Token: 0x1700038F RID: 911
	// (get) Token: 0x060015B0 RID: 5552 RVA: 0x000DB0B0 File Offset: 0x000D92B0
	// (set) Token: 0x060015B1 RID: 5553 RVA: 0x000DB0E0 File Offset: 0x000D92E0
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

	// Token: 0x17000390 RID: 912
	// (get) Token: 0x060015B2 RID: 5554 RVA: 0x000DB110 File Offset: 0x000D9310
	// (set) Token: 0x060015B3 RID: 5555 RVA: 0x000DB140 File Offset: 0x000D9340
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

	// Token: 0x17000391 RID: 913
	// (get) Token: 0x060015B4 RID: 5556 RVA: 0x000DB170 File Offset: 0x000D9370
	// (set) Token: 0x060015B5 RID: 5557 RVA: 0x000DB1A0 File Offset: 0x000D93A0
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

	// Token: 0x17000392 RID: 914
	// (get) Token: 0x060015B6 RID: 5558 RVA: 0x000DB1D0 File Offset: 0x000D93D0
	// (set) Token: 0x060015B7 RID: 5559 RVA: 0x000DB200 File Offset: 0x000D9400
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

	// Token: 0x17000393 RID: 915
	// (get) Token: 0x060015B8 RID: 5560 RVA: 0x000DB230 File Offset: 0x000D9430
	// (set) Token: 0x060015B9 RID: 5561 RVA: 0x000DB260 File Offset: 0x000D9460
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

	// Token: 0x17000394 RID: 916
	// (get) Token: 0x060015BA RID: 5562 RVA: 0x000DB290 File Offset: 0x000D9490
	// (set) Token: 0x060015BB RID: 5563 RVA: 0x000DB2C0 File Offset: 0x000D94C0
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

	// Token: 0x17000395 RID: 917
	// (get) Token: 0x060015BC RID: 5564 RVA: 0x000DB2F0 File Offset: 0x000D94F0
	// (set) Token: 0x060015BD RID: 5565 RVA: 0x000DB320 File Offset: 0x000D9520
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

	// Token: 0x17000396 RID: 918
	// (get) Token: 0x060015BE RID: 5566 RVA: 0x000DB350 File Offset: 0x000D9550
	// (set) Token: 0x060015BF RID: 5567 RVA: 0x000DB380 File Offset: 0x000D9580
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

	// Token: 0x060015C0 RID: 5568 RVA: 0x000DB3B0 File Offset: 0x000D95B0
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

	// Token: 0x040021EB RID: 8683
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x040021EC RID: 8684
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x040021ED RID: 8685
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x040021EE RID: 8686
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x040021EF RID: 8687
	private const string Str_Event1 = "Event1";

	// Token: 0x040021F0 RID: 8688
	private const string Str_Event2 = "Event2";

	// Token: 0x040021F1 RID: 8689
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x040021F2 RID: 8690
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x040021F3 RID: 8691
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x040021F4 RID: 8692
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
