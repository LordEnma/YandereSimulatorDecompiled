using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059A RID: 1434
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x06002462 RID: 9314 RVA: 0x002014A8 File Offset: 0x001FF6A8
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x06002463 RID: 9315 RVA: 0x002014DB File Offset: 0x001FF6DB
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002464 RID: 9316 RVA: 0x002014FD File Offset: 0x001FF6FD
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002465 RID: 9317 RVA: 0x0020151F File Offset: 0x001FF71F
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x06002466 RID: 9318 RVA: 0x00201528 File Offset: 0x001FF728
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

		// Token: 0x06002467 RID: 9319 RVA: 0x00201584 File Offset: 0x001FF784
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x002015D7 File Offset: 0x001FF7D7
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004CE8 RID: 19688
		public GameObject[] customerPrefabs;

		// Token: 0x04004CE9 RID: 19689
		private float spawnRate = 10f;

		// Token: 0x04004CEA RID: 19690
		private float spawnVariance = 5f;

		// Token: 0x04004CEB RID: 19691
		private float timeTillSpawn;

		// Token: 0x04004CEC RID: 19692
		private int spawnedCustomers;

		// Token: 0x04004CED RID: 19693
		private bool isPaused;
	}
}
