// Decompiled with JetBrains decompiler
// Type: TopicJson
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
public class TopicJson : JsonData
{
  [SerializeField]
  private int[] topics;

  public static string FilePath => !GameGlobals.Eighties ? Path.Combine(JsonData.FolderPath, "Topics.json") : Path.Combine(JsonData.FolderPath, "EightiesTopics.json");

  public static TopicJson[] LoadFromJson(string path)
  {
    TopicJson[] topicJsonArray = new TopicJson[101];
    foreach (Dictionary<string, object> d in JsonData.Deserialize(path))
    {
      int index1 = TFUtils.LoadInt(d, "ID");
      if (index1 != 0)
      {
        topicJsonArray[index1] = new TopicJson();
        TopicJson topicJson = topicJsonArray[index1];
        topicJson.topics = new int[26];
        for (int index2 = 1; index2 <= 25; ++index2)
          topicJson.topics[index2] = TFUtils.LoadInt(d, index2.ToString());
      }
      else
        break;
    }
    return topicJsonArray;
  }

  public int[] Topics => this.topics;
}
