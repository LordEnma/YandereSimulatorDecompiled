// Decompiled with JetBrains decompiler
// Type: MGPMSpawnerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MGPMSpawnerScript : MonoBehaviour
{
  public MGPMManagerScript GameplayManager;
  public MGPMMiyukiScript Miyuki;
  public Transform[] SpawnPositions;
  public float[] SpawnTimers;
  public int[] SpawnEnemies;
  public GameObject[] LoadBearer;
  public GameObject[] Enemy;
  public Transform HealthBar;
  public float SpawnRate;
  public float Timer;
  public bool RandomMode;
  public int Wave;
  public int ID;

  private void Start()
  {
    if (this.Wave != 8 && this.Wave != 9)
      return;
    for (this.ID = 1; this.ID < 100; ++this.ID)
      this.SpawnTimers[this.ID] = this.SpawnTimers[this.ID - 1] + 0.1f;
    this.ID = 0;
  }

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if (this.ID < this.SpawnTimers.Length)
    {
      if ((double) this.Timer <= (double) this.SpawnTimers[this.ID])
        return;
      GameObject gameObject = Object.Instantiate<GameObject>(this.Enemy[this.SpawnEnemies[this.ID]], this.transform.position, Quaternion.identity);
      gameObject.transform.parent = this.transform.parent;
      gameObject.transform.localScale = this.SpawnEnemies[this.ID] == 4 || this.SpawnEnemies[this.ID] == 11 ? new Vector3(1f, 1f, 1f) : (this.SpawnEnemies[this.ID] == 6 || this.SpawnEnemies[this.ID] == 9 || this.SpawnEnemies[this.ID] == 12 ? new Vector3(128f, 128f, 1f) : new Vector3(64f, 64f, 1f));
      gameObject.transform.position = this.SpawnPositions[this.ID].position;
      MGPMEnemyScript component = gameObject.GetComponent<MGPMEnemyScript>();
      component.GameplayManager = this.GameplayManager;
      component.Miyuki = this.Miyuki;
      if (this.Wave == 9)
      {
        if (this.ID < 100)
          this.SpawnPositions[this.ID].localPosition = new Vector3(Random.Range(-100f, 100f), 0.0f, 0.0f);
        else if (this.ID == 100)
          this.LoadBearer[1] = gameObject;
        else if (this.ID == 101)
          this.LoadBearer[2] = gameObject;
      }
      ++this.ID;
    }
    else
    {
      if (this.Wave != 9 || !((Object) this.LoadBearer[1] == (Object) null) || !((Object) this.LoadBearer[2] == (Object) null))
        return;
      this.GameplayManager.Jukebox.volume = Mathf.MoveTowards(this.GameplayManager.Jukebox.volume, 0.0f, Time.deltaTime * 0.5f);
      if ((double) this.GameplayManager.Jukebox.volume != 0.0)
        return;
      GameObject gameObject = Object.Instantiate<GameObject>(this.Enemy[this.SpawnEnemies[this.ID]], this.transform.position, Quaternion.identity);
      gameObject.transform.parent = this.transform.parent;
      gameObject.transform.localScale = new Vector3(256f, 128f, 1f);
      gameObject.transform.position = this.SpawnPositions[this.ID].position;
      MGPMEnemyScript component = gameObject.GetComponent<MGPMEnemyScript>();
      component.GameplayManager = this.GameplayManager;
      component.HealthBar = this.HealthBar;
      component.Miyuki = this.Miyuki;
      this.HealthBar.parent.gameObject.SetActive(true);
      this.GameplayManager.Jukebox.clip = this.GameplayManager.FinalBoss;
      this.GameplayManager.Jukebox.volume = 0.5f;
      this.GameplayManager.Jukebox.Play();
      this.enabled = false;
    }
  }
}
