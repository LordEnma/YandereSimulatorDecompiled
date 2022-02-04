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
		// (get) Token: 0x060023EF RID: 9199 RVA: 0x001F81A8 File Offset: 0x001F63A8
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

		// Token: 0x060023F0 RID: 9200 RVA: 0x001F81C6 File Offset: 0x001F63C6
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x060023F1 RID: 9201 RVA: 0x001F81F7 File Offset: 0x001F63F7
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F2 RID: 9202 RVA: 0x001F8219 File Offset: 0x001F6419
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023F3 RID: 9203 RVA: 0x001F823B File Offset: 0x001F643B
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x060023F4 RID: 9204 RVA: 0x001F825C File Offset: 0x001F645C
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x060023F5 RID: 9205 RVA: 0x001F826E File Offset: 0x001F646E
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x060023F6 RID: 9206 RVA: 0x001F8290 File Offset: 0x001F6490
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

		// Token: 0x060023F7 RID: 9207 RVA: 0x001F8374 File Offset: 0x001F6574
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x001F8386 File Offset: 0x001F6586
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004BBF RID: 19391
		private static Chef instance;

		// Token: 0x04004BC0 RID: 19392
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004BC1 RID: 19393
		public FoodMenu foodMenu;

		// Token: 0x04004BC2 RID: 19394
		public Meter cookMeter;

		// Token: 0x04004BC3 RID: 19395
		public float cookTime = 3f;

		// Token: 0x04004BC4 RID: 19396
		private Chef.ChefState state;

		// Token: 0x04004BC5 RID: 19397
		private Food currentPlate;

		// Token: 0x04004BC6 RID: 19398
		private Animator animator;

		// Token: 0x04004BC7 RID: 19399
		private float timeToFinishDish;

		// Token: 0x04004BC8 RID: 19400
		private bool isPaused;

		// Token: 0x020006D3 RID: 1747
		public enum ChefState
		{
			// Token: 0x04005183 RID: 20867
			Queueing,
			// Token: 0x04005184 RID: 20868
			Cooking,
			// Token: 0x04005185 RID: 20869
			Delivering
		}
	}
}
