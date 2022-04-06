using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x060024A2 RID: 9378 RVA: 0x001FFD24 File Offset: 0x001FDF24
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x060024A3 RID: 9379 RVA: 0x001FFD78 File Offset: 0x001FDF78
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

		// Token: 0x060024A4 RID: 9380 RVA: 0x001FFDC8 File Offset: 0x001FDFC8
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x060024A5 RID: 9381 RVA: 0x001FFDDD File Offset: 0x001FDFDD
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

		// Token: 0x060024A6 RID: 9382 RVA: 0x001FFDEC File Offset: 0x001FDFEC
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x060024A7 RID: 9383 RVA: 0x001FFDFB File Offset: 0x001FDFFB
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004D01 RID: 19713
		public List<Sprite> numbers;

		// Token: 0x04004D02 RID: 19714
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004D03 RID: 19715
		public Sprite timeUp;

		// Token: 0x04004D04 RID: 19716
		public TipPage tipPage;

		// Token: 0x04004D05 RID: 19717
		private AudioSource audioSource;

		// Token: 0x04004D06 RID: 19718
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D07 RID: 19719
		private int timeToStart = 3;
	}
}
