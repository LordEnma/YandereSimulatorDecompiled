using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000589 RID: 1417
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Collider2D))]
	public class AIController : AIMover
	{
		// Token: 0x060023F3 RID: 9203 RVA: 0x001F6440 File Offset: 0x001F4640
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

		// Token: 0x060023F4 RID: 9204 RVA: 0x001F64D0 File Offset: 0x001F46D0
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

		// Token: 0x060023F5 RID: 9205 RVA: 0x001F655C File Offset: 0x001F475C
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F6 RID: 9206 RVA: 0x001F657E File Offset: 0x001F477E
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F7 RID: 9207 RVA: 0x001F65A0 File Offset: 0x001F47A0
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			base.GetComponent<Animator>().speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x001F65C4 File Offset: 0x001F47C4
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

		// Token: 0x060023F9 RID: 9209 RVA: 0x001F6778 File Offset: 0x001F4978
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

		// Token: 0x060023FA RID: 9210 RVA: 0x001F6848 File Offset: 0x001F4A48
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

		// Token: 0x060023FB RID: 9211 RVA: 0x001F68FC File Offset: 0x001F4AFC
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

		// Token: 0x060023FC RID: 9212 RVA: 0x001F6A08 File Offset: 0x001F4C08
		private void SitDown()
		{
			base.transform.position = new Vector3(this.targetChair.transform.position.x, base.transform.position.y, base.transform.position.z);
			this.animator.SetTrigger("SitDown");
			this.SetFlip(this.targetChair.transform.localScale.x <= 0f);
			this.SetSortingLayer(true);
			this.collider2d.enabled = true;
			this.happinessMeter.gameObject.SetActive(true);
		}

		// Token: 0x060023FD RID: 9213 RVA: 0x001F6AB4 File Offset: 0x001F4CB4
		private void StandUp()
		{
			this.animator.SetTrigger("StandUp");
			this.SetSortingLayer(false);
			this.targetChair.available = true;
			this.collider2d.enabled = false;
			this.happinessMeter.gameObject.SetActive(false);
		}

		// Token: 0x060023FE RID: 9214 RVA: 0x001F6B04 File Offset: 0x001F4D04
		private void ReduceHappiness()
		{
			this.happiness -= Time.deltaTime * this.patienceDegradation;
			this.animator.SetFloat("Happiness", this.happiness);
			this.happinessMeter.SetFill(this.happiness / 100f);
		}

		// Token: 0x060023FF RID: 9215 RVA: 0x001F6B57 File Offset: 0x001F4D57
		private void SetFlip(bool flip)
		{
			this.spriteRenderer.flipX = flip;
			base.GetComponentInChildren<CharacterHairPlacer>().hairInstance.flipX = flip;
		}

		// Token: 0x06002400 RID: 9216 RVA: 0x001F6B78 File Offset: 0x001F4D78
		public void SetSortingLayer(bool back)
		{
			this.spriteRenderer.sortingLayerName = (back ? "CustomerSitting" : "Default");
			base.GetComponent<CharacterHairPlacer>().hairInstance.sortingLayerName = (back ? "CustomerSitting" : "Default");
			this.throbObject.GetComponent<SpriteRenderer>().sortingLayerName = (back ? "CustomerSitting" : "Default");
		}

		// Token: 0x04004BA5 RID: 19365
		public GameObject throbObject;

		// Token: 0x04004BA6 RID: 19366
		public Meter happinessMeter;

		// Token: 0x04004BA7 RID: 19367
		public Bubble speechBubble;

		// Token: 0x04004BA8 RID: 19368
		public float distanceThreshold = 0.5f;

		// Token: 0x04004BA9 RID: 19369
		private Food desiredFood;

		// Token: 0x04004BAA RID: 19370
		private Collider2D collider2d;

		// Token: 0x04004BAB RID: 19371
		private Chair targetChair;

		// Token: 0x04004BAC RID: 19372
		[HideInInspector]
		public Transform leaveTarget;

		// Token: 0x04004BAD RID: 19373
		[HideInInspector]
		public AIController.AIState state;

		// Token: 0x04004BAE RID: 19374
		private Animator animator;

		// Token: 0x04004BAF RID: 19375
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BB0 RID: 19376
		private float patienceDegradation = 2f;

		// Token: 0x04004BB1 RID: 19377
		private float timeToOrder = 0.5f;

		// Token: 0x04004BB2 RID: 19378
		private float timeToEat;

		// Token: 0x04004BB3 RID: 19379
		private float happiness = 50f;

		// Token: 0x04004BB4 RID: 19380
		private float orderTime;

		// Token: 0x04004BB5 RID: 19381
		private float eatTime;

		// Token: 0x04004BB6 RID: 19382
		private int normalSortingLayer;

		// Token: 0x04004BB7 RID: 19383
		private bool isPaused;

		// Token: 0x04004BB8 RID: 19384
		public bool Male;

		// Token: 0x020006D7 RID: 1751
		public enum AIState
		{
			// Token: 0x04005189 RID: 20873
			Entering,
			// Token: 0x0400518A RID: 20874
			Menu,
			// Token: 0x0400518B RID: 20875
			Ordering,
			// Token: 0x0400518C RID: 20876
			Waiting,
			// Token: 0x0400518D RID: 20877
			Eating,
			// Token: 0x0400518E RID: 20878
			Leaving
		}
	}
}
