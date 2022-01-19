using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058C RID: 1420
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(SpriteRenderer))]
	[RequireComponent(typeof(Collider2D))]
	public class AIController : AIMover
	{
		// Token: 0x06002400 RID: 9216 RVA: 0x001F7AB0 File Offset: 0x001F5CB0
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

		// Token: 0x06002401 RID: 9217 RVA: 0x001F7B40 File Offset: 0x001F5D40
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

		// Token: 0x06002402 RID: 9218 RVA: 0x001F7BCC File Offset: 0x001F5DCC
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002403 RID: 9219 RVA: 0x001F7BEE File Offset: 0x001F5DEE
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002404 RID: 9220 RVA: 0x001F7C10 File Offset: 0x001F5E10
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			base.GetComponent<Animator>().speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002405 RID: 9221 RVA: 0x001F7C34 File Offset: 0x001F5E34
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

		// Token: 0x06002406 RID: 9222 RVA: 0x001F7DE8 File Offset: 0x001F5FE8
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

		// Token: 0x06002407 RID: 9223 RVA: 0x001F7EB8 File Offset: 0x001F60B8
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

		// Token: 0x06002408 RID: 9224 RVA: 0x001F7F6C File Offset: 0x001F616C
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

		// Token: 0x06002409 RID: 9225 RVA: 0x001F8078 File Offset: 0x001F6278
		private void SitDown()
		{
			base.transform.position = new Vector3(this.targetChair.transform.position.x, base.transform.position.y, base.transform.position.z);
			this.animator.SetTrigger("SitDown");
			this.SetFlip(this.targetChair.transform.localScale.x <= 0f);
			this.SetSortingLayer(true);
			this.collider2d.enabled = true;
			this.happinessMeter.gameObject.SetActive(true);
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x001F8124 File Offset: 0x001F6324
		private void StandUp()
		{
			this.animator.SetTrigger("StandUp");
			this.SetSortingLayer(false);
			this.targetChair.available = true;
			this.collider2d.enabled = false;
			this.happinessMeter.gameObject.SetActive(false);
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x001F8174 File Offset: 0x001F6374
		private void ReduceHappiness()
		{
			this.happiness -= Time.deltaTime * this.patienceDegradation;
			this.animator.SetFloat("Happiness", this.happiness);
			this.happinessMeter.SetFill(this.happiness / 100f);
		}

		// Token: 0x0600240C RID: 9228 RVA: 0x001F81C7 File Offset: 0x001F63C7
		private void SetFlip(bool flip)
		{
			this.spriteRenderer.flipX = flip;
			base.GetComponentInChildren<CharacterHairPlacer>().hairInstance.flipX = flip;
		}

		// Token: 0x0600240D RID: 9229 RVA: 0x001F81E8 File Offset: 0x001F63E8
		public void SetSortingLayer(bool back)
		{
			this.spriteRenderer.sortingLayerName = (back ? "CustomerSitting" : "Default");
			base.GetComponent<CharacterHairPlacer>().hairInstance.sortingLayerName = (back ? "CustomerSitting" : "Default");
			this.throbObject.GetComponent<SpriteRenderer>().sortingLayerName = (back ? "CustomerSitting" : "Default");
		}

		// Token: 0x04004BC0 RID: 19392
		public GameObject throbObject;

		// Token: 0x04004BC1 RID: 19393
		public Meter happinessMeter;

		// Token: 0x04004BC2 RID: 19394
		public Bubble speechBubble;

		// Token: 0x04004BC3 RID: 19395
		public float distanceThreshold = 0.5f;

		// Token: 0x04004BC4 RID: 19396
		private Food desiredFood;

		// Token: 0x04004BC5 RID: 19397
		private Collider2D collider2d;

		// Token: 0x04004BC6 RID: 19398
		private Chair targetChair;

		// Token: 0x04004BC7 RID: 19399
		[HideInInspector]
		public Transform leaveTarget;

		// Token: 0x04004BC8 RID: 19400
		[HideInInspector]
		public AIController.AIState state;

		// Token: 0x04004BC9 RID: 19401
		private Animator animator;

		// Token: 0x04004BCA RID: 19402
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BCB RID: 19403
		private float patienceDegradation = 2f;

		// Token: 0x04004BCC RID: 19404
		private float timeToOrder = 0.5f;

		// Token: 0x04004BCD RID: 19405
		private float timeToEat;

		// Token: 0x04004BCE RID: 19406
		private float happiness = 50f;

		// Token: 0x04004BCF RID: 19407
		private float orderTime;

		// Token: 0x04004BD0 RID: 19408
		private float eatTime;

		// Token: 0x04004BD1 RID: 19409
		private int normalSortingLayer;

		// Token: 0x04004BD2 RID: 19410
		private bool isPaused;

		// Token: 0x04004BD3 RID: 19411
		public bool Male;

		// Token: 0x020006DA RID: 1754
		public enum AIState
		{
			// Token: 0x040051A4 RID: 20900
			Entering,
			// Token: 0x040051A5 RID: 20901
			Menu,
			// Token: 0x040051A6 RID: 20902
			Ordering,
			// Token: 0x040051A7 RID: 20903
			Waiting,
			// Token: 0x040051A8 RID: 20904
			Eating,
			// Token: 0x040051A9 RID: 20905
			Leaving
		}
	}
}
