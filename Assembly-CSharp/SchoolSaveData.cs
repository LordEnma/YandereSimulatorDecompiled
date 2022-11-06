// Decompiled with JetBrains decompiler
// Type: SchoolSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

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
    foreach (int demonID in SchoolGlobals.KeysOfDemonActive())
    {
      if (SchoolGlobals.GetDemonActive(demonID))
        schoolSaveData.demonActive.Add(demonID);
    }
    foreach (int graveID in SchoolGlobals.KeysOfGardenGraveOccupied())
    {
      if (SchoolGlobals.GetGardenGraveOccupied(graveID))
        schoolSaveData.gardenGraveOccupied.Add(graveID);
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
    foreach (int demonID in (HashSet<int>) data.demonActive)
      SchoolGlobals.SetDemonActive(demonID, true);
    foreach (int graveID in (HashSet<int>) data.gardenGraveOccupied)
      SchoolGlobals.SetGardenGraveOccupied(graveID, true);
    SchoolGlobals.KidnapVictim = data.kidnapVictim;
    SchoolGlobals.Population = data.population;
    SchoolGlobals.RoofFence = data.roofFence;
    SchoolGlobals.SchoolAtmosphere = data.schoolAtmosphere;
    SchoolGlobals.SchoolAtmosphereSet = data.schoolAtmosphereSet;
    SchoolGlobals.SCP = data.scp;
  }
}
