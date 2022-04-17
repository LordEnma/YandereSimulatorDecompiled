using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B7 RID: 1463
	public class FailGame : MonoBehaviour
	{
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x060024DC RID: 9436 RVA: 0x00201064 File Offset: 0x001FF264
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

		// Token: 0x060024DD RID: 9437 RVA: 0x00201084 File Offset: 0x001FF284
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x060024DE RID: 9438 RVA: 0x002010D0 File Offset: 0x001FF2D0
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x060024DF RID: 9439 RVA: 0x00201102 File Offset: 0x001FF302
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

		// Token: 0x060024E0 RID: 9440 RVA: 0x00201111 File Offset: 0x001FF311
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

		// Token: 0x04004D35 RID: 19765
		private static FailGame instance;

		// Token: 0x04004D36 RID: 19766
		public float fadeMultiplier = 2f;

		// Token: 0x04004D37 RID: 19767
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D38 RID: 19768
		private SpriteRenderer textRenderer;

		// Token: 0x04004D39 RID: 19769
		private float targetTransitionTime;

		// Token: 0x04004D3A RID: 19770
		private float transitionTime;
	}
}
