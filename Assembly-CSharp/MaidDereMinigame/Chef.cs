using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000590 RID: 1424
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06002420 RID: 9248 RVA: 0x001FBD80 File Offset: 0x001F9F80
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

		// Token: 0x06002421 RID: 9249 RVA: 0x001FBD9E File Offset: 0x001F9F9E
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x06002422 RID: 9250 RVA: 0x001FBDCF File Offset: 0x001F9FCF
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002423 RID: 9251 RVA: 0x001FBDF1 File Offset: 0x001F9FF1
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002424 RID: 9252 RVA: 0x001FBE13 File Offset: 0x001FA013
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002425 RID: 9253 RVA: 0x001FBE34 File Offset: 0x001FA034
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x06002426 RID: 9254 RVA: 0x001FBE46 File Offset: 0x001FA046
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x06002427 RID: 9255 RVA: 0x001FBE68 File Offset: 0x001FA068
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

		// Token: 0x06002428 RID: 9256 RVA: 0x001FBF4C File Offset: 0x001FA14C
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x06002429 RID: 9257 RVA: 0x001FBF5E File Offset: 0x001FA15E
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004C57 RID: 19543
		private static Chef instance;

		// Token: 0x04004C58 RID: 19544
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004C59 RID: 19545
		public FoodMenu foodMenu;

		// Token: 0x04004C5A RID: 19546
		public Meter cookMeter;

		// Token: 0x04004C5B RID: 19547
		public float cookTime = 3f;

		// Token: 0x04004C5C RID: 19548
		private Chef.ChefState state;

		// Token: 0x04004C5D RID: 19549
		private Food currentPlate;

		// Token: 0x04004C5E RID: 19550
		private Animator animator;

		// Token: 0x04004C5F RID: 19551
		private float timeToFinishDish;

		// Token: 0x04004C60 RID: 19552
		private bool isPaused;

		// Token: 0x020006DC RID: 1756
		public enum ChefState
		{
			// Token: 0x04005220 RID: 21024
			Queueing,
			// Token: 0x04005221 RID: 21025
			Cooking,
			// Token: 0x04005222 RID: 21026
			Delivering
		}
	}
}
