using System;
using UnityEngine;

// Token: 0x020002FB RID: 763
public static class SchoolGlobals
{
	// Token: 0x0600171A RID: 5914 RVA: 0x000E0C5C File Offset: 0x000DEE5C
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x0600171B RID: 5915 RVA: 0x000E0C94 File Offset: 0x000DEE94
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x0600171C RID: 5916 RVA: 0x000E0CF0 File Offset: 0x000DEEF0
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x0600171D RID: 5917 RVA: 0x000E0D20 File Offset: 0x000DEF20
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x0600171E RID: 5918 RVA: 0x000E0D58 File Offset: 0x000DEF58
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x0600171F RID: 5919 RVA: 0x000E0DB4 File Offset: 0x000DEFB4
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x06001720 RID: 5920 RVA: 0x000E0DE4 File Offset: 0x000DEFE4
	// (set) Token: 0x06001721 RID: 5921 RVA: 0x000E0E14 File Offset: 0x000DF014
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
	// (get) Token: 0x06001722 RID: 5922 RVA: 0x000E0E44 File Offset: 0x000DF044
	// (set) Token: 0x06001723 RID: 5923 RVA: 0x000E0E74 File Offset: 0x000DF074
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
	// (get) Token: 0x06001724 RID: 5924 RVA: 0x000E0EA4 File Offset: 0x000DF0A4
	// (set) Token: 0x06001725 RID: 5925 RVA: 0x000E0ED4 File Offset: 0x000DF0D4
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
	// (get) Token: 0x06001726 RID: 5926 RVA: 0x000E0F04 File Offset: 0x000DF104
	// (set) Token: 0x06001727 RID: 5927 RVA: 0x000E0F34 File Offset: 0x000DF134
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
	// (get) Token: 0x06001728 RID: 5928 RVA: 0x000E0F64 File Offset: 0x000DF164
	// (set) Token: 0x06001729 RID: 5929 RVA: 0x000E0F94 File Offset: 0x000DF194
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
	// (get) Token: 0x0600172A RID: 5930 RVA: 0x000E0FC4 File Offset: 0x000DF1C4
	// (set) Token: 0x0600172B RID: 5931 RVA: 0x000E0FF4 File Offset: 0x000DF1F4
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
	// (get) Token: 0x0600172C RID: 5932 RVA: 0x000E1024 File Offset: 0x000DF224
	// (set) Token: 0x0600172D RID: 5933 RVA: 0x000E1054 File Offset: 0x000DF254
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
	// (get) Token: 0x0600172E RID: 5934 RVA: 0x000E1084 File Offset: 0x000DF284
	// (set) Token: 0x0600172F RID: 5935 RVA: 0x000E10B4 File Offset: 0x000DF2B4
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
	// (get) Token: 0x06001730 RID: 5936 RVA: 0x000E10E4 File Offset: 0x000DF2E4
	// (set) Token: 0x06001731 RID: 5937 RVA: 0x000E1114 File Offset: 0x000DF314
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

	// Token: 0x06001732 RID: 5938 RVA: 0x000E1144 File Offset: 0x000DF344
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

	// Token: 0x040022AE RID: 8878
	private const string Str_DemonActive = "DemonActive_";

	// Token: 0x040022AF RID: 8879
	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	// Token: 0x040022B0 RID: 8880
	private const string Str_KidnapVictim = "KidnapVictim";

	// Token: 0x040022B1 RID: 8881
	private const string Str_Population = "Population";

	// Token: 0x040022B2 RID: 8882
	private const string Str_RoofFence = "RoofFence";

	// Token: 0x040022B3 RID: 8883
	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	// Token: 0x040022B4 RID: 8884
	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	// Token: 0x040022B5 RID: 8885
	private const string Str_PreviousSchoolAtmosphere = "PreviousSchoolAtmosphere";

	// Token: 0x040022B6 RID: 8886
	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	// Token: 0x040022B7 RID: 8887
	private const string Str_SCP = "SCP";

	// Token: 0x040022B8 RID: 8888
	private const string Str_HighSecurity = "HighSecurity";
}
