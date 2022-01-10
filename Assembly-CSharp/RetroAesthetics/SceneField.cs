using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000547 RID: 1351
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06002281 RID: 8833 RVA: 0x001ED089 File Offset: 0x001EB289
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x06002282 RID: 8834 RVA: 0x001ED091 File Offset: 0x001EB291
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004A69 RID: 19049
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004A6A RID: 19050
		[SerializeField]
		private string m_SceneName = "";
	}
}
