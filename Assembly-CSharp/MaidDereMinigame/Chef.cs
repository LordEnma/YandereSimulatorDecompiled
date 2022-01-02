using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000586 RID: 1414
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x060023DC RID: 9180 RVA: 0x001F5F80 File Offset: 0x001F4180
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

		// Token: 0x060023DD RID: 9181 RVA: 0x001F5F9E File Offset: 0x001F419E
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x060023DE RID: 9182 RVA: 0x001F5FCF File Offset: 0x001F41CF
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023DF RID: 9183 RVA: 0x001F5FF1 File Offset: 0x001F41F1
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023E0 RID: 9184 RVA: 0x001F6013 File Offset: 0x001F4213
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x060023E1 RID: 9185 RVA: 0x001F6034 File Offset: 0x001F4234
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x060023E2 RID: 9186 RVA: 0x001F6046 File Offset: 0x001F4246
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x060023E3 RID: 9187 RVA: 0x001F6068 File Offset: 0x001F4268
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

		// Token: 0x060023E4 RID: 9188 RVA: 0x001F614C File Offset: 0x001F434C
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x060023E5 RID: 9189 RVA: 0x001F615E File Offset: 0x001F435E
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004B93 RID: 19347
		private static Chef instance;

		// Token: 0x04004B94 RID: 19348
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004B95 RID: 19349
		public FoodMenu foodMenu;

		// Token: 0x04004B96 RID: 19350
		public Meter cookMeter;

		// Token: 0x04004B97 RID: 19351
		public float cookTime = 3f;

		// Token: 0x04004B98 RID: 19352
		private Chef.ChefState state;

		// Token: 0x04004B99 RID: 19353
		private Food currentPlate;

		// Token: 0x04004B9A RID: 19354
		private Animator animator;

		// Token: 0x04004B9B RID: 19355
		private float timeToFinishDish;

		// Token: 0x04004B9C RID: 19356
		private bool isPaused;

		// Token: 0x020006D6 RID: 1750
		public enum ChefState
		{
			// Token: 0x04005185 RID: 20869
			Queueing,
			// Token: 0x04005186 RID: 20870
			Cooking,
			// Token: 0x04005187 RID: 20871
			Delivering
		}
	}
}
