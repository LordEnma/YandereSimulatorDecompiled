using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000555 RID: 1365
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x060022D9 RID: 8921 RVA: 0x001F4CE5 File Offset: 0x001F2EE5
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x060022DA RID: 8922 RVA: 0x001F4CED File Offset: 0x001F2EED
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004B61 RID: 19297
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004B62 RID: 19298
		[SerializeField]
		private string m_SceneName = "";
	}
}
