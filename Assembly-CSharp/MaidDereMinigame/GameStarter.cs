using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AA RID: 1450
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x060024B2 RID: 9394 RVA: 0x00201C5C File Offset: 0x001FFE5C
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x060024B3 RID: 9395 RVA: 0x00201CB0 File Offset: 0x001FFEB0
		public void SetGameTime(float gameTime)
		{
			int num = Mathf.CeilToInt(gameTime);
			if ((float)num == 10f)
			{
				SFXController.PlaySound(SFXController.Sounds.ClockTick);
			}
			if (gameTime > 3f)
			{
				return;
			}
			if (num - 1 <= 2)
			{
				this.spriteRenderer.sprite = this.numbers[num];
				return;
			}
			this.EndGame();
		}

		// Token: 0x060024B4 RID: 9396 RVA: 0x00201D00 File Offset: 0x001FFF00
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x060024B5 RID: 9397 RVA: 0x00201D15 File Offset: 0x001FFF15
		private IEnumerator CountdownToStart()
		{
			yield return new WaitForSeconds(GameController.Instance.activeDifficultyVariables.transitionTime);
			SFXController.PlaySound(SFXController.Sounds.Countdown);
			while (this.timeToStart > 0)
			{
				yield return new WaitForSeconds(1f);
				this.timeToStart--;
				this.spriteRenderer.sprite = this.numbers[this.timeToStart];
			}
			yield return new WaitForSeconds(1f);
			GameController.SetPause(false);
			this.spriteRenderer.sprite = null;
			yield break;
		}

		// Token: 0x060024B6 RID: 9398 RVA: 0x00201D24 File Offset: 0x001FFF24
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x060024B7 RID: 9399 RVA: 0x00201D33 File Offset: 0x001FFF33
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004D2C RID: 19756
		public List<Sprite> numbers;

		// Token: 0x04004D2D RID: 19757
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004D2E RID: 19758
		public Sprite timeUp;

		// Token: 0x04004D2F RID: 19759
		public TipPage tipPage;

		// Token: 0x04004D30 RID: 19760
		private AudioSource audioSource;

		// Token: 0x04004D31 RID: 19761
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D32 RID: 19762
		private int timeToStart = 3;
	}
}
