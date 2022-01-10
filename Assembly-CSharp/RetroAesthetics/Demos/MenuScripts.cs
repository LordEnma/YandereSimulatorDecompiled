using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054A RID: 1354
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x0600228E RID: 8846 RVA: 0x001ED910 File Offset: 0x001EBB10
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

		// Token: 0x0600228F RID: 8847 RVA: 0x001ED944 File Offset: 0x001EBB44
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

		// Token: 0x06002290 RID: 8848 RVA: 0x001ED9E2 File Offset: 0x001EBBE2
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004A8D RID: 19085
		public SceneField loadingScene;

		// Token: 0x04004A8E RID: 19086
		public SceneField levelScene;

		// Token: 0x04004A8F RID: 19087
		public bool fadeInMenu = true;

		// Token: 0x04004A90 RID: 19088
		public bool fadeOutMenu = true;

		// Token: 0x04004A91 RID: 19089
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004A92 RID: 19090
		private AsyncOperation _loadingSceneAsync;
	}
}
