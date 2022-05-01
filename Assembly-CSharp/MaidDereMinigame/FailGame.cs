using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B8 RID: 1464
	public class FailGame : MonoBehaviour
	{
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060024E5 RID: 9445 RVA: 0x00202604 File Offset: 0x00200804
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

		// Token: 0x060024E6 RID: 9446 RVA: 0x00202624 File Offset: 0x00200824
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x060024E7 RID: 9447 RVA: 0x00202670 File Offset: 0x00200870
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x060024E8 RID: 9448 RVA: 0x002026A2 File Offset: 0x002008A2
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

		// Token: 0x060024E9 RID: 9449 RVA: 0x002026B1 File Offset: 0x002008B1
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

		// Token: 0x04004D53 RID: 19795
		private static FailGame instance;

		// Token: 0x04004D54 RID: 19796
		public float fadeMultiplier = 2f;

		// Token: 0x04004D55 RID: 19797
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D56 RID: 19798
		private SpriteRenderer textRenderer;

		// Token: 0x04004D57 RID: 19799
		private float targetTransitionTime;

		// Token: 0x04004D58 RID: 19800
		private float transitionTime;
	}
}
