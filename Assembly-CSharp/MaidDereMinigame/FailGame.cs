using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AA RID: 1450
	public class FailGame : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x0600248A RID: 9354 RVA: 0x001FA978 File Offset: 0x001F8B78
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

		// Token: 0x0600248B RID: 9355 RVA: 0x001FA998 File Offset: 0x001F8B98
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x0600248C RID: 9356 RVA: 0x001FA9E4 File Offset: 0x001F8BE4
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x0600248D RID: 9357 RVA: 0x001FAA16 File Offset: 0x001F8C16
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

		// Token: 0x0600248E RID: 9358 RVA: 0x001FAA25 File Offset: 0x001F8C25
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

		// Token: 0x04004C4F RID: 19535
		private static FailGame instance;

		// Token: 0x04004C50 RID: 19536
		public float fadeMultiplier = 2f;

		// Token: 0x04004C51 RID: 19537
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C52 RID: 19538
		private SpriteRenderer textRenderer;

		// Token: 0x04004C53 RID: 19539
		private float targetTransitionTime;

		// Token: 0x04004C54 RID: 19540
		private float transitionTime;
	}
}
