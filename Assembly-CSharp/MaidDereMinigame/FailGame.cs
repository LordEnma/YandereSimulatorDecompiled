using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A7 RID: 1447
	public class FailGame : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06002479 RID: 9337 RVA: 0x001F8A68 File Offset: 0x001F6C68
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

		// Token: 0x0600247A RID: 9338 RVA: 0x001F8A88 File Offset: 0x001F6C88
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x0600247B RID: 9339 RVA: 0x001F8AD4 File Offset: 0x001F6CD4
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x0600247C RID: 9340 RVA: 0x001F8B06 File Offset: 0x001F6D06
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

		// Token: 0x0600247D RID: 9341 RVA: 0x001F8B15 File Offset: 0x001F6D15
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

		// Token: 0x04004C29 RID: 19497
		private static FailGame instance;

		// Token: 0x04004C2A RID: 19498
		public float fadeMultiplier = 2f;

		// Token: 0x04004C2B RID: 19499
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C2C RID: 19500
		private SpriteRenderer textRenderer;

		// Token: 0x04004C2D RID: 19501
		private float targetTransitionTime;

		// Token: 0x04004C2E RID: 19502
		private float transitionTime;
	}
}
