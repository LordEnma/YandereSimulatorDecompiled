using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000554 RID: 1364
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x060022CA RID: 8906 RVA: 0x001F3D59 File Offset: 0x001F1F59
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x060022CB RID: 8907 RVA: 0x001F3D61 File Offset: 0x001F1F61
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004B4B RID: 19275
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004B4C RID: 19276
		[SerializeField]
		private string m_SceneName = "";
	}
}
