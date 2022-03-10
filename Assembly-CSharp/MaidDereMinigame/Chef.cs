using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058C RID: 1420
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06002408 RID: 9224 RVA: 0x001F9E18 File Offset: 0x001F8018
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

		// Token: 0x06002409 RID: 9225 RVA: 0x001F9E36 File Offset: 0x001F8036
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x0600240A RID: 9226 RVA: 0x001F9E67 File Offset: 0x001F8067
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x001F9E89 File Offset: 0x001F8089
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600240C RID: 9228 RVA: 0x001F9EAB File Offset: 0x001F80AB
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x0600240D RID: 9229 RVA: 0x001F9ECC File Offset: 0x001F80CC
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x0600240E RID: 9230 RVA: 0x001F9EDE File Offset: 0x001F80DE
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x0600240F RID: 9231 RVA: 0x001F9F00 File Offset: 0x001F8100
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

		// Token: 0x06002410 RID: 9232 RVA: 0x001F9FE4 File Offset: 0x001F81E4
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x06002411 RID: 9233 RVA: 0x001F9FF6 File Offset: 0x001F81F6
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004BF8 RID: 19448
		private static Chef instance;

		// Token: 0x04004BF9 RID: 19449
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004BFA RID: 19450
		public FoodMenu foodMenu;

		// Token: 0x04004BFB RID: 19451
		public Meter cookMeter;

		// Token: 0x04004BFC RID: 19452
		public float cookTime = 3f;

		// Token: 0x04004BFD RID: 19453
		private Chef.ChefState state;

		// Token: 0x04004BFE RID: 19454
		private Food currentPlate;

		// Token: 0x04004BFF RID: 19455
		private Animator animator;

		// Token: 0x04004C00 RID: 19456
		private float timeToFinishDish;

		// Token: 0x04004C01 RID: 19457
		private bool isPaused;

		// Token: 0x020006D8 RID: 1752
		public enum ChefState
		{
			// Token: 0x040051C1 RID: 20929
			Queueing,
			// Token: 0x040051C2 RID: 20930
			Cooking,
			// Token: 0x040051C3 RID: 20931
			Delivering
		}
	}
}
