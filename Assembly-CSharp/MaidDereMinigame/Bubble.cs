using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000596 RID: 1430
	public class Bubble : MonoBehaviour
	{
		// Token: 0x0600244F RID: 9295 RVA: 0x001FBAA6 File Offset: 0x001F9CA6
		private void Awake()
		{
			this.foodRenderer.sprite = null;
		}

		// Token: 0x06002450 RID: 9296 RVA: 0x001FBAB4 File Offset: 0x001F9CB4
		private void OnEnable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Combine(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002451 RID: 9297 RVA: 0x001FBAD6 File Offset: 0x001F9CD6
		private void OnDisable()
		{
			GameController.PauseGame = (BoolParameterEvent)Delegate.Remove(GameController.PauseGame, new BoolParameterEvent(this.Pause));
		}

		// Token: 0x06002452 RID: 9298 RVA: 0x001FBAF8 File Offset: 0x001F9CF8
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

		// Token: 0x06002453 RID: 9299 RVA: 0x001FBB38 File Offset: 0x001F9D38
		public void BubbleReachedMax()
		{
			this.foodRenderer.gameObject.SetActive(true);
			this.foodRenderer.sprite = this.food.largeSprite;
		}

		// Token: 0x06002454 RID: 9300 RVA: 0x001FBB61 File Offset: 0x001F9D61
		public void BubbleClosing()
		{
			this.foodRenderer.gameObject.SetActive(false);
		}

		// Token: 0x06002455 RID: 9301 RVA: 0x001FBB74 File Offset: 0x001F9D74
		public void KillBubble()
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		// Token: 0x04004C44 RID: 19524
		[HideInInspector]
		public Food food;

		// Token: 0x04004C45 RID: 19525
		public SpriteRenderer foodRenderer;
	}
}
