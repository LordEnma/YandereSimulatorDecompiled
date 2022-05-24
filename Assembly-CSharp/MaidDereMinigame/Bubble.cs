using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A2 RID: 1442
	public class Bubble : MonoBehaviour
	{
		// Token: 0x0600249B RID: 9371 RVA: 0x0020339A File Offset: 0x0020159A
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x0600249C RID: 9372 RVA: 0x002033A8 File Offset: 0x002015A8
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600249D RID: 9373 RVA: 0x002033CA File Offset: 0x002015CA
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x0600249E RID: 9374 RVA: 0x002033EC File Offset: 0x002015EC
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

		// Token: 0x0600249F RID: 9375 RVA: 0x0020342C File Offset: 0x0020162C
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x060024A0 RID: 9376 RVA: 0x00203455 File Offset: 0x00201655
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x00203468 File Offset: 0x00201668
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004D34 RID: 19764
		[HideInInspector]
		public Food food;

		// Token: 0x04004D35 RID: 19765
		public SpriteRenderer foodRenderer;
	}
}
