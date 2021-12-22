using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000548 RID: 1352
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x06002280 RID: 8832 RVA: 0x001EC980 File Offset: 0x001EAB80
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

		// Token: 0x06002281 RID: 8833 RVA: 0x001EC9B4 File Offset: 0x001EABB4
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

		// Token: 0x06002282 RID: 8834 RVA: 0x001ECA52 File Offset: 0x001EAC52
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004A70 RID: 19056
		public SceneField loadingScene;

		// Token: 0x04004A71 RID: 19057
		public SceneField levelScene;

		// Token: 0x04004A72 RID: 19058
		public bool fadeInMenu = true;

		// Token: 0x04004A73 RID: 19059
		public bool fadeOutMenu = true;

		// Token: 0x04004A74 RID: 19060
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004A75 RID: 19061
		private AsyncOperation _loadingSceneAsync;
	}
}
