using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005B9 RID: 1465
	public class FailGame : MonoBehaviour
	{
		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x060024F0 RID: 9456 RVA: 0x00203D50 File Offset: 0x00201F50
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

		// Token: 0x060024F1 RID: 9457 RVA: 0x00203D70 File Offset: 0x00201F70
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x060024F2 RID: 9458 RVA: 0x00203DBC File Offset: 0x00201FBC
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x060024F3 RID: 9459 RVA: 0x00203DEE File Offset: 0x00201FEE
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

		// Token: 0x060024F4 RID: 9460 RVA: 0x00203DFD File Offset: 0x00201FFD
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

		// Token: 0x04004D7A RID: 19834
		private static FailGame instance;

		// Token: 0x04004D7B RID: 19835
		public float fadeMultiplier = 2f;

		// Token: 0x04004D7C RID: 19836
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004D7D RID: 19837
		private SpriteRenderer textRenderer;

		// Token: 0x04004D7E RID: 19838
		private float targetTransitionTime;

		// Token: 0x04004D7F RID: 19839
		private float transitionTime;
	}
}
