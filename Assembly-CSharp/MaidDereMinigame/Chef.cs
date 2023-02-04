using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		public enum ChefState
		{
			Queueing = 0,
			Cooking = 1,
			Delivering = 2
		}

		private static Chef instance;

		[Reorderable]
		public Foods cookQueue;

		public FoodMenu foodMenu;

		public Meter cookMeter;

		public float cookTime = 3f;

		private ChefState state;

		private Food currentPlate;

		private Animator animator;

		private float timeToFinishDish;

		private bool isPaused;

		public static Chef Instance
		{
			get
			{
				if (instance == null)
				{
					instance = UnityEngine.Object.FindObjectOfType<Chef>();
				}
				return instance;
			}
		}

		private void Awake()
		{
			cookQueue = new Foods();
			animator = GetComponent<Animator>();
			cookMeter.gameObject.SetActive(value: false);
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
			animator.speed = ((!isPaused) ? 1 : 0);
		}

		public static void AddToQueue(Food foodItem)
		{
			Instance.cookQueue.Add(foodItem);
		}

		public static Food GrabFromQueue()
		{
			Food result = Instance.cookQueue[0];
			Instance.cookQueue.RemoveAt(0);
			return result;
		}

		private void Update()
		{
			if (isPaused)
			{
				return;
			}
			switch (state)
			{
			case ChefState.Queueing:
				if (cookQueue.Count > 0)
				{
					currentPlate = GrabFromQueue();
					timeToFinishDish = currentPlate.cookTimeMultiplier * cookTime;
					state = ChefState.Cooking;
					cookMeter.gameObject.SetActive(value: true);
				}
				break;
			case ChefState.Cooking:
				if (timeToFinishDish <= 0f)
				{
					state = ChefState.Delivering;
					animator.SetTrigger("PlateCooked");
					cookMeter.gameObject.SetActive(value: false);
				}
				else
				{
					timeToFinishDish -= Time.deltaTime;
					cookMeter.SetFill(1f - timeToFinishDish / (currentPlate.cookTimeMultiplier * cookTime));
				}
				break;
			}
		}

		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(currentPlate);
		}

		public void Queue()
		{
			state = ChefState.Queueing;
		}
	}
}
