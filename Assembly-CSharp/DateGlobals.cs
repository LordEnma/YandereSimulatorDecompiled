using System;
using UnityEngine;

// Token: 0x020002ED RID: 749
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06001579 RID: 5497 RVA: 0x000D987C File Offset: 0x000D7A7C
	// (set) Token: 0x0600157A RID: 5498 RVA: 0x000D98AC File Offset: 0x000D7AAC
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
	// (get) Token: 0x0600157B RID: 5499 RVA: 0x000D98DC File Offset: 0x000D7ADC
	// (set) Token: 0x0600157C RID: 5500 RVA: 0x000D990C File Offset: 0x000D7B0C
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
	// (get) Token: 0x0600157D RID: 5501 RVA: 0x000D993C File Offset: 0x000D7B3C
	// (set) Token: 0x0600157E RID: 5502 RVA: 0x000D996C File Offset: 0x000D7B6C
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
	// (get) Token: 0x0600157F RID: 5503 RVA: 0x000D999C File Offset: 0x000D7B9C
	// (set) Token: 0x06001580 RID: 5504 RVA: 0x000D99CC File Offset: 0x000D7BCC
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
	// (get) Token: 0x06001581 RID: 5505 RVA: 0x000D99FC File Offset: 0x000D7BFC
	// (set) Token: 0x06001582 RID: 5506 RVA: 0x000D9A2C File Offset: 0x000D7C2C
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

	// Token: 0x06001583 RID: 5507 RVA: 0x000D9A5C File Offset: 0x000D7C5C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
	}

	// Token: 0x040021B2 RID: 8626
	private const string Str_Week = "Week";

	// Token: 0x040021B3 RID: 8627
	private const string Str_Weekday = "Weekday";

	// Token: 0x040021B4 RID: 8628
	private const string Str_PassDays = "PassDays";

	// Token: 0x040021B5 RID: 8629
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x040021B6 RID: 8630
	private const string Str_GameplayDay = "GameplayDay";
}
