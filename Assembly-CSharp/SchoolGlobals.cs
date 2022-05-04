using System;
using UnityEngine;

// Token: 0x020002FC RID: 764
public static class SchoolGlobals
{
	// Token: 0x06001726 RID: 5926 RVA: 0x000E13F0 File Offset: 0x000DF5F0
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x06001727 RID: 5927 RVA: 0x000E1428 File Offset: 0x000DF628
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x06001728 RID: 5928 RVA: 0x000E1484 File Offset: 0x000DF684
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x06001729 RID: 5929 RVA: 0x000E14B4 File Offset: 0x000DF6B4
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x0600172A RID: 5930 RVA: 0x000E14EC File Offset: 0x000DF6EC
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x0600172B RID: 5931 RVA: 0x000E1548 File Offset: 0x000DF748
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x0600172C RID: 5932 RVA: 0x000E1578 File Offset: 0x000DF778
	// (set) Token: 0x0600172D RID: 5933 RVA: 0x000E15A8 File Offset: 0x000DF7A8
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
	// (get) Token: 0x0600172E RID: 5934 RVA: 0x000E15D8 File Offset: 0x000DF7D8
	// (set) Token: 0x0600172F RID: 5935 RVA: 0x000E1608 File Offset: 0x000DF808
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
	// (get) Token: 0x06001730 RID: 5936 RVA: 0x000E1638 File Offset: 0x000DF838
	// (set) Token: 0x06001731 RID: 5937 RVA: 0x000E1668 File Offset: 0x000DF868
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
	// (get) Token: 0x06001732 RID: 5938 RVA: 0x000E1698 File Offset: 0x000DF898
	// (set) Token: 0x06001733 RID: 5939 RVA: 0x000E16C8 File Offset: 0x000DF8C8
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
	// (get) Token: 0x06001734 RID: 5940 RVA: 0x000E16F8 File Offset: 0x000DF8F8
	// (set) Token: 0x06001735 RID: 5941 RVA: 0x000E1728 File Offset: 0x000DF928
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
	// (get) Token: 0x06001736 RID: 5942 RVA: 0x000E1758 File Offset: 0x000DF958
	// (set) Token: 0x06001737 RID: 5943 RVA: 0x000E1788 File Offset: 0x000DF988
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
	// (get) Token: 0x06001738 RID: 5944 RVA: 0x000E17B8 File Offset: 0x000DF9B8
	// (set) Token: 0x06001739 RID: 5945 RVA: 0x000E17E8 File Offset: 0x000DF9E8
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
	// (get) Token: 0x0600173A RID: 5946 RVA: 0x000E1818 File Offset: 0x000DFA18
	// (set) Token: 0x0600173B RID: 5947 RVA: 0x000E1848 File Offset: 0x000DFA48
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
	// (get) Token: 0x0600173C RID: 5948 RVA: 0x000E1878 File Offset: 0x000DFA78
	// (set) Token: 0x0600173D RID: 5949 RVA: 0x000E18A8 File Offset: 0x000DFAA8
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

	// Token: 0x0600173E RID: 5950 RVA: 0x000E18D8 File Offset: 0x000DFAD8
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
