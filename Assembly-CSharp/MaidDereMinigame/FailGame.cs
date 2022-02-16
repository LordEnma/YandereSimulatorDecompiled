using System;
using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005AB RID: 1451
	public class FailGame : MonoBehaviour
	{
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06002496 RID: 9366 RVA: 0x001FB348 File Offset: 0x001F9548
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

		// Token: 0x06002497 RID: 9367 RVA: 0x001FB368 File Offset: 0x001F9568
		private void Awake()
		{
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			this.textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			this.targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * this.fadeMultiplier;
		}

		// Token: 0x06002498 RID: 9368 RVA: 0x001FB3B4 File Offset: 0x001F95B4
		public static void GameFailed()
		{
			FailGame.Instance.StartCoroutine(FailGame.Instance.GameFailedRoutine());
			FailGame.Instance.StartCoroutine(FailGame.Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		// Token: 0x06002499 RID: 9369 RVA: 0x001FB3E6 File Offset: 0x001F95E6
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

		// Token: 0x0600249A RID: 9370 RVA: 0x001FB3F5 File Offset: 0x001F95F5
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

		// Token: 0x04004C61 RID: 19553
		private static FailGame instance;

		// Token: 0x04004C62 RID: 19554
		public float fadeMultiplier = 2f;

		// Token: 0x04004C63 RID: 19555
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C64 RID: 19556
		private SpriteRenderer textRenderer;

		// Token: 0x04004C65 RID: 19557
		private float targetTransitionTime;

		// Token: 0x04004C66 RID: 19558
		private float transitionTime;
	}
}
