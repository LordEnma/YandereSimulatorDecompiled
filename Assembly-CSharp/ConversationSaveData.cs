﻿// Decompiled with JetBrains decompiler
// Type: ConversationSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

[Serializable]
public class ConversationSaveData
{
  public IntHashSet topicDiscovered = new IntHashSet();
  public IntAndIntPairHashSet topicLearnedByStudent = new IntAndIntPairHashSet();

  public static ConversationSaveData ReadFromGlobals()
  {
    ConversationSaveData conversationSaveData = new ConversationSaveData();
    foreach (int topicID in ConversationGlobals.KeysOfTopicDiscovered())
    {
      if (ConversationGlobals.GetTopicDiscovered(topicID))
        conversationSaveData.topicDiscovered.Add(topicID);
    }
    foreach (IntAndIntPair intAndIntPair in ConversationGlobals.KeysOfTopicLearnedByStudent())
    {
      if (ConversationGlobals.GetTopicLearnedByStudent(intAndIntPair.first, intAndIntPair.second))
        conversationSaveData.topicLearnedByStudent.Add(intAndIntPair);
    }
    return conversationSaveData;
  }

  public static void WriteToGlobals(ConversationSaveData data)
  {
    foreach (int topicID in (HashSet<int>) data.topicDiscovered)
      ConversationGlobals.SetTopicDiscovered(topicID, true);
    foreach (IntAndIntPair intAndIntPair in (HashSet<IntAndIntPair>) data.topicLearnedByStudent)
      ConversationGlobals.SetTopicLearnedByStudent(intAndIntPair.first, intAndIntPair.second, true);
  }
}
