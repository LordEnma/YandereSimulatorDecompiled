using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	public class MenuScripts : MonoBehaviour
	{
		public SceneField loadingScene;

		public SceneField levelScene;

		public bool fadeInMenu = true;

		public bool fadeOutMenu = true;

		private RetroCameraEffect _cameraEffect;

		private AsyncOperation _loadingSceneAsync;

		private void Start()
		{
			if (fadeInMenu)
			{
				_cameraEffect = Object.FindObjectOfType<RetroCameraEffect>();
				if (_cameraEffect != null)
				{
					_cameraEffect.FadeIn();
				}
			}
		}

		public virtual void StartLevel()
		{
			if (levelScene != null)
			{
				if (_cameraEffect != null)
				{
					if (loadingScene != null)
					{
						_loadingSceneAsync = SceneManager.LoadSceneAsync(loadingScene);
						if (_loadingSceneAsync == null)
						{
							Debug.LogWarning($"Please add scene `{loadingScene.SceneName}` to the built scenes in the Build Settings.");
							return;
						}
						_loadingSceneAsync.allowSceneActivation = false;
					}
					_cameraEffect.FadeOut(0.5f, LoadNextScene);
				}
				else
				{
					LoadNextScene();
				}
			}
			else
			{
				Debug.LogWarning("Level scene is not set.");
			}
		}

		private void LoadNextScene()
		{
			if (_loadingSceneAsync != null)
			{
				_loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(levelScene);
		}
	}
}
