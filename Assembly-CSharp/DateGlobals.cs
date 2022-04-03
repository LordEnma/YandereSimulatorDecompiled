using System;
using UnityEngine;

// Token: 0x020002F0 RID: 752
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06001590 RID: 5520 RVA: 0x000DAFA8 File Offset: 0x000D91A8
	// (set) Token: 0x06001591 RID: 5521 RVA: 0x000DAFD8 File Offset: 0x000D91D8
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
	// (get) Token: 0x06001592 RID: 5522 RVA: 0x000DB008 File Offset: 0x000D9208
	// (set) Token: 0x06001593 RID: 5523 RVA: 0x000DB038 File Offset: 0x000D9238
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
	// (get) Token: 0x06001594 RID: 5524 RVA: 0x000DB068 File Offset: 0x000D9268
	// (set) Token: 0x06001595 RID: 5525 RVA: 0x000DB098 File Offset: 0x000D9298
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
	// (get) Token: 0x06001596 RID: 5526 RVA: 0x000DB0C8 File Offset: 0x000D92C8
	// (set) Token: 0x06001597 RID: 5527 RVA: 0x000DB0F8 File Offset: 0x000D92F8
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
	// (get) Token: 0x06001598 RID: 5528 RVA: 0x000DB128 File Offset: 0x000D9328
	// (set) Token: 0x06001599 RID: 5529 RVA: 0x000DB158 File Offset: 0x000D9358
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
	// (get) Token: 0x0600159A RID: 5530 RVA: 0x000DB188 File Offset: 0x000D9388
	// (set) Token: 0x0600159B RID: 5531 RVA: 0x000DB1B8 File Offset: 0x000D93B8
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

	// Token: 0x0600159C RID: 5532 RVA: 0x000DB1E8 File Offset: 0x000D93E8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
	}

	// Token: 0x040021FA RID: 8698
	private const string Str_Week = "Week";

	// Token: 0x040021FB RID: 8699
	private const string Str_Weekday = "Weekday";

	// Token: 0x040021FC RID: 8700
	private const string Str_PassDays = "PassDays";

	// Token: 0x040021FD RID: 8701
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x040021FE RID: 8702
	private const string Str_GameplayDay = "GameplayDay";

	// Token: 0x040021FF RID: 8703
	private const string Str_ForceSkip = "ForceSkip";
}
