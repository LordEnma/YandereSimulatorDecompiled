using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x0200059B RID: 1435
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x06002451 RID: 9297 RVA: 0x001F8B24 File Offset: 0x001F6D24
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x06002452 RID: 9298 RVA: 0x001F8B78 File Offset: 0x001F6D78
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

		// Token: 0x06002453 RID: 9299 RVA: 0x001F8BC8 File Offset: 0x001F6DC8
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x06002454 RID: 9300 RVA: 0x001F8BDD File Offset: 0x001F6DDD
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

		// Token: 0x06002455 RID: 9301 RVA: 0x001F8BEC File Offset: 0x001F6DEC
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x06002456 RID: 9302 RVA: 0x001F8BFB File Offset: 0x001F6DFB
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004C1B RID: 19483
		public List<Sprite> numbers;

		// Token: 0x04004C1C RID: 19484
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C1D RID: 19485
		public Sprite timeUp;

		// Token: 0x04004C1E RID: 19486
		public TipPage tipPage;

		// Token: 0x04004C1F RID: 19487
		private AudioSource audioSource;

		// Token: 0x04004C20 RID: 19488
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C21 RID: 19489
		private int timeToStart = 3;
	}
}
