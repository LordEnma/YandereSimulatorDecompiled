using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059C RID: 1436
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x06002453 RID: 9299 RVA: 0x001F97F4 File Offset: 0x001F79F4
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x06002454 RID: 9300 RVA: 0x001F9848 File Offset: 0x001F7A48
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

		// Token: 0x06002455 RID: 9301 RVA: 0x001F9898 File Offset: 0x001F7A98
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x06002456 RID: 9302 RVA: 0x001F98AD File Offset: 0x001F7AAD
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

		// Token: 0x06002457 RID: 9303 RVA: 0x001F98BC File Offset: 0x001F7ABC
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x001F98CB File Offset: 0x001F7ACB
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004C22 RID: 19490
		public List<Sprite> numbers;

		// Token: 0x04004C23 RID: 19491
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C24 RID: 19492
		public Sprite timeUp;

		// Token: 0x04004C25 RID: 19493
		public TipPage tipPage;

		// Token: 0x04004C26 RID: 19494
		private AudioSource audioSource;

		// Token: 0x04004C27 RID: 19495
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C28 RID: 19496
		private int timeToStart = 3;
	}
}
