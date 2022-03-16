using System;

// Token: 0x020002F1 RID: 753
public static class EventGlobals
{
	// Token: 0x1700038D RID: 909
	// (get) Token: 0x060015AF RID: 5551 RVA: 0x000DB460 File Offset: 0x000D9660
	// (set) Token: 0x060015B0 RID: 5552 RVA: 0x000DB490 File Offset: 0x000D9690
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
	// (get) Token: 0x060015B1 RID: 5553 RVA: 0x000DB4C0 File Offset: 0x000D96C0
	// (set) Token: 0x060015B2 RID: 5554 RVA: 0x000DB4F0 File Offset: 0x000D96F0
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
	// (get) Token: 0x060015B3 RID: 5555 RVA: 0x000DB520 File Offset: 0x000D9720
	// (set) Token: 0x060015B4 RID: 5556 RVA: 0x000DB550 File Offset: 0x000D9750
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
	// (get) Token: 0x060015B5 RID: 5557 RVA: 0x000DB580 File Offset: 0x000D9780
	// (set) Token: 0x060015B6 RID: 5558 RVA: 0x000DB5B0 File Offset: 0x000D97B0
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
	// (get) Token: 0x060015B7 RID: 5559 RVA: 0x000DB5E0 File Offset: 0x000D97E0
	// (set) Token: 0x060015B8 RID: 5560 RVA: 0x000DB610 File Offset: 0x000D9810
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
	// (get) Token: 0x060015B9 RID: 5561 RVA: 0x000DB640 File Offset: 0x000D9840
	// (set) Token: 0x060015BA RID: 5562 RVA: 0x000DB670 File Offset: 0x000D9870
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
	// (get) Token: 0x060015BB RID: 5563 RVA: 0x000DB6A0 File Offset: 0x000D98A0
	// (set) Token: 0x060015BC RID: 5564 RVA: 0x000DB6D0 File Offset: 0x000D98D0
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
	// (get) Token: 0x060015BD RID: 5565 RVA: 0x000DB700 File Offset: 0x000D9900
	// (set) Token: 0x060015BE RID: 5566 RVA: 0x000DB730 File Offset: 0x000D9930
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
	// (get) Token: 0x060015BF RID: 5567 RVA: 0x000DB760 File Offset: 0x000D9960
	// (set) Token: 0x060015C0 RID: 5568 RVA: 0x000DB790 File Offset: 0x000D9990
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
	// (get) Token: 0x060015C1 RID: 5569 RVA: 0x000DB7C0 File Offset: 0x000D99C0
	// (set) Token: 0x060015C2 RID: 5570 RVA: 0x000DB7F0 File Offset: 0x000D99F0
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

	// Token: 0x060015C3 RID: 5571 RVA: 0x000DB820 File Offset: 0x000D9A20
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

	// Token: 0x040021FB RID: 8699
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x040021FC RID: 8700
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x040021FD RID: 8701
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x040021FE RID: 8702
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x040021FF RID: 8703
	private const string Str_Event1 = "Event1";

	// Token: 0x04002200 RID: 8704
	private const string Str_Event2 = "Event2";

	// Token: 0x04002201 RID: 8705
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x04002202 RID: 8706
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x04002203 RID: 8707
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x04002204 RID: 8708
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
