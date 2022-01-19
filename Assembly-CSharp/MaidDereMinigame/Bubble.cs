using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000593 RID: 1427
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002430 RID: 9264 RVA: 0x001F927E File Offset: 0x001F747E
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002431 RID: 9265 RVA: 0x001F928C File Offset: 0x001F748C
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002432 RID: 9266 RVA: 0x001F92AE File Offset: 0x001F74AE
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002433 RID: 9267 RVA: 0x001F92D0 File Offset: 0x001F74D0
		public void Pause(bool toPause)
		{
			if (toPause)
			{
				base.GetComponent<SpriteRenderer>().enabled = false;
				this.foodRenderer.gameObject.SetActive(false);
				return;
			}
			base.GetComponent<SpriteRenderer>().enabled = true;
			this.foodRenderer.gameObject.SetActive(true);
		}

		// Token: 0x06002434 RID: 9268 RVA: 0x001F9310 File Offset: 0x001F7510
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x06002435 RID: 9269 RVA: 0x001F9339 File Offset: 0x001F7539
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x06002436 RID: 9270 RVA: 0x001F934C File Offset: 0x001F754C
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004BFA RID: 19450
		[HideInInspector]
		public Food food;

		// Token: 0x04004BFB RID: 19451
		public SpriteRenderer foodRenderer;
	}
}
