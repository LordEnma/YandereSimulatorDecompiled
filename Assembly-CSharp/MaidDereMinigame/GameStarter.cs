using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059C RID: 1436
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x06002457 RID: 9303 RVA: 0x001FA094 File Offset: 0x001F8294
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x06002458 RID: 9304 RVA: 0x001FA0E8 File Offset: 0x001F82E8
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

		// Token: 0x06002459 RID: 9305 RVA: 0x001FA138 File Offset: 0x001F8338
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x0600245A RID: 9306 RVA: 0x001FA14D File Offset: 0x001F834D
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

		// Token: 0x0600245B RID: 9307 RVA: 0x001FA15C File Offset: 0x001F835C
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x0600245C RID: 9308 RVA: 0x001FA16B File Offset: 0x001F836B
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004C2D RID: 19501
		public List<Sprite> numbers;

		// Token: 0x04004C2E RID: 19502
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C2F RID: 19503
		public Sprite timeUp;

		// Token: 0x04004C30 RID: 19504
		public TipPage tipPage;

		// Token: 0x04004C31 RID: 19505
		private AudioSource audioSource;

		// Token: 0x04004C32 RID: 19506
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C33 RID: 19507
		private int timeToStart = 3;
	}
}
