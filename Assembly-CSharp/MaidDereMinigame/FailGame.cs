using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A5 RID: 1445
	public class FailGame : MonoBehaviour
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06002465 RID: 9317 RVA: 0x001F6D44 File Offset: 0x001F4F44
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

		// Token: 0x06002466 RID: 9318 RVA: 0x001F6D64 File Offset: 0x001F4F64
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x001F6DB0 File Offset: 0x001F4FB0
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x001F6DE2 File Offset: 0x001F4FE2
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

		// Token: 0x06002469 RID: 9321 RVA: 0x001F6DF1 File Offset: 0x001F4FF1
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

		// Token: 0x04004BE1 RID: 19425
		private static FailGame instance;

		// Token: 0x04004BE2 RID: 19426
		public float fadeMultiplier = 2f;

		// Token: 0x04004BE3 RID: 19427
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004BE4 RID: 19428
		private SpriteRenderer textRenderer;

		// Token: 0x04004BE5 RID: 19429
		private float targetTransitionTime;

		// Token: 0x04004BE6 RID: 19430
		private float transitionTime;
	}
}
