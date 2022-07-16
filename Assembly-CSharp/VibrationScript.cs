// Decompiled with JetBrains decompiler
// Type: VibrationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using XInputDotNetPure;

public class VibrationScript : MonoBehaviour
{
  public float Strength1;
  public float Strength2;
  public float TimeLimit;
  public float Timer;

  private void Start() => GamePad.SetVibration(PlayerIndex.One, this.Strength1, this.Strength2);

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= (double) this.TimeLimit)
      return;
    GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
    this.enabled = false;
  }
}
