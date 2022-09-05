// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.CustomerSpawner
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  public class CustomerSpawner : MonoBehaviour
  {
    public GameObject[] customerPrefabs;
    private float spawnRate = 10f;
    private float spawnVariance = 5f;
    private float timeTillSpawn;
    private int spawnedCustomers;
    private bool isPaused;

    private void Start()
    {
      this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
      this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
      this.isPaused = true;
    }

    private void OnEnable() => GameController.PauseGame += new BoolParameterEvent(this.Pause);

    private void OnDisable() => GameController.PauseGame -= new BoolParameterEvent(this.Pause);

    public void Pause(bool toPause) => this.isPaused = toPause;

    private void Update()
    {
      if (this.isPaused)
        return;
      if ((double) this.timeTillSpawn <= 0.0)
      {
        this.timeTillSpawn = this.spawnRate + Random.Range(-this.spawnVariance, this.spawnVariance);
        this.SpawnCustomer();
      }
      else
        this.timeTillSpawn -= Time.deltaTime;
    }

    private void SpawnCustomer()
    {
      GameObject gameObject = Object.Instantiate<GameObject>(this.customerPrefabs[Random.Range(0, this.customerPrefabs.Length)]);
      gameObject.transform.position = this.transform.position;
      AIController component = gameObject.GetComponent<AIController>();
      component.Init();
      component.leaveTarget = this.transform;
    }

    public void OpenDoor() => this.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
  }
}
