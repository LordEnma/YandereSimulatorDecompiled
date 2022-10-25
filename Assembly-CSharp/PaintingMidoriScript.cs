// Decompiled with JetBrains decompiler
// Type: PaintingMidoriScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PaintingMidoriScript : MonoBehaviour
{
  public Animation Anim;
  public float Rotation;
  public int ID;

  private void Update()
  {
    if (Input.GetKeyDown("z"))
      ++this.ID;
    if (this.ID == 0)
      this.Anim.CrossFade("f02_painting_00");
    else if (this.ID == 1)
    {
      this.Anim.CrossFade("f02_shock_00");
      this.Rotation = Mathf.Lerp(this.Rotation, -180f, Time.deltaTime * 10f);
    }
    else if (this.ID == 2)
      this.transform.position -= new Vector3(Time.deltaTime * 2f, 0.0f, 0.0f);
    this.transform.localEulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
  }
}
