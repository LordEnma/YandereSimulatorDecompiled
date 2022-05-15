using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000598 RID: 1432
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06002453 RID: 9299 RVA: 0x00201154 File Offset: 0x001FF354
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

		// Token: 0x06002454 RID: 9300 RVA: 0x00201172 File Offset: 0x001FF372
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x06002455 RID: 9301 RVA: 0x002011A3 File Offset: 0x001FF3A3
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002456 RID: 9302 RVA: 0x002011C5 File Offset: 0x001FF3C5
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002457 RID: 9303 RVA: 0x002011E7 File Offset: 0x001FF3E7
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x00201208 File Offset: 0x001FF408
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x06002459 RID: 9305 RVA: 0x0020121A File Offset: 0x001FF41A
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x0020123C File Offset: 0x001FF43C
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

		// Token: 0x0600245B RID: 9307 RVA: 0x00201320 File Offset: 0x001FF520
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x0600245C RID: 9308 RVA: 0x00201332 File Offset: 0x001FF532
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004CDC RID: 19676
		private static Chef instance;

		// Token: 0x04004CDD RID: 19677
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004CDE RID: 19678
		public FoodMenu foodMenu;

		// Token: 0x04004CDF RID: 19679
		public Meter cookMeter;

		// Token: 0x04004CE0 RID: 19680
		public float cookTime = 3f;

		// Token: 0x04004CE1 RID: 19681
		private Chef.ChefState state;

		// Token: 0x04004CE2 RID: 19682
		private Food currentPlate;

		// Token: 0x04004CE3 RID: 19683
		private Animator animator;

		// Token: 0x04004CE4 RID: 19684
		private float timeToFinishDish;

		// Token: 0x04004CE5 RID: 19685
		private bool isPaused;

		// Token: 0x020006E4 RID: 1764
		public enum ChefState
		{
			// Token: 0x040052AD RID: 21165
			Queueing,
			// Token: 0x040052AE RID: 21166
			Cooking,
			// Token: 0x040052AF RID: 21167
			Delivering
		}
	}
}
