using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000556 RID: 1366
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x060022E3 RID: 8931 RVA: 0x001F626D File Offset: 0x001F446D
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x060022E4 RID: 8932 RVA: 0x001F6275 File Offset: 0x001F4475
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004B77 RID: 19319
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004B78 RID: 19320
		[SerializeField]
		private string m_SceneName = "";
	}
}
