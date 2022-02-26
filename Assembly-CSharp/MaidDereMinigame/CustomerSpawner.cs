using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058D RID: 1421
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x06002411 RID: 9233 RVA: 0x001F9794 File Offset: 0x001F7994
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x06002412 RID: 9234 RVA: 0x001F97C7 File Offset: 0x001F79C7
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002413 RID: 9235 RVA: 0x001F97E9 File Offset: 0x001F79E9
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002414 RID: 9236 RVA: 0x001F980B File Offset: 0x001F7A0B
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002415 RID: 9237 RVA: 0x001F9814 File Offset: 0x001F7A14
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

		// Token: 0x06002416 RID: 9238 RVA: 0x001F9870 File Offset: 0x001F7A70
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x06002417 RID: 9239 RVA: 0x001F98C3 File Offset: 0x001F7AC3
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004BE7 RID: 19431
		public GameObject[] customerPrefabs;

		// Token: 0x04004BE8 RID: 19432
		private float spawnRate = 10f;

		// Token: 0x04004BE9 RID: 19433
		private float spawnVariance = 5f;

		// Token: 0x04004BEA RID: 19434
		private float timeTillSpawn;

		// Token: 0x04004BEB RID: 19435
		private int spawnedCustomers;

		// Token: 0x04004BEC RID: 19436
		private bool isPaused;
	}
}
