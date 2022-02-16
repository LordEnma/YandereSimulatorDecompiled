using System;

// Token: 0x02000403 RID: 1027
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C19 RID: 7193 RVA: 0x00146EC8 File Offset: 0x001450C8
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

	// Token: 0x06001C1A RID: 7194 RVA: 0x00146F7C File Offset: 0x0014517C
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

	// Token: 0x04003157 RID: 12631
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x04003158 RID: 12632
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x04003159 RID: 12633
	public int kidnapVictim;

	// Token: 0x0400315A RID: 12634
	public int population;

	// Token: 0x0400315B RID: 12635
	public bool roofFence;

	// Token: 0x0400315C RID: 12636
	public float schoolAtmosphere;

	// Token: 0x0400315D RID: 12637
	public bool schoolAtmosphereSet;

	// Token: 0x0400315E RID: 12638
	public bool scp;
}
