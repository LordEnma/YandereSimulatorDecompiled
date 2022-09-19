// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.SceneWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
  [CreateAssetMenu(fileName = "New Scene Wrapper", menuName = "Scenes/New Scene Wrapper")]
  public class SceneWrapper : ScriptableObject
  {
    [Reorderable]
    public SceneObjectMetaData m_Scenes;

    public SceneObject GetSceneByBuildIndex(int buildIndex)
    {
      foreach (SceneObject scene in (ReorderableArray<SceneObject>) this.m_Scenes)
      {
        if (scene.sceneBuildNumber == buildIndex)
          return scene;
      }
      return (SceneObject) null;
    }

    public SceneObject GetSceneByName(string name)
    {
      foreach (SceneObject scene in (ReorderableArray<SceneObject>) this.m_Scenes)
      {
        if (scene.name == name)
          return scene;
      }
      return (SceneObject) null;
    }

    public static void LoadScene(SceneObject sceneObject) => GameController.Scenes.LoadLevel(sceneObject);

    public void LoadLevel(SceneObject sceneObject)
    {
      int sceneBuildIndex = -1;
      for (int index = 0; index < this.m_Scenes.Length; ++index)
      {
        if ((Object) this.m_Scenes[index] == (Object) sceneObject)
          sceneBuildIndex = this.m_Scenes[index].sceneBuildNumber;
      }
      if (sceneBuildIndex == -1)
        Debug.LogError((object) "Scene could not be found. Is it in the Scene Wrapper?");
      else
        SceneManager.LoadScene(sceneBuildIndex);
    }

    public int GetSceneID(SceneObject scene)
    {
      for (int index = 0; index < this.m_Scenes.Count; ++index)
      {
        if ((Object) this.m_Scenes[index] == (Object) scene)
          return index;
      }
      return -1;
    }

    public SceneObject GetSceneByIndex(int scene) => this.m_Scenes[scene];
  }
}
