using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000545 RID: 1349
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06002273 RID: 8819 RVA: 0x001EC0F9 File Offset: 0x001EA2F9
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x06002274 RID: 8820 RVA: 0x001EC101 File Offset: 0x001EA301
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004A4C RID: 19020
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004A4D RID: 19021
		[SerializeField]
		private string m_SceneName = "";
	}
}
