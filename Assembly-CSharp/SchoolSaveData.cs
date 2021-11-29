using System;

// Token: 0x020003FE RID: 1022
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001BFC RID: 7164 RVA: 0x00143DB0 File Offset: 0x00141FB0
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

	// Token: 0x06001BFD RID: 7165 RVA: 0x00143E64 File Offset: 0x00142064
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

	// Token: 0x0400310B RID: 12555
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x0400310C RID: 12556
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x0400310D RID: 12557
	public int kidnapVictim;

	// Token: 0x0400310E RID: 12558
	public int population;

	// Token: 0x0400310F RID: 12559
	public bool roofFence;

	// Token: 0x04003110 RID: 12560
	public float schoolAtmosphere;

	// Token: 0x04003111 RID: 12561
	public bool schoolAtmosphereSet;

	// Token: 0x04003112 RID: 12562
	public bool scp;
}
