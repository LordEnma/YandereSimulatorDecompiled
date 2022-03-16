using System;
using UnityEngine;

// Token: 0x020002EF RID: 751
public static class DateGlobals
{
	// Token: 0x17000383 RID: 899
	// (get) Token: 0x0600158A RID: 5514 RVA: 0x000DAAA8 File Offset: 0x000D8CA8
	// (set) Token: 0x0600158B RID: 5515 RVA: 0x000DAAD8 File Offset: 0x000D8CD8
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
	// (get) Token: 0x0600158C RID: 5516 RVA: 0x000DAB08 File Offset: 0x000D8D08
	// (set) Token: 0x0600158D RID: 5517 RVA: 0x000DAB38 File Offset: 0x000D8D38
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
	// (get) Token: 0x0600158E RID: 5518 RVA: 0x000DAB68 File Offset: 0x000D8D68
	// (set) Token: 0x0600158F RID: 5519 RVA: 0x000DAB98 File Offset: 0x000D8D98
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
	// (get) Token: 0x06001590 RID: 5520 RVA: 0x000DABC8 File Offset: 0x000D8DC8
	// (set) Token: 0x06001591 RID: 5521 RVA: 0x000DABF8 File Offset: 0x000D8DF8
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
	// (get) Token: 0x06001592 RID: 5522 RVA: 0x000DAC28 File Offset: 0x000D8E28
	// (set) Token: 0x06001593 RID: 5523 RVA: 0x000DAC58 File Offset: 0x000D8E58
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
	// (get) Token: 0x06001594 RID: 5524 RVA: 0x000DAC88 File Offset: 0x000D8E88
	// (set) Token: 0x06001595 RID: 5525 RVA: 0x000DACB8 File Offset: 0x000D8EB8
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

	// Token: 0x06001596 RID: 5526 RVA: 0x000DACE8 File Offset: 0x000D8EE8
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Week");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Weekday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PassDays");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DayPassed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_GameplayDay");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ForceSkip");
	}

	// Token: 0x040021EC RID: 8684
	private const string Str_Week = "Week";

	// Token: 0x040021ED RID: 8685
	private const string Str_Weekday = "Weekday";

	// Token: 0x040021EE RID: 8686
	private const string Str_PassDays = "PassDays";

	// Token: 0x040021EF RID: 8687
	private const string Str_DayPassed = "DayPassed";

	// Token: 0x040021F0 RID: 8688
	private const string Str_GameplayDay = "GameplayDay";

	// Token: 0x040021F1 RID: 8689
	private const string Str_ForceSkip = "ForceSkip";
}
