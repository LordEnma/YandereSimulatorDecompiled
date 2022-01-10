using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000588 RID: 1416
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060023E7 RID: 9191 RVA: 0x001F6920 File Offset: 0x001F4B20
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

		// Token: 0x060023E8 RID: 9192 RVA: 0x001F693E File Offset: 0x001F4B3E
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x060023E9 RID: 9193 RVA: 0x001F696F File Offset: 0x001F4B6F
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023EA RID: 9194 RVA: 0x001F6991 File Offset: 0x001F4B91
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023EB RID: 9195 RVA: 0x001F69B3 File Offset: 0x001F4BB3
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x060023EC RID: 9196 RVA: 0x001F69D4 File Offset: 0x001F4BD4
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x060023ED RID: 9197 RVA: 0x001F69E6 File Offset: 0x001F4BE6
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x060023EE RID: 9198 RVA: 0x001F6A08 File Offset: 0x001F4C08
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

		// Token: 0x060023EF RID: 9199 RVA: 0x001F6AEC File Offset: 0x001F4CEC
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x060023F0 RID: 9200 RVA: 0x001F6AFE File Offset: 0x001F4CFE
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004BA7 RID: 19367
		private static Chef instance;

		// Token: 0x04004BA8 RID: 19368
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004BA9 RID: 19369
		public FoodMenu foodMenu;

		// Token: 0x04004BAA RID: 19370
		public Meter cookMeter;

		// Token: 0x04004BAB RID: 19371
		public float cookTime = 3f;

		// Token: 0x04004BAC RID: 19372
		private Chef.ChefState state;

		// Token: 0x04004BAD RID: 19373
		private Food currentPlate;

		// Token: 0x04004BAE RID: 19374
		private Animator animator;

		// Token: 0x04004BAF RID: 19375
		private float timeToFinishDish;

		// Token: 0x04004BB0 RID: 19376
		private bool isPaused;

		// Token: 0x020006D8 RID: 1752
		public enum ChefState
		{
			// Token: 0x04005199 RID: 20889
			Queueing,
			// Token: 0x0400519A RID: 20890
			Cooking,
			// Token: 0x0400519B RID: 20891
			Delivering
		}
	}
}
