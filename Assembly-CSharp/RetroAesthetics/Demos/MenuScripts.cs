using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054D RID: 1357
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x060022A9 RID: 8873 RVA: 0x001F0430 File Offset: 0x001EE630
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

		// Token: 0x060022AA RID: 8874 RVA: 0x001F0464 File Offset: 0x001EE664
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

		// Token: 0x060022AB RID: 8875 RVA: 0x001F0502 File Offset: 0x001EE702
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004AC1 RID: 19137
		public SceneField loadingScene;

		// Token: 0x04004AC2 RID: 19138
		public SceneField levelScene;

		// Token: 0x04004AC3 RID: 19139
		public bool fadeInMenu = true;

		// Token: 0x04004AC4 RID: 19140
		public bool fadeOutMenu = true;

		// Token: 0x04004AC5 RID: 19141
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004AC6 RID: 19142
		private AsyncOperation _loadingSceneAsync;
	}
}
