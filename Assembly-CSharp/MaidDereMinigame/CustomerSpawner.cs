using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000597 RID: 1431
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x0600243F RID: 9279 RVA: 0x001FD944 File Offset: 0x001FBB44
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x06002440 RID: 9280 RVA: 0x001FD977 File Offset: 0x001FBB77
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x001FD999 File Offset: 0x001FBB99
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002442 RID: 9282 RVA: 0x001FD9BB File Offset: 0x001FBBBB
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002443 RID: 9283 RVA: 0x001FD9C4 File Offset: 0x001FBBC4
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

		// Token: 0x06002444 RID: 9284 RVA: 0x001FDA20 File Offset: 0x001FBC20
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x06002445 RID: 9285 RVA: 0x001FDA73 File Offset: 0x001FBC73
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004C95 RID: 19605
		public GameObject[] customerPrefabs;

		// Token: 0x04004C96 RID: 19606
		private float spawnRate = 10f;

		// Token: 0x04004C97 RID: 19607
		private float spawnVariance = 5f;

		// Token: 0x04004C98 RID: 19608
		private float timeTillSpawn;

		// Token: 0x04004C99 RID: 19609
		private int spawnedCustomers;

		// Token: 0x04004C9A RID: 19610
		private bool isPaused;
	}
}
