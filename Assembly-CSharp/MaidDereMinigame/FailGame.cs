using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B6 RID: 1462
	public class FailGame : MonoBehaviour
	{
		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x060024CD RID: 9421 RVA: 0x002000D8 File Offset: 0x001FE2D8
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

		// Token: 0x060024CE RID: 9422 RVA: 0x002000F8 File Offset: 0x001FE2F8
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x060024CF RID: 9423 RVA: 0x00200144 File Offset: 0x001FE344
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x060024D0 RID: 9424 RVA: 0x00200176 File Offset: 0x001FE376
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

		// Token: 0x060024D1 RID: 9425 RVA: 0x00200185 File Offset: 0x001FE385
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

		// Token: 0x04004D1F RID: 19743
		private static FailGame instance;

		// Token: 0x04004D20 RID: 19744
		public float fadeMultiplier = 2f;

		// Token: 0x04004D21 RID: 19745
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D22 RID: 19746
		private SpriteRenderer textRenderer;

		// Token: 0x04004D23 RID: 19747
		private float targetTransitionTime;

		// Token: 0x04004D24 RID: 19748
		private float transitionTime;
	}
}
