using System;

// Token: 0x020002F2 RID: 754
public static class EventGlobals
{
	// Token: 0x1700038D RID: 909
	// (get) Token: 0x060015B5 RID: 5557 RVA: 0x000DB960 File Offset: 0x000D9B60
	// (set) Token: 0x060015B6 RID: 5558 RVA: 0x000DB990 File Offset: 0x000D9B90
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
	// (get) Token: 0x060015B7 RID: 5559 RVA: 0x000DB9C0 File Offset: 0x000D9BC0
	// (set) Token: 0x060015B8 RID: 5560 RVA: 0x000DB9F0 File Offset: 0x000D9BF0
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
	// (get) Token: 0x060015B9 RID: 5561 RVA: 0x000DBA20 File Offset: 0x000D9C20
	// (set) Token: 0x060015BA RID: 5562 RVA: 0x000DBA50 File Offset: 0x000D9C50
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
	// (get) Token: 0x060015BB RID: 5563 RVA: 0x000DBA80 File Offset: 0x000D9C80
	// (set) Token: 0x060015BC RID: 5564 RVA: 0x000DBAB0 File Offset: 0x000D9CB0
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
	// (get) Token: 0x060015BD RID: 5565 RVA: 0x000DBAE0 File Offset: 0x000D9CE0
	// (set) Token: 0x060015BE RID: 5566 RVA: 0x000DBB10 File Offset: 0x000D9D10
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
	// (get) Token: 0x060015BF RID: 5567 RVA: 0x000DBB40 File Offset: 0x000D9D40
	// (set) Token: 0x060015C0 RID: 5568 RVA: 0x000DBB70 File Offset: 0x000D9D70
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
	// (get) Token: 0x060015C1 RID: 5569 RVA: 0x000DBBA0 File Offset: 0x000D9DA0
	// (set) Token: 0x060015C2 RID: 5570 RVA: 0x000DBBD0 File Offset: 0x000D9DD0
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
	// (get) Token: 0x060015C3 RID: 5571 RVA: 0x000DBC00 File Offset: 0x000D9E00
	// (set) Token: 0x060015C4 RID: 5572 RVA: 0x000DBC30 File Offset: 0x000D9E30
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
	// (get) Token: 0x060015C5 RID: 5573 RVA: 0x000DBC60 File Offset: 0x000D9E60
	// (set) Token: 0x060015C6 RID: 5574 RVA: 0x000DBC90 File Offset: 0x000D9E90
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
	// (get) Token: 0x060015C7 RID: 5575 RVA: 0x000DBCC0 File Offset: 0x000D9EC0
	// (set) Token: 0x060015C8 RID: 5576 RVA: 0x000DBCF0 File Offset: 0x000D9EF0
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

	// Token: 0x060015C9 RID: 5577 RVA: 0x000DBD20 File Offset: 0x000D9F20
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

	// Token: 0x04002209 RID: 8713
	private const string Str_BefriendConversation = "BefriendConversation";

	// Token: 0x0400220A RID: 8714
	private const string Str_StalkerConversation = "StalkerConversation";

	// Token: 0x0400220B RID: 8715
	private const string Str_KidnapConversation = "KidnapConversation";

	// Token: 0x0400220C RID: 8716
	private const string Str_OsanaConversation = "OsanaConversation";

	// Token: 0x0400220D RID: 8717
	private const string Str_Event1 = "Event1";

	// Token: 0x0400220E RID: 8718
	private const string Str_Event2 = "Event2";

	// Token: 0x0400220F RID: 8719
	private const string Str_OsanaEvent1 = "OsanaEvent1";

	// Token: 0x04002210 RID: 8720
	private const string Str_OsanaEvent2 = "OsanaEvent2";

	// Token: 0x04002211 RID: 8721
	private const string Str_LivingRoom = "LivingRoom";

	// Token: 0x04002212 RID: 8722
	private const string Str_LearnedAboutPhotographer = "LearnedAboutPhotographer";
}
