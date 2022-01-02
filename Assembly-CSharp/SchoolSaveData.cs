using System;

// Token: 0x020003FF RID: 1023
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C06 RID: 7174 RVA: 0x00144A6C File Offset: 0x00142C6C
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

	// Token: 0x06001C07 RID: 7175 RVA: 0x00144B20 File Offset: 0x00142D20
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

	// Token: 0x0400313C RID: 12604
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x0400313D RID: 12605
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x0400313E RID: 12606
	public int kidnapVictim;

	// Token: 0x0400313F RID: 12607
	public int population;

	// Token: 0x04003140 RID: 12608
	public bool roofFence;

	// Token: 0x04003141 RID: 12609
	public float schoolAtmosphere;

	// Token: 0x04003142 RID: 12610
	public bool schoolAtmosphereSet;

	// Token: 0x04003143 RID: 12611
	public bool scp;
}
