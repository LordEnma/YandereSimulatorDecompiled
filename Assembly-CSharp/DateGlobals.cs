using System;
using UnityEngine;

// Token: 0x020002F1 RID: 753
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06001596 RID: 5526 RVA: 0x000DB0B8 File Offset: 0x000D92B8
	// (set) Token: 0x06001597 RID: 5527 RVA: 0x000DB0E8 File Offset: 0x000D92E8
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
	// (get) Token: 0x06001598 RID: 5528 RVA: 0x000DB118 File Offset: 0x000D9318
	// (set) Token: 0x06001599 RID: 5529 RVA: 0x000DB148 File Offset: 0x000D9348
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
	// (get) Token: 0x0600159A RID: 5530 RVA: 0x000DB178 File Offset: 0x000D9378
	// (set) Token: 0x0600159B RID: 5531 RVA: 0x000DB1A8 File Offset: 0x000D93A8
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
	// (get) Token: 0x0600159C RID: 5532 RVA: 0x000DB1D8 File Offset: 0x000D93D8
	// (set) Token: 0x0600159D RID: 5533 RVA: 0x000DB208 File Offset: 0x000D9408
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
	// (get) Token: 0x0600159E RID: 5534 RVA: 0x000DB238 File Offset: 0x000D9438
	// (set) Token: 0x0600159F RID: 5535 RVA: 0x000DB268 File Offset: 0x000D9468
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
	// (get) Token: 0x060015A0 RID: 5536 RVA: 0x000DB298 File Offset: 0x000D9498
	// (set) Token: 0x060015A1 RID: 5537 RVA: 0x000DB2C8 File Offset: 0x000D94C8
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

	// Token: 0x060015A2 RID: 5538 RVA: 0x000DB2F8 File Offset: 0x000D94F8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
	}

	// Token: 0x040021FC RID: 8700
	private const string Str_Week = "Week";

	// Token: 0x040021FD RID: 8701
	private const string Str_Weekday = "Weekday";

	// Token: 0x040021FE RID: 8702
	private const string Str_PassDays = "PassDays";

	// Token: 0x040021FF RID: 8703
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x04002200 RID: 8704
	private const string Str_GameplayDay = "GameplayDay";

	// Token: 0x04002201 RID: 8705
	private const string Str_ForceSkip = "ForceSkip";
}
