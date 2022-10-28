// Decompiled with JetBrains decompiler
// Type: AmplifyMotionEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (Camera))]
[AddComponentMenu("Image Effects/Amplify Motion")]
public class AmplifyMotionEffect : AmplifyMotionEffectBase
{
  public static AmplifyMotionEffect FirstInstance => (AmplifyMotionEffect) AmplifyMotionEffectBase.FirstInstance;

  public static AmplifyMotionEffect Instance => (AmplifyMotionEffect) AmplifyMotionEffectBase.Instance;
}
