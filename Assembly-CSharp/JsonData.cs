// Decompiled with JetBrains decompiler
// Type: JsonData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using JsonFx.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class JsonData
{
  protected static string FolderPath => Path.Combine(Application.streamingAssetsPath, "JSON");

  protected static Dictionary<string, object>[] Deserialize(string filename) => JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
}
