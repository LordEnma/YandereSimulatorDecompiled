using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AC RID: 1452
	public class FailGame : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x0600249F RID: 9375 RVA: 0x001FBF28 File Offset: 0x001FA128
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

		// Token: 0x060024A0 RID: 9376 RVA: 0x001FBF48 File Offset: 0x001FA148
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x060024A1 RID: 9377 RVA: 0x001FBF94 File Offset: 0x001FA194
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x060024A2 RID: 9378 RVA: 0x001FBFC6 File Offset: 0x001FA1C6
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

		// Token: 0x060024A3 RID: 9379 RVA: 0x001FBFD5 File Offset: 0x001FA1D5
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

		// Token: 0x04004C71 RID: 19569
		private static FailGame instance;

		// Token: 0x04004C72 RID: 19570
		public float fadeMultiplier = 2f;

		// Token: 0x04004C73 RID: 19571
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C74 RID: 19572
		private SpriteRenderer textRenderer;

		// Token: 0x04004C75 RID: 19573
		private float targetTransitionTime;

		// Token: 0x04004C76 RID: 19574
		private float transitionTime;
	}
}
