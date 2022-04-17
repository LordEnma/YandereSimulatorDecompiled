using System;
using UnityEngine;

// Token: 0x020002FC RID: 764
public static class SchoolGlobals
{
	// Token: 0x06001722 RID: 5922 RVA: 0x000E0F54 File Offset: 0x000DF154
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x06001723 RID: 5923 RVA: 0x000E0F8C File Offset: 0x000DF18C
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x06001724 RID: 5924 RVA: 0x000E0FE8 File Offset: 0x000DF1E8
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x06001725 RID: 5925 RVA: 0x000E1018 File Offset: 0x000DF218
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x06001726 RID: 5926 RVA: 0x000E1050 File Offset: 0x000DF250
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x06001727 RID: 5927 RVA: 0x000E10AC File Offset: 0x000DF2AC
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x06001728 RID: 5928 RVA: 0x000E10DC File Offset: 0x000DF2DC
	// (set) Token: 0x06001729 RID: 5929 RVA: 0x000E110C File Offset: 0x000DF30C
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
	// (get) Token: 0x0600172A RID: 5930 RVA: 0x000E113C File Offset: 0x000DF33C
	// (set) Token: 0x0600172B RID: 5931 RVA: 0x000E116C File Offset: 0x000DF36C
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
	// (get) Token: 0x0600172C RID: 5932 RVA: 0x000E119C File Offset: 0x000DF39C
	// (set) Token: 0x0600172D RID: 5933 RVA: 0x000E11CC File Offset: 0x000DF3CC
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
	// (get) Token: 0x0600172E RID: 5934 RVA: 0x000E11FC File Offset: 0x000DF3FC
	// (set) Token: 0x0600172F RID: 5935 RVA: 0x000E122C File Offset: 0x000DF42C
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
	// (get) Token: 0x06001730 RID: 5936 RVA: 0x000E125C File Offset: 0x000DF45C
	// (set) Token: 0x06001731 RID: 5937 RVA: 0x000E128C File Offset: 0x000DF48C
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
	// (get) Token: 0x06001732 RID: 5938 RVA: 0x000E12BC File Offset: 0x000DF4BC
	// (set) Token: 0x06001733 RID: 5939 RVA: 0x000E12EC File Offset: 0x000DF4EC
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
	// (get) Token: 0x06001734 RID: 5940 RVA: 0x000E131C File Offset: 0x000DF51C
	// (set) Token: 0x06001735 RID: 5941 RVA: 0x000E134C File Offset: 0x000DF54C
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
	// (get) Token: 0x06001736 RID: 5942 RVA: 0x000E137C File Offset: 0x000DF57C
	// (set) Token: 0x06001737 RID: 5943 RVA: 0x000E13AC File Offset: 0x000DF5AC
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
	// (get) Token: 0x06001738 RID: 5944 RVA: 0x000E13DC File Offset: 0x000DF5DC
	// (set) Token: 0x06001739 RID: 5945 RVA: 0x000E140C File Offset: 0x000DF60C
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

	// Token: 0x0600173A RID: 5946 RVA: 0x000E143C File Offset: 0x000DF63C
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

	// Token: 0x040022B2 RID: 8882
	private const string Str_DemonActive = "DemonActive_";

	// Token: 0x040022B3 RID: 8883
	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	// Token: 0x040022B4 RID: 8884
	private const string Str_KidnapVictim = "KidnapVictim";

	// Token: 0x040022B5 RID: 8885
	private const string Str_Population = "Population";

	// Token: 0x040022B6 RID: 8886
	private const string Str_RoofFence = "RoofFence";

	// Token: 0x040022B7 RID: 8887
	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	// Token: 0x040022B8 RID: 8888
	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	// Token: 0x040022B9 RID: 8889
	private const string Str_PreviousSchoolAtmosphere = "PreviousSchoolAtmosphere";

	// Token: 0x040022BA RID: 8890
	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	// Token: 0x040022BB RID: 8891
	private const string Str_SCP = "SCP";

	// Token: 0x040022BC RID: 8892
	private const string Str_HighSecurity = "HighSecurity";
}
