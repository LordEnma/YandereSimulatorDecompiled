// Decompiled with JetBrains decompiler
// Type: MGPMProjectileScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MGPMProjectileScript : MonoBehaviour
{
  public Transform Sprite;
  public int Angle;
  public float Speed;
  public bool Eighties;

  private void Start()
  {
    if (!this.Eighties)
      return;
    this.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
  }

  private void Update()
  {
    if (this.gameObject.layer == 8)
      this.transform.Translate(Vector3.up * Time.deltaTime * this.Speed);
    else
      this.transform.Translate(Vector3.forward * Time.deltaTime * this.Speed);
    if (this.Angle == 1)
      this.transform.Translate(Vector3.right * Time.deltaTime * this.Speed * 0.2f);
    else if (this.Angle == -1)
      this.transform.Translate(Vector3.right * Time.deltaTime * this.Speed * -0.2f);
    if ((double) this.transform.localPosition.y <= 300.0 && (double) this.transform.localPosition.y >= -300.0 && (double) this.transform.localPosition.x <= 134.0 && (double) this.transform.localPosition.x >= -134.0)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
