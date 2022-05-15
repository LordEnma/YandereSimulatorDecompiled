using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000557 RID: 1367
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x060022ED RID: 8941 RVA: 0x001F78BD File Offset: 0x001F5ABD
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x060022EE RID: 8942 RVA: 0x001F78C5 File Offset: 0x001F5AC5
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004B9E RID: 19358
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004B9F RID: 19359
		[SerializeField]
		private string m_SceneName = "";
	}
}
