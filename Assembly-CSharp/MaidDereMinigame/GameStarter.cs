using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000599 RID: 1433
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x06002446 RID: 9286 RVA: 0x001F8184 File Offset: 0x001F6384
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x06002447 RID: 9287 RVA: 0x001F81D8 File Offset: 0x001F63D8
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

		// Token: 0x06002448 RID: 9288 RVA: 0x001F8228 File Offset: 0x001F6428
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x06002449 RID: 9289 RVA: 0x001F823D File Offset: 0x001F643D
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

		// Token: 0x0600244A RID: 9290 RVA: 0x001F824C File Offset: 0x001F644C
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x0600244B RID: 9291 RVA: 0x001F825B File Offset: 0x001F645B
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004C07 RID: 19463
		public List<Sprite> numbers;

		// Token: 0x04004C08 RID: 19464
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C09 RID: 19465
		public Sprite timeUp;

		// Token: 0x04004C0A RID: 19466
		public TipPage tipPage;

		// Token: 0x04004C0B RID: 19467
		private AudioSource audioSource;

		// Token: 0x04004C0C RID: 19468
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C0D RID: 19469
		private int timeToStart = 3;
	}
}
