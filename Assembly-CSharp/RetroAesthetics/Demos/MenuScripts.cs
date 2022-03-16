using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000552 RID: 1362
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x060022C7 RID: 8903 RVA: 0x001F2D70 File Offset: 0x001F0F70
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

		// Token: 0x060022C8 RID: 8904 RVA: 0x001F2DA4 File Offset: 0x001F0FA4
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

		// Token: 0x060022C9 RID: 8905 RVA: 0x001F2E42 File Offset: 0x001F1042
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004B3D RID: 19261
		public SceneField loadingScene;

		// Token: 0x04004B3E RID: 19262
		public SceneField levelScene;

		// Token: 0x04004B3F RID: 19263
		public bool fadeInMenu = true;

		// Token: 0x04004B40 RID: 19264
		public bool fadeOutMenu = true;

		// Token: 0x04004B41 RID: 19265
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004B42 RID: 19266
		private AsyncOperation _loadingSceneAsync;
	}
}
