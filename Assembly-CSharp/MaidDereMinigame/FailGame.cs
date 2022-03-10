using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AD RID: 1453
	public class FailGame : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x060024A5 RID: 9381 RVA: 0x001FC900 File Offset: 0x001FAB00
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

		// Token: 0x060024A6 RID: 9382 RVA: 0x001FC920 File Offset: 0x001FAB20
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x060024A7 RID: 9383 RVA: 0x001FC96C File Offset: 0x001FAB6C
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x060024A8 RID: 9384 RVA: 0x001FC99E File Offset: 0x001FAB9E
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

		// Token: 0x060024A9 RID: 9385 RVA: 0x001FC9AD File Offset: 0x001FABAD
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

		// Token: 0x04004C8E RID: 19598
		private static FailGame instance;

		// Token: 0x04004C8F RID: 19599
		public float fadeMultiplier = 2f;

		// Token: 0x04004C90 RID: 19600
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C91 RID: 19601
		private SpriteRenderer textRenderer;

		// Token: 0x04004C92 RID: 19602
		private float targetTransitionTime;

		// Token: 0x04004C93 RID: 19603
		private float transitionTime;
	}
}
