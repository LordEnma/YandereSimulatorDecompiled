using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200055A RID: 1370
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x060022FA RID: 8954 RVA: 0x001F8144 File Offset: 0x001F6344
		private void Start()
		{
			if (this.fadeInMenu)
			{
				this._cameraEffect = UnityEngine.Object.FindObjectOfType<RetroCameraEffect>();
				if (this._cameraEffect != null)
				{
					this._cameraEffect.FadeIn(1f, null);
				}
			}
		}

		// Token: 0x060022FB RID: 8955 RVA: 0x001F8178 File Offset: 0x001F6378
		public virtual void StartLevel()
		{
			if (this.levelScene == null)
			{
				Debug.LogWarning("Level scene is not set.");
				return;
			}
			if (this._cameraEffect != null)
			{
				if (this.loadingScene != null)
				{
					this._loadingSceneAsync = SceneManager.LoadSceneAsync(this.loadingScene);
					if (this._loadingSceneAsync == null)
					{
						Debug.LogWarning(string.Format("Please add scene `{0}` to the built scenes in the Build Settings.", this.loadingScene.SceneName));
						return;
					}
					this._loadingSceneAsync.allowSceneActivation = false;
				}
				this._cameraEffect.FadeOut(0.5f, new Action(this.LoadNextScene));
				return;
			}
			this.LoadNextScene();
		}

		// Token: 0x060022FC RID: 8956 RVA: 0x001F8216 File Offset: 0x001F6416
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004BC2 RID: 19394
		public SceneField loadingScene;

		// Token: 0x04004BC3 RID: 19395
		public SceneField levelScene;

		// Token: 0x04004BC4 RID: 19396
		public bool fadeInMenu = true;

		// Token: 0x04004BC5 RID: 19397
		public bool fadeOutMenu = true;

		// Token: 0x04004BC6 RID: 19398
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004BC7 RID: 19399
		private AsyncOperation _loadingSceneAsync;
	}
}
