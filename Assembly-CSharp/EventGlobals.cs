using System;

// Token: 0x020002ED RID: 749
public static class EventGlobals
{
	// Token: 0x1700038C RID: 908
	// (get) Token: 0x06001590 RID: 5520 RVA: 0x000D8EBC File Offset: 0x000D70BC
	// (set) Token: 0x06001591 RID: 5521 RVA: 0x000D8EEC File Offset: 0x000D70EC
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
	// (get) Token: 0x06001592 RID: 5522 RVA: 0x000D8F1C File Offset: 0x000D711C
	// (set) Token: 0x06001593 RID: 5523 RVA: 0x000D8F4C File Offset: 0x000D714C
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
	// (get) Token: 0x06001594 RID: 5524 RVA: 0x000D8F7C File Offset: 0x000D717C
	// (set) Token: 0x06001595 RID: 5525 RVA: 0x000D8FAC File Offset: 0x000D71AC
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
	// (get) Token: 0x06001596 RID: 5526 RVA: 0x000D8FDC File Offset: 0x000D71DC
	// (set) Token: 0x06001597 RID: 5527 RVA: 0x000D900C File Offset: 0x000D720C
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
	// (get) Token: 0x06001598 RID: 5528 RVA: 0x000D903C File Offset: 0x000D723C
	// (set) Token: 0x06001599 RID: 5529 RVA: 0x000D906C File Offset: 0x000D726C
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
	// (get) Token: 0x0600159A RID: 5530 RVA: 0x000D909C File Offset: 0x000D729C
	// (set) Token: 0x0600159B RID: 5531 RVA: 0x000D90CC File Offset: 0x000D72CC
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
	// (get) Token: 0x0600159C RID: 5532 RVA: 0x000D90FC File Offset: 0x000D72FC
	// (set) Token: 0x0600159D RID: 5533 RVA: 0x000D912C File Offset: 0x000D732C
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
	// (get) Token: 0x0600159E RID: 5534 RVA: 0x000D915C File Offset: 0x000D735C
	// (set) Token: 0x0600159F RID: 5535 RVA: 0x000D918C File Offset: 0x000D738C
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
	// (get) Token: 0x060015A0 RID: 5536 RVA: 0x000D91BC File Offset: 0x000D73BC
	// (set) Token: 0x060015A1 RID: 5537 RVA: 0x000D91EC File Offset: 0x000D73EC
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
	// (get) Token: 0x060015A2 RID: 5538 RVA: 0x000D921C File Offset: 0x000D741C
	// (set) Token: 0x060015A3 RID: 5539 RVA: 0x000D924C File Offset: 0x000D744C
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

	// Token: 0x060015A4 RID: 5540 RVA: 0x000D927C File Offset: 0x000D747C
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

	// Token: 0x04002190 RID: 8592
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x04002191 RID: 8593
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x04002192 RID: 8594
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x04002193 RID: 8595
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x04002194 RID: 8596
	private const string Str_Event1 = "Event1";

	// Token: 0x04002195 RID: 8597
	private const string Str_Event2 = "Event2";

	// Token: 0x04002196 RID: 8598
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x04002197 RID: 8599
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x04002198 RID: 8600
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x04002199 RID: 8601
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
