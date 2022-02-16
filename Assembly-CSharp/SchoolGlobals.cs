using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class SchoolGlobals
{
	// Token: 0x06001706 RID: 5894 RVA: 0x000DF69C File Offset: 0x000DD89C
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x06001707 RID: 5895 RVA: 0x000DF6D4 File Offset: 0x000DD8D4
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x06001708 RID: 5896 RVA: 0x000DF730 File Offset: 0x000DD930
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x06001709 RID: 5897 RVA: 0x000DF760 File Offset: 0x000DD960
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x0600170A RID: 5898 RVA: 0x000DF798 File Offset: 0x000DD998
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x0600170B RID: 5899 RVA: 0x000DF7F4 File Offset: 0x000DD9F4
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x1700041F RID: 1055
	// (get) Token: 0x0600170C RID: 5900 RVA: 0x000DF824 File Offset: 0x000DDA24
	// (set) Token: 0x0600170D RID: 5901 RVA: 0x000DF854 File Offset: 0x000DDA54
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
	// (get) Token: 0x0600170E RID: 5902 RVA: 0x000DF884 File Offset: 0x000DDA84
	// (set) Token: 0x0600170F RID: 5903 RVA: 0x000DF8B4 File Offset: 0x000DDAB4
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
	// (get) Token: 0x06001710 RID: 5904 RVA: 0x000DF8E4 File Offset: 0x000DDAE4
	// (set) Token: 0x06001711 RID: 5905 RVA: 0x000DF914 File Offset: 0x000DDB14
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
	// (get) Token: 0x06001712 RID: 5906 RVA: 0x000DF944 File Offset: 0x000DDB44
	// (set) Token: 0x06001713 RID: 5907 RVA: 0x000DF974 File Offset: 0x000DDB74
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
	// (get) Token: 0x06001714 RID: 5908 RVA: 0x000DF9A4 File Offset: 0x000DDBA4
	// (set) Token: 0x06001715 RID: 5909 RVA: 0x000DF9D4 File Offset: 0x000DDBD4
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
	// (get) Token: 0x06001716 RID: 5910 RVA: 0x000DFA04 File Offset: 0x000DDC04
	// (set) Token: 0x06001717 RID: 5911 RVA: 0x000DFA34 File Offset: 0x000DDC34
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
	// (get) Token: 0x06001718 RID: 5912 RVA: 0x000DFA64 File Offset: 0x000DDC64
	// (set) Token: 0x06001719 RID: 5913 RVA: 0x000DFA94 File Offset: 0x000DDC94
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
	// (get) Token: 0x0600171A RID: 5914 RVA: 0x000DFAC4 File Offset: 0x000DDCC4
	// (set) Token: 0x0600171B RID: 5915 RVA: 0x000DFAF4 File Offset: 0x000DDCF4
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
	// (get) Token: 0x0600171C RID: 5916 RVA: 0x000DFB24 File Offset: 0x000DDD24
	// (set) Token: 0x0600171D RID: 5917 RVA: 0x000DFB54 File Offset: 0x000DDD54
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

	// Token: 0x0600171E RID: 5918 RVA: 0x000DFB84 File Offset: 0x000DDD84
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

	// Token: 0x0400226C RID: 8812
	private const string Str_DemonActive = "DemonActive_";

	// Token: 0x0400226D RID: 8813
	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	// Token: 0x0400226E RID: 8814
	private const string Str_KidnapVictim = "KidnapVictim";

	// Token: 0x0400226F RID: 8815
	private const string Str_Population = "Population";

	// Token: 0x04002270 RID: 8816
	private const string Str_RoofFence = "RoofFence";

	// Token: 0x04002271 RID: 8817
	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	// Token: 0x04002272 RID: 8818
	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	// Token: 0x04002273 RID: 8819
	private const string Str_PreviousSchoolAtmosphere = "PreviousSchoolAtmosphere";

	// Token: 0x04002274 RID: 8820
	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	// Token: 0x04002275 RID: 8821
	private const string Str_SCP = "SCP";

	// Token: 0x04002276 RID: 8822
	private const string Str_HighSecurity = "HighSecurity";
}
