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
		// Token: 0x060023F0 RID: 9200 RVA: 0x001F5E50 File Offset: 0x001F4050
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

		// Token: 0x060023F1 RID: 9201 RVA: 0x001F5EE0 File Offset: 0x001F40E0
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

		// Token: 0x060023F2 RID: 9202 RVA: 0x001F5F6C File Offset: 0x001F416C
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F3 RID: 9203 RVA: 0x001F5F8E File Offset: 0x001F418E
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F4 RID: 9204 RVA: 0x001F5FB0 File Offset: 0x001F41B0
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			base.GetComponent<Animator>().speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x060023F5 RID: 9205 RVA: 0x001F5FD4 File Offset: 0x001F41D4
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

		// Token: 0x060023F6 RID: 9206 RVA: 0x001F6188 File Offset: 0x001F4388
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

		// Token: 0x060023F7 RID: 9207 RVA: 0x001F6258 File Offset: 0x001F4458
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

		// Token: 0x060023F8 RID: 9208 RVA: 0x001F630C File Offset: 0x001F450C
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

		// Token: 0x060023F9 RID: 9209 RVA: 0x001F6418 File Offset: 0x001F4618
		private void SitDown()
		{
			base.transform.position = new Vector3(this.targetChair.transform.position.x, base.transform.position.y, base.transform.position.z);
			this.animator.SetTrigger("SitDown");
			this.SetFlip(this.targetChair.transform.localScale.x <= 0f);
			this.SetSortingLayer(true);
			this.collider2d.enabled = true;
			this.happinessMeter.gameObject.SetActive(true);
		}

		// Token: 0x060023FA RID: 9210 RVA: 0x001F64C4 File Offset: 0x001F46C4
		private void StandUp()
		{
			this.animator.SetTrigger("StandUp");
			this.SetSortingLayer(false);
			this.targetChair.available = true;
			this.collider2d.enabled = false;
			this.happinessMeter.gameObject.SetActive(false);
		}

		// Token: 0x060023FB RID: 9211 RVA: 0x001F6514 File Offset: 0x001F4714
		private void ReduceHappiness()
		{
			this.happiness -= Time.deltaTime * this.patienceDegradation;
			this.animator.SetFloat("Happiness", this.happiness);
			this.happinessMeter.SetFill(this.happiness / 100f);
		}

		// Token: 0x060023FC RID: 9212 RVA: 0x001F6567 File Offset: 0x001F4767
		private void SetFlip(bool flip)
		{
			this.spriteRenderer.flipX = flip;
			base.GetComponentInChildren<CharacterHairPlacer>().hairInstance.flipX = flip;
		}

		// Token: 0x060023FD RID: 9213 RVA: 0x001F6588 File Offset: 0x001F4788
		public void SetSortingLayer(bool back)
		{
			this.spriteRenderer.sortingLayerName = (back ? "CustomerSitting" : "Default");
			base.GetComponent<CharacterHairPlacer>().hairInstance.sortingLayerName = (back ? "CustomerSitting" : "Default");
			this.throbObject.GetComponent<SpriteRenderer>().sortingLayerName = (back ? "CustomerSitting" : "Default");
		}

		// Token: 0x04004B9C RID: 19356
		public GameObject throbObject;

		// Token: 0x04004B9D RID: 19357
		public Meter happinessMeter;

		// Token: 0x04004B9E RID: 19358
		public Bubble speechBubble;

		// Token: 0x04004B9F RID: 19359
		public float distanceThreshold = 0.5f;

		// Token: 0x04004BA0 RID: 19360
		private Food desiredFood;

		// Token: 0x04004BA1 RID: 19361
		private Collider2D collider2d;

		// Token: 0x04004BA2 RID: 19362
		private Chair targetChair;

		// Token: 0x04004BA3 RID: 19363
		[HideInInspector]
		public Transform leaveTarget;

		// Token: 0x04004BA4 RID: 19364
		[HideInInspector]
		public AIController.AIState state;

		// Token: 0x04004BA5 RID: 19365
		private Animator animator;

		// Token: 0x04004BA6 RID: 19366
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BA7 RID: 19367
		private float patienceDegradation = 2f;

		// Token: 0x04004BA8 RID: 19368
		private float timeToOrder = 0.5f;

		// Token: 0x04004BA9 RID: 19369
		private float timeToEat;

		// Token: 0x04004BAA RID: 19370
		private float happiness = 50f;

		// Token: 0x04004BAB RID: 19371
		private float orderTime;

		// Token: 0x04004BAC RID: 19372
		private float eatTime;

		// Token: 0x04004BAD RID: 19373
		private int normalSortingLayer;

		// Token: 0x04004BAE RID: 19374
		private bool isPaused;

		// Token: 0x04004BAF RID: 19375
		public bool Male;

		// Token: 0x020006D7 RID: 1751
		public enum AIState
		{
			// Token: 0x04005180 RID: 20864
			Entering,
			// Token: 0x04005181 RID: 20865
			Menu,
			// Token: 0x04005182 RID: 20866
			Ordering,
			// Token: 0x04005183 RID: 20867
			Waiting,
			// Token: 0x04005184 RID: 20868
			Eating,
			// Token: 0x04005185 RID: 20869
			Leaving
		}
	}
}
