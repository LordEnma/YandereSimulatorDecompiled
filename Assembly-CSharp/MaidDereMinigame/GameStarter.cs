using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059D RID: 1437
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x06002463 RID: 9315 RVA: 0x001FAA64 File Offset: 0x001F8C64
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x06002464 RID: 9316 RVA: 0x001FAAB8 File Offset: 0x001F8CB8
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

		// Token: 0x06002465 RID: 9317 RVA: 0x001FAB08 File Offset: 0x001F8D08
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x06002466 RID: 9318 RVA: 0x001FAB1D File Offset: 0x001F8D1D
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

		// Token: 0x06002467 RID: 9319 RVA: 0x001FAB2C File Offset: 0x001F8D2C
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x001FAB3B File Offset: 0x001F8D3B
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004C3F RID: 19519
		public List<Sprite> numbers;

		// Token: 0x04004C40 RID: 19520
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C41 RID: 19521
		public Sprite timeUp;

		// Token: 0x04004C42 RID: 19522
		public TipPage tipPage;

		// Token: 0x04004C43 RID: 19523
		private AudioSource audioSource;

		// Token: 0x04004C44 RID: 19524
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C45 RID: 19525
		private int timeToStart = 3;
	}
}
