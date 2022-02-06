using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058B RID: 1419
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x06002401 RID: 9217 RVA: 0x001F8700 File Offset: 0x001F6900
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x06002402 RID: 9218 RVA: 0x001F8733 File Offset: 0x001F6933
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002403 RID: 9219 RVA: 0x001F8755 File Offset: 0x001F6955
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002404 RID: 9220 RVA: 0x001F8777 File Offset: 0x001F6977
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002405 RID: 9221 RVA: 0x001F8780 File Offset: 0x001F6980
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

		// Token: 0x06002406 RID: 9222 RVA: 0x001F87DC File Offset: 0x001F69DC
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x06002407 RID: 9223 RVA: 0x001F882F File Offset: 0x001F6A2F
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004BCE RID: 19406
		public GameObject[] customerPrefabs;

		// Token: 0x04004BCF RID: 19407
		private float spawnRate = 10f;

		// Token: 0x04004BD0 RID: 19408
		private float spawnVariance = 5f;

		// Token: 0x04004BD1 RID: 19409
		private float timeTillSpawn;

		// Token: 0x04004BD2 RID: 19410
		private int spawnedCustomers;

		// Token: 0x04004BD3 RID: 19411
		private bool isPaused;
	}
}
