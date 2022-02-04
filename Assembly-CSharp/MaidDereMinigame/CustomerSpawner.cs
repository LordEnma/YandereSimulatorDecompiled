using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058B RID: 1419
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x060023FE RID: 9214 RVA: 0x001F84FC File Offset: 0x001F66FC
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x060023FF RID: 9215 RVA: 0x001F852F File Offset: 0x001F672F
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002400 RID: 9216 RVA: 0x001F8551 File Offset: 0x001F6751
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002401 RID: 9217 RVA: 0x001F8573 File Offset: 0x001F6773
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002402 RID: 9218 RVA: 0x001F857C File Offset: 0x001F677C
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

		// Token: 0x06002403 RID: 9219 RVA: 0x001F85D8 File Offset: 0x001F67D8
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x06002404 RID: 9220 RVA: 0x001F862B File Offset: 0x001F682B
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004BCB RID: 19403
		public GameObject[] customerPrefabs;

		// Token: 0x04004BCC RID: 19404
		private float spawnRate = 10f;

		// Token: 0x04004BCD RID: 19405
		private float spawnVariance = 5f;

		// Token: 0x04004BCE RID: 19406
		private float timeTillSpawn;

		// Token: 0x04004BCF RID: 19407
		private int spawnedCustomers;

		// Token: 0x04004BD0 RID: 19408
		private bool isPaused;
	}
}
