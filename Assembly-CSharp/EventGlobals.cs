using System;

// Token: 0x020002F4 RID: 756
public static class EventGlobals
{
	// Token: 0x1700038D RID: 909
	// (get) Token: 0x060015C3 RID: 5571 RVA: 0x000DC574 File Offset: 0x000DA774
	// (set) Token: 0x060015C4 RID: 5572 RVA: 0x000DC5A4 File Offset: 0x000DA7A4
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
	// (get) Token: 0x060015C5 RID: 5573 RVA: 0x000DC5D4 File Offset: 0x000DA7D4
	// (set) Token: 0x060015C6 RID: 5574 RVA: 0x000DC604 File Offset: 0x000DA804
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
	// (get) Token: 0x060015C7 RID: 5575 RVA: 0x000DC634 File Offset: 0x000DA834
	// (set) Token: 0x060015C8 RID: 5576 RVA: 0x000DC664 File Offset: 0x000DA864
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
	// (get) Token: 0x060015C9 RID: 5577 RVA: 0x000DC694 File Offset: 0x000DA894
	// (set) Token: 0x060015CA RID: 5578 RVA: 0x000DC6C4 File Offset: 0x000DA8C4
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
	// (get) Token: 0x060015CB RID: 5579 RVA: 0x000DC6F4 File Offset: 0x000DA8F4
	// (set) Token: 0x060015CC RID: 5580 RVA: 0x000DC724 File Offset: 0x000DA924
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
	// (get) Token: 0x060015CD RID: 5581 RVA: 0x000DC754 File Offset: 0x000DA954
	// (set) Token: 0x060015CE RID: 5582 RVA: 0x000DC784 File Offset: 0x000DA984
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
	// (get) Token: 0x060015CF RID: 5583 RVA: 0x000DC7B4 File Offset: 0x000DA9B4
	// (set) Token: 0x060015D0 RID: 5584 RVA: 0x000DC7E4 File Offset: 0x000DA9E4
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
	// (get) Token: 0x060015D1 RID: 5585 RVA: 0x000DC814 File Offset: 0x000DAA14
	// (set) Token: 0x060015D2 RID: 5586 RVA: 0x000DC844 File Offset: 0x000DAA44
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
	// (get) Token: 0x060015D3 RID: 5587 RVA: 0x000DC874 File Offset: 0x000DAA74
	// (set) Token: 0x060015D4 RID: 5588 RVA: 0x000DC8A4 File Offset: 0x000DAAA4
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
	// (get) Token: 0x060015D5 RID: 5589 RVA: 0x000DC8D4 File Offset: 0x000DAAD4
	// (set) Token: 0x060015D6 RID: 5590 RVA: 0x000DC904 File Offset: 0x000DAB04
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

	// Token: 0x060015D7 RID: 5591 RVA: 0x000DC934 File Offset: 0x000DAB34
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

	// Token: 0x04002220 RID: 8736
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x04002221 RID: 8737
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x04002222 RID: 8738
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x04002223 RID: 8739
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x04002224 RID: 8740
	private const string Str_Event1 = "Event1";

	// Token: 0x04002225 RID: 8741
	private const string Str_Event2 = "Event2";

	// Token: 0x04002226 RID: 8742
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x04002227 RID: 8743
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x04002228 RID: 8744
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x04002229 RID: 8745
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
