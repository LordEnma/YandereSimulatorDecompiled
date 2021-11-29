using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000543 RID: 1347
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06002262 RID: 8802 RVA: 0x001EA9C5 File Offset: 0x001E8BC5
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x06002263 RID: 8803 RVA: 0x001EA9CD File Offset: 0x001E8BCD
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004A0D RID: 18957
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004A0E RID: 18958
		[SerializeField]
		private string m_SceneName = "";
	}
}
