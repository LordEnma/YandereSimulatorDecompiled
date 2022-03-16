using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000592 RID: 1426
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x0600242F RID: 9263 RVA: 0x001FC0D4 File Offset: 0x001FA2D4
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x06002430 RID: 9264 RVA: 0x001FC107 File Offset: 0x001FA307
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002431 RID: 9265 RVA: 0x001FC129 File Offset: 0x001FA329
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002432 RID: 9266 RVA: 0x001FC14B File Offset: 0x001FA34B
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002433 RID: 9267 RVA: 0x001FC154 File Offset: 0x001FA354
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

		// Token: 0x06002434 RID: 9268 RVA: 0x001FC1B0 File Offset: 0x001FA3B0
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x06002435 RID: 9269 RVA: 0x001FC203 File Offset: 0x001FA403
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004C63 RID: 19555
		public GameObject[] customerPrefabs;

		// Token: 0x04004C64 RID: 19556
		private float spawnRate = 10f;

		// Token: 0x04004C65 RID: 19557
		private float spawnVariance = 5f;

		// Token: 0x04004C66 RID: 19558
		private float timeTillSpawn;

		// Token: 0x04004C67 RID: 19559
		private int spawnedCustomers;

		// Token: 0x04004C68 RID: 19560
		private bool isPaused;
	}
}
