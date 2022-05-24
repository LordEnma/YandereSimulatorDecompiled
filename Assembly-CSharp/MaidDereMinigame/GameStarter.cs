using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x060024BE RID: 9406 RVA: 0x00203910 File Offset: 0x00201B10
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x060024BF RID: 9407 RVA: 0x00203964 File Offset: 0x00201B64
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

		// Token: 0x060024C0 RID: 9408 RVA: 0x002039B4 File Offset: 0x00201BB4
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x060024C1 RID: 9409 RVA: 0x002039C9 File Offset: 0x00201BC9
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

		// Token: 0x060024C2 RID: 9410 RVA: 0x002039D8 File Offset: 0x00201BD8
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x060024C3 RID: 9411 RVA: 0x002039E7 File Offset: 0x00201BE7
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004D5C RID: 19804
		public List<Sprite> numbers;

		// Token: 0x04004D5D RID: 19805
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004D5E RID: 19806
		public Sprite timeUp;

		// Token: 0x04004D5F RID: 19807
		public TipPage tipPage;

		// Token: 0x04004D60 RID: 19808
		private AudioSource audioSource;

		// Token: 0x04004D61 RID: 19809
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D62 RID: 19810
		private int timeToStart = 3;
	}
}
