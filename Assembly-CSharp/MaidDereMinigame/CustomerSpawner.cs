using System;
using UnityEngine;

namespace MaidDereMinigame
{
	public class CustomerSpawner : MonoBehaviour
	{
		public GameObject[] customerPrefabs;

		private float spawnRate = 10f;

		private float spawnVariance = 5f;

		private float timeTillSpawn;

		private int spawnedCustomers;

		private bool isPaused;

		private void Start()
		{
			spawnRate = GameController.Instance.activeDifficultyVariables.customerSpawnRate;
			spawnVariance = GameController.Instance.activeDifficultyVariables.customerSpawnVariance;
			isPaused = true;
		}

		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(Pause));
		}

		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(Pause));
		}

		public void Pause(bool toPause)
		{
			isPaused = toPause;
		}

		private void Update()
		{
			if (!isPaused)
			{
				if (timeTillSpawn <= 0f)
				{
					timeTillSpawn = spawnRate + UnityEngine.Random.Range(0f - spawnVariance, spawnVariance);
					SpawnCustomer();
				}
				else
				{
					timeTillSpawn -= Time.deltaTime;
				}
			}
		}

		private void SpawnCustomer()
		{
			GameObject obj = UnityEngine.Object.Instantiate(customerPrefabs[UnityEngine.Random.Range(0, customerPrefabs.Length)]);
			obj.transform.position = base.transform.position;
			AIController component = obj.GetComponent<AIController>();
			component.Init();
			component.leaveTarget = base.transform;
		}

		public void OpenDoor()
		{
			base.transform.parent.GetComponent<Animator>().SetTrigger("DoorOpen");
		}
	}
}
