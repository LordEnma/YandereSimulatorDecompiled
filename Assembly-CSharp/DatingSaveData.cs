// Decompiled with JetBrains decompiler
// Type: DatingSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

[Serializable]
public class DatingSaveData
{
  public float affection;
  public float affectionLevel;
  public IntHashSet complimentGiven = new IntHashSet();
  public IntHashSet suitorCheck = new IntHashSet();
  public int suitorProgress;
  public IntAndIntDictionary suitorTrait = new IntAndIntDictionary();
  public IntHashSet topicDiscussed = new IntHashSet();
  public IntAndIntDictionary traitDemonstrated = new IntAndIntDictionary();

  public static DatingSaveData ReadFromGlobals()
  {
    DatingSaveData datingSaveData = new DatingSaveData();
    datingSaveData.affection = DatingGlobals.Affection;
    datingSaveData.affectionLevel = DatingGlobals.AffectionLevel;
    foreach (int complimentID in DatingGlobals.KeysOfComplimentGiven())
    {
      if (DatingGlobals.GetComplimentGiven(complimentID))
        datingSaveData.complimentGiven.Add(complimentID);
    }
    foreach (int checkID in DatingGlobals.KeysOfSuitorCheck())
    {
      if (DatingGlobals.GetSuitorCheck(checkID))
        datingSaveData.suitorCheck.Add(checkID);
    }
    datingSaveData.suitorProgress = DatingGlobals.SuitorProgress;
    foreach (int num in DatingGlobals.KeysOfSuitorTrait())
      datingSaveData.suitorTrait.Add(num, DatingGlobals.GetSuitorTrait(num));
    foreach (int topicID in DatingGlobals.KeysOfTopicDiscussed())
    {
      if (DatingGlobals.GetTopicDiscussed(topicID))
        datingSaveData.topicDiscussed.Add(topicID);
    }
    foreach (int num in DatingGlobals.KeysOfTraitDemonstrated())
      datingSaveData.traitDemonstrated.Add(num, DatingGlobals.GetTraitDemonstrated(num));
    return datingSaveData;
  }

  public static void WriteToGlobals(DatingSaveData data)
  {
    DatingGlobals.Affection = data.affection;
    DatingGlobals.AffectionLevel = data.affectionLevel;
    foreach (int complimentID in (HashSet<int>) data.complimentGiven)
      DatingGlobals.SetComplimentGiven(complimentID, true);
    foreach (int checkID in (HashSet<int>) data.suitorCheck)
      DatingGlobals.SetSuitorCheck(checkID, true);
    DatingGlobals.SuitorProgress = data.suitorProgress;
    foreach (KeyValuePair<int, int> keyValuePair in (Dictionary<int, int>) data.suitorTrait)
      DatingGlobals.SetSuitorTrait(keyValuePair.Key, keyValuePair.Value);
    foreach (int topicID in (HashSet<int>) data.topicDiscussed)
      DatingGlobals.SetTopicDiscussed(topicID, true);
    foreach (KeyValuePair<int, int> keyValuePair in (Dictionary<int, int>) data.traitDemonstrated)
      DatingGlobals.SetTraitDemonstrated(keyValuePair.Key, keyValuePair.Value);
  }
}
