using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000559 RID: 1369
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x060022EF RID: 8943 RVA: 0x001F69F8 File Offset: 0x001F4BF8
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

		// Token: 0x060022F0 RID: 8944 RVA: 0x001F6A2C File Offset: 0x001F4C2C
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

		// Token: 0x060022F1 RID: 8945 RVA: 0x001F6ACA File Offset: 0x001F4CCA
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004B9B RID: 19355
		public SceneField loadingScene;

		// Token: 0x04004B9C RID: 19356
		public SceneField levelScene;

		// Token: 0x04004B9D RID: 19357
		public bool fadeInMenu = true;

		// Token: 0x04004B9E RID: 19358
		public bool fadeOutMenu = true;

		// Token: 0x04004B9F RID: 19359
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004BA0 RID: 19360
		private AsyncOperation _loadingSceneAsync;
	}
}
