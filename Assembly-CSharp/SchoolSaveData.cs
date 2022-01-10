using System;

// Token: 0x02000401 RID: 1025
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C0D RID: 7181 RVA: 0x00144DE0 File Offset: 0x00142FE0
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

	// Token: 0x06001C0E RID: 7182 RVA: 0x00144E94 File Offset: 0x00143094
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

	// Token: 0x04003142 RID: 12610
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x04003143 RID: 12611
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x04003144 RID: 12612
	public int kidnapVictim;

	// Token: 0x04003145 RID: 12613
	public int population;

	// Token: 0x04003146 RID: 12614
	public bool roofFence;

	// Token: 0x04003147 RID: 12615
	public float schoolAtmosphere;

	// Token: 0x04003148 RID: 12616
	public bool schoolAtmosphereSet;

	// Token: 0x04003149 RID: 12617
	public bool scp;
}
