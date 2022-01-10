using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A9 RID: 1449
	public class FailGame : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06002484 RID: 9348 RVA: 0x001F9408 File Offset: 0x001F7608
		public static FailGame Instance
		{
			get
			{
				if (FailGame.instance == null)
				{
					FailGame.instance = UnityEngine.Object.FindObjectOfType<FailGame>();
				}
				return FailGame.instance;
			}
		}

		// Token: 0x06002485 RID: 9349 RVA: 0x001F9428 File Offset: 0x001F7628
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x06002486 RID: 9350 RVA: 0x001F9474 File Offset: 0x001F7674
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x06002487 RID: 9351 RVA: 0x001F94A6 File Offset: 0x001F76A6
		private IEnumerator GameFailedRoutine()
		{
			UnityEngine.Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(false);
			yield return null;
			this.textRenderer.color = Color.white;
			while (this.transitionTime < this.targetTransitionTime)
			{
				this.transitionTime += Time.deltaTime;
				yield return null;
			}
			base.transform.GetChild(1).gameObject.SetActive(true);
			while (!Input.anyKeyDown)
			{
				yield return null;
			}
			while (this.transitionTime < this.targetTransitionTime)
			{
				this.transitionTime += Time.deltaTime;
				float a = Mathf.Lerp(0f, 1f, this.transitionTime / this.targetTransitionTime);
				this.spriteRenderer.color = new Color(0f, 0f, 0f, a);
				yield return null;
			}
			GameController.GoToExitScene(false);
			yield break;
		}

		// Token: 0x06002488 RID: 9352 RVA: 0x001F94B5 File Offset: 0x001F76B5
		private IEnumerator SlowPitch()
		{
			GameStarter starter = UnityEngine.Object.FindObjectOfType<GameStarter>();
			float timeToZero = 5f;
			while (timeToZero > 0f)
			{
				starter.SetAudioPitch(Mathf.Lerp(0f, 1f, timeToZero / 5f));
				timeToZero -= Time.deltaTime;
				yield return null;
			}
			starter.SetAudioPitch(0f);
			yield break;
		}

		// Token: 0x04004C3D RID: 19517
		private static FailGame instance;

		// Token: 0x04004C3E RID: 19518
		public float fadeMultiplier = 2f;

		// Token: 0x04004C3F RID: 19519
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C40 RID: 19520
		private SpriteRenderer textRenderer;

		// Token: 0x04004C41 RID: 19521
		private float targetTransitionTime;

		// Token: 0x04004C42 RID: 19522
		private float transitionTime;
	}
}
