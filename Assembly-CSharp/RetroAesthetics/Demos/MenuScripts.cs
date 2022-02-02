using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054B RID: 1355
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x06002294 RID: 8852 RVA: 0x001EEE80 File Offset: 0x001ED080
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

		// Token: 0x06002295 RID: 8853 RVA: 0x001EEEB4 File Offset: 0x001ED0B4
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

		// Token: 0x06002296 RID: 8854 RVA: 0x001EEF52 File Offset: 0x001ED152
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004A9F RID: 19103
		public SceneField loadingScene;

		// Token: 0x04004AA0 RID: 19104
		public SceneField levelScene;

		// Token: 0x04004AA1 RID: 19105
		public bool fadeInMenu = true;

		// Token: 0x04004AA2 RID: 19106
		public bool fadeOutMenu = true;

		// Token: 0x04004AA3 RID: 19107
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004AA4 RID: 19108
		private AsyncOperation _loadingSceneAsync;
	}
}
