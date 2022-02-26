using System;
using UnityEngine;

// Token: 0x020002EF RID: 751
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06001587 RID: 5511 RVA: 0x000DA308 File Offset: 0x000D8508
	// (set) Token: 0x06001588 RID: 5512 RVA: 0x000DA338 File Offset: 0x000D8538
	public static int Week
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Week", value);
		}
	}

	// Token: 0x17000384 RID: 900
	// (get) Token: 0x06001589 RID: 5513 RVA: 0x000DA368 File Offset: 0x000D8568
	// (set) Token: 0x0600158A RID: 5514 RVA: 0x000DA398 File Offset: 0x000D8598
	public static DayOfWeek Weekday
	{
		get
		{
			return GlobalsHelper.GetEnum<DayOfWeek>("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		}
		set
		{
			GlobalsHelper.SetEnum<DayOfWeek>("Profile_" + GameGlobals.Profile.ToString() + "_Weekday", value);
		}
	}

	// Token: 0x17000385 RID: 901
	// (get) Token: 0x0600158B RID: 5515 RVA: 0x000DA3C8 File Offset: 0x000D85C8
	// (set) Token: 0x0600158C RID: 5516 RVA: 0x000DA3F8 File Offset: 0x000D85F8
	public static int PassDays
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PassDays", value);
		}
	}

	// Token: 0x17000386 RID: 902
	// (get) Token: 0x0600158D RID: 5517 RVA: 0x000DA428 File Offset: 0x000D8628
	// (set) Token: 0x0600158E RID: 5518 RVA: 0x000DA458 File Offset: 0x000D8658
	public static bool DayPassed
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed", value);
		}
	}

	// Token: 0x17000387 RID: 903
	// (get) Token: 0x0600158F RID: 5519 RVA: 0x000DA488 File Offset: 0x000D8688
	// (set) Token: 0x06001590 RID: 5520 RVA: 0x000DA4B8 File Offset: 0x000D86B8
	public static int GameplayDay
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay", value);
		}
	}

	// Token: 0x17000388 RID: 904
	// (get) Token: 0x06001591 RID: 5521 RVA: 0x000DA4E8 File Offset: 0x000D86E8
	// (set) Token: 0x06001592 RID: 5522 RVA: 0x000DA518 File Offset: 0x000D8718
	public static bool ForceSkip
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip", value);
		}
	}

	// Token: 0x06001593 RID: 5523 RVA: 0x000DA548 File Offset: 0x000D8748
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
	}

	// Token: 0x040021C8 RID: 8648
	private const string Str_Week = "Week";

	// Token: 0x040021C9 RID: 8649
	private const string Str_Weekday = "Weekday";

	// Token: 0x040021CA RID: 8650
	private const string Str_PassDays = "PassDays";

	// Token: 0x040021CB RID: 8651
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x040021CC RID: 8652
	private const string Str_GameplayDay = "GameplayDay";

	// Token: 0x040021CD RID: 8653
	private const string Str_ForceSkip = "ForceSkip";
}
