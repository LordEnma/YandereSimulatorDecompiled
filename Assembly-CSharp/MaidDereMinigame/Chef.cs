using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000595 RID: 1429
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06002430 RID: 9264 RVA: 0x001FD5F0 File Offset: 0x001FB7F0
		public static Chef Instance
		{
			get
			{
				if (Chef.instance == null)
				{
					Chef.instance = UnityEngine.Object.FindObjectOfType<Chef>();
				}
				return Chef.instance;
			}
		}

		// Token: 0x06002431 RID: 9265 RVA: 0x001FD60E File Offset: 0x001FB80E
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x06002432 RID: 9266 RVA: 0x001FD63F File Offset: 0x001FB83F
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002433 RID: 9267 RVA: 0x001FD661 File Offset: 0x001FB861
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002434 RID: 9268 RVA: 0x001FD683 File Offset: 0x001FB883
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002435 RID: 9269 RVA: 0x001FD6A4 File Offset: 0x001FB8A4
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x06002436 RID: 9270 RVA: 0x001FD6B6 File Offset: 0x001FB8B6
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x06002437 RID: 9271 RVA: 0x001FD6D8 File Offset: 0x001FB8D8
		private void Update()
		{
			if (this.isPaused)
			{
				return;
			}
			Chef.ChefState chefState = this.state;
			if (chefState != Chef.ChefState.Queueing)
			{
				if (chefState != Chef.ChefState.Cooking)
				{
					return;
				}
				if (this.timeToFinishDish <= 0f)
				{
					this.state = Chef.ChefState.Delivering;
					this.animator.SetTrigger("PlateCooked");
					this.cookMeter.gameObject.SetActive(false);
					return;
				}
				this.timeToFinishDish -= Time.deltaTime;
				this.cookMeter.SetFill(1f - this.timeToFinishDish / (this.currentPlate.cookTimeMultiplier * this.cookTime));
			}
			else if (this.cookQueue.Count > 0)
			{
				this.currentPlate = Chef.GrabFromQueue();
				this.timeToFinishDish = this.currentPlate.cookTimeMultiplier * this.cookTime;
				this.state = Chef.ChefState.Cooking;
				this.cookMeter.gameObject.SetActive(true);
				return;
			}
		}

		// Token: 0x06002438 RID: 9272 RVA: 0x001FD7BC File Offset: 0x001FB9BC
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x06002439 RID: 9273 RVA: 0x001FD7CE File Offset: 0x001FB9CE
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004C89 RID: 19593
		private static Chef instance;

		// Token: 0x04004C8A RID: 19594
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004C8B RID: 19595
		public FoodMenu foodMenu;

		// Token: 0x04004C8C RID: 19596
		public Meter cookMeter;

		// Token: 0x04004C8D RID: 19597
		public float cookTime = 3f;

		// Token: 0x04004C8E RID: 19598
		private Chef.ChefState state;

		// Token: 0x04004C8F RID: 19599
		private Food currentPlate;

		// Token: 0x04004C90 RID: 19600
		private Animator animator;

		// Token: 0x04004C91 RID: 19601
		private float timeToFinishDish;

		// Token: 0x04004C92 RID: 19602
		private bool isPaused;

		// Token: 0x020006E1 RID: 1761
		public enum ChefState
		{
			// Token: 0x04005252 RID: 21074
			Queueing,
			// Token: 0x04005253 RID: 21075
			Cooking,
			// Token: 0x04005254 RID: 21076
			Delivering
		}
	}
}
