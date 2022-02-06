using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059C RID: 1436
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x0600245C RID: 9308 RVA: 0x001FA5B0 File Offset: 0x001F87B0
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x0600245D RID: 9309 RVA: 0x001FA604 File Offset: 0x001F8804
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

		// Token: 0x0600245E RID: 9310 RVA: 0x001FA654 File Offset: 0x001F8854
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x0600245F RID: 9311 RVA: 0x001FA669 File Offset: 0x001F8869
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

		// Token: 0x06002460 RID: 9312 RVA: 0x001FA678 File Offset: 0x001F8878
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x06002461 RID: 9313 RVA: 0x001FA687 File Offset: 0x001F8887
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004C36 RID: 19510
		public List<Sprite> numbers;

		// Token: 0x04004C37 RID: 19511
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C38 RID: 19512
		public Sprite timeUp;

		// Token: 0x04004C39 RID: 19513
		public TipPage tipPage;

		// Token: 0x04004C3A RID: 19514
		private AudioSource audioSource;

		// Token: 0x04004C3B RID: 19515
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C3C RID: 19516
		private int timeToStart = 3;
	}
}
