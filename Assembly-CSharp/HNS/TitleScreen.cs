using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HNS
{
	public class TitleScreen : MonoBehaviour
	{
		[Header("References")]
		public UIPanel Generic;

		public UIPanel Menu;

		public UIPanel Controls;

		public UIPanel Tips;

		public UIPanel Credits;

		public UIPanel Fade;

		[Space]
		public Transform Selector;

		public Transform[] Options;

		[Space]
		public UITexture Matrix;

		public AudioSource Music;

		public AudioClip Confirm;

		public AudioClip Cancel;

		public AudioClip Move;

		[Header("Settings")]
		public TitleScreenState State;

		public float TransitionSpeed = 5f;

		public float FadeOutSpeed = 2f;

		public float MusicFadeSpeed = 1f;

		public Vector2 MatrixSpeed = new Vector2(0.1f, 0.1f);

		private int selection;

		private UIPanel[] panels;

		private bool isTransitioning;

		private float targetMusicVolume = 1f;

		private void OnEnable()
		{
			panels = new UIPanel[4] { Menu, Controls, Tips, Credits };
			Generic.alpha = 0f;
			UIPanel[] array = panels;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].alpha = 0f;
			}
			Fade.alpha = 0f;
			if ((bool)Music)
			{
				Music.volume = 0f;
				targetMusicVolume = 1f;
			}
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		private void Update()
		{
			UpdateMusic();
			if (isTransitioning)
			{
				return;
			}
			UpdatePanels();
			UpdateMatrix();
			UpdateSelector();
			if (IsPanelVisible())
			{
				if (State == TitleScreenState.Menu)
				{
					UpdateMenuInput();
				}
				else
				{
					UpdateSecondaryInput();
				}
			}
		}

		private void UpdateMusic()
		{
			if ((bool)Music)
			{
				Music.volume = Mathf.MoveTowards(Music.volume, targetMusicVolume, Time.deltaTime * MusicFadeSpeed);
			}
		}

		private void UpdatePanels()
		{
			Generic.alpha = Mathf.MoveTowards(Generic.alpha, 1f, Time.deltaTime * TransitionSpeed);
			for (int i = 0; i < panels.Length; i++)
			{
				float target = ((i == (int)State) ? 1f : 0f);
				panels[i].alpha = Mathf.MoveTowards(panels[i].alpha, target, Time.deltaTime * TransitionSpeed);
			}
		}

		private void UpdateMatrix()
		{
			Matrix.uvRect = new Rect(Matrix.uvRect.position + MatrixSpeed * Time.deltaTime, Matrix.uvRect.size);
		}

		private void UpdateSelector()
		{
			Selector.position = Vector3.Lerp(Selector.position, Options[selection].position, Time.deltaTime * 20f);
		}

		private void UpdateMenuInput()
		{
			bool num = ((!InputQuery.IsUsingKeyboardMouse) ? (InputQuery.DirectionDown(Direction.Down) || InputQuery.DirectionDown(Direction.Down, StickType.DPad)) : (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)));
			bool flag = ((!InputQuery.IsUsingKeyboardMouse) ? (InputQuery.DirectionDown(Direction.Up) || InputQuery.DirectionDown(Direction.Up, StickType.DPad)) : (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)));
			if (num)
			{
				selection = (selection + 1) % Options.Length;
			}
			else if (flag)
			{
				selection = (selection - 1 + Options.Length) % Options.Length;
			}
			if (num | flag)
			{
				Audio.Play(Move, AudioType.UI, 0.5f);
			}
			if (InputQuery.IsUsingKeyboardMouse ? Input.GetKeyDown(KeyCode.E) : InputQuery.ButtonDown(ButtonInput.A))
			{
				Audio.Play(Confirm, AudioType.UI, 0.5f);
				switch (selection)
				{
				case 0:
					StartCoroutine(TransitionToScene("HNSGameplay"));
					break;
				case 1:
					State = TitleScreenState.Controls;
					break;
				case 2:
					State = TitleScreenState.Tips;
					break;
				case 3:
					State = TitleScreenState.Credits;
					break;
				case 4:
					StartCoroutine(TransitionToQuit());
					break;
				}
			}
		}

		private void UpdateSecondaryInput()
		{
			if (InputQuery.IsUsingKeyboardMouse ? Input.GetKeyDown(KeyCode.Q) : InputQuery.ButtonDown(ButtonInput.B))
			{
				Audio.Play(Cancel, AudioType.UI, 0.5f);
				State = TitleScreenState.Menu;
			}
		}

		private bool IsPanelVisible()
		{
			UIPanel[] array = panels;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].alpha >= 1f)
				{
					return true;
				}
			}
			return false;
		}

		private IEnumerator TransitionToScene(string sceneName)
		{
			isTransitioning = true;
			targetMusicVolume = 0f;
			while (Generic.alpha > 0f || panels[(int)State].alpha > 0f)
			{
				Generic.alpha = Mathf.MoveTowards(Generic.alpha, 0f, Time.deltaTime * FadeOutSpeed);
				UIPanel[] array = panels;
				foreach (UIPanel obj in array)
				{
					obj.alpha = Mathf.MoveTowards(obj.alpha, 0f, Time.deltaTime * FadeOutSpeed);
				}
				yield return null;
			}
			while (Fade.alpha < 1f || ((bool)Music && Music.volume > 0.01f))
			{
				Fade.alpha = Mathf.MoveTowards(Fade.alpha, 1f, Time.deltaTime * FadeOutSpeed);
				yield return null;
			}
			SceneManager.LoadScene(sceneName);
		}

		private IEnumerator TransitionToQuit()
		{
			isTransitioning = true;
			targetMusicVolume = 0f;
			while (Generic.alpha > 0f || panels[(int)State].alpha > 0f)
			{
				Generic.alpha = Mathf.MoveTowards(Generic.alpha, 0f, Time.deltaTime * FadeOutSpeed);
				UIPanel[] array = panels;
				foreach (UIPanel obj in array)
				{
					obj.alpha = Mathf.MoveTowards(obj.alpha, 0f, Time.deltaTime * FadeOutSpeed);
				}
				yield return null;
			}
			while (Fade.alpha < 1f || ((bool)Music && Music.volume > 0.01f))
			{
				Fade.alpha = Mathf.MoveTowards(Fade.alpha, 1f, Time.deltaTime * FadeOutSpeed);
				yield return null;
			}
			SceneManager.LoadScene("HomeScene");
		}
	}
}
