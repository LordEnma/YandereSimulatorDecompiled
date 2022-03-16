using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x0200054F RID: 1359
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x060022BA RID: 8890 RVA: 0x001F24E9 File Offset: 0x001F06E9
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x060022BB RID: 8891 RVA: 0x001F24F1 File Offset: 0x001F06F1
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004B19 RID: 19225
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004B1A RID: 19226
		[SerializeField]
		private string m_SceneName = "";
	}
}
