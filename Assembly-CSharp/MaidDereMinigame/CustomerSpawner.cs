using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000586 RID: 1414
	public class CustomerSpawner : MonoBehaviour
	{
		// Token: 0x060023D7 RID: 9175 RVA: 0x001F45B0 File Offset: 0x001F27B0
		private void Start()
		{
			this.spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			this.spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			this.isPaused = true;
		}

		// Token: 0x060023D8 RID: 9176 RVA: 0x001F45E3 File Offset: 0x001F27E3
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023D9 RID: 9177 RVA: 0x001F4605 File Offset: 0x001F2805
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023DA RID: 9178 RVA: 0x001F4627 File Offset: 0x001F2827
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
		}

		// Token: 0x060023DB RID: 9179 RVA: 0x001F4630 File Offset: 0x001F2830
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

		// Token: 0x060023DC RID: 9180 RVA: 0x001F468C File Offset: 0x001F288C
		private void SpawnCustomer()
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.customerPrefabs[UnityEngine.Random.Range(0, this.customerPrefabs.Length)]);
			gameObject.transform.position = base.transform.position;
			AIController component = gameObject.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		// Token: 0x060023DD RID: 9181 RVA: 0x001F46DF File Offset: 0x001F28DF
		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}

		// Token: 0x04004B57 RID: 19287
		public GameObject[] customerPrefabs;

		// Token: 0x04004B58 RID: 19288
		private float spawnRate = 10f;

		// Token: 0x04004B59 RID: 19289
		private float spawnVariance = 5f;

		// Token: 0x04004B5A RID: 19290
		private float timeTillSpawn;

		// Token: 0x04004B5B RID: 19291
		private int spawnedCustomers;

		// Token: 0x04004B5C RID: 19292
		private bool isPaused;
	}
}
