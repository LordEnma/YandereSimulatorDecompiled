using System;
using UnityEngine;

// Token: 0x020002FA RID: 762
public static class SchoolGlobals
{
	// Token: 0x0600170F RID: 5903 RVA: 0x000DFF80 File Offset: 0x000DE180
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x06001710 RID: 5904 RVA: 0x000DFFB8 File Offset: 0x000DE1B8
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x06001711 RID: 5905 RVA: 0x000E0014 File Offset: 0x000DE214
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x06001712 RID: 5906 RVA: 0x000E0044 File Offset: 0x000DE244
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x06001713 RID: 5907 RVA: 0x000E007C File Offset: 0x000DE27C
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x06001714 RID: 5908 RVA: 0x000E00D8 File Offset: 0x000DE2D8
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x1700041F RID: 1055
	// (get) Token: 0x06001715 RID: 5909 RVA: 0x000E0108 File Offset: 0x000DE308
	// (set) Token: 0x06001716 RID: 5910 RVA: 0x000E0138 File Offset: 0x000DE338
	public static int KidnapVictim
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim", value);
		}
	}

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x06001717 RID: 5911 RVA: 0x000E0168 File Offset: 0x000DE368
	// (set) Token: 0x06001718 RID: 5912 RVA: 0x000E0198 File Offset: 0x000DE398
	public static int Population
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Population");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Population", value);
		}
	}

	// Token: 0x17000421 RID: 1057
	// (get) Token: 0x06001719 RID: 5913 RVA: 0x000E01C8 File Offset: 0x000DE3C8
	// (set) Token: 0x0600171A RID: 5914 RVA: 0x000E01F8 File Offset: 0x000DE3F8
	public static bool RoofFence
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence", value);
		}
	}

	// Token: 0x17000422 RID: 1058
	// (get) Token: 0x0600171B RID: 5915 RVA: 0x000E0228 File Offset: 0x000DE428
	// (set) Token: 0x0600171C RID: 5916 RVA: 0x000E0258 File Offset: 0x000DE458
	public static float PreviousSchoolAtmosphere
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere", value);
		}
	}

	// Token: 0x17000423 RID: 1059
	// (get) Token: 0x0600171D RID: 5917 RVA: 0x000E0288 File Offset: 0x000DE488
	// (set) Token: 0x0600171E RID: 5918 RVA: 0x000E02B8 File Offset: 0x000DE4B8
	public static float SchoolAtmosphere
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere", value);
		}
	}

	// Token: 0x17000424 RID: 1060
	// (get) Token: 0x0600171F RID: 5919 RVA: 0x000E02E8 File Offset: 0x000DE4E8
	// (set) Token: 0x06001720 RID: 5920 RVA: 0x000E0318 File Offset: 0x000DE518
	public static bool SchoolAtmosphereSet
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet", value);
		}
	}

	// Token: 0x17000425 RID: 1061
	// (get) Token: 0x06001721 RID: 5921 RVA: 0x000E0348 File Offset: 0x000DE548
	// (set) Token: 0x06001722 RID: 5922 RVA: 0x000E0378 File Offset: 0x000DE578
	public static bool ReactedToGameLeader
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader", value);
		}
	}

	// Token: 0x17000426 RID: 1062
	// (get) Token: 0x06001723 RID: 5923 RVA: 0x000E03A8 File Offset: 0x000DE5A8
	// (set) Token: 0x06001724 RID: 5924 RVA: 0x000E03D8 File Offset: 0x000DE5D8
	public static bool HighSecurity
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity", value);
		}
	}

	// Token: 0x17000427 RID: 1063
	// (get) Token: 0x06001725 RID: 5925 RVA: 0x000E0408 File Offset: 0x000DE608
	// (set) Token: 0x06001726 RID: 5926 RVA: 0x000E0438 File Offset: 0x000DE638
	public static bool SCP
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SCP");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SCP", value);
		}
	}

	// Token: 0x06001727 RID: 5927 RVA: 0x000E0468 File Offset: 0x000DE668
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", SchoolGlobals.KeysOfDemonActive());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", SchoolGlobals.KeysOfGardenGraveOccupied());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Population");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SCP");
	}

	// Token: 0x0400227B RID: 8827
	private const string Str_DemonActive = "DemonActive_";

	// Token: 0x0400227C RID: 8828
	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	// Token: 0x0400227D RID: 8829
	private const string Str_KidnapVictim = "KidnapVictim";

	// Token: 0x0400227E RID: 8830
	private const string Str_Population = "Population";

	// Token: 0x0400227F RID: 8831
	private const string Str_RoofFence = "RoofFence";

	// Token: 0x04002280 RID: 8832
	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	// Token: 0x04002281 RID: 8833
	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	// Token: 0x04002282 RID: 8834
	private const string Str_PreviousSchoolAtmosphere = "PreviousSchoolAtmosphere";

	// Token: 0x04002283 RID: 8835
	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	// Token: 0x04002284 RID: 8836
	private const string Str_SCP = "SCP";

	// Token: 0x04002285 RID: 8837
	private const string Str_HighSecurity = "HighSecurity";
}
