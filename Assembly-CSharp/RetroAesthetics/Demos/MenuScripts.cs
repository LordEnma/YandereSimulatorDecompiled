using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000546 RID: 1350
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x0600226F RID: 8815 RVA: 0x001EB24C File Offset: 0x001E944C
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

		// Token: 0x06002270 RID: 8816 RVA: 0x001EB280 File Offset: 0x001E9480
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

		// Token: 0x06002271 RID: 8817 RVA: 0x001EB31E File Offset: 0x001E951E
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004A31 RID: 18993
		public SceneField loadingScene;

		// Token: 0x04004A32 RID: 18994
		public SceneField levelScene;

		// Token: 0x04004A33 RID: 18995
		public bool fadeInMenu = true;

		// Token: 0x04004A34 RID: 18996
		public bool fadeOutMenu = true;

		// Token: 0x04004A35 RID: 18997
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004A36 RID: 18998
		private AsyncOperation _loadingSceneAsync;
	}
}
