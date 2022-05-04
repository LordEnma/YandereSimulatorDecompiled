using System;

// Token: 0x0200040A RID: 1034
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C4C RID: 7244 RVA: 0x0014A6D8 File Offset: 0x001488D8
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

	// Token: 0x06001C4D RID: 7245 RVA: 0x0014A78C File Offset: 0x0014898C
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

	// Token: 0x040031E7 RID: 12775
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x040031E8 RID: 12776
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x040031E9 RID: 12777
	public int kidnapVictim;

	// Token: 0x040031EA RID: 12778
	public int population;

	// Token: 0x040031EB RID: 12779
	public bool roofFence;

	// Token: 0x040031EC RID: 12780
	public float schoolAtmosphere;

	// Token: 0x040031ED RID: 12781
	public bool schoolAtmosphereSet;

	// Token: 0x040031EE RID: 12782
	public bool scp;
}
