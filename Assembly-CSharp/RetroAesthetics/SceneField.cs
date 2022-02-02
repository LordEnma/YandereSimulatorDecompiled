using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000548 RID: 1352
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06002287 RID: 8839 RVA: 0x001EE5F9 File Offset: 0x001EC7F9
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x06002288 RID: 8840 RVA: 0x001EE601 File Offset: 0x001EC801
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004A7B RID: 19067
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004A7C RID: 19068
		[SerializeField]
		private string m_SceneName = "";
	}
}
