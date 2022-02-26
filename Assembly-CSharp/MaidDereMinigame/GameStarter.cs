using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059E RID: 1438
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x0600246C RID: 9324 RVA: 0x001FB644 File Offset: 0x001F9844
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x0600246D RID: 9325 RVA: 0x001FB698 File Offset: 0x001F9898
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

		// Token: 0x0600246E RID: 9326 RVA: 0x001FB6E8 File Offset: 0x001F98E8
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x0600246F RID: 9327 RVA: 0x001FB6FD File Offset: 0x001F98FD
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

		// Token: 0x06002470 RID: 9328 RVA: 0x001FB70C File Offset: 0x001F990C
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x06002471 RID: 9329 RVA: 0x001FB71B File Offset: 0x001F991B
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004C4F RID: 19535
		public List<Sprite> numbers;

		// Token: 0x04004C50 RID: 19536
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C51 RID: 19537
		public Sprite timeUp;

		// Token: 0x04004C52 RID: 19538
		public TipPage tipPage;

		// Token: 0x04004C53 RID: 19539
		private AudioSource audioSource;

		// Token: 0x04004C54 RID: 19540
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C55 RID: 19541
		private int timeToStart = 3;
	}
}
