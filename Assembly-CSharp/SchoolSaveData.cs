using System;

// Token: 0x0200040B RID: 1035
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C52 RID: 7250 RVA: 0x0014B38C File Offset: 0x0014958C
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

	// Token: 0x06001C53 RID: 7251 RVA: 0x0014B440 File Offset: 0x00149640
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

	// Token: 0x040031FC RID: 12796
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x040031FD RID: 12797
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x040031FE RID: 12798
	public int kidnapVictim;

	// Token: 0x040031FF RID: 12799
	public int population;

	// Token: 0x04003200 RID: 12800
	public bool roofFence;

	// Token: 0x04003201 RID: 12801
	public float schoolAtmosphere;

	// Token: 0x04003202 RID: 12802
	public bool schoolAtmosphereSet;

	// Token: 0x04003203 RID: 12803
	public bool scp;
}
