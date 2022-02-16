using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000549 RID: 1353
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06002293 RID: 8851 RVA: 0x001EEFC9 File Offset: 0x001ED1C9
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x06002294 RID: 8852 RVA: 0x001EEFD1 File Offset: 0x001ED1D1
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004A8D RID: 19085
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004A8E RID: 19086
		[SerializeField]
		private string m_SceneName = "";
	}
}
