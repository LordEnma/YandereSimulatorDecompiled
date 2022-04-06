using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000598 RID: 1432
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x06002447 RID: 9287 RVA: 0x001FDE74 File Offset: 0x001FC074
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x06002448 RID: 9288 RVA: 0x001FDEA7 File Offset: 0x001FC0A7
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002449 RID: 9289 RVA: 0x001FDEC9 File Offset: 0x001FC0C9
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600244A RID: 9290 RVA: 0x001FDEEB File Offset: 0x001FC0EB
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600244B RID: 9291 RVA: 0x001FDEF4 File Offset: 0x001FC0F4
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

		// Token: 0x0600244C RID: 9292 RVA: 0x001FDF50 File Offset: 0x001FC150
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x0600244D RID: 9293 RVA: 0x001FDFA3 File Offset: 0x001FC1A3
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004C99 RID: 19609
		public GameObject[] customerPrefabs;

		// Token: 0x04004C9A RID: 19610
		private float spawnRate = 10f;

		// Token: 0x04004C9B RID: 19611
		private float spawnVariance = 5f;

		// Token: 0x04004C9C RID: 19612
		private float timeTillSpawn;

		// Token: 0x04004C9D RID: 19613
		private int spawnedCustomers;

		// Token: 0x04004C9E RID: 19614
		private bool isPaused;
	}
}
