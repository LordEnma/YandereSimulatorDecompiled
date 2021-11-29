using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000584 RID: 1412
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023C8 RID: 9160 RVA: 0x001F425C File Offset: 0x001F245C
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

		// Token: 0x060023C9 RID: 9161 RVA: 0x001F427A File Offset: 0x001F247A
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x060023CA RID: 9162 RVA: 0x001F42AB File Offset: 0x001F24AB
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023CB RID: 9163 RVA: 0x001F42CD File Offset: 0x001F24CD
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023CC RID: 9164 RVA: 0x001F42EF File Offset: 0x001F24EF
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x060023CD RID: 9165 RVA: 0x001F4310 File Offset: 0x001F2510
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x060023CE RID: 9166 RVA: 0x001F4322 File Offset: 0x001F2522
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x060023CF RID: 9167 RVA: 0x001F4344 File Offset: 0x001F2544
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

		// Token: 0x060023D0 RID: 9168 RVA: 0x001F4428 File Offset: 0x001F2628
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x060023D1 RID: 9169 RVA: 0x001F443A File Offset: 0x001F263A
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004B4B RID: 19275
		private static Chef instance;

		// Token: 0x04004B4C RID: 19276
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004B4D RID: 19277
		public FoodMenu foodMenu;

		// Token: 0x04004B4E RID: 19278
		public Meter cookMeter;

		// Token: 0x04004B4F RID: 19279
		public float cookTime = 3f;

		// Token: 0x04004B50 RID: 19280
		private Chef.ChefState state;

		// Token: 0x04004B51 RID: 19281
		private Food currentPlate;

		// Token: 0x04004B52 RID: 19282
		private Animator animator;

		// Token: 0x04004B53 RID: 19283
		private float timeToFinishDish;

		// Token: 0x04004B54 RID: 19284
		private bool isPaused;

		// Token: 0x020006D3 RID: 1747
		public enum ChefState
		{
			// Token: 0x04005131 RID: 20785
			Queueing,
			// Token: 0x04005132 RID: 20786
			Cooking,
			// Token: 0x04005133 RID: 20787
			Delivering
		}
	}
}
