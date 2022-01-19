using System;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x020005A7 RID: 1447
	[CreateAssetMenu(fileName = "New Scene Wrapper", menuName = "Scenes/New Scene Wrapper")]
	public class SceneWrapper : ScriptableObject
	{
		// Token: 0x0600247C RID: 9340 RVA: 0x001F9F44 File Offset: 0x001F8144
		public SceneObject GetSceneByBuildIndex(int buildIndex)
		{
			foreach (SceneObject sceneObject in this.m_Scenes)
			{
				if (sceneObject.sceneBuildNumber == buildIndex)
				{
					return sceneObject;
				}
			}
			return null;
		}

		// Token: 0x0600247D RID: 9341 RVA: 0x001F9F9C File Offset: 0x001F819C
		public SceneObject GetSceneByName(string name)
		{
			foreach (SceneObject sceneObject in this.m_Scenes)
			{
				if (sceneObject.name == name)
				{
					return sceneObject;
				}
			}
			return null;
		}

		// Token: 0x0600247E RID: 9342 RVA: 0x001F9FF8 File Offset: 0x001F81F8
		public static void LoadScene(SceneObject sceneObject)
		{
			GameController.Scenes.LoadLevel(sceneObject);
		}

		// Token: 0x0600247F RID: 9343 RVA: 0x001FA008 File Offset: 0x001F8208
		public void LoadLevel(SceneObject sceneObject)
		{
			int num = -1;
			for (int i = 0; i < this.m_Scenes.Length; i++)
			{
				if (this.m_Scenes[i] == sceneObject)
				{
					num = this.m_Scenes[i].sceneBuildNumber;
				}
			}
			if (num == -1)
			{
				Debug.LogError("Scene could not be found. Is it in the Scene Wrapper?");
				return;
			}
			SceneManager.LoadScene(num);
		}

		// Token: 0x06002480 RID: 9344 RVA: 0x001FA068 File Offset: 0x001F8268
		public int GetSceneID(SceneObject scene)
		{
			for (int i = 0; i < this.m_Scenes.Count; i++)
			{
				if (this.m_Scenes[i] == scene)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06002481 RID: 9345 RVA: 0x001FA0A2 File Offset: 0x001F82A2
		public SceneObject GetSceneByIndex(int scene)
		{
			return this.m_Scenes[scene];
		}

		// Token: 0x04004C43 RID: 19523
		[Reorderable]
		public SceneObjectMetaData m_Scenes;
	}
}
