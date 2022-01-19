using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000589 RID: 1417
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060023E9 RID: 9193 RVA: 0x001F75F0 File Offset: 0x001F57F0
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

		// Token: 0x060023EA RID: 9194 RVA: 0x001F760E File Offset: 0x001F580E
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x060023EB RID: 9195 RVA: 0x001F763F File Offset: 0x001F583F
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023EC RID: 9196 RVA: 0x001F7661 File Offset: 0x001F5861
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023ED RID: 9197 RVA: 0x001F7683 File Offset: 0x001F5883
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x060023EE RID: 9198 RVA: 0x001F76A4 File Offset: 0x001F58A4
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x060023EF RID: 9199 RVA: 0x001F76B6 File Offset: 0x001F58B6
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x060023F0 RID: 9200 RVA: 0x001F76D8 File Offset: 0x001F58D8
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

		// Token: 0x060023F1 RID: 9201 RVA: 0x001F77BC File Offset: 0x001F59BC
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x060023F2 RID: 9202 RVA: 0x001F77CE File Offset: 0x001F59CE
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004BAE RID: 19374
		private static Chef instance;

		// Token: 0x04004BAF RID: 19375
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004BB0 RID: 19376
		public FoodMenu foodMenu;

		// Token: 0x04004BB1 RID: 19377
		public Meter cookMeter;

		// Token: 0x04004BB2 RID: 19378
		public float cookTime = 3f;

		// Token: 0x04004BB3 RID: 19379
		private Chef.ChefState state;

		// Token: 0x04004BB4 RID: 19380
		private Food currentPlate;

		// Token: 0x04004BB5 RID: 19381
		private Animator animator;

		// Token: 0x04004BB6 RID: 19382
		private float timeToFinishDish;

		// Token: 0x04004BB7 RID: 19383
		private bool isPaused;

		// Token: 0x020006D9 RID: 1753
		public enum ChefState
		{
			// Token: 0x040051A0 RID: 20896
			Queueing,
			// Token: 0x040051A1 RID: 20897
			Cooking,
			// Token: 0x040051A2 RID: 20898
			Delivering
		}
	}
}
