using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000558 RID: 1368
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x060022DF RID: 8927 RVA: 0x001F4B10 File Offset: 0x001F2D10
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

		// Token: 0x060022E0 RID: 8928 RVA: 0x001F4B44 File Offset: 0x001F2D44
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

		// Token: 0x060022E1 RID: 8929 RVA: 0x001F4BE2 File Offset: 0x001F2DE2
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004B73 RID: 19315
		public SceneField loadingScene;

		// Token: 0x04004B74 RID: 19316
		public SceneField levelScene;

		// Token: 0x04004B75 RID: 19317
		public bool fadeInMenu = true;

		// Token: 0x04004B76 RID: 19318
		public bool fadeOutMenu = true;

		// Token: 0x04004B77 RID: 19319
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004B78 RID: 19320
		private AsyncOperation _loadingSceneAsync;
	}
}
