using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x0200054A RID: 1354
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x0600229C RID: 8860 RVA: 0x001EFBA9 File Offset: 0x001EDDA9
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x0600229D RID: 8861 RVA: 0x001EFBB1 File Offset: 0x001EDDB1
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004A9D RID: 19101
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004A9E RID: 19102
		[SerializeField]
		private string m_SceneName = "";
	}
}
