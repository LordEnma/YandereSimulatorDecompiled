using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058A RID: 1418
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x060023F6 RID: 9206 RVA: 0x001F6C74 File Offset: 0x001F4E74
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x060023F7 RID: 9207 RVA: 0x001F6CA7 File Offset: 0x001F4EA7
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x001F6CC9 File Offset: 0x001F4EC9
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F9 RID: 9209 RVA: 0x001F6CEB File Offset: 0x001F4EEB
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060023FA RID: 9210 RVA: 0x001F6CF4 File Offset: 0x001F4EF4
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

		// Token: 0x060023FB RID: 9211 RVA: 0x001F6D50 File Offset: 0x001F4F50
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x060023FC RID: 9212 RVA: 0x001F6DA3 File Offset: 0x001F4FA3
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004BB3 RID: 19379
		public GameObject[] customerPrefabs;

		// Token: 0x04004BB4 RID: 19380
		private float spawnRate = 10f;

		// Token: 0x04004BB5 RID: 19381
		private float spawnVariance = 5f;

		// Token: 0x04004BB6 RID: 19382
		private float timeTillSpawn;

		// Token: 0x04004BB7 RID: 19383
		private int spawnedCustomers;

		// Token: 0x04004BB8 RID: 19384
		private bool isPaused;
	}
}
