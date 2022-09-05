// Decompiled with JetBrains decompiler
// Type: CameraMoveScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CameraMoveScript : MonoBehaviour
{
  public Transform StartPos;
  public Transform EndPos;
  public Transform RightDoor;
  public Transform LeftDoor;
  public Transform Target;
  public bool OpenDoors;
  public bool Begin;
  public float Speed;
  public float Timer;

  private void Start()
  {
    this.transform.position = this.StartPos.position;
    this.transform.rotation = this.StartPos.rotation;
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
      this.Begin = true;
    if (!this.Begin)
      return;
    this.Timer += Time.deltaTime * this.Speed;
    if ((double) this.Timer > 0.10000000149011612)
    {
      this.OpenDoors = true;
      if ((Object) this.LeftDoor != (Object) null)
      {
        this.LeftDoor.transform.localPosition = new Vector3(Mathf.Lerp(this.LeftDoor.transform.localPosition.x, 1f, Time.deltaTime), this.LeftDoor.transform.localPosition.y, this.LeftDoor.transform.localPosition.z);
        this.RightDoor.transform.localPosition = new Vector3(Mathf.Lerp(this.RightDoor.transform.localPosition.x, -1f, Time.deltaTime), this.RightDoor.transform.localPosition.y, this.RightDoor.transform.localPosition.z);
      }
    }
    this.transform.position = Vector3.Lerp(this.transform.position, this.EndPos.position, Time.deltaTime * this.Timer);
    this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.EndPos.rotation, Time.deltaTime * this.Timer);
  }

  private void LateUpdate()
  {
    if (!((Object) this.Target != (Object) null))
      return;
    this.transform.LookAt(this.Target);
  }
}
