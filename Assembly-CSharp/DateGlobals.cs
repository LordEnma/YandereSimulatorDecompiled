using System;
using UnityEngine;

// Token: 0x020002ED RID: 749
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06001578 RID: 5496 RVA: 0x000D93A8 File Offset: 0x000D75A8
	// (set) Token: 0x06001579 RID: 5497 RVA: 0x000D93D8 File Offset: 0x000D75D8
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
	// (get) Token: 0x0600157A RID: 5498 RVA: 0x000D9408 File Offset: 0x000D7608
	// (set) Token: 0x0600157B RID: 5499 RVA: 0x000D9438 File Offset: 0x000D7638
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
	// (get) Token: 0x0600157C RID: 5500 RVA: 0x000D9468 File Offset: 0x000D7668
	// (set) Token: 0x0600157D RID: 5501 RVA: 0x000D9498 File Offset: 0x000D7698
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
	// (get) Token: 0x0600157E RID: 5502 RVA: 0x000D94C8 File Offset: 0x000D76C8
	// (set) Token: 0x0600157F RID: 5503 RVA: 0x000D94F8 File Offset: 0x000D76F8
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
	// (get) Token: 0x06001580 RID: 5504 RVA: 0x000D9528 File Offset: 0x000D7728
	// (set) Token: 0x06001581 RID: 5505 RVA: 0x000D9558 File Offset: 0x000D7758
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

	// Token: 0x06001582 RID: 5506 RVA: 0x000D9588 File Offset: 0x000D7788
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
	}

	// Token: 0x040021AC RID: 8620
	private const string Str_Week = "Week";

	// Token: 0x040021AD RID: 8621
	private const string Str_Weekday = "Weekday";

	// Token: 0x040021AE RID: 8622
	private const string Str_PassDays = "PassDays";

	// Token: 0x040021AF RID: 8623
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x040021B0 RID: 8624
	private const string Str_GameplayDay = "GameplayDay";
}
