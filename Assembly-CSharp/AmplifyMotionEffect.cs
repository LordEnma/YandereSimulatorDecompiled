// Decompiled with JetBrains decompiler
// Type: AmplifyMotionEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (Camera))]
[AddComponentMenu("Image Effects/Amplify Motion")]
public class AmplifyMotionEffect : AmplifyMotionEffectBase
{
  public static AmplifyMotionEffect FirstInstance => (AmplifyMotionEffect) AmplifyMotionEffectBase.FirstInstance;

  public static AmplifyMotionEffect Instance => (AmplifyMotionEffect) AmplifyMotionEffectBase.Instance;
}
