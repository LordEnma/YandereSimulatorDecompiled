using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000593 RID: 1427
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002434 RID: 9268 RVA: 0x001F9B1E File Offset: 0x001F7D1E
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002435 RID: 9269 RVA: 0x001F9B2C File Offset: 0x001F7D2C
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002436 RID: 9270 RVA: 0x001F9B4E File Offset: 0x001F7D4E
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002437 RID: 9271 RVA: 0x001F9B70 File Offset: 0x001F7D70
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

		// Token: 0x06002438 RID: 9272 RVA: 0x001F9BB0 File Offset: 0x001F7DB0
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x06002439 RID: 9273 RVA: 0x001F9BD9 File Offset: 0x001F7DD9
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x0600243A RID: 9274 RVA: 0x001F9BEC File Offset: 0x001F7DEC
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004C05 RID: 19461
		[HideInInspector]
		public Food food;

		// Token: 0x04004C06 RID: 19462
		public SpriteRenderer foodRenderer;
	}
}
