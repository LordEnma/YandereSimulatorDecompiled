using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000594 RID: 1428
	public class Bubble : MonoBehaviour
	{
		// Token: 0x06002440 RID: 9280 RVA: 0x001FA4EE File Offset: 0x001F86EE
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002441 RID: 9281 RVA: 0x001FA4FC File Offset: 0x001F86FC
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002442 RID: 9282 RVA: 0x001FA51E File Offset: 0x001F871E
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002443 RID: 9283 RVA: 0x001FA540 File Offset: 0x001F8740
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

		// Token: 0x06002444 RID: 9284 RVA: 0x001FA580 File Offset: 0x001F8780
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x06002445 RID: 9285 RVA: 0x001FA5A9 File Offset: 0x001F87A9
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x06002446 RID: 9286 RVA: 0x001FA5BC File Offset: 0x001F87BC
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004C17 RID: 19479
		[HideInInspector]
		public Food food;

		// Token: 0x04004C18 RID: 19480
		public SpriteRenderer foodRenderer;
	}
}
