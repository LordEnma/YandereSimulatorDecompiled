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
		// (get) Token: 0x06002454 RID: 9300 RVA: 0x002016BC File Offset: 0x001FF8BC
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

		// Token: 0x06002455 RID: 9301 RVA: 0x002016DA File Offset: 0x001FF8DA
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x06002456 RID: 9302 RVA: 0x0020170B File Offset: 0x001FF90B
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002457 RID: 9303 RVA: 0x0020172D File Offset: 0x001FF92D
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x0020174F File Offset: 0x001FF94F
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002459 RID: 9305 RVA: 0x00201770 File Offset: 0x001FF970
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x00201782 File Offset: 0x001FF982
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x0600245B RID: 9307 RVA: 0x002017A4 File Offset: 0x001FF9A4
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

		// Token: 0x0600245C RID: 9308 RVA: 0x00201888 File Offset: 0x001FFA88
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x0020189A File Offset: 0x001FFA9A
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004CE5 RID: 19685
		private static Chef instance;

		// Token: 0x04004CE6 RID: 19686
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004CE7 RID: 19687
		public FoodMenu foodMenu;

		// Token: 0x04004CE8 RID: 19688
		public Meter cookMeter;

		// Token: 0x04004CE9 RID: 19689
		public float cookTime = 3f;

		// Token: 0x04004CEA RID: 19690
		private Chef.ChefState state;

		// Token: 0x04004CEB RID: 19691
		private Food currentPlate;

		// Token: 0x04004CEC RID: 19692
		private Animator animator;

		// Token: 0x04004CED RID: 19693
		private float timeToFinishDish;

		// Token: 0x04004CEE RID: 19694
		private bool isPaused;

		// Token: 0x020006E4 RID: 1764
		public enum ChefState
		{
			// Token: 0x040052B6 RID: 21174
			Queueing,
			// Token: 0x040052B7 RID: 21175
			Cooking,
			// Token: 0x040052B8 RID: 21176
			Delivering
		}
	}
}
