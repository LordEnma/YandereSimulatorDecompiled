using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054B RID: 1355
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x06002299 RID: 8857 RVA: 0x001EF39C File Offset: 0x001ED59C
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

		// Token: 0x0600229A RID: 8858 RVA: 0x001EF3D0 File Offset: 0x001ED5D0
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

		// Token: 0x0600229B RID: 8859 RVA: 0x001EF46E File Offset: 0x001ED66E
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004AA8 RID: 19112
		public SceneField loadingScene;

		// Token: 0x04004AA9 RID: 19113
		public SceneField levelScene;

		// Token: 0x04004AAA RID: 19114
		public bool fadeInMenu = true;

		// Token: 0x04004AAB RID: 19115
		public bool fadeOutMenu = true;

		// Token: 0x04004AAC RID: 19116
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004AAD RID: 19117
		private AsyncOperation _loadingSceneAsync;
	}
}
