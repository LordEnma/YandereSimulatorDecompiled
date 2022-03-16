using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A3 RID: 1443
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x0600248A RID: 9354 RVA: 0x001FDF84 File Offset: 0x001FC184
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x0600248B RID: 9355 RVA: 0x001FDFD8 File Offset: 0x001FC1D8
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

		// Token: 0x0600248C RID: 9356 RVA: 0x001FE028 File Offset: 0x001FC228
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x0600248D RID: 9357 RVA: 0x001FE03D File Offset: 0x001FC23D
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

		// Token: 0x0600248E RID: 9358 RVA: 0x001FE04C File Offset: 0x001FC24C
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x0600248F RID: 9359 RVA: 0x001FE05B File Offset: 0x001FC25B
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004CCB RID: 19659
		public List<Sprite> numbers;

		// Token: 0x04004CCC RID: 19660
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004CCD RID: 19661
		public Sprite timeUp;

		// Token: 0x04004CCE RID: 19662
		public TipPage tipPage;

		// Token: 0x04004CCF RID: 19663
		private AudioSource audioSource;

		// Token: 0x04004CD0 RID: 19664
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004CD1 RID: 19665
		private int timeToStart = 3;
	}
}
