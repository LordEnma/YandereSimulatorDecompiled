using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AA RID: 1450
	public class FailGame : MonoBehaviour
	{
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x0600248F RID: 9359 RVA: 0x001FAE94 File Offset: 0x001F9094
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

		// Token: 0x06002490 RID: 9360 RVA: 0x001FAEB4 File Offset: 0x001F90B4
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x06002491 RID: 9361 RVA: 0x001FAF00 File Offset: 0x001F9100
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x06002492 RID: 9362 RVA: 0x001FAF32 File Offset: 0x001F9132
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

		// Token: 0x06002493 RID: 9363 RVA: 0x001FAF41 File Offset: 0x001F9141
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

		// Token: 0x04004C58 RID: 19544
		private static FailGame instance;

		// Token: 0x04004C59 RID: 19545
		public float fadeMultiplier = 2f;

		// Token: 0x04004C5A RID: 19546
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C5B RID: 19547
		private SpriteRenderer textRenderer;

		// Token: 0x04004C5C RID: 19548
		private float targetTransitionTime;

		// Token: 0x04004C5D RID: 19549
		private float transitionTime;
	}
}
