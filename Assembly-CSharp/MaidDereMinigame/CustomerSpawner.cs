using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058E RID: 1422
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x06002417 RID: 9239 RVA: 0x001FA16C File Offset: 0x001F836C
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x06002418 RID: 9240 RVA: 0x001FA19F File Offset: 0x001F839F
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002419 RID: 9241 RVA: 0x001FA1C1 File Offset: 0x001F83C1
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600241A RID: 9242 RVA: 0x001FA1E3 File Offset: 0x001F83E3
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600241B RID: 9243 RVA: 0x001FA1EC File Offset: 0x001F83EC
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

		// Token: 0x0600241C RID: 9244 RVA: 0x001FA248 File Offset: 0x001F8448
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x0600241D RID: 9245 RVA: 0x001FA29B File Offset: 0x001F849B
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004C04 RID: 19460
		public GameObject[] customerPrefabs;

		// Token: 0x04004C05 RID: 19461
		private float spawnRate = 10f;

		// Token: 0x04004C06 RID: 19462
		private float spawnVariance = 5f;

		// Token: 0x04004C07 RID: 19463
		private float timeTillSpawn;

		// Token: 0x04004C08 RID: 19464
		private int spawnedCustomers;

		// Token: 0x04004C09 RID: 19465
		private bool isPaused;
	}
}
