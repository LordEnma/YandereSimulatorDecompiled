// Decompiled with JetBrains decompiler
// Type: WritheScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WritheScript : MonoBehaviour
{
  public float Rotation;
  public float StartTime;
  public float Duration;
  public float StartValue;
  public float EndValue;
  public int ID;
  public bool SpecialCase;

  private void Start()
  {
    this.StartTime = Time.time;
    this.Duration = Random.Range(1f, 5f);
  }

  private void Update()
  {
    if ((double) this.Rotation == (double) this.EndValue)
    {
      this.StartValue = this.EndValue;
      this.EndValue = Random.Range(-45f, 45f);
      this.StartTime = Time.time;
      this.Duration = Random.Range(1f, 5f);
    }
    this.Rotation = Mathf.SmoothStep(this.StartValue, this.EndValue, (Time.time - this.StartTime) / this.Duration);
    switch (this.ID)
    {
      case 1:
        this.transform.localEulerAngles = new Vector3(this.Rotation, this.transform.localEulerAngles.y, this.transform.localEulerAngles.z);
        break;
      case 2:
        if (this.SpecialCase)
          this.Rotation += 180f;
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.Rotation, this.transform.localEulerAngles.z);
        break;
      case 3:
        this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, this.Rotation);
        break;
    }
  }
}
