// Decompiled with JetBrains decompiler
// Type: MiyukiEnemyScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MiyukiEnemyScript : MonoBehaviour
{
  public float Float;
  public float Limit;
  public float Speed;
  public bool Dead;
  public bool Down;
  public GameObject DeathEffect;
  public GameObject HitEffect;
  public GameObject Enemy;
  public Transform[] SpawnPoints;
  public float RespawnTimer;
  public float Health;
  public int ID;

  private void Start()
  {
    this.transform.position = this.SpawnPoints[this.ID].position;
    this.transform.rotation = this.SpawnPoints[this.ID].rotation;
  }

  private void Update()
  {
    if (this.Enemy.activeInHierarchy)
    {
      if (!this.Down)
      {
        this.Float += Time.deltaTime * this.Speed;
        if ((double) this.Float > (double) this.Limit)
          this.Down = true;
      }
      else
      {
        this.Float -= Time.deltaTime * this.Speed;
        if ((double) this.Float < -1.0 * (double) this.Limit)
          this.Down = false;
      }
      this.Enemy.transform.position += new Vector3(0.0f, this.Float * Time.deltaTime, 0.0f);
      if ((double) this.Enemy.transform.position.y > (double) this.SpawnPoints[this.ID].position.y + 1.5)
        this.Enemy.transform.position = new Vector3(this.Enemy.transform.position.x, this.SpawnPoints[this.ID].position.y + 1.5f, this.Enemy.transform.position.z);
      if ((double) this.Enemy.transform.position.y >= (double) this.SpawnPoints[this.ID].position.y + 0.5)
        return;
      this.Enemy.transform.position = new Vector3(this.Enemy.transform.position.x, this.SpawnPoints[this.ID].position.y + 0.5f, this.Enemy.transform.position.z);
    }
    else
    {
      this.RespawnTimer += Time.deltaTime;
      if ((double) this.RespawnTimer <= 5.0)
        return;
      this.transform.position = this.SpawnPoints[this.ID].position;
      this.transform.rotation = this.SpawnPoints[this.ID].rotation;
      this.Enemy.SetActive(true);
      this.RespawnTimer = 0.0f;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!this.Enemy.activeInHierarchy || !(other.gameObject.tag == "missile"))
      return;
    Object.Instantiate<GameObject>(this.HitEffect, other.transform.position, Quaternion.identity);
    Object.Destroy((Object) other.gameObject);
    --this.Health;
    if ((double) this.Health != 0.0)
      return;
    Object.Instantiate<GameObject>(this.DeathEffect, other.transform.position, Quaternion.identity);
    this.Enemy.SetActive(false);
    this.Health = 50f;
    ++this.ID;
    if (this.ID < this.SpawnPoints.Length)
      return;
    this.ID = 0;
  }
}
