using System;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x020005A4 RID: 1444
	[CreateAssetMenu(fileName = "New Scene Wrapper", menuName = "Scenes/New Scene Wrapper")]
	public class SceneWrapper : ScriptableObject
	{
		// Token: 0x0600246C RID: 9324 RVA: 0x001F82E4 File Offset: 0x001F64E4
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

		// Token: 0x0600246D RID: 9325 RVA: 0x001F833C File Offset: 0x001F653C
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

		// Token: 0x0600246E RID: 9326 RVA: 0x001F8398 File Offset: 0x001F6598
		public static void LoadScene(SceneObject sceneObject)
		{
			GameController.Scenes.LoadLevel(sceneObject);
		}

		// Token: 0x0600246F RID: 9327 RVA: 0x001F83A8 File Offset: 0x001F65A8
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

		// Token: 0x06002470 RID: 9328 RVA: 0x001F8408 File Offset: 0x001F6608
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

		// Token: 0x06002471 RID: 9329 RVA: 0x001F8442 File Offset: 0x001F6642
		public SceneObject GetSceneByIndex(int scene)
		{
			return this.m_Scenes[scene];
		}

		// Token: 0x04004C1F RID: 19487
		[Reorderable]
		public SceneObjectMetaData m_Scenes;
	}
}
