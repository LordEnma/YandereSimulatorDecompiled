// Decompiled with JetBrains decompiler
// Type: RetroAesthetics.Demos.MenuScripts
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RetroAesthetics.Demos
{
  public class MenuScripts : MonoBehaviour
  {
    public SceneField loadingScene;
    public SceneField levelScene;
    public bool fadeInMenu = true;
    public bool fadeOutMenu = true;
    private RetroCameraEffect _cameraEffect;
    private AsyncOperation _loadingSceneAsync;

    private void Start()
    {
      if (!this.fadeInMenu)
        return;
      this._cameraEffect = UnityEngine.Object.FindObjectOfType<RetroCameraEffect>();
      if (!((UnityEngine.Object) this._cameraEffect != (UnityEngine.Object) null))
        return;
      this._cameraEffect.FadeIn();
    }

    public virtual void StartLevel()
    {
      if (this.levelScene != null)
      {
        if ((UnityEngine.Object) this._cameraEffect != (UnityEngine.Object) null)
        {
          if (this.loadingScene != null)
          {
            this._loadingSceneAsync = SceneManager.LoadSceneAsync((string) this.loadingScene);
            if (this._loadingSceneAsync == null)
            {
              Debug.LogWarning((object) string.Format("Please add scene `{0}` to the built scenes in the Build Settings.", (object) this.loadingScene.SceneName));
              return;
            }
            this._loadingSceneAsync.allowSceneActivation = false;
          }
          this._cameraEffect.FadeOut(0.5f, new Action(this.LoadNextScene));
        }
        else
          this.LoadNextScene();
      }
      else
        Debug.LogWarning((object) "Level scene is not set.");
    }

    private void LoadNextScene()
    {
      if (this._loadingSceneAsync != null)
        this._loadingSceneAsync.allowSceneActivation = true;
      SceneManager.LoadSceneAsync((string) this.levelScene);
    }
  }
}
