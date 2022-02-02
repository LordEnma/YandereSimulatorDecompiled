using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058B RID: 1419
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x060023FC RID: 9212 RVA: 0x001F81E4 File Offset: 0x001F63E4
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x060023FD RID: 9213 RVA: 0x001F8217 File Offset: 0x001F6417
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023FE RID: 9214 RVA: 0x001F8239 File Offset: 0x001F6439
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023FF RID: 9215 RVA: 0x001F825B File Offset: 0x001F645B
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002400 RID: 9216 RVA: 0x001F8264 File Offset: 0x001F6464
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

		// Token: 0x06002401 RID: 9217 RVA: 0x001F82C0 File Offset: 0x001F64C0
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x06002402 RID: 9218 RVA: 0x001F8313 File Offset: 0x001F6513
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004BC5 RID: 19397
		public GameObject[] customerPrefabs;

		// Token: 0x04004BC6 RID: 19398
		private float spawnRate = 10f;

		// Token: 0x04004BC7 RID: 19399
		private float spawnVariance = 5f;

		// Token: 0x04004BC8 RID: 19400
		private float timeTillSpawn;

		// Token: 0x04004BC9 RID: 19401
		private int spawnedCustomers;

		// Token: 0x04004BCA RID: 19402
		private bool isPaused;
	}
}
