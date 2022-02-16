using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058C RID: 1420
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x06002408 RID: 9224 RVA: 0x001F8BB4 File Offset: 0x001F6DB4
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x06002409 RID: 9225 RVA: 0x001F8BE7 File Offset: 0x001F6DE7
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x001F8C09 File Offset: 0x001F6E09
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x001F8C2B File Offset: 0x001F6E2B
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600240C RID: 9228 RVA: 0x001F8C34 File Offset: 0x001F6E34
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

		// Token: 0x0600240D RID: 9229 RVA: 0x001F8C90 File Offset: 0x001F6E90
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x0600240E RID: 9230 RVA: 0x001F8CE3 File Offset: 0x001F6EE3
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004BD7 RID: 19415
		public GameObject[] customerPrefabs;

		// Token: 0x04004BD8 RID: 19416
		private float spawnRate = 10f;

		// Token: 0x04004BD9 RID: 19417
		private float spawnVariance = 5f;

		// Token: 0x04004BDA RID: 19418
		private float timeTillSpawn;

		// Token: 0x04004BDB RID: 19419
		private int spawnedCustomers;

		// Token: 0x04004BDC RID: 19420
		private bool isPaused;
	}
}
