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
		// Token: 0x06002480 RID: 9344 RVA: 0x001FA7E4 File Offset: 0x001F89E4
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

		// Token: 0x06002481 RID: 9345 RVA: 0x001FA83C File Offset: 0x001F8A3C
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

		// Token: 0x06002482 RID: 9346 RVA: 0x001FA898 File Offset: 0x001F8A98
		public static void LoadScene(SceneObject sceneObject)
		{
			GameController.Scenes.LoadLevel(sceneObject);
		}

		// Token: 0x06002483 RID: 9347 RVA: 0x001FA8A8 File Offset: 0x001F8AA8
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

		// Token: 0x06002484 RID: 9348 RVA: 0x001FA908 File Offset: 0x001F8B08
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

		// Token: 0x06002485 RID: 9349 RVA: 0x001FA942 File Offset: 0x001F8B42
		public SceneObject GetSceneByIndex(int scene)
		{
			return this.m_Scenes[scene];
		}

		// Token: 0x04004C4E RID: 19534
		[Reorderable]
		public SceneObjectMetaData m_Scenes;
	}
}
