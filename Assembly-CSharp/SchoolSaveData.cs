using System;

// Token: 0x02000409 RID: 1033
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C45 RID: 7237 RVA: 0x00149ED0 File Offset: 0x001480D0
	public static SchoolSaveData ReadFromGlobals()
	{
		SchoolSaveData schoolSaveData = new SchoolSaveData();
		foreach (int num in SchoolGlobals.KeysOfDemonActive())
		{
			if (SchoolGlobals.GetDemonActive(num))
			{
				schoolSaveData.demonActive.Add(num);
			}
		}
		foreach (int num2 in SchoolGlobals.KeysOfGardenGraveOccupied())
		{
			if (SchoolGlobals.GetGardenGraveOccupied(num2))
			{
				schoolSaveData.gardenGraveOccupied.Add(num2);
			}
		}
		schoolSaveData.kidnapVictim = SchoolGlobals.KidnapVictim;
		schoolSaveData.population = SchoolGlobals.Population;
		schoolSaveData.roofFence = SchoolGlobals.RoofFence;
		schoolSaveData.schoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
		schoolSaveData.schoolAtmosphereSet = SchoolGlobals.SchoolAtmosphereSet;
		schoolSaveData.scp = SchoolGlobals.SCP;
		return schoolSaveData;
	}

	// Token: 0x06001C46 RID: 7238 RVA: 0x00149F84 File Offset: 0x00148184
	public static void WriteToGlobals(SchoolSaveData data)
	{
		foreach (int demonID in data.demonActive)
		{
			SchoolGlobals.SetDemonActive(demonID, true);
		}
		foreach (int graveID in data.gardenGraveOccupied)
		{
			SchoolGlobals.SetGardenGraveOccupied(graveID, true);
		}
		SchoolGlobals.KidnapVictim = data.kidnapVictim;
		SchoolGlobals.Population = data.population;
		SchoolGlobals.RoofFence = data.roofFence;
		SchoolGlobals.SchoolAtmosphere = data.schoolAtmosphere;
		SchoolGlobals.SchoolAtmosphereSet = data.schoolAtmosphereSet;
		SchoolGlobals.SCP = data.scp;
	}

	// Token: 0x040031D8 RID: 12760
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x040031D9 RID: 12761
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x040031DA RID: 12762
	public int kidnapVictim;

	// Token: 0x040031DB RID: 12763
	public int population;

	// Token: 0x040031DC RID: 12764
	public bool roofFence;

	// Token: 0x040031DD RID: 12765
	public float schoolAtmosphere;

	// Token: 0x040031DE RID: 12766
	public bool schoolAtmosphereSet;

	// Token: 0x040031DF RID: 12767
	public bool scp;
}
