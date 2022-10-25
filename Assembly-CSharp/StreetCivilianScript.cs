// Decompiled with JetBrains decompiler
// Type: StreetCivilianScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using Pathfinding;
using UnityEngine;

public class StreetCivilianScript : MonoBehaviour
{
  public CharacterController MyController;
  public Animation MyAnimation;
  public AIPath Pathfinding;
  public Transform[] Destinations;
  public float Timer;
  public int ID;

  private void Start() => this.Pathfinding.target = this.Destinations[0];

  private void Update()
  {
    if ((double) Vector3.Distance(this.transform.position, this.Destinations[this.ID].position) >= 0.550000011920929)
      return;
    this.MoveTowardsTarget(this.Destinations[this.ID].position);
    this.MyAnimation.CrossFade("f02_idle_00");
    this.Pathfinding.canSearch = false;
    this.Pathfinding.canMove = false;
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 13.5)
      return;
    this.MyAnimation.CrossFade("f02_newWalk_00");
    ++this.ID;
    if (this.ID == this.Destinations.Length)
      this.ID = 0;
    this.Pathfinding.target = this.Destinations[this.ID];
    this.Pathfinding.canSearch = true;
    this.Pathfinding.canMove = true;
    this.Timer = 0.0f;
  }

  public void MoveTowardsTarget(Vector3 target)
  {
    Vector3 vector3 = target - this.transform.position;
    if ((double) vector3.sqrMagnitude > 9.9999999747524271E-07)
    {
      int num = (int) this.MyController.Move(vector3 * (Time.deltaTime * 1f / Time.timeScale));
    }
    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.Destinations[this.ID].rotation, 10f * Time.deltaTime);
  }
}
