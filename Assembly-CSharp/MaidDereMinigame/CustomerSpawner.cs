using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000599 RID: 1433
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x06002457 RID: 9303 RVA: 0x001FFD5C File Offset: 0x001FDF5C
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x001FFD8F File Offset: 0x001FDF8F
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002459 RID: 9305 RVA: 0x001FFDB1 File Offset: 0x001FDFB1
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x001FFDD3 File Offset: 0x001FDFD3
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x001FFDDC File Offset: 0x001FDFDC
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

		// Token: 0x0600245C RID: 9308 RVA: 0x001FFE38 File Offset: 0x001FE038
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x001FFE8B File Offset: 0x001FE08B
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004CC1 RID: 19649
		public GameObject[] customerPrefabs;

		// Token: 0x04004CC2 RID: 19650
		private float spawnRate = 10f;

		// Token: 0x04004CC3 RID: 19651
		private float spawnVariance = 5f;

		// Token: 0x04004CC4 RID: 19652
		private float timeTillSpawn;

		// Token: 0x04004CC5 RID: 19653
		private int spawnedCustomers;

		// Token: 0x04004CC6 RID: 19654
		private bool isPaused;
	}
}
