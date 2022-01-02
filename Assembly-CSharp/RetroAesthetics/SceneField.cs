using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000545 RID: 1349
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06002276 RID: 8822 RVA: 0x001EC6E9 File Offset: 0x001EA8E9
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x06002277 RID: 8823 RVA: 0x001EC6F1 File Offset: 0x001EA8F1
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004A55 RID: 19029
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004A56 RID: 19030
		[SerializeField]
		private string m_SceneName = "";
	}
}
