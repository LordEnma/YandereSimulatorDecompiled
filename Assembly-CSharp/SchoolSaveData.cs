using System;

// Token: 0x02000404 RID: 1028
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C24 RID: 7204 RVA: 0x00147E7C File Offset: 0x0014607C
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

	// Token: 0x06001C25 RID: 7205 RVA: 0x00147F30 File Offset: 0x00146130
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

	// Token: 0x0400317D RID: 12669
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x0400317E RID: 12670
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x0400317F RID: 12671
	public int kidnapVictim;

	// Token: 0x04003180 RID: 12672
	public int population;

	// Token: 0x04003181 RID: 12673
	public bool roofFence;

	// Token: 0x04003182 RID: 12674
	public float schoolAtmosphere;

	// Token: 0x04003183 RID: 12675
	public bool schoolAtmosphereSet;

	// Token: 0x04003184 RID: 12676
	public bool scp;
}
