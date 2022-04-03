using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000557 RID: 1367
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x060022D7 RID: 8919 RVA: 0x001F45E0 File Offset: 0x001F27E0
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

		// Token: 0x060022D8 RID: 8920 RVA: 0x001F4614 File Offset: 0x001F2814
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

		// Token: 0x060022D9 RID: 8921 RVA: 0x001F46B2 File Offset: 0x001F28B2
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004B6F RID: 19311
		public SceneField loadingScene;

		// Token: 0x04004B70 RID: 19312
		public SceneField levelScene;

		// Token: 0x04004B71 RID: 19313
		public bool fadeInMenu = true;

		// Token: 0x04004B72 RID: 19314
		public bool fadeOutMenu = true;

		// Token: 0x04004B73 RID: 19315
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004B74 RID: 19316
		private AsyncOperation _loadingSceneAsync;
	}
}
