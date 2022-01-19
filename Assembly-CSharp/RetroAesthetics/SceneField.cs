using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000548 RID: 1352
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06002283 RID: 8835 RVA: 0x001EDD59 File Offset: 0x001EBF59
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x06002284 RID: 8836 RVA: 0x001EDD61 File Offset: 0x001EBF61
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004A70 RID: 19056
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004A71 RID: 19057
		[SerializeField]
		private string m_SceneName = "";
	}
}
