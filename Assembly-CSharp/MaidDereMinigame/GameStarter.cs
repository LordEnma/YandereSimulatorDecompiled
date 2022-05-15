using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class GameStarter : MonoBehaviour
	{
		// Token: 0x060024BD RID: 9405 RVA: 0x002033A8 File Offset: 0x002015A8
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.audioSource = base.GetComponent<AudioSource>();
			base.StartCoroutine(this.CountdownToStart());
			GameController.Instance.tipPage = this.tipPage;
			GameController.Instance.whiteFadeOutPost = this.whiteFadeOutPost;
		}

		// Token: 0x060024BE RID: 9406 RVA: 0x002033FC File Offset: 0x002015FC
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

		// Token: 0x060024BF RID: 9407 RVA: 0x0020344C File Offset: 0x0020164C
		public void EndGame()
		{
			base.StartCoroutine(this.EndGameRoutine());
			SFXController.PlaySound(SFXController.Sounds.GameSuccess);
		}

		// Token: 0x060024C0 RID: 9408 RVA: 0x00203461 File Offset: 0x00201661
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

		// Token: 0x060024C1 RID: 9409 RVA: 0x00203470 File Offset: 0x00201670
		private IEnumerator EndGameRoutine()
		{
			GameController.SetPause(true);
			this.spriteRenderer.sprite = this.timeUp;
			yield return new WaitForSeconds(1f);
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			GameController.TimeUp();
			yield break;
		}

		// Token: 0x060024C2 RID: 9410 RVA: 0x0020347F File Offset: 0x0020167F
		public void SetAudioPitch(float value)
		{
			this.audioSource.pitch = value;
		}

		// Token: 0x04004D53 RID: 19795
		public List<Sprite> numbers;

		// Token: 0x04004D54 RID: 19796
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004D55 RID: 19797
		public Sprite timeUp;

		// Token: 0x04004D56 RID: 19798
		public TipPage tipPage;

		// Token: 0x04004D57 RID: 19799
		private AudioSource audioSource;

		// Token: 0x04004D58 RID: 19800
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D59 RID: 19801
		private int timeToStart = 3;
	}
}
