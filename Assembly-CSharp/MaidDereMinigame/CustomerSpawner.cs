using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059A RID: 1434
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x06002463 RID: 9315 RVA: 0x00201A10 File Offset: 0x001FFC10
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x06002464 RID: 9316 RVA: 0x00201A43 File Offset: 0x001FFC43
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002465 RID: 9317 RVA: 0x00201A65 File Offset: 0x001FFC65
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002466 RID: 9318 RVA: 0x00201A87 File Offset: 0x001FFC87
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x00201A90 File Offset: 0x001FFC90
		private void Update()
		{
			if (this.isPaused)
			{
				return;
			}
			if (this.timeTillSpawn <= 0f)
			{
				this.timeTillSpawn = this.spawnRate + UnityEngine.Random.Range(-this.spawnVariance, this.spawnVariance);
				this.SpawnCustomer();
				return;
			}
			this.timeTillSpawn -= Time.deltaTime;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x00201AEC File Offset: 0x001FFCEC
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x06002469 RID: 9321 RVA: 0x00201B3F File Offset: 0x001FFD3F
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004CF1 RID: 19697
		public GameObject[] customerPrefabs;

		// Token: 0x04004CF2 RID: 19698
		private float spawnRate = 10f;

		// Token: 0x04004CF3 RID: 19699
		private float spawnVariance = 5f;

		// Token: 0x04004CF4 RID: 19700
		private float timeTillSpawn;

		// Token: 0x04004CF5 RID: 19701
		private int spawnedCustomers;

		// Token: 0x04004CF6 RID: 19702
		private bool isPaused;
	}
}
