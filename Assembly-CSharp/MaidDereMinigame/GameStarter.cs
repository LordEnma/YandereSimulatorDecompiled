using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A8 RID: 1448
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x0600249A RID: 9370 RVA: 0x001FF7F4 File Offset: 0x001FD9F4
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x0600249B RID: 9371 RVA: 0x001FF848 File Offset: 0x001FDA48
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

		// Token: 0x0600249C RID: 9372 RVA: 0x001FF898 File Offset: 0x001FDA98
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x0600249D RID: 9373 RVA: 0x001FF8AD File Offset: 0x001FDAAD
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

		// Token: 0x0600249E RID: 9374 RVA: 0x001FF8BC File Offset: 0x001FDABC
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x0600249F RID: 9375 RVA: 0x001FF8CB File Offset: 0x001FDACB
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004CFD RID: 19709
		public List<Sprite> numbers;

		// Token: 0x04004CFE RID: 19710
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004CFF RID: 19711
		public Sprite timeUp;

		// Token: 0x04004D00 RID: 19712
		public TipPage tipPage;

		// Token: 0x04004D01 RID: 19713
		private AudioSource audioSource;

		// Token: 0x04004D02 RID: 19714
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D03 RID: 19715
		private int timeToStart = 3;
	}
}
