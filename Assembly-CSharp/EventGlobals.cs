using System;

// Token: 0x020002F3 RID: 755
public static class EventGlobals
{
	// Token: 0x1700038D RID: 909
	// (get) Token: 0x060015C1 RID: 5569 RVA: 0x000DC0F4 File Offset: 0x000DA2F4
	// (set) Token: 0x060015C2 RID: 5570 RVA: 0x000DC124 File Offset: 0x000DA324
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
	// (get) Token: 0x060015C3 RID: 5571 RVA: 0x000DC154 File Offset: 0x000DA354
	// (set) Token: 0x060015C4 RID: 5572 RVA: 0x000DC184 File Offset: 0x000DA384
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
	// (get) Token: 0x060015C5 RID: 5573 RVA: 0x000DC1B4 File Offset: 0x000DA3B4
	// (set) Token: 0x060015C6 RID: 5574 RVA: 0x000DC1E4 File Offset: 0x000DA3E4
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
	// (get) Token: 0x060015C7 RID: 5575 RVA: 0x000DC214 File Offset: 0x000DA414
	// (set) Token: 0x060015C8 RID: 5576 RVA: 0x000DC244 File Offset: 0x000DA444
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
	// (get) Token: 0x060015C9 RID: 5577 RVA: 0x000DC274 File Offset: 0x000DA474
	// (set) Token: 0x060015CA RID: 5578 RVA: 0x000DC2A4 File Offset: 0x000DA4A4
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
	// (get) Token: 0x060015CB RID: 5579 RVA: 0x000DC2D4 File Offset: 0x000DA4D4
	// (set) Token: 0x060015CC RID: 5580 RVA: 0x000DC304 File Offset: 0x000DA504
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
	// (get) Token: 0x060015CD RID: 5581 RVA: 0x000DC334 File Offset: 0x000DA534
	// (set) Token: 0x060015CE RID: 5582 RVA: 0x000DC364 File Offset: 0x000DA564
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
	// (get) Token: 0x060015CF RID: 5583 RVA: 0x000DC394 File Offset: 0x000DA594
	// (set) Token: 0x060015D0 RID: 5584 RVA: 0x000DC3C4 File Offset: 0x000DA5C4
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
	// (get) Token: 0x060015D1 RID: 5585 RVA: 0x000DC3F4 File Offset: 0x000DA5F4
	// (set) Token: 0x060015D2 RID: 5586 RVA: 0x000DC424 File Offset: 0x000DA624
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
	// (get) Token: 0x060015D3 RID: 5587 RVA: 0x000DC454 File Offset: 0x000DA654
	// (set) Token: 0x060015D4 RID: 5588 RVA: 0x000DC484 File Offset: 0x000DA684
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

	// Token: 0x060015D5 RID: 5589 RVA: 0x000DC4B4 File Offset: 0x000DA6B4
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

	// Token: 0x04002216 RID: 8726
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x04002217 RID: 8727
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x04002218 RID: 8728
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x04002219 RID: 8729
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x0400221A RID: 8730
	private const string Str_Event1 = "Event1";

	// Token: 0x0400221B RID: 8731
	private const string Str_Event2 = "Event2";

	// Token: 0x0400221C RID: 8732
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x0400221D RID: 8733
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x0400221E RID: 8734
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x0400221F RID: 8735
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
