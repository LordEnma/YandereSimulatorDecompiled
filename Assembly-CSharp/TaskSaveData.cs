// Decompiled with JetBrains decompiler
// Type: TaskSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

[Serializable]
public class TaskSaveData
{
  public IntHashSet guitarPhoto = new IntHashSet();
  public IntHashSet kittenPhoto = new IntHashSet();
  public IntHashSet horudaPhoto = new IntHashSet();
  public IntAndIntDictionary taskStatus = new IntAndIntDictionary();

  public static TaskSaveData ReadFromGlobals()
  {
    TaskSaveData taskSaveData = new TaskSaveData();
    foreach (int photoID in TaskGlobals.KeysOfGuitarPhoto())
    {
      if (TaskGlobals.GetGuitarPhoto(photoID))
        taskSaveData.guitarPhoto.Add(photoID);
    }
    foreach (int photoID in TaskGlobals.KeysOfKittenPhoto())
    {
      if (TaskGlobals.GetKittenPhoto(photoID))
        taskSaveData.kittenPhoto.Add(photoID);
    }
    foreach (int photoID in TaskGlobals.KeysOfHorudaPhoto())
    {
      if (TaskGlobals.GetHorudaPhoto(photoID))
        taskSaveData.horudaPhoto.Add(photoID);
    }
    foreach (int keysOfTaskStatu in TaskGlobals.KeysOfTaskStatus())
      taskSaveData.taskStatus.Add(keysOfTaskStatu, TaskGlobals.GetTaskStatus(keysOfTaskStatu));
    return taskSaveData;
  }

  public static void WriteToGlobals(TaskSaveData data)
  {
    foreach (int photoID in (HashSet<int>) data.kittenPhoto)
      TaskGlobals.SetKittenPhoto(photoID, true);
    foreach (int photoID in (HashSet<int>) data.guitarPhoto)
      TaskGlobals.SetGuitarPhoto(photoID, true);
    foreach (KeyValuePair<int, int> taskStatu in (Dictionary<int, int>) data.taskStatus)
      TaskGlobals.SetTaskStatus(taskStatu.Key, taskStatu.Value);
  }
}
