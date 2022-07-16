// Decompiled with JetBrains decompiler
// Type: GrandfatherScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GrandfatherScript : MonoBehaviour
{
  public ClockScript Clock;
  public Transform MinuteHand;
  public Transform HourHand;
  public Transform Pendulum;
  public float Rotation;
  public float Force;
  public float Speed;
  public bool Flip;

  private void Update()
  {
    if (!this.Flip)
    {
      if ((double) this.Force < 0.1)
        this.Force += Time.deltaTime * 0.1f * this.Speed;
    }
    else if ((double) this.Force > -0.1)
      this.Force -= Time.deltaTime * 0.1f * this.Speed;
    this.Rotation += this.Force;
    if ((double) this.Rotation > 1.0)
      this.Flip = true;
    else if ((double) this.Rotation < -1.0)
      this.Flip = false;
    if ((double) this.Rotation > 5.0)
      this.Rotation = 5f;
    else if ((double) this.Rotation < -5.0)
      this.Rotation = -5f;
    this.Pendulum.localEulerAngles = new Vector3(0.0f, 0.0f, this.Rotation);
    this.MinuteHand.localEulerAngles = new Vector3(this.MinuteHand.localEulerAngles.x, this.MinuteHand.localEulerAngles.y, this.Clock.Minute * 6f);
    this.HourHand.localEulerAngles = new Vector3(this.HourHand.localEulerAngles.x, this.HourHand.localEulerAngles.y, this.Clock.Hour * 30f);
  }
}
