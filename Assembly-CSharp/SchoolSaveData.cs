using System;

// Token: 0x02000408 RID: 1032
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C3B RID: 7227 RVA: 0x001497DC File Offset: 0x001479DC
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

	// Token: 0x06001C3C RID: 7228 RVA: 0x00149890 File Offset: 0x00147A90
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

	// Token: 0x040031CA RID: 12746
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x040031CB RID: 12747
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x040031CC RID: 12748
	public int kidnapVictim;

	// Token: 0x040031CD RID: 12749
	public int population;

	// Token: 0x040031CE RID: 12750
	public bool roofFence;

	// Token: 0x040031CF RID: 12751
	public float schoolAtmosphere;

	// Token: 0x040031D0 RID: 12752
	public bool schoolAtmosphereSet;

	// Token: 0x040031D1 RID: 12753
	public bool scp;
}
