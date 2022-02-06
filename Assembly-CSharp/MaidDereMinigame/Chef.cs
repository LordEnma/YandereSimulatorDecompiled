using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000589 RID: 1417
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x060023F2 RID: 9202 RVA: 0x001F83AC File Offset: 0x001F65AC
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

		// Token: 0x060023F3 RID: 9203 RVA: 0x001F83CA File Offset: 0x001F65CA
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x060023F4 RID: 9204 RVA: 0x001F83FB File Offset: 0x001F65FB
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F5 RID: 9205 RVA: 0x001F841D File Offset: 0x001F661D
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F6 RID: 9206 RVA: 0x001F843F File Offset: 0x001F663F
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x060023F7 RID: 9207 RVA: 0x001F8460 File Offset: 0x001F6660
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x001F8472 File Offset: 0x001F6672
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x060023F9 RID: 9209 RVA: 0x001F8494 File Offset: 0x001F6694
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

		// Token: 0x060023FA RID: 9210 RVA: 0x001F8578 File Offset: 0x001F6778
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x060023FB RID: 9211 RVA: 0x001F858A File Offset: 0x001F678A
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004BC2 RID: 19394
		private static Chef instance;

		// Token: 0x04004BC3 RID: 19395
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004BC4 RID: 19396
		public FoodMenu foodMenu;

		// Token: 0x04004BC5 RID: 19397
		public Meter cookMeter;

		// Token: 0x04004BC6 RID: 19398
		public float cookTime = 3f;

		// Token: 0x04004BC7 RID: 19399
		private Chef.ChefState state;

		// Token: 0x04004BC8 RID: 19400
		private Food currentPlate;

		// Token: 0x04004BC9 RID: 19401
		private Animator animator;

		// Token: 0x04004BCA RID: 19402
		private float timeToFinishDish;

		// Token: 0x04004BCB RID: 19403
		private bool isPaused;

		// Token: 0x020006D3 RID: 1747
		public enum ChefState
		{
			// Token: 0x04005186 RID: 20870
			Queueing,
			// Token: 0x04005187 RID: 20871
			Cooking,
			// Token: 0x04005188 RID: 20872
			Delivering
		}
	}
}
