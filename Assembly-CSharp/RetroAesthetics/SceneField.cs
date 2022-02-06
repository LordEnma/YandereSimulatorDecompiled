using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000548 RID: 1352
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x0600228C RID: 8844 RVA: 0x001EEB15 File Offset: 0x001ECD15
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x0600228D RID: 8845 RVA: 0x001EEB1D File Offset: 0x001ECD1D
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004A84 RID: 19076
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004A85 RID: 19077
		[SerializeField]
		private string m_SceneName = "";
	}
}
