// Decompiled with JetBrains decompiler
// Type: YanSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public struct YanSaveData
{
  public string LoadedLevelName;
  public SerializedGameObject[] SerializedGameObjects;
  public SerializedStaticClass[] SerializedStaticClasses;
  public ValueDict SerializedPlayerPrefs;
}
