using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x02000558 RID: 1368
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x060022E6 RID: 8934 RVA: 0x001F556C File Offset: 0x001F376C
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

		// Token: 0x060022E7 RID: 8935 RVA: 0x001F55A0 File Offset: 0x001F37A0
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

		// Token: 0x060022E8 RID: 8936 RVA: 0x001F563E File Offset: 0x001F383E
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004B85 RID: 19333
		public SceneField loadingScene;

		// Token: 0x04004B86 RID: 19334
		public SceneField levelScene;

		// Token: 0x04004B87 RID: 19335
		public bool fadeInMenu = true;

		// Token: 0x04004B88 RID: 19336
		public bool fadeOutMenu = true;

		// Token: 0x04004B89 RID: 19337
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004B8A RID: 19338
		private AsyncOperation _loadingSceneAsync;
	}
}
