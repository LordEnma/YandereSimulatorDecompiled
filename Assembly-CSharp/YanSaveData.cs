// Decompiled with JetBrains decompiler
// Type: YanSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public struct YanSaveData
{
  public string LoadedLevelName;
  public SerializedGameObject[] SerializedGameObjects;
  public SerializedStaticClass[] SerializedStaticClasses;
  public ValueDict SerializedPlayerPrefs;
}
