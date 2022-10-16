// Decompiled with JetBrains decompiler
// Type: JsonData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using JsonFx.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class JsonData
{
  protected static string FolderPath => Path.Combine(Application.streamingAssetsPath, "JSON");

  protected static Dictionary<string, object>[] Deserialize(string filename) => JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
}
