using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058B RID: 1419
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06002402 RID: 9218 RVA: 0x001F9440 File Offset: 0x001F7640
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

		// Token: 0x06002403 RID: 9219 RVA: 0x001F945E File Offset: 0x001F765E
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x06002404 RID: 9220 RVA: 0x001F948F File Offset: 0x001F768F
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002405 RID: 9221 RVA: 0x001F94B1 File Offset: 0x001F76B1
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002406 RID: 9222 RVA: 0x001F94D3 File Offset: 0x001F76D3
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002407 RID: 9223 RVA: 0x001F94F4 File Offset: 0x001F76F4
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x06002408 RID: 9224 RVA: 0x001F9506 File Offset: 0x001F7706
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x06002409 RID: 9225 RVA: 0x001F9528 File Offset: 0x001F7728
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

		// Token: 0x0600240A RID: 9226 RVA: 0x001F960C File Offset: 0x001F780C
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x0600240B RID: 9227 RVA: 0x001F961E File Offset: 0x001F781E
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004BDB RID: 19419
		private static Chef instance;

		// Token: 0x04004BDC RID: 19420
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004BDD RID: 19421
		public FoodMenu foodMenu;

		// Token: 0x04004BDE RID: 19422
		public Meter cookMeter;

		// Token: 0x04004BDF RID: 19423
		public float cookTime = 3f;

		// Token: 0x04004BE0 RID: 19424
		private Chef.ChefState state;

		// Token: 0x04004BE1 RID: 19425
		private Food currentPlate;

		// Token: 0x04004BE2 RID: 19426
		private Animator animator;

		// Token: 0x04004BE3 RID: 19427
		private float timeToFinishDish;

		// Token: 0x04004BE4 RID: 19428
		private bool isPaused;

		// Token: 0x020006D7 RID: 1751
		public enum ChefState
		{
			// Token: 0x040051A4 RID: 20900
			Queueing,
			// Token: 0x040051A5 RID: 20901
			Cooking,
			// Token: 0x040051A6 RID: 20902
			Delivering
		}
	}
}
