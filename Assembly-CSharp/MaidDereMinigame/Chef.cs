using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200058A RID: 1418
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x060023F9 RID: 9209 RVA: 0x001F8860 File Offset: 0x001F6A60
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

		// Token: 0x060023FA RID: 9210 RVA: 0x001F887E File Offset: 0x001F6A7E
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x060023FB RID: 9211 RVA: 0x001F88AF File Offset: 0x001F6AAF
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023FC RID: 9212 RVA: 0x001F88D1 File Offset: 0x001F6AD1
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023FD RID: 9213 RVA: 0x001F88F3 File Offset: 0x001F6AF3
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x060023FE RID: 9214 RVA: 0x001F8914 File Offset: 0x001F6B14
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x060023FF RID: 9215 RVA: 0x001F8926 File Offset: 0x001F6B26
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x06002400 RID: 9216 RVA: 0x001F8948 File Offset: 0x001F6B48
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

		// Token: 0x06002401 RID: 9217 RVA: 0x001F8A2C File Offset: 0x001F6C2C
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x06002402 RID: 9218 RVA: 0x001F8A3E File Offset: 0x001F6C3E
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004BCB RID: 19403
		private static Chef instance;

		// Token: 0x04004BCC RID: 19404
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004BCD RID: 19405
		public FoodMenu foodMenu;

		// Token: 0x04004BCE RID: 19406
		public Meter cookMeter;

		// Token: 0x04004BCF RID: 19407
		public float cookTime = 3f;

		// Token: 0x04004BD0 RID: 19408
		private Chef.ChefState state;

		// Token: 0x04004BD1 RID: 19409
		private Food currentPlate;

		// Token: 0x04004BD2 RID: 19410
		private Animator animator;

		// Token: 0x04004BD3 RID: 19411
		private float timeToFinishDish;

		// Token: 0x04004BD4 RID: 19412
		private bool isPaused;

		// Token: 0x020006D4 RID: 1748
		public enum ChefState
		{
			// Token: 0x0400518F RID: 20879
			Queueing,
			// Token: 0x04005190 RID: 20880
			Cooking,
			// Token: 0x04005191 RID: 20881
			Delivering
		}
	}
}
