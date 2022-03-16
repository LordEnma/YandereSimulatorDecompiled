using System;

// Token: 0x02000405 RID: 1029
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C31 RID: 7217 RVA: 0x00148D20 File Offset: 0x00146F20
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

	// Token: 0x06001C32 RID: 7218 RVA: 0x00148DD4 File Offset: 0x00146FD4
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

	// Token: 0x040031B1 RID: 12721
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x040031B2 RID: 12722
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x040031B3 RID: 12723
	public int kidnapVictim;

	// Token: 0x040031B4 RID: 12724
	public int population;

	// Token: 0x040031B5 RID: 12725
	public bool roofFence;

	// Token: 0x040031B6 RID: 12726
	public float schoolAtmosphere;

	// Token: 0x040031B7 RID: 12727
	public bool schoolAtmosphereSet;

	// Token: 0x040031B8 RID: 12728
	public bool scp;
}
