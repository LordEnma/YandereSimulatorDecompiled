using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A7 RID: 1447
	public class FailGame : MonoBehaviour
	{
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06002476 RID: 9334 RVA: 0x001F8478 File Offset: 0x001F6678
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

		// Token: 0x06002477 RID: 9335 RVA: 0x001F8498 File Offset: 0x001F6698
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x06002478 RID: 9336 RVA: 0x001F84E4 File Offset: 0x001F66E4
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x06002479 RID: 9337 RVA: 0x001F8516 File Offset: 0x001F6716
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

		// Token: 0x0600247A RID: 9338 RVA: 0x001F8525 File Offset: 0x001F6725
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

		// Token: 0x04004C20 RID: 19488
		private static FailGame instance;

		// Token: 0x04004C21 RID: 19489
		public float fadeMultiplier = 2f;

		// Token: 0x04004C22 RID: 19490
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C23 RID: 19491
		private SpriteRenderer textRenderer;

		// Token: 0x04004C24 RID: 19492
		private float targetTransitionTime;

		// Token: 0x04004C25 RID: 19493
		private float transitionTime;
	}
}
