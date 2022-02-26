using System;

// Token: 0x02000404 RID: 1028
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C22 RID: 7202 RVA: 0x00147940 File Offset: 0x00145B40
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

	// Token: 0x06001C23 RID: 7203 RVA: 0x001479F4 File Offset: 0x00145BF4
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

	// Token: 0x04003167 RID: 12647
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x04003168 RID: 12648
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x04003169 RID: 12649
	public int kidnapVictim;

	// Token: 0x0400316A RID: 12650
	public int population;

	// Token: 0x0400316B RID: 12651
	public bool roofFence;

	// Token: 0x0400316C RID: 12652
	public float schoolAtmosphere;

	// Token: 0x0400316D RID: 12653
	public bool schoolAtmosphereSet;

	// Token: 0x0400316E RID: 12654
	public bool scp;
}
