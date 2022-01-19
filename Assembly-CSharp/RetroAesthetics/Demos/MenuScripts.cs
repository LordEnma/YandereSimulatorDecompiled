using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
	// Token: 0x0200054B RID: 1355
	public class MenuScripts : MonoBehaviour
	{
		// Token: 0x06002290 RID: 8848 RVA: 0x001EE5E0 File Offset: 0x001EC7E0
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

		// Token: 0x06002291 RID: 8849 RVA: 0x001EE614 File Offset: 0x001EC814
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

		// Token: 0x06002292 RID: 8850 RVA: 0x001EE6B2 File Offset: 0x001EC8B2
		private void LoadNextScene()
		{
			if (this._loadingSceneAsync != null)
			{
				this._loadingSceneAsync.allowSceneActivation = true;
			}
			SceneManager.LoadSceneAsync(this.levelScene);
		}

		// Token: 0x04004A94 RID: 19092
		public SceneField loadingScene;

		// Token: 0x04004A95 RID: 19093
		public SceneField levelScene;

		// Token: 0x04004A96 RID: 19094
		public bool fadeInMenu = true;

		// Token: 0x04004A97 RID: 19095
		public bool fadeOutMenu = true;

		// Token: 0x04004A98 RID: 19096
		private RetroCameraEffect _cameraEffect;

		// Token: 0x04004A99 RID: 19097
		private AsyncOperation _loadingSceneAsync;
	}
}
