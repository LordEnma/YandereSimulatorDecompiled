using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000548 RID: 1352
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06002289 RID: 8841 RVA: 0x001EE911 File Offset: 0x001ECB11
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x0600228A RID: 8842 RVA: 0x001EE919 File Offset: 0x001ECB19
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004A81 RID: 19073
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004A82 RID: 19074
		[SerializeField]
		private string m_SceneName = "";
	}
}
