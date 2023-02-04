using System.Collections;
using UnityEngine;

namespace MaidDereMinigame
{
	public class FailGame : MonoBehaviour
	{
		private static FailGame instance;

		public float fadeMultiplier = 2f;

		private SpriteRenderer spriteRenderer;

		private SpriteRenderer textRenderer;

		private float targetTransitionTime;

		private float transitionTime;

		public static FailGame Instance
		{
			get
			{
				if (instance == null)
				{
					instance = Object.FindObjectOfType<FailGame>();
				}
				return instance;
			}
		}

		private void Awake()
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
			textRenderer = base.transform.GetChild(0).GetComponent<SpriteRenderer>();
			targetTransitionTime = GameController.Instance.activeDifficultyVariables.transitionTime * fadeMultiplier;
		}

		public static void GameFailed()
		{
			Instance.StartCoroutine(Instance.GameFailedRoutine());
			Instance.StartCoroutine(Instance.SlowPitch());
			SFXController.PlaySound(SFXController.Sounds.GameFail);
		}

		private IEnumerator GameFailedRoutine()
		{
			Object.FindObjectOfType<InteractionMenu>().gameObject.SetActive(value: false);
			yield return null;
			textRenderer.color = Color.white;
			while (transitionTime < targetTransitionTime)
			{
				transitionTime += Time.deltaTime;
				yield return null;
			}
			base.transform.GetChild(1).gameObject.SetActive(value: true);
			while (!Input.anyKeyDown)
			{
				yield return null;
			}
			while (transitionTime < targetTransitionTime)
			{
				transitionTime += Time.deltaTime;
				float a = Mathf.Lerp(0f, 1f, transitionTime / targetTransitionTime);
				spriteRenderer.color = new Color(0f, 0f, 0f, a);
				yield return null;
			}
			GameController.GoToExitScene(fadeOut: false);
		}

		private IEnumerator SlowPitch()
		{
			GameStarter starter = Object.FindObjectOfType<GameStarter>();
			float timeToZero = 5f;
			while (timeToZero > 0f)
			{
				starter.SetAudioPitch(Mathf.Lerp(0f, 1f, timeToZero / 5f));
				timeToZero -= Time.deltaTime;
				yield return null;
			}
			starter.SetAudioPitch(0f);
		}
	}
}
