using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000598 RID: 1432
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x0600244E RID: 9294 RVA: 0x001FE8D0 File Offset: 0x001FCAD0
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x0600244F RID: 9295 RVA: 0x001FE903 File Offset: 0x001FCB03
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002450 RID: 9296 RVA: 0x001FE925 File Offset: 0x001FCB25
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002451 RID: 9297 RVA: 0x001FE947 File Offset: 0x001FCB47
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002452 RID: 9298 RVA: 0x001FE950 File Offset: 0x001FCB50
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

		// Token: 0x06002453 RID: 9299 RVA: 0x001FE9AC File Offset: 0x001FCBAC
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x06002454 RID: 9300 RVA: 0x001FE9FF File Offset: 0x001FCBFF
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004CAB RID: 19627
		public GameObject[] customerPrefabs;

		// Token: 0x04004CAC RID: 19628
		private float spawnRate = 10f;

		// Token: 0x04004CAD RID: 19629
		private float spawnVariance = 5f;

		// Token: 0x04004CAE RID: 19630
		private float timeTillSpawn;

		// Token: 0x04004CAF RID: 19631
		private int spawnedCustomers;

		// Token: 0x04004CB0 RID: 19632
		private bool isPaused;
	}
}
