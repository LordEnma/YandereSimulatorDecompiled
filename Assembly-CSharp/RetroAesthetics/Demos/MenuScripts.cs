using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054E RID: 1358
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x060022AF RID: 8879 RVA: 0x001F0E08 File Offset: 0x001EF008
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

		// Token: 0x060022B0 RID: 8880 RVA: 0x001F0E3C File Offset: 0x001EF03C
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

		// Token: 0x060022B1 RID: 8881 RVA: 0x001F0EDA File Offset: 0x001EF0DA
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004ADE RID: 19166
		public SceneField loadingScene;

		// Token: 0x04004ADF RID: 19167
		public SceneField levelScene;

		// Token: 0x04004AE0 RID: 19168
		public bool fadeInMenu = true;

		// Token: 0x04004AE1 RID: 19169
		public bool fadeOutMenu = true;

		// Token: 0x04004AE2 RID: 19170
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004AE3 RID: 19171
		private AsyncOperation _loadingSceneAsync;
	}
}
