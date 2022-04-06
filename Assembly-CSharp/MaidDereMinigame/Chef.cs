using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000596 RID: 1430
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06002438 RID: 9272 RVA: 0x001FDB20 File Offset: 0x001FBD20
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

		// Token: 0x06002439 RID: 9273 RVA: 0x001FDB3E File Offset: 0x001FBD3E
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x0600243A RID: 9274 RVA: 0x001FDB6F File Offset: 0x001FBD6F
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600243B RID: 9275 RVA: 0x001FDB91 File Offset: 0x001FBD91
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600243C RID: 9276 RVA: 0x001FDBB3 File Offset: 0x001FBDB3
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x0600243D RID: 9277 RVA: 0x001FDBD4 File Offset: 0x001FBDD4
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x0600243E RID: 9278 RVA: 0x001FDBE6 File Offset: 0x001FBDE6
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x0600243F RID: 9279 RVA: 0x001FDC08 File Offset: 0x001FBE08
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

		// Token: 0x06002440 RID: 9280 RVA: 0x001FDCEC File Offset: 0x001FBEEC
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x001FDCFE File Offset: 0x001FBEFE
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004C8D RID: 19597
		private static Chef instance;

		// Token: 0x04004C8E RID: 19598
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004C8F RID: 19599
		public FoodMenu foodMenu;

		// Token: 0x04004C90 RID: 19600
		public Meter cookMeter;

		// Token: 0x04004C91 RID: 19601
		public float cookTime = 3f;

		// Token: 0x04004C92 RID: 19602
		private Chef.ChefState state;

		// Token: 0x04004C93 RID: 19603
		private Food currentPlate;

		// Token: 0x04004C94 RID: 19604
		private Animator animator;

		// Token: 0x04004C95 RID: 19605
		private float timeToFinishDish;

		// Token: 0x04004C96 RID: 19606
		private bool isPaused;

		// Token: 0x020006E2 RID: 1762
		public enum ChefState
		{
			// Token: 0x04005256 RID: 21078
			Queueing,
			// Token: 0x04005257 RID: 21079
			Cooking,
			// Token: 0x04005258 RID: 21080
			Delivering
		}
	}
}
