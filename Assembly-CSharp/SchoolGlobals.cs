using System;
using UnityEngine;

// Token: 0x020002FC RID: 764
public static class SchoolGlobals
{
	// Token: 0x06001726 RID: 5926 RVA: 0x000E1424 File Offset: 0x000DF624
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x06001727 RID: 5927 RVA: 0x000E145C File Offset: 0x000DF65C
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x06001728 RID: 5928 RVA: 0x000E14B8 File Offset: 0x000DF6B8
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x06001729 RID: 5929 RVA: 0x000E14E8 File Offset: 0x000DF6E8
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x0600172A RID: 5930 RVA: 0x000E1520 File Offset: 0x000DF720
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x0600172B RID: 5931 RVA: 0x000E157C File Offset: 0x000DF77C
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x0600172C RID: 5932 RVA: 0x000E15AC File Offset: 0x000DF7AC
	// (set) Token: 0x0600172D RID: 5933 RVA: 0x000E15DC File Offset: 0x000DF7DC
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
	// (get) Token: 0x0600172E RID: 5934 RVA: 0x000E160C File Offset: 0x000DF80C
	// (set) Token: 0x0600172F RID: 5935 RVA: 0x000E163C File Offset: 0x000DF83C
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
	// (get) Token: 0x06001730 RID: 5936 RVA: 0x000E166C File Offset: 0x000DF86C
	// (set) Token: 0x06001731 RID: 5937 RVA: 0x000E169C File Offset: 0x000DF89C
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
	// (get) Token: 0x06001732 RID: 5938 RVA: 0x000E16CC File Offset: 0x000DF8CC
	// (set) Token: 0x06001733 RID: 5939 RVA: 0x000E16FC File Offset: 0x000DF8FC
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
	// (get) Token: 0x06001734 RID: 5940 RVA: 0x000E172C File Offset: 0x000DF92C
	// (set) Token: 0x06001735 RID: 5941 RVA: 0x000E175C File Offset: 0x000DF95C
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
	// (get) Token: 0x06001736 RID: 5942 RVA: 0x000E178C File Offset: 0x000DF98C
	// (set) Token: 0x06001737 RID: 5943 RVA: 0x000E17BC File Offset: 0x000DF9BC
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
	// (get) Token: 0x06001738 RID: 5944 RVA: 0x000E17EC File Offset: 0x000DF9EC
	// (set) Token: 0x06001739 RID: 5945 RVA: 0x000E181C File Offset: 0x000DFA1C
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
	// (get) Token: 0x0600173A RID: 5946 RVA: 0x000E184C File Offset: 0x000DFA4C
	// (set) Token: 0x0600173B RID: 5947 RVA: 0x000E187C File Offset: 0x000DFA7C
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
	// (get) Token: 0x0600173C RID: 5948 RVA: 0x000E18AC File Offset: 0x000DFAAC
	// (set) Token: 0x0600173D RID: 5949 RVA: 0x000E18DC File Offset: 0x000DFADC
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

	// Token: 0x0600173E RID: 5950 RVA: 0x000E190C File Offset: 0x000DFB0C
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

	// Token: 0x040022BB RID: 8891
	private const string Str_DemonActive = "DemonActive_";

	// Token: 0x040022BC RID: 8892
	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	// Token: 0x040022BD RID: 8893
	private const string Str_KidnapVictim = "KidnapVictim";

	// Token: 0x040022BE RID: 8894
	private const string Str_Population = "Population";

	// Token: 0x040022BF RID: 8895
	private const string Str_RoofFence = "RoofFence";

	// Token: 0x040022C0 RID: 8896
	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	// Token: 0x040022C1 RID: 8897
	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	// Token: 0x040022C2 RID: 8898
	private const string Str_PreviousSchoolAtmosphere = "PreviousSchoolAtmosphere";

	// Token: 0x040022C3 RID: 8899
	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	// Token: 0x040022C4 RID: 8900
	private const string Str_SCP = "SCP";

	// Token: 0x040022C5 RID: 8901
	private const string Str_HighSecurity = "HighSecurity";
}
