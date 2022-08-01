// Decompiled with JetBrains decompiler
// Type: VibrationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
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
