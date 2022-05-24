using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200055A RID: 1370
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x060022FB RID: 8955 RVA: 0x001F86AC File Offset: 0x001F68AC
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

		// Token: 0x060022FC RID: 8956 RVA: 0x001F86E0 File Offset: 0x001F68E0
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

		// Token: 0x060022FD RID: 8957 RVA: 0x001F877E File Offset: 0x001F697E
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004BCB RID: 19403
		public SceneField loadingScene;

		// Token: 0x04004BCC RID: 19404
		public SceneField levelScene;

		// Token: 0x04004BCD RID: 19405
		public bool fadeInMenu = true;

		// Token: 0x04004BCE RID: 19406
		public bool fadeOutMenu = true;

		// Token: 0x04004BCF RID: 19407
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004BD0 RID: 19408
		private AsyncOperation _loadingSceneAsync;
	}
}
