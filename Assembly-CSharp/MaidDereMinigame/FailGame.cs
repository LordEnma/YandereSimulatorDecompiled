using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AA RID: 1450
	public class FailGame : MonoBehaviour
	{
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06002486 RID: 9350 RVA: 0x001FA0D8 File Offset: 0x001F82D8
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

		// Token: 0x06002487 RID: 9351 RVA: 0x001FA0F8 File Offset: 0x001F82F8
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x06002488 RID: 9352 RVA: 0x001FA144 File Offset: 0x001F8344
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x06002489 RID: 9353 RVA: 0x001FA176 File Offset: 0x001F8376
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

		// Token: 0x0600248A RID: 9354 RVA: 0x001FA185 File Offset: 0x001F8385
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

		// Token: 0x04004C44 RID: 19524
		private static FailGame instance;

		// Token: 0x04004C45 RID: 19525
		public float fadeMultiplier = 2f;

		// Token: 0x04004C46 RID: 19526
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C47 RID: 19527
		private SpriteRenderer textRenderer;

		// Token: 0x04004C48 RID: 19528
		private float targetTransitionTime;

		// Token: 0x04004C49 RID: 19529
		private float transitionTime;
	}
}
