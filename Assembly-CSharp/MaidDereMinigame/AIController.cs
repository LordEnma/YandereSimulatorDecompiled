using System;
using UnityEngine;

namespace MaidDereMinigame
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Collider2D))]
	public class AIController : AIMover
	{
		public enum AIState
		{
			Entering = 0,
			Menu = 1,
			Ordering = 2,
			Waiting = 3,
			Eating = 4,
			Leaving = 5
		}

		public GameObject throbObject;

		public Meter happinessMeter;

		public Bubble speechBubble;

		public float distanceThreshold = 0.5f;

		private Food desiredFood;

		private Collider2D collider2d;

		private Chair targetChair;

		[HideInInspector]
		public Transform leaveTarget;

		[HideInInspector]
		public AIState state;

		private Animator animator;

		private SpriteRenderer spriteRenderer;

		private float patienceDegradation = 2f;

		private float timeToOrder = 0.5f;

		private float timeToEat;

		private float happiness = 50f;

		private float orderTime;

		private float eatTime;

		private int normalSortingLayer;

		private bool isPaused;

		public bool Male;

		public void Init()
		{
			animator = GetComponent<Animator>();
			spriteRenderer = GetComponent<SpriteRenderer>();
			throbObject.SetActive(value: false);
			targetChair = Chair.RandomChair;
			collider2d = GetComponent<Collider2D>();
			collider2d.enabled = false;
			if (targetChair == null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			happinessMeter.gameObject.SetActive(value: false);
			speechBubble.gameObject.SetActive(value: false);
		}

		private void Start()
		{
			leaveTarget.GetComponent<CustomerSpawner>().OpenDoor();
			moveSpeed = GameController.Instance.activeDifficultyVariables.customerMoveSpeed;
			timeToOrder = GameController.Instance.activeDifficultyVariables.timeSpentOrdering;
			eatTime = GameController.Instance.activeDifficultyVariables.timeSpentEatingFood;
			patienceDegradation = GameController.Instance.activeDifficultyVariables.customerPatienceDegradation;
			timeToEat = GameController.Instance.activeDifficultyVariables.timeSpentEatingFood;
			SFXController.PlaySound(SFXController.Sounds.DoorBell);
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
			GetComponent<Animator>().speed = ((!isPaused) ? 1 : 0);
		}

		private void Update()
		{
			if (isPaused)
			{
				return;
			}
			switch (state)
			{
			case AIState.Entering:
				if (Mathf.Abs(base.transform.position.x - targetChair.transform.position.x) <= distanceThreshold)
				{
					SitDown();
					happiness = 100f;
					happinessMeter.SetFill(happiness / 100f);
					state = AIState.Menu;
				}
				break;
			case AIState.Menu:
				if (happiness <= 0f)
				{
					StandUp();
					state = AIState.Leaving;
					GameController.AddAngryCustomer();
				}
				else
				{
					ReduceHappiness();
				}
				break;
			case AIState.Ordering:
				if (orderTime <= 0f)
				{
					state = AIState.Waiting;
					speechBubble.GetComponent<Animator>().SetTrigger("BubbleDrop");
					animator.SetTrigger("DoneOrdering");
				}
				else
				{
					orderTime -= Time.deltaTime;
				}
				break;
			case AIState.Waiting:
				if (happiness <= 0f)
				{
					StandUp();
					state = AIState.Leaving;
					GameController.AddAngryCustomer();
				}
				else
				{
					ReduceHappiness();
				}
				break;
			case AIState.Eating:
				if (eatTime <= 0f)
				{
					StandUp();
					state = AIState.Leaving;
				}
				else
				{
					eatTime -= Time.deltaTime;
				}
				break;
			case AIState.Leaving:
				if (Mathf.Abs(base.transform.position.x - leaveTarget.position.x) <= distanceThreshold)
				{
					UnityEngine.Object.Destroy(base.gameObject);
					leaveTarget.GetComponent<CustomerSpawner>().OpenDoor();
				}
				break;
			}
		}

		public override ControlInput GetInput()
		{
			ControlInput result = default(ControlInput);
			if (isPaused)
			{
				return result;
			}
			switch (state)
			{
			case AIState.Entering:
				if (targetChair.transform.position.x > base.transform.position.x)
				{
					result.horizontal = 1f;
					SetFlip(flip: false);
				}
				else
				{
					result.horizontal = -1f;
					SetFlip(flip: true);
				}
				break;
			case AIState.Leaving:
				if (leaveTarget.position.x > base.transform.position.x)
				{
					result.horizontal = 1f;
					SetFlip(flip: false);
				}
				else
				{
					result.horizontal = -1f;
					SetFlip(flip: true);
				}
				break;
			}
			return result;
		}

		public void TakeOrder()
		{
			state = AIState.Ordering;
			happiness = 100f;
			happinessMeter.SetFill(happiness / 100f);
			orderTime = timeToOrder;
			animator.SetTrigger("OrderTaken");
			animator.SetFloat("Happiness", happiness);
			desiredFood = FoodMenu.Instance.GetRandomFood();
			speechBubble.gameObject.SetActive(value: true);
			speechBubble.food = desiredFood;
			if (Male)
			{
				SFXController.PlaySound(SFXController.Sounds.MaleCustomerGreet);
			}
			else
			{
				SFXController.PlaySound(SFXController.Sounds.FemaleCustomerGreet);
			}
		}

		public void DeliverFood(Food deliveredFood)
		{
			if (deliveredFood.name == desiredFood.name)
			{
				state = AIState.Eating;
				animator.SetTrigger("ServedFood");
				eatTime = timeToEat;
				GameController.AddTip(GameController.Instance.activeDifficultyVariables.baseTip * happiness);
				if (happiness <= 50f)
				{
					happiness = 50f;
					animator.SetFloat("Happiness", happiness);
				}
				if (Male)
				{
					SFXController.PlaySound(SFXController.Sounds.MaleCustomerThank);
				}
				else
				{
					SFXController.PlaySound(SFXController.Sounds.FemaleCustomerThank);
				}
			}
			else
			{
				state = AIState.Leaving;
				happiness = 0f;
				animator.SetFloat("Happiness", happiness);
				GameController.AddAngryCustomer();
				StandUp();
				if (Male)
				{
					SFXController.PlaySound(SFXController.Sounds.MaleCustomerLeave);
				}
				else
				{
					SFXController.PlaySound(SFXController.Sounds.FemaleCustomerLeave);
				}
			}
			happinessMeter.gameObject.SetActive(value: false);
		}

		private void SitDown()
		{
			base.transform.position = new Vector3(targetChair.transform.position.x, base.transform.position.y, base.transform.position.z);
			animator.SetTrigger("SitDown");
			SetFlip(!(targetChair.transform.localScale.x > 0f));
			SetSortingLayer(back: true);
			collider2d.enabled = true;
			happinessMeter.gameObject.SetActive(value: true);
		}

		private void StandUp()
		{
			animator.SetTrigger("StandUp");
			SetSortingLayer(back: false);
			targetChair.available = true;
			collider2d.enabled = false;
			happinessMeter.gameObject.SetActive(value: false);
		}

		private void ReduceHappiness()
		{
			happiness -= Time.deltaTime * patienceDegradation;
			animator.SetFloat("Happiness", happiness);
			happinessMeter.SetFill(happiness / 100f);
		}

		private void SetFlip(bool flip)
		{
			spriteRenderer.flipX = flip;
			GetComponentInChildren<CharacterHairPlacer>().hairInstance.flipX = flip;
		}

		public void SetSortingLayer(bool back)
		{
			spriteRenderer.sortingLayerName = (back ? "CustomerSitting" : "Default");
			GetComponent<CharacterHairPlacer>().hairInstance.sortingLayerName = (back ? "CustomerSitting" : "Default");
			throbObject.GetComponent<SpriteRenderer>().sortingLayerName = (back ? "CustomerSitting" : "Default");
		}
	}
}
