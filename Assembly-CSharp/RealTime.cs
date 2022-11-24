// Decompiled with JetBrains decompiler
// Type: RealTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RealTime : MonoBehaviour
{
  public static float time => Time.unscaledTime;

  public static float deltaTime => Time.unscaledDeltaTime;
}
