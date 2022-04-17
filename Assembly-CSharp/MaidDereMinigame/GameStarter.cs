using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x060024A9 RID: 9385 RVA: 0x00200780 File Offset: 0x001FE980
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x060024AA RID: 9386 RVA: 0x002007D4 File Offset: 0x001FE9D4
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

		// Token: 0x060024AB RID: 9387 RVA: 0x00200824 File Offset: 0x001FEA24
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x060024AC RID: 9388 RVA: 0x00200839 File Offset: 0x001FEA39
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

		// Token: 0x060024AD RID: 9389 RVA: 0x00200848 File Offset: 0x001FEA48
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x060024AE RID: 9390 RVA: 0x00200857 File Offset: 0x001FEA57
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004D13 RID: 19731
		public List<Sprite> numbers;

		// Token: 0x04004D14 RID: 19732
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004D15 RID: 19733
		public Sprite timeUp;

		// Token: 0x04004D16 RID: 19734
		public TipPage tipPage;

		// Token: 0x04004D17 RID: 19735
		private AudioSource audioSource;

		// Token: 0x04004D18 RID: 19736
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D19 RID: 19737
		private int timeToStart = 3;
	}
}
