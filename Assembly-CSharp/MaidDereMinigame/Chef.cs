using System;
using MaidDereMinigame.Malee;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000596 RID: 1430
	[RequireComponent(typeof(Animator))]
	public class Chef : MonoBehaviour
	{
		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x0600243F RID: 9279 RVA: 0x001FE57C File Offset: 0x001FC77C
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

		// Token: 0x06002440 RID: 9280 RVA: 0x001FE59A File Offset: 0x001FC79A
		private void Awake()
		{
			this.cookQueue = new Foods();
			this.animator = base.GetComponent<Animator>();
			this.cookMeter.gameObject.SetActive(false);
			this.isPaused = true;
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x001FE5CB File Offset: 0x001FC7CB
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002442 RID: 9282 RVA: 0x001FE5ED File Offset: 0x001FC7ED
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002443 RID: 9283 RVA: 0x001FE60F File Offset: 0x001FC80F
		public void Pause(bool toPause)
		{
			this.isPaused = toPause;
			this.animator.speed = (float)(this.isPaused ? 0 : 1);
		}

		// Token: 0x06002444 RID: 9284 RVA: 0x001FE630 File Offset: 0x001FC830
		public static void AddToQueue(Food foodItem)
		{
			Chef.Instance.cookQueue.Add(foodItem);
		}

		// Token: 0x06002445 RID: 9285 RVA: 0x001FE642 File Offset: 0x001FC842
		public static Food GrabFromQueue()
		{
			Food result = Chef.Instance.cookQueue[0];
			Chef.Instance.cookQueue.RemoveAt(0);
			return result;
		}

		// Token: 0x06002446 RID: 9286 RVA: 0x001FE664 File Offset: 0x001FC864
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

		// Token: 0x06002447 RID: 9287 RVA: 0x001FE748 File Offset: 0x001FC948
		public void Deliver()
		{
			UnityEngine.Object.FindObjectOfType<ServingCounter>().AddPlate(this.currentPlate);
		}

		// Token: 0x06002448 RID: 9288 RVA: 0x001FE75A File Offset: 0x001FC95A
		public void Queue()
		{
			this.state = Chef.ChefState.Queueing;
		}

		// Token: 0x04004C9F RID: 19615
		private static Chef instance;

		// Token: 0x04004CA0 RID: 19616
		[Reorderable]
		public Foods cookQueue;

		// Token: 0x04004CA1 RID: 19617
		public FoodMenu foodMenu;

		// Token: 0x04004CA2 RID: 19618
		public Meter cookMeter;

		// Token: 0x04004CA3 RID: 19619
		public float cookTime = 3f;

		// Token: 0x04004CA4 RID: 19620
		private Chef.ChefState state;

		// Token: 0x04004CA5 RID: 19621
		private Food currentPlate;

		// Token: 0x04004CA6 RID: 19622
		private Animator animator;

		// Token: 0x04004CA7 RID: 19623
		private float timeToFinishDish;

		// Token: 0x04004CA8 RID: 19624
		private bool isPaused;

		// Token: 0x020006E2 RID: 1762
		public enum ChefState
		{
			// Token: 0x04005268 RID: 21096
			Queueing,
			// Token: 0x04005269 RID: 21097
			Cooking,
			// Token: 0x0400526A RID: 21098
			Delivering
		}
	}
}
