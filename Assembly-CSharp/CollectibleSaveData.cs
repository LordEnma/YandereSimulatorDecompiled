// Decompiled with JetBrains decompiler
// Type: CollectibleSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

[Serializable]
public class CollectibleSaveData
{
  public IntHashSet basementTapeCollected = new IntHashSet();
  public IntHashSet basementTapeListened = new IntHashSet();
  public IntHashSet mangaCollected = new IntHashSet();
  public IntHashSet tapeCollected = new IntHashSet();
  public IntHashSet tapeListened = new IntHashSet();

  public static CollectibleSaveData ReadFromGlobals()
  {
    CollectibleSaveData collectibleSaveData = new CollectibleSaveData();
    foreach (int tapeID in CollectibleGlobals.KeysOfBasementTapeCollected())
    {
      if (CollectibleGlobals.GetBasementTapeCollected(tapeID))
        collectibleSaveData.basementTapeCollected.Add(tapeID);
    }
    foreach (int tapeID in CollectibleGlobals.KeysOfBasementTapeListened())
    {
      if (CollectibleGlobals.GetBasementTapeListened(tapeID))
        collectibleSaveData.basementTapeListened.Add(tapeID);
    }
    foreach (int mangaID in CollectibleGlobals.KeysOfMangaCollected())
    {
      if (CollectibleGlobals.GetMangaCollected(mangaID))
        collectibleSaveData.mangaCollected.Add(mangaID);
    }
    foreach (int tapeID in CollectibleGlobals.KeysOfTapeCollected())
    {
      if (CollectibleGlobals.GetTapeCollected(tapeID))
        collectibleSaveData.tapeCollected.Add(tapeID);
    }
    foreach (int tapeID in CollectibleGlobals.KeysOfTapeListened())
    {
      if (CollectibleGlobals.GetTapeListened(tapeID))
        collectibleSaveData.tapeListened.Add(tapeID);
    }
    return collectibleSaveData;
  }

  public static void WriteToGlobals(CollectibleSaveData data)
  {
    foreach (int tapeID in (HashSet<int>) data.basementTapeCollected)
      CollectibleGlobals.SetBasementTapeCollected(tapeID, true);
    foreach (int tapeID in (HashSet<int>) data.basementTapeListened)
      CollectibleGlobals.SetBasementTapeListened(tapeID, true);
    foreach (int mangaID in (HashSet<int>) data.mangaCollected)
      CollectibleGlobals.SetMangaCollected(mangaID, true);
    foreach (int tapeID in (HashSet<int>) data.tapeCollected)
      CollectibleGlobals.SetTapeCollected(tapeID, true);
    foreach (int tapeID in (HashSet<int>) data.tapeListened)
      CollectibleGlobals.SetTapeListened(tapeID, true);
  }
}
