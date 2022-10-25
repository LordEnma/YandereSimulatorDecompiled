// Decompiled with JetBrains decompiler
// Type: GrowShrinkScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GrowShrinkScript : MonoBehaviour
{
  public float FallSpeed;
  public float Threshold = 1f;
  public float Slowdown = 0.5f;
  public float Strength = 1f;
  public float Target = 1f;
  public float Scale;
  public float Speed = 5f;
  public float Timer;
  public bool Shrink;
  public Vector3 OriginalPosition;

  private void Start()
  {
    this.OriginalPosition = this.transform.localPosition;
    this.transform.localScale = Vector3.zero;
  }

  private void Update()
  {
    this.Timer += Time.deltaTime * 2f;
    this.Scale += (float) ((double) Time.deltaTime * ((double) this.Strength * (double) this.Speed) * 2.0);
    if (!this.Shrink)
    {
      this.Strength += (float) ((double) Time.deltaTime * (double) this.Speed * 2.0);
      if ((double) this.Strength > (double) this.Threshold)
        this.Strength = this.Threshold;
      if ((double) this.Scale > (double) this.Target)
      {
        this.Threshold *= this.Slowdown;
        this.Shrink = true;
      }
    }
    else
    {
      this.Strength -= (float) ((double) Time.deltaTime * (double) this.Speed * 2.0);
      float num = this.Threshold * -1f;
      if ((double) this.Strength < (double) num)
        this.Strength = num;
      if ((double) this.Scale < (double) this.Target)
      {
        this.Threshold *= this.Slowdown;
        this.Shrink = false;
      }
    }
    if ((double) this.Timer > 3.3333299160003662)
    {
      this.FallSpeed += (float) ((double) Time.deltaTime * 10.0 * 2.0);
      this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - (float) ((double) this.FallSpeed * (double) this.FallSpeed * 2.0), this.transform.localPosition.z);
    }
    this.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
  }

  public void Return()
  {
    this.transform.localPosition = this.OriginalPosition;
    this.transform.localScale = Vector3.zero;
    this.FallSpeed = 0.0f;
    this.Threshold = 1f;
    this.Slowdown = 0.5f;
    this.Strength = 1f;
    this.Target = 1f;
    this.Scale = 0.0f;
    this.Speed = 5f;
    this.Timer = 0.0f;
    this.gameObject.SetActive(false);
  }
}
