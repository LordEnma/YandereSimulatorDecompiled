using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000588 RID: 1416
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x060023EB RID: 9195 RVA: 0x001F62D4 File Offset: 0x001F44D4
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x060023EC RID: 9196 RVA: 0x001F6307 File Offset: 0x001F4507
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023ED RID: 9197 RVA: 0x001F6329 File Offset: 0x001F4529
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023EE RID: 9198 RVA: 0x001F634B File Offset: 0x001F454B
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060023EF RID: 9199 RVA: 0x001F6354 File Offset: 0x001F4554
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

		// Token: 0x060023F0 RID: 9200 RVA: 0x001F63B0 File Offset: 0x001F45B0
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x060023F1 RID: 9201 RVA: 0x001F6403 File Offset: 0x001F4603
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004B9F RID: 19359
		public GameObject[] customerPrefabs;

		// Token: 0x04004BA0 RID: 19360
		private float spawnRate = 10f;

		// Token: 0x04004BA1 RID: 19361
		private float spawnVariance = 5f;

		// Token: 0x04004BA2 RID: 19362
		private float timeTillSpawn;

		// Token: 0x04004BA3 RID: 19363
		private int spawnedCustomers;

		// Token: 0x04004BA4 RID: 19364
		private bool isPaused;
	}
}
