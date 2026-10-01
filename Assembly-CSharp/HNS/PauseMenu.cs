using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HNS
{
	public class PauseMenu : MonoBehaviour
	{
		[Header("References")]
		public UIPanel Menu;

		public UIPanel HUD;

		public UIPanel Fade;

		[Space]
		public UITexture Matrix;

		public UILabel Controls;

		[Space]
		public AudioClip Pause;

		public AudioClip Unpause;

		public AudioClip Confirm;

		[Header("Settings")]
		public float TransitionSpeed = 10f;

		public float FadeOutSpeed = 2f;

		public Vector2 MatrixSpeed = new Vector2(0.1f, 0.1f);

		private bool isPaused;

		private float menuAlpha;

		private float hudAlpha;

		private bool isTransitioning;

		public static PauseMenu Instance { get; private set; }

		public bool IsPaused => isPaused;

		private void OnEnable()
		{
			Instance = this;
			isPaused = false;
			menuAlpha = 0f;
			hudAlpha = 1f;
			isTransitioning = false;
			UpdatePanels();
			Time.timeScale = 1f;
			if ((bool)Fade)
			{
				Fade.alpha = 0f;
			}
		}

		private void Update()
		{
			if (!isTransitioning && (!GameOverScreen.Instance || !GameOverScreen.Instance.IsGameOver))
			{
				UpdateMatrix();
				HandlePauseToggle();
				UpdateTransitions();
				if (isPaused)
				{
					HandleMenuInput();
				}
			}
		}

		private void HandlePauseToggle()
		{
			bool num = Input.GetButtonDown(InputNames.Xbox_Start) || Input.GetKeyDown(KeyCode.Escape);
			bool buttonDown = Input.GetButtonDown(InputNames.Xbox_B);
			if (num | buttonDown)
			{
				TogglePause();
			}
		}

		private void TogglePause()
		{
			if (isPaused)
			{
				Audio.Play(Unpause, AudioType.UI, 0.5f);
			}
			else
			{
				Audio.Play(Pause, AudioType.UI, 0.5f);
			}
			isPaused = !isPaused;
			Time.timeScale = (isPaused ? 0f : 1f);
		}

		private void UpdateTransitions()
		{
			float target = (isPaused ? 1f : 0f);
			float target2 = (isPaused ? 0f : 1f);
			menuAlpha = Mathf.MoveTowards(menuAlpha, target, Time.unscaledDeltaTime * TransitionSpeed);
			hudAlpha = Mathf.MoveTowards(hudAlpha, target2, Time.unscaledDeltaTime * TransitionSpeed);
			UpdatePanels();
		}

		private void UpdatePanels()
		{
			Menu.alpha = menuAlpha;
			HUD.alpha = hudAlpha;
		}

		private void UpdateMatrix()
		{
			Matrix.uvRect = new Rect(Matrix.uvRect.position + MatrixSpeed * Time.unscaledDeltaTime, Matrix.uvRect.size);
		}

		private void HandleMenuInput()
		{
			Controls.text = (InputQuery.IsUsingKeyboardMouse ? "E: Confirm             Q: Cancel" : "A: Confirm             B: Cancel");
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				StartCoroutine(TransitionToTitle());
			}
		}

		private IEnumerator TransitionToTitle()
		{
			isTransitioning = true;
			Audio.Play(Confirm, AudioType.UI, 0.5f);
			if ((bool)MusicManager.instance)
			{
				MusicManager.instance.FadeOut();
			}
			if ((bool)FadeManager.instance)
			{
				FadeManager.instance.FadeIn();
			}
			while (menuAlpha > 0f || hudAlpha < 1f)
			{
				menuAlpha = Mathf.MoveTowards(menuAlpha, 0f, Time.unscaledDeltaTime * FadeOutSpeed);
				hudAlpha = Mathf.MoveTowards(hudAlpha, 1f, Time.unscaledDeltaTime * FadeOutSpeed);
				UpdatePanels();
				yield return null;
			}
			if ((bool)FadeManager.instance)
			{
				while (FadeManager.instance.IsFading)
				{
					yield return null;
				}
			}
			else if ((bool)Fade)
			{
				while (Fade.alpha < 1f)
				{
					Fade.alpha = Mathf.MoveTowards(Fade.alpha, 1f, Time.unscaledDeltaTime * FadeOutSpeed);
					yield return null;
				}
			}
			if ((bool)MusicManager.instance)
			{
				while (MusicManager.instance.IsFading)
				{
					yield return null;
				}
			}
			Time.timeScale = 1f;
			SceneManager.LoadScene("HNSTitleScreen");
		}
	}
}
