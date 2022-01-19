using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058B RID: 1419
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x060023F8 RID: 9208 RVA: 0x001F7944 File Offset: 0x001F5B44
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x060023F9 RID: 9209 RVA: 0x001F7977 File Offset: 0x001F5B77
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023FA RID: 9210 RVA: 0x001F7999 File Offset: 0x001F5B99
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023FB RID: 9211 RVA: 0x001F79BB File Offset: 0x001F5BBB
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060023FC RID: 9212 RVA: 0x001F79C4 File Offset: 0x001F5BC4
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

		// Token: 0x060023FD RID: 9213 RVA: 0x001F7A20 File Offset: 0x001F5C20
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x060023FE RID: 9214 RVA: 0x001F7A73 File Offset: 0x001F5C73
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004BBA RID: 19386
		public GameObject[] customerPrefabs;

		// Token: 0x04004BBB RID: 19387
		private float spawnRate = 10f;

		// Token: 0x04004BBC RID: 19388
		private float spawnVariance = 5f;

		// Token: 0x04004BBD RID: 19389
		private float timeTillSpawn;

		// Token: 0x04004BBE RID: 19390
		private int spawnedCustomers;

		// Token: 0x04004BBF RID: 19391
		private bool isPaused;
	}
}
