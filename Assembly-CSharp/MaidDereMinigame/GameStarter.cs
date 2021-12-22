using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000599 RID: 1433
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x06002443 RID: 9283 RVA: 0x001F7B94 File Offset: 0x001F5D94
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x06002444 RID: 9284 RVA: 0x001F7BE8 File Offset: 0x001F5DE8
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

		// Token: 0x06002445 RID: 9285 RVA: 0x001F7C38 File Offset: 0x001F5E38
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x06002446 RID: 9286 RVA: 0x001F7C4D File Offset: 0x001F5E4D
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

		// Token: 0x06002447 RID: 9287 RVA: 0x001F7C5C File Offset: 0x001F5E5C
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x06002448 RID: 9288 RVA: 0x001F7C6B File Offset: 0x001F5E6B
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004BFE RID: 19454
		public List<Sprite> numbers;

		// Token: 0x04004BFF RID: 19455
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C00 RID: 19456
		public Sprite timeUp;

		// Token: 0x04004C01 RID: 19457
		public TipPage tipPage;

		// Token: 0x04004C02 RID: 19458
		private AudioSource audioSource;

		// Token: 0x04004C03 RID: 19459
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C04 RID: 19460
		private int timeToStart = 3;
	}
}
