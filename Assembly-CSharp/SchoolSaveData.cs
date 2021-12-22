using System;

// Token: 0x020003FF RID: 1023
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C04 RID: 7172 RVA: 0x00144670 File Offset: 0x00142870
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

	// Token: 0x06001C05 RID: 7173 RVA: 0x00144724 File Offset: 0x00142924
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

	// Token: 0x04003135 RID: 12597
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x04003136 RID: 12598
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x04003137 RID: 12599
	public int kidnapVictim;

	// Token: 0x04003138 RID: 12600
	public int population;

	// Token: 0x04003139 RID: 12601
	public bool roofFence;

	// Token: 0x0400313A RID: 12602
	public float schoolAtmosphere;

	// Token: 0x0400313B RID: 12603
	public bool schoolAtmosphereSet;

	// Token: 0x0400313C RID: 12604
	public bool scp;
}
