using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000588 RID: 1416
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x060023E8 RID: 9192 RVA: 0x001F5CE4 File Offset: 0x001F3EE4
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x060023E9 RID: 9193 RVA: 0x001F5D17 File Offset: 0x001F3F17
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023EA RID: 9194 RVA: 0x001F5D39 File Offset: 0x001F3F39
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023EB RID: 9195 RVA: 0x001F5D5B File Offset: 0x001F3F5B
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060023EC RID: 9196 RVA: 0x001F5D64 File Offset: 0x001F3F64
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

		// Token: 0x060023ED RID: 9197 RVA: 0x001F5DC0 File Offset: 0x001F3FC0
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x060023EE RID: 9198 RVA: 0x001F5E13 File Offset: 0x001F4013
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004B96 RID: 19350
		public GameObject[] customerPrefabs;

		// Token: 0x04004B97 RID: 19351
		private float spawnRate = 10f;

		// Token: 0x04004B98 RID: 19352
		private float spawnVariance = 5f;

		// Token: 0x04004B99 RID: 19353
		private float timeTillSpawn;

		// Token: 0x04004B9A RID: 19354
		private int spawnedCustomers;

		// Token: 0x04004B9B RID: 19355
		private bool isPaused;
	}
}
