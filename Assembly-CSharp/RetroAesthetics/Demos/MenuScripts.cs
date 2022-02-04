using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054B RID: 1355
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x06002296 RID: 8854 RVA: 0x001EF198 File Offset: 0x001ED398
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

		// Token: 0x06002297 RID: 8855 RVA: 0x001EF1CC File Offset: 0x001ED3CC
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

		// Token: 0x06002298 RID: 8856 RVA: 0x001EF26A File Offset: 0x001ED46A
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004AA5 RID: 19109
		public SceneField loadingScene;

		// Token: 0x04004AA6 RID: 19110
		public SceneField levelScene;

		// Token: 0x04004AA7 RID: 19111
		public bool fadeInMenu = true;

		// Token: 0x04004AA8 RID: 19112
		public bool fadeOutMenu = true;

		// Token: 0x04004AA9 RID: 19113
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004AAA RID: 19114
		private AsyncOperation _loadingSceneAsync;
	}
}
