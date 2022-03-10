using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x0200054B RID: 1355
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x060022A2 RID: 8866 RVA: 0x001F0581 File Offset: 0x001EE781
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x060022A3 RID: 8867 RVA: 0x001F0589 File Offset: 0x001EE789
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004ABA RID: 19130
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004ABB RID: 19131
		[SerializeField]
		private string m_SceneName = "";
	}
}
