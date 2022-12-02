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
			foreach (SceneObject scene in m_Scenes)
			{
				if (scene.sceneBuildNumber == buildIndex)
				{
					return scene;
				}
			}
			return null;
		}

		public SceneObject GetSceneByName(string name)
		{
			foreach (SceneObject scene in m_Scenes)
			{
				if (scene.name == name)
				{
					return scene;
				}
			}
			return null;
		}

		public static void LoadScene(SceneObject sceneObject)
		{
			GameController.Scenes.LoadLevel(sceneObject);
		}

		public void LoadLevel(SceneObject sceneObject)
		{
			int num = -1;
			for (int i = 0; i < m_Scenes.Length; i++)
			{
				if (m_Scenes[i] == sceneObject)
				{
					num = m_Scenes[i].sceneBuildNumber;
				}
			}
			if (num == -1)
			{
				Debug.LogError("Scene could not be found. Is it in the Scene Wrapper?");
			}
			else
			{
				SceneManager.LoadScene(num);
			}
		}

		public int GetSceneID(SceneObject scene)
		{
			for (int i = 0; i < m_Scenes.Count; i++)
			{
				if (m_Scenes[i] == scene)
				{
					return i;
				}
			}
			return -1;
		}

		public SceneObject GetSceneByIndex(int scene)
		{
			return m_Scenes[scene];
		}
	}
}
