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
		// (get) Token: 0x060023ED RID: 9197 RVA: 0x001F7E90 File Offset: 0x001F6090
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

		// Token: 0x060023EE RID: 9198 RVA: 0x001F7EAE File Offset: 0x001F60AE
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x060023EF RID: 9199 RVA: 0x001F7EDF File Offset: 0x001F60DF
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F0 RID: 9200 RVA: 0x001F7F01 File Offset: 0x001F6101
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F1 RID: 9201 RVA: 0x001F7F23 File Offset: 0x001F6123
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x060023F2 RID: 9202 RVA: 0x001F7F44 File Offset: 0x001F6144
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x060023F3 RID: 9203 RVA: 0x001F7F56 File Offset: 0x001F6156
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x060023F4 RID: 9204 RVA: 0x001F7F78 File Offset: 0x001F6178
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

		// Token: 0x060023F5 RID: 9205 RVA: 0x001F805C File Offset: 0x001F625C
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x060023F6 RID: 9206 RVA: 0x001F806E File Offset: 0x001F626E
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004BB9 RID: 19385
		private static Chef instance;

		// Token: 0x04004BBA RID: 19386
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004BBB RID: 19387
		public FoodMenu foodMenu;

		// Token: 0x04004BBC RID: 19388
		public Meter cookMeter;

		// Token: 0x04004BBD RID: 19389
		public float cookTime = 3f;

		// Token: 0x04004BBE RID: 19390
		private Chef.ChefState state;

		// Token: 0x04004BBF RID: 19391
		private Food currentPlate;

		// Token: 0x04004BC0 RID: 19392
		private Animator animator;

		// Token: 0x04004BC1 RID: 19393
		private float timeToFinishDish;

		// Token: 0x04004BC2 RID: 19394
		private bool isPaused;

		// Token: 0x020006D3 RID: 1747
		public enum ChefState
		{
			// Token: 0x0400517D RID: 20861
			Queueing,
			// Token: 0x0400517E RID: 20862
			Cooking,
			// Token: 0x0400517F RID: 20863
			Delivering
		}
	}
}
