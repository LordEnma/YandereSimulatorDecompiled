using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000555 RID: 1365
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x060022D2 RID: 8914 RVA: 0x001F4289 File Offset: 0x001F2489
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x060022D3 RID: 8915 RVA: 0x001F4291 File Offset: 0x001F2491
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004B4F RID: 19279
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004B50 RID: 19280
		[SerializeField]
		private string m_SceneName = "";
	}
}
