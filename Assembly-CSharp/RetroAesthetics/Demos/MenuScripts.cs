using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054C RID: 1356
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x060022A0 RID: 8864 RVA: 0x001EF850 File Offset: 0x001EDA50
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

		// Token: 0x060022A1 RID: 8865 RVA: 0x001EF884 File Offset: 0x001EDA84
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

		// Token: 0x060022A2 RID: 8866 RVA: 0x001EF922 File Offset: 0x001EDB22
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004AB1 RID: 19121
		public SceneField loadingScene;

		// Token: 0x04004AB2 RID: 19122
		public SceneField levelScene;

		// Token: 0x04004AB3 RID: 19123
		public bool fadeInMenu = true;

		// Token: 0x04004AB4 RID: 19124
		public bool fadeOutMenu = true;

		// Token: 0x04004AB5 RID: 19125
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004AB6 RID: 19126
		private AsyncOperation _loadingSceneAsync;
	}
}
