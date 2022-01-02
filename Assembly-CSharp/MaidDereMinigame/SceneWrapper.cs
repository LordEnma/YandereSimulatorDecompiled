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
		// Token: 0x0600246F RID: 9327 RVA: 0x001F88D4 File Offset: 0x001F6AD4
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

		// Token: 0x06002470 RID: 9328 RVA: 0x001F892C File Offset: 0x001F6B2C
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

		// Token: 0x06002471 RID: 9329 RVA: 0x001F8988 File Offset: 0x001F6B88
		public static void LoadScene(SceneObject sceneObject)
		{
			GameController.Scenes.LoadLevel(sceneObject);
		}

		// Token: 0x06002472 RID: 9330 RVA: 0x001F8998 File Offset: 0x001F6B98
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

		// Token: 0x06002473 RID: 9331 RVA: 0x001F89F8 File Offset: 0x001F6BF8
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

		// Token: 0x06002474 RID: 9332 RVA: 0x001F8A32 File Offset: 0x001F6C32
		public SceneObject GetSceneByIndex(int scene)
		{
			return this.m_Scenes[scene];
		}

		// Token: 0x04004C28 RID: 19496
		[Reorderable]
		public SceneObjectMetaData m_Scenes;
	}
}
