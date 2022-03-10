using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058F RID: 1423
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Collider2D))]
	public class AIController : AIMover
	{
		// Token: 0x0600241F RID: 9247 RVA: 0x001FA2D8 File Offset: 0x001F84D8
		public void Init()
		{
			this.animator = base.GetComponent<Animator>();
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.throbObject.SetActive(false);
			this.targetChair = Chair.RandomChair;
			this.collider2d = base.GetComponent<Collider2D>();
			this.collider2d.enabled = false;
			if (this.targetChair == null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			this.happinessMeter.gameObject.SetActive(false);
			this.speechBubble.gameObject.SetActive(false);
		}

		// Token: 0x06002420 RID: 9248 RVA: 0x001FA368 File Offset: 0x001F8568
		private void Start()
		{
			this.leaveTarget.GetComponent<CustomerSpawner>().OpenDoor();
			this.moveSpeed = GameController.Instance.activeDifficultyVariables.customerMoveSpeed;
			this.timeToOrder = GameController.Instance.activeDifficultyVariables.timeSpentOrdering;
			this.eatTime = GameController.Instance.activeDifficultyVariables.timeSpentEatingFood;
			this.patienceDegradation = GameController.Instance.activeDifficultyVariables.customerPatienceDegradation;
			this.timeToEat = GameController.Instance.activeDifficultyVariables.timeSpentEatingFood;
			SFXController.PlaySound(SFXController.Sounds.DoorBell);
		}

		// Token: 0x06002421 RID: 9249 RVA: 0x001FA3F4 File Offset: 0x001F85F4
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002422 RID: 9250 RVA: 0x001FA416 File Offset: 0x001F8616
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002423 RID: 9251 RVA: 0x001FA438 File Offset: 0x001F8638
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			base.GetComponent<Animator>().speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002424 RID: 9252 RVA: 0x001FA45C File Offset: 0x001F865C
		private void Update()
		{
			if (this.isPaused)
			{
				return;
			}
			switch (this.state)
			{
			case AIController.AIState.Entering:
				if (Mathf.Abs(base.transform.position.x - this.targetChair.transform.position.x) <= this.distanceThreshold)
				{
					this.SitDown();
					this.happiness = 100f;
					this.happinessMeter.SetFill(this.happiness / 100f);
					this.state = AIController.AIState.Menu;
					return;
				}
				break;
			case AIController.AIState.Menu:
				if (this.happiness <= 0f)
				{
					this.StandUp();
					this.state = AIController.AIState.Leaving;
					GameController.AddAngryCustomer();
					return;
				}
				this.ReduceHappiness();
				return;
			case AIController.AIState.Ordering:
				if (this.orderTime <= 0f)
				{
					this.state = AIController.AIState.Waiting;
					this.speechBubble.GetComponent<Animator>().SetTrigger("BubbleDrop");
					this.animator.SetTrigger("DoneOrdering");
					return;
				}
				this.orderTime -= Time.deltaTime;
				return;
			case AIController.AIState.Waiting:
				if (this.happiness <= 0f)
				{
					this.StandUp();
					this.state = AIController.AIState.Leaving;
					GameController.AddAngryCustomer();
					return;
				}
				this.ReduceHappiness();
				return;
			case AIController.AIState.Eating:
				if (this.eatTime <= 0f)
				{
					this.StandUp();
					this.state = AIController.AIState.Leaving;
					return;
				}
				this.eatTime -= Time.deltaTime;
				return;
			case AIController.AIState.Leaving:
				if (Mathf.Abs(base.transform.position.x - this.leaveTarget.position.x) <= this.distanceThreshold)
				{
					UnityEngine.Object.Destroy(base.gameObject);
					this.leaveTarget.GetComponent<CustomerSpawner>().OpenDoor();
				}
				break;
			default:
				return;
			}
		}

		// Token: 0x06002425 RID: 9253 RVA: 0x001FA610 File Offset: 0x001F8810
		public override ControlInput GetInput()
		{
			ControlInput result = default(ControlInput);
			if (this.isPaused)
			{
				return result;
			}
			AIController.AIState aistate = this.state;
			if (aistate != AIController.AIState.Entering)
			{
				if (aistate == AIController.AIState.Leaving)
				{
					if (this.leaveTarget.position.x > base.transform.position.x)
					{
						result.horizontal = 1f;
						this.SetFlip(false);
					}
					else
					{
						result.horizontal = -1f;
						this.SetFlip(true);
					}
				}
			}
			else if (this.targetChair.transform.position.x > base.transform.position.x)
			{
				result.horizontal = 1f;
				this.SetFlip(false);
			}
			else
			{
				result.horizontal = -1f;
				this.SetFlip(true);
			}
			return result;
		}

		// Token: 0x06002426 RID: 9254 RVA: 0x001FA6E0 File Offset: 0x001F88E0
		public void TakeOrder()
		{
			this.state = AIController.AIState.Ordering;
			this.happiness = 100f;
			this.happinessMeter.SetFill(this.happiness / 100f);
			this.orderTime = this.timeToOrder;
			this.animator.SetTrigger("OrderTaken");
			this.animator.SetFloat("Happiness", this.happiness);
			this.desiredFood = FoodMenu.Instance.GetRandomFood();
			this.speechBubble.gameObject.SetActive(true);
			this.speechBubble.food = this.desiredFood;
			if (this.Male)
			{
				SFXController.PlaySound(SFXController.Sounds.MaleCustomerGreet);
				return;
			}
			SFXController.PlaySound(SFXController.Sounds.FemaleCustomerGreet);
		}

		// Token: 0x06002427 RID: 9255 RVA: 0x001FA794 File Offset: 0x001F8994
		public void DeliverFood(Food deliveredFood)
		{
			if (deliveredFood.name == this.desiredFood.name)
			{
				this.state = AIController.AIState.Eating;
				this.animator.SetTrigger("ServedFood");
				this.eatTime = this.timeToEat;
				GameController.AddTip(GameController.Instance.activeDifficultyVariables.baseTip * this.happiness);
				if (this.happiness <= 50f)
				{
					this.happiness = 50f;
					this.animator.SetFloat("Happiness", this.happiness);
				}
				if (this.Male)
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
				this.state = AIController.AIState.Leaving;
				this.happiness = 0f;
				this.animator.SetFloat("Happiness", this.happiness);
				GameController.AddAngryCustomer();
				this.StandUp();
				if (this.Male)
				{
					SFXController.PlaySound(SFXController.Sounds.MaleCustomerLeave);
				}
				else
				{
					SFXController.PlaySound(SFXController.Sounds.FemaleCustomerLeave);
				}
			}
			this.happinessMeter.gameObject.SetActive(false);
		}

		// Token: 0x06002428 RID: 9256 RVA: 0x001FA8A0 File Offset: 0x001F8AA0
		private void SitDown()
		{
			base.transform.position = new Vector3(this.targetChair.transform.position.x, base.transform.position.y, base.transform.position.z);
			this.animator.SetTrigger("SitDown");
			this.SetFlip(this.targetChair.transform.localScale.x <= 0f);
			this.SetSortingLayer(true);
			this.collider2d.enabled = true;
			this.happinessMeter.gameObject.SetActive(true);
		}

		// Token: 0x06002429 RID: 9257 RVA: 0x001FA94C File Offset: 0x001F8B4C
		private void StandUp()
		{
			this.animator.SetTrigger("StandUp");
			this.SetSortingLayer(false);
			this.targetChair.available = true;
			this.collider2d.enabled = false;
			this.happinessMeter.gameObject.SetActive(false);
		}

		// Token: 0x0600242A RID: 9258 RVA: 0x001FA99C File Offset: 0x001F8B9C
		private void ReduceHappiness()
		{
			this.happiness -= Time.deltaTime * this.patienceDegradation;
			this.animator.SetFloat("Happiness", this.happiness);
			this.happinessMeter.SetFill(this.happiness / 100f);
		}

		// Token: 0x0600242B RID: 9259 RVA: 0x001FA9EF File Offset: 0x001F8BEF
		private void SetFlip(bool flip)
		{
			this.spriteRenderer.flipX = flip;
			base.GetComponentInChildren<CharacterHairPlacer>().hairInstance.flipX = flip;
		}

		// Token: 0x0600242C RID: 9260 RVA: 0x001FAA10 File Offset: 0x001F8C10
		public void SetSortingLayer(bool back)
		{
			this.spriteRenderer.sortingLayerName = (back ? "CustomerSitting" : "Default");
			base.GetComponent<CharacterHairPlacer>().hairInstance.sortingLayerName = (back ? "CustomerSitting" : "Default");
			this.throbObject.GetComponent<SpriteRenderer>().sortingLayerName = (back ? "CustomerSitting" : "Default");
		}

		// Token: 0x04004C0A RID: 19466
		public GameObject throbObject;

		// Token: 0x04004C0B RID: 19467
		public Meter happinessMeter;

		// Token: 0x04004C0C RID: 19468
		public Bubble speechBubble;

		// Token: 0x04004C0D RID: 19469
		public float distanceThreshold = 0.5f;

		// Token: 0x04004C0E RID: 19470
		private Food desiredFood;

		// Token: 0x04004C0F RID: 19471
		private Collider2D collider2d;

		// Token: 0x04004C10 RID: 19472
		private Chair targetChair;

		// Token: 0x04004C11 RID: 19473
		[HideInInspector]
		public Transform leaveTarget;

		// Token: 0x04004C12 RID: 19474
		[HideInInspector]
		public AIController.AIState state;

		// Token: 0x04004C13 RID: 19475
		private Animator animator;

		// Token: 0x04004C14 RID: 19476
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C15 RID: 19477
		private float patienceDegradation = 2f;

		// Token: 0x04004C16 RID: 19478
		private float timeToOrder = 0.5f;

		// Token: 0x04004C17 RID: 19479
		private float timeToEat;

		// Token: 0x04004C18 RID: 19480
		private float happiness = 50f;

		// Token: 0x04004C19 RID: 19481
		private float orderTime;

		// Token: 0x04004C1A RID: 19482
		private float eatTime;

		// Token: 0x04004C1B RID: 19483
		private int normalSortingLayer;

		// Token: 0x04004C1C RID: 19484
		private bool isPaused;

		// Token: 0x04004C1D RID: 19485
		public bool Male;

		// Token: 0x020006D9 RID: 1753
		public enum AIState
		{
			// Token: 0x040051C5 RID: 20933
			Entering,
			// Token: 0x040051C6 RID: 20934
			Menu,
			// Token: 0x040051C7 RID: 20935
			Ordering,
			// Token: 0x040051C8 RID: 20936
			Waiting,
			// Token: 0x040051C9 RID: 20937
			Eating,
			// Token: 0x040051CA RID: 20938
			Leaving
		}
	}
}
