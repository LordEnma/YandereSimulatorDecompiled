using System;

// Token: 0x020002F3 RID: 755
public static class EventGlobals
{
	// Token: 0x1700038D RID: 909
	// (get) Token: 0x060015BD RID: 5565 RVA: 0x000DBC58 File Offset: 0x000D9E58
	// (set) Token: 0x060015BE RID: 5566 RVA: 0x000DBC88 File Offset: 0x000D9E88
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
	// (get) Token: 0x060015BF RID: 5567 RVA: 0x000DBCB8 File Offset: 0x000D9EB8
	// (set) Token: 0x060015C0 RID: 5568 RVA: 0x000DBCE8 File Offset: 0x000D9EE8
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
	// (get) Token: 0x060015C1 RID: 5569 RVA: 0x000DBD18 File Offset: 0x000D9F18
	// (set) Token: 0x060015C2 RID: 5570 RVA: 0x000DBD48 File Offset: 0x000D9F48
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
	// (get) Token: 0x060015C3 RID: 5571 RVA: 0x000DBD78 File Offset: 0x000D9F78
	// (set) Token: 0x060015C4 RID: 5572 RVA: 0x000DBDA8 File Offset: 0x000D9FA8
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
	// (get) Token: 0x060015C5 RID: 5573 RVA: 0x000DBDD8 File Offset: 0x000D9FD8
	// (set) Token: 0x060015C6 RID: 5574 RVA: 0x000DBE08 File Offset: 0x000DA008
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
	// (get) Token: 0x060015C7 RID: 5575 RVA: 0x000DBE38 File Offset: 0x000DA038
	// (set) Token: 0x060015C8 RID: 5576 RVA: 0x000DBE68 File Offset: 0x000DA068
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
	// (get) Token: 0x060015C9 RID: 5577 RVA: 0x000DBE98 File Offset: 0x000DA098
	// (set) Token: 0x060015CA RID: 5578 RVA: 0x000DBEC8 File Offset: 0x000DA0C8
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
	// (get) Token: 0x060015CB RID: 5579 RVA: 0x000DBEF8 File Offset: 0x000DA0F8
	// (set) Token: 0x060015CC RID: 5580 RVA: 0x000DBF28 File Offset: 0x000DA128
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
	// (get) Token: 0x060015CD RID: 5581 RVA: 0x000DBF58 File Offset: 0x000DA158
	// (set) Token: 0x060015CE RID: 5582 RVA: 0x000DBF88 File Offset: 0x000DA188
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
	// (get) Token: 0x060015CF RID: 5583 RVA: 0x000DBFB8 File Offset: 0x000DA1B8
	// (set) Token: 0x060015D0 RID: 5584 RVA: 0x000DBFE8 File Offset: 0x000DA1E8
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

	// Token: 0x060015D1 RID: 5585 RVA: 0x000DC018 File Offset: 0x000DA218
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

	// Token: 0x0400220D RID: 8717
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x0400220E RID: 8718
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x0400220F RID: 8719
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x04002210 RID: 8720
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x04002211 RID: 8721
	private const string Str_Event1 = "Event1";

	// Token: 0x04002212 RID: 8722
	private const string Str_Event2 = "Event2";

	// Token: 0x04002213 RID: 8723
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x04002214 RID: 8724
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x04002215 RID: 8725
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x04002216 RID: 8726
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
