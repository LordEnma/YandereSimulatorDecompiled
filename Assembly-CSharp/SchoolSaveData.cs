using System;

// Token: 0x0200040B RID: 1035
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C53 RID: 7251 RVA: 0x0014B648 File Offset: 0x00149848
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

	// Token: 0x06001C54 RID: 7252 RVA: 0x0014B6FC File Offset: 0x001498FC
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

	// Token: 0x04003204 RID: 12804
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x04003205 RID: 12805
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x04003206 RID: 12806
	public int kidnapVictim;

	// Token: 0x04003207 RID: 12807
	public int population;

	// Token: 0x04003208 RID: 12808
	public bool roofFence;

	// Token: 0x04003209 RID: 12809
	public float schoolAtmosphere;

	// Token: 0x0400320A RID: 12810
	public bool schoolAtmosphereSet;

	// Token: 0x0400320B RID: 12811
	public bool scp;
}
