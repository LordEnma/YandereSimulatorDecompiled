using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000597 RID: 1431
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x06002432 RID: 9266 RVA: 0x001F6460 File Offset: 0x001F4660
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x06002433 RID: 9267 RVA: 0x001F64B4 File Offset: 0x001F46B4
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

		// Token: 0x06002434 RID: 9268 RVA: 0x001F6504 File Offset: 0x001F4704
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x06002435 RID: 9269 RVA: 0x001F6519 File Offset: 0x001F4719
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

		// Token: 0x06002436 RID: 9270 RVA: 0x001F6528 File Offset: 0x001F4728
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x06002437 RID: 9271 RVA: 0x001F6537 File Offset: 0x001F4737
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004BBF RID: 19391
		public List<Sprite> numbers;

		// Token: 0x04004BC0 RID: 19392
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004BC1 RID: 19393
		public Sprite timeUp;

		// Token: 0x04004BC2 RID: 19394
		public TipPage tipPage;

		// Token: 0x04004BC3 RID: 19395
		private AudioSource audioSource;

		// Token: 0x04004BC4 RID: 19396
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BC5 RID: 19397
		private int timeToStart = 3;
	}
}
