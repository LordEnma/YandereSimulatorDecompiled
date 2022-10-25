// Decompiled with JetBrains decompiler
// Type: RealTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RealTime : MonoBehaviour
{
  public static float time => Time.unscaledTime;

  public static float deltaTime => Time.unscaledDeltaTime;
}
