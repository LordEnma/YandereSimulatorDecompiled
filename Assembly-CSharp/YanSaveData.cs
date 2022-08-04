// Decompiled with JetBrains decompiler
// Type: YanSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
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
