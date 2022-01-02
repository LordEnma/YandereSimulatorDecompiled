using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000548 RID: 1352
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x06002283 RID: 8835 RVA: 0x001ECF70 File Offset: 0x001EB170
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

		// Token: 0x06002284 RID: 8836 RVA: 0x001ECFA4 File Offset: 0x001EB1A4
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

		// Token: 0x06002285 RID: 8837 RVA: 0x001ED042 File Offset: 0x001EB242
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004A79 RID: 19065
		public SceneField loadingScene;

		// Token: 0x04004A7A RID: 19066
		public SceneField levelScene;

		// Token: 0x04004A7B RID: 19067
		public bool fadeInMenu = true;

		// Token: 0x04004A7C RID: 19068
		public bool fadeOutMenu = true;

		// Token: 0x04004A7D RID: 19069
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004A7E RID: 19070
		private AsyncOperation _loadingSceneAsync;
	}
}
