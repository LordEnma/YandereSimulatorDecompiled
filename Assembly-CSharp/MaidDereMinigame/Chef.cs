using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000586 RID: 1414
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x060023D9 RID: 9177 RVA: 0x001F5990 File Offset: 0x001F3B90
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

		// Token: 0x060023DA RID: 9178 RVA: 0x001F59AE File Offset: 0x001F3BAE
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x060023DB RID: 9179 RVA: 0x001F59DF File Offset: 0x001F3BDF
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023DC RID: 9180 RVA: 0x001F5A01 File Offset: 0x001F3C01
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x060023DD RID: 9181 RVA: 0x001F5A23 File Offset: 0x001F3C23
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x060023DE RID: 9182 RVA: 0x001F5A44 File Offset: 0x001F3C44
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x060023DF RID: 9183 RVA: 0x001F5A56 File Offset: 0x001F3C56
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x060023E0 RID: 9184 RVA: 0x001F5A78 File Offset: 0x001F3C78
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

		// Token: 0x060023E1 RID: 9185 RVA: 0x001F5B5C File Offset: 0x001F3D5C
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x060023E2 RID: 9186 RVA: 0x001F5B6E File Offset: 0x001F3D6E
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004B8A RID: 19338
		private static Chef instance;

		// Token: 0x04004B8B RID: 19339
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004B8C RID: 19340
		public FoodMenu foodMenu;

		// Token: 0x04004B8D RID: 19341
		public Meter cookMeter;

		// Token: 0x04004B8E RID: 19342
		public float cookTime = 3f;

		// Token: 0x04004B8F RID: 19343
		private Chef.ChefState state;

		// Token: 0x04004B90 RID: 19344
		private Food currentPlate;

		// Token: 0x04004B91 RID: 19345
		private Animator animator;

		// Token: 0x04004B92 RID: 19346
		private float timeToFinishDish;

		// Token: 0x04004B93 RID: 19347
		private bool isPaused;

		// Token: 0x020006D6 RID: 1750
		public enum ChefState
		{
			// Token: 0x0400517C RID: 20860
			Queueing,
			// Token: 0x0400517D RID: 20861
			Cooking,
			// Token: 0x0400517E RID: 20862
			Delivering
		}
	}
}
