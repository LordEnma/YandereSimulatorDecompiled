// Decompiled with JetBrains decompiler
// Type: ARMiyukiScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ARMiyukiScript : MonoBehaviour
{
  public Transform BulletSpawnPoint;
  public StudentScript MyStudent;
  public YandereScript Yandere;
  public GameObject Bullet;
  public Transform Enemy;
  public GameObject MagicalGirl;
  public bool Student;

  private void Start()
  {
    if (!((Object) this.Enemy == (Object) null) || !((Object) this.MyStudent.StudentManager != (Object) null))
      return;
    this.Enemy = this.MyStudent.StudentManager.MiyukiCat;
  }

  private void Update()
  {
    if (this.Student || !this.Yandere.AR || (double) Time.timeScale != 1.0)
      return;
    this.transform.LookAt(this.Enemy.position);
    if (!Input.GetButtonDown("X"))
      return;
    this.Shoot();
  }

  public void Shoot()
  {
    if ((Object) this.Enemy == (Object) null)
      this.Enemy = this.MyStudent.StudentManager.MiyukiCat;
    this.transform.LookAt(this.Enemy.position);
    Object.Instantiate<GameObject>(this.Bullet, this.BulletSpawnPoint.position, this.transform.rotation);
  }
}
