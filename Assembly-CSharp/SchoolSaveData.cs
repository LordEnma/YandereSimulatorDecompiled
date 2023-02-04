using System;

[Serializable]
public class SchoolSaveData
{
	public IntHashSet demonActive = new IntHashSet();

	public IntHashSet gardenGraveOccupied = new IntHashSet();

	public int kidnapVictim;

	public int population;

	public bool roofFence;

	public float schoolAtmosphere;

	public bool schoolAtmosphereSet;

	public bool scp;

	public static SchoolSaveData ReadFromGlobals()
	{
		SchoolSaveData schoolSaveData = new SchoolSaveData();
		int[] array = SchoolGlobals.KeysOfDemonActive();
		foreach (int num in array)
		{
			if (SchoolGlobals.GetDemonActive(num))
			{
				schoolSaveData.demonActive.Add(num);
			}
		}
		array = SchoolGlobals.KeysOfGardenGraveOccupied();
		foreach (int num2 in array)
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

	public static void WriteToGlobals(SchoolSaveData data)
	{
		foreach (int item in data.demonActive)
		{
			SchoolGlobals.SetDemonActive(item, value: true);
		}
		foreach (int item2 in data.gardenGraveOccupied)
		{
			SchoolGlobals.SetGardenGraveOccupied(item2, value: true);
		}
		SchoolGlobals.KidnapVictim = data.kidnapVictim;
		SchoolGlobals.Population = data.population;
		SchoolGlobals.RoofFence = data.roofFence;
		SchoolGlobals.SchoolAtmosphere = data.schoolAtmosphere;
		SchoolGlobals.SchoolAtmosphereSet = data.schoolAtmosphereSet;
		SchoolGlobals.SCP = data.scp;
	}
}
