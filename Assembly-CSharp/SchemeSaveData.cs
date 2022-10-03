// Decompiled with JetBrains decompiler
// Type: SchemeSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

[Serializable]
public class SchemeSaveData
{
  public int currentScheme;
  public bool darkSecret;
  public IntAndIntDictionary schemePreviousStage = new IntAndIntDictionary();
  public IntAndIntDictionary schemeStage = new IntAndIntDictionary();
  public IntHashSet schemeStatus = new IntHashSet();
  public IntHashSet schemeUnlocked = new IntHashSet();
  public IntHashSet servicePurchased = new IntHashSet();

  public static SchemeSaveData ReadFromGlobals()
  {
    SchemeSaveData schemeSaveData = new SchemeSaveData();
    schemeSaveData.currentScheme = SchemeGlobals.CurrentScheme;
    schemeSaveData.darkSecret = SchemeGlobals.EmbarassingSecret;
    foreach (int num in SchemeGlobals.KeysOfSchemePreviousStage())
      schemeSaveData.schemePreviousStage.Add(num, SchemeGlobals.GetSchemePreviousStage(num));
    foreach (int num in SchemeGlobals.KeysOfSchemeStage())
      schemeSaveData.schemeStage.Add(num, SchemeGlobals.GetSchemeStage(num));
    foreach (int keysOfSchemeStatu in SchemeGlobals.KeysOfSchemeStatus())
    {
      if (SchemeGlobals.GetSchemeStatus(keysOfSchemeStatu))
        schemeSaveData.schemeStatus.Add(keysOfSchemeStatu);
    }
    foreach (int schemeID in SchemeGlobals.KeysOfSchemeUnlocked())
    {
      if (SchemeGlobals.GetSchemeUnlocked(schemeID))
        schemeSaveData.schemeUnlocked.Add(schemeID);
    }
    foreach (int serviceID in SchemeGlobals.KeysOfServicePurchased())
    {
      if (SchemeGlobals.GetServicePurchased(serviceID))
        schemeSaveData.servicePurchased.Add(serviceID);
    }
    return schemeSaveData;
  }

  public static void WriteToGlobals(SchemeSaveData data)
  {
    SchemeGlobals.CurrentScheme = data.currentScheme;
    SchemeGlobals.EmbarassingSecret = data.darkSecret;
    foreach (KeyValuePair<int, int> keyValuePair in (Dictionary<int, int>) data.schemePreviousStage)
      SchemeGlobals.SetSchemePreviousStage(keyValuePair.Key, keyValuePair.Value);
    foreach (KeyValuePair<int, int> keyValuePair in (Dictionary<int, int>) data.schemeStage)
      SchemeGlobals.SetSchemeStage(keyValuePair.Key, keyValuePair.Value);
    foreach (int schemeStatu in (HashSet<int>) data.schemeStatus)
      SchemeGlobals.SetSchemeStatus(schemeStatu, true);
    foreach (int schemeID in (HashSet<int>) data.schemeUnlocked)
      SchemeGlobals.SetSchemeUnlocked(schemeID, true);
    foreach (int serviceID in (HashSet<int>) data.servicePurchased)
      SchemeGlobals.SetServicePurchased(serviceID, true);
  }
}
