// Decompiled with JetBrains decompiler
// Type: AmplifyMotionEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (Camera))]
[AddComponentMenu("Image Effects/Amplify Motion")]
public class AmplifyMotionEffect : AmplifyMotionEffectBase
{
  public static AmplifyMotionEffect FirstInstance => (AmplifyMotionEffect) AmplifyMotionEffectBase.FirstInstance;

  public static AmplifyMotionEffect Instance => (AmplifyMotionEffect) AmplifyMotionEffectBase.Instance;
}
