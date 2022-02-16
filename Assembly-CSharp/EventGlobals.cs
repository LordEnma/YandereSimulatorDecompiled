using System;

// Token: 0x020002F0 RID: 752
public static class EventGlobals
{
	// Token: 0x1700038D RID: 909
	// (get) Token: 0x060015A3 RID: 5539 RVA: 0x000DA3DC File Offset: 0x000D85DC
	// (set) Token: 0x060015A4 RID: 5540 RVA: 0x000DA40C File Offset: 0x000D860C
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
	// (get) Token: 0x060015A5 RID: 5541 RVA: 0x000DA43C File Offset: 0x000D863C
	// (set) Token: 0x060015A6 RID: 5542 RVA: 0x000DA46C File Offset: 0x000D866C
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
	// (get) Token: 0x060015A7 RID: 5543 RVA: 0x000DA49C File Offset: 0x000D869C
	// (set) Token: 0x060015A8 RID: 5544 RVA: 0x000DA4CC File Offset: 0x000D86CC
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
	// (get) Token: 0x060015A9 RID: 5545 RVA: 0x000DA4FC File Offset: 0x000D86FC
	// (set) Token: 0x060015AA RID: 5546 RVA: 0x000DA52C File Offset: 0x000D872C
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
	// (get) Token: 0x060015AB RID: 5547 RVA: 0x000DA55C File Offset: 0x000D875C
	// (set) Token: 0x060015AC RID: 5548 RVA: 0x000DA58C File Offset: 0x000D878C
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
	// (get) Token: 0x060015AD RID: 5549 RVA: 0x000DA5BC File Offset: 0x000D87BC
	// (set) Token: 0x060015AE RID: 5550 RVA: 0x000DA5EC File Offset: 0x000D87EC
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
	// (get) Token: 0x060015AF RID: 5551 RVA: 0x000DA61C File Offset: 0x000D881C
	// (set) Token: 0x060015B0 RID: 5552 RVA: 0x000DA64C File Offset: 0x000D884C
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
	// (get) Token: 0x060015B1 RID: 5553 RVA: 0x000DA67C File Offset: 0x000D887C
	// (set) Token: 0x060015B2 RID: 5554 RVA: 0x000DA6AC File Offset: 0x000D88AC
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
	// (get) Token: 0x060015B3 RID: 5555 RVA: 0x000DA6DC File Offset: 0x000D88DC
	// (set) Token: 0x060015B4 RID: 5556 RVA: 0x000DA70C File Offset: 0x000D890C
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
	// (get) Token: 0x060015B5 RID: 5557 RVA: 0x000DA73C File Offset: 0x000D893C
	// (set) Token: 0x060015B6 RID: 5558 RVA: 0x000DA76C File Offset: 0x000D896C
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

	// Token: 0x060015B7 RID: 5559 RVA: 0x000DA79C File Offset: 0x000D899C
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

	// Token: 0x040021C8 RID: 8648
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x040021C9 RID: 8649
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x040021CA RID: 8650
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x040021CB RID: 8651
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x040021CC RID: 8652
	private const string Str_Event1 = "Event1";

	// Token: 0x040021CD RID: 8653
	private const string Str_Event2 = "Event2";

	// Token: 0x040021CE RID: 8654
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x040021CF RID: 8655
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x040021D0 RID: 8656
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x040021D1 RID: 8657
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
