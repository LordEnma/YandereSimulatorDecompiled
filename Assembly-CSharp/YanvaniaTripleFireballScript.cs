// Decompiled with JetBrains decompiler
// Type: YanvaniaTripleFireballScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaTripleFireballScript : MonoBehaviour
{
  public Transform[] Fireballs;
  public Transform Dracula;
  public int Direction;
  public float Speed;
  public float Timer;

  private void Start() => this.Direction = (double) this.Dracula.position.x > (double) this.transform.position.x ? -1 : 1;

  private void Update()
  {
    Transform fireball1 = this.Fireballs[1];
    Transform fireball2 = this.Fireballs[2];
    Transform fireball3 = this.Fireballs[3];
    if ((Object) fireball1 != (Object) null)
      fireball1.position = new Vector3(fireball1.position.x, Mathf.MoveTowards(fireball1.position.y, 7.5f, Time.deltaTime * this.Speed), fireball1.position.z);
    if ((Object) fireball2 != (Object) null)
      fireball2.position = new Vector3(fireball2.position.x, Mathf.MoveTowards(fireball2.position.y, 7.16666f, Time.deltaTime * this.Speed), fireball2.position.z);
    if ((Object) fireball3 != (Object) null)
      fireball3.position = new Vector3(fireball3.position.x, Mathf.MoveTowards(fireball3.position.y, 6.83333f, Time.deltaTime * this.Speed), fireball3.position.z);
    for (int index = 1; index < 4; ++index)
    {
      Transform fireball4 = this.Fireballs[index];
      if ((Object) fireball4 != (Object) null)
        fireball4.position = new Vector3(fireball4.position.x + (float) this.Direction * Time.deltaTime * this.Speed, fireball4.position.y, fireball4.position.z);
    }
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= 10.0)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
