using System;
using UnityEngine;

// Token: 0x020002FA RID: 762
public static class SchoolGlobals
{
	// Token: 0x06001714 RID: 5908 RVA: 0x000E075C File Offset: 0x000DE95C
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x06001715 RID: 5909 RVA: 0x000E0794 File Offset: 0x000DE994
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x06001716 RID: 5910 RVA: 0x000E07F0 File Offset: 0x000DE9F0
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x06001717 RID: 5911 RVA: 0x000E0820 File Offset: 0x000DEA20
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x06001718 RID: 5912 RVA: 0x000E0858 File Offset: 0x000DEA58
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x06001719 RID: 5913 RVA: 0x000E08B4 File Offset: 0x000DEAB4
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x0600171A RID: 5914 RVA: 0x000E08E4 File Offset: 0x000DEAE4
	// (set) Token: 0x0600171B RID: 5915 RVA: 0x000E0914 File Offset: 0x000DEB14
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

	// Token: 0x17000421 RID: 1057
	// (get) Token: 0x0600171C RID: 5916 RVA: 0x000E0944 File Offset: 0x000DEB44
	// (set) Token: 0x0600171D RID: 5917 RVA: 0x000E0974 File Offset: 0x000DEB74
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

	// Token: 0x17000422 RID: 1058
	// (get) Token: 0x0600171E RID: 5918 RVA: 0x000E09A4 File Offset: 0x000DEBA4
	// (set) Token: 0x0600171F RID: 5919 RVA: 0x000E09D4 File Offset: 0x000DEBD4
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

	// Token: 0x17000423 RID: 1059
	// (get) Token: 0x06001720 RID: 5920 RVA: 0x000E0A04 File Offset: 0x000DEC04
	// (set) Token: 0x06001721 RID: 5921 RVA: 0x000E0A34 File Offset: 0x000DEC34
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

	// Token: 0x17000424 RID: 1060
	// (get) Token: 0x06001722 RID: 5922 RVA: 0x000E0A64 File Offset: 0x000DEC64
	// (set) Token: 0x06001723 RID: 5923 RVA: 0x000E0A94 File Offset: 0x000DEC94
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

	// Token: 0x17000425 RID: 1061
	// (get) Token: 0x06001724 RID: 5924 RVA: 0x000E0AC4 File Offset: 0x000DECC4
	// (set) Token: 0x06001725 RID: 5925 RVA: 0x000E0AF4 File Offset: 0x000DECF4
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

	// Token: 0x17000426 RID: 1062
	// (get) Token: 0x06001726 RID: 5926 RVA: 0x000E0B24 File Offset: 0x000DED24
	// (set) Token: 0x06001727 RID: 5927 RVA: 0x000E0B54 File Offset: 0x000DED54
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

	// Token: 0x17000427 RID: 1063
	// (get) Token: 0x06001728 RID: 5928 RVA: 0x000E0B84 File Offset: 0x000DED84
	// (set) Token: 0x06001729 RID: 5929 RVA: 0x000E0BB4 File Offset: 0x000DEDB4
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

	// Token: 0x17000428 RID: 1064
	// (get) Token: 0x0600172A RID: 5930 RVA: 0x000E0BE4 File Offset: 0x000DEDE4
	// (set) Token: 0x0600172B RID: 5931 RVA: 0x000E0C14 File Offset: 0x000DEE14
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

	// Token: 0x0600172C RID: 5932 RVA: 0x000E0C44 File Offset: 0x000DEE44
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

	// Token: 0x040022A0 RID: 8864
	private const string Str_DemonActive = "DemonActive_";

	// Token: 0x040022A1 RID: 8865
	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	// Token: 0x040022A2 RID: 8866
	private const string Str_KidnapVictim = "KidnapVictim";

	// Token: 0x040022A3 RID: 8867
	private const string Str_Population = "Population";

	// Token: 0x040022A4 RID: 8868
	private const string Str_RoofFence = "RoofFence";

	// Token: 0x040022A5 RID: 8869
	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	// Token: 0x040022A6 RID: 8870
	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	// Token: 0x040022A7 RID: 8871
	private const string Str_PreviousSchoolAtmosphere = "PreviousSchoolAtmosphere";

	// Token: 0x040022A8 RID: 8872
	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	// Token: 0x040022A9 RID: 8873
	private const string Str_SCP = "SCP";

	// Token: 0x040022AA RID: 8874
	private const string Str_HighSecurity = "HighSecurity";
}
