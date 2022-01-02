using System;
using UnityEngine;

// Token: 0x020002EC RID: 748
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x06001574 RID: 5492 RVA: 0x000D8F94 File Offset: 0x000D7194
	// (set) Token: 0x06001575 RID: 5493 RVA: 0x000D8FC4 File Offset: 0x000D71C4
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
	// (get) Token: 0x06001576 RID: 5494 RVA: 0x000D8FF4 File Offset: 0x000D71F4
	// (set) Token: 0x06001577 RID: 5495 RVA: 0x000D9024 File Offset: 0x000D7224
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
	// (get) Token: 0x06001578 RID: 5496 RVA: 0x000D9054 File Offset: 0x000D7254
	// (set) Token: 0x06001579 RID: 5497 RVA: 0x000D9084 File Offset: 0x000D7284
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
	// (get) Token: 0x0600157A RID: 5498 RVA: 0x000D90B4 File Offset: 0x000D72B4
	// (set) Token: 0x0600157B RID: 5499 RVA: 0x000D90E4 File Offset: 0x000D72E4
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
	// (get) Token: 0x0600157C RID: 5500 RVA: 0x000D9114 File Offset: 0x000D7314
	// (set) Token: 0x0600157D RID: 5501 RVA: 0x000D9144 File Offset: 0x000D7344
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

	// Token: 0x0600157E RID: 5502 RVA: 0x000D9174 File Offset: 0x000D7374
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
	}

	// Token: 0x040021A5 RID: 8613
	private const string Str_Week = "Week";

	// Token: 0x040021A6 RID: 8614
	private const string Str_Weekday = "Weekday";

	// Token: 0x040021A7 RID: 8615
	private const string Str_PassDays = "PassDays";

	// Token: 0x040021A8 RID: 8616
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x040021A9 RID: 8617
	private const string Str_GameplayDay = "GameplayDay";
}
