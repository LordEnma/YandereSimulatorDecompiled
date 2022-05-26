// Decompiled with JetBrains decompiler
// Type: InfoChanWindowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class InfoChanWindowScript : MonoBehaviour
{
  public DropsScript DropMenu;
  public Transform DropPoint;
  public GameObject[] Drops;
  public int[] ItemsToDrop;
  public int Orders;
  public int ID;
  public float Rotation;
  public float Timer;
  public bool Dropped;
  public bool Drop;
  public bool Test;
  public bool Open = true;

  private void Update()
  {
    if (this.Drop)
    {
      this.Rotation = Mathf.Lerp(this.Rotation, this.Drop ? -90f : 0.0f, Time.deltaTime * 10f);
      this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, this.Rotation, this.transform.localEulerAngles.z);
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 1.0)
      {
        if ((double) this.Orders > 0.0)
        {
          Object.Instantiate<GameObject>(this.Drops[this.ItemsToDrop[this.Orders]], this.DropPoint.position, Quaternion.identity).name = this.DropMenu.DropNames[this.ItemsToDrop[this.Orders]];
          this.Timer = 0.0f;
          --this.Orders;
        }
        else
        {
          this.Open = false;
          if ((double) this.Timer > 3.0)
          {
            this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x, 0.0f, this.transform.localEulerAngles.z);
            this.Drop = false;
          }
        }
      }
    }
    if (!this.Test)
      return;
    this.DropObject();
  }

  public void DropObject()
  {
    this.Rotation = 0.0f;
    this.Timer = 0.0f;
    this.Dropped = false;
    this.Test = false;
    this.Drop = true;
    this.Open = true;
  }
}
