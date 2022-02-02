using System;

// Token: 0x02000402 RID: 1026
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C10 RID: 7184 RVA: 0x0014692C File Offset: 0x00144B2C
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

	// Token: 0x06001C11 RID: 7185 RVA: 0x001469E0 File Offset: 0x00144BE0
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

	// Token: 0x0400314D RID: 12621
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x0400314E RID: 12622
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x0400314F RID: 12623
	public int kidnapVictim;

	// Token: 0x04003150 RID: 12624
	public int population;

	// Token: 0x04003151 RID: 12625
	public bool roofFence;

	// Token: 0x04003152 RID: 12626
	public float schoolAtmosphere;

	// Token: 0x04003153 RID: 12627
	public bool schoolAtmosphereSet;

	// Token: 0x04003154 RID: 12628
	public bool scp;
}
