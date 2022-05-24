using System;
using UnityEngine;

namespace RetroAesthetics
{
	// Token: 0x02000557 RID: 1367
	[Serializable]
	public class SceneField
	{
		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x060022EE RID: 8942 RVA: 0x001F7E25 File Offset: 0x001F6025
		public string SceneName
		{
			get
			{
				return this.m_SceneName;
			}
		}

		// Token: 0x060022EF RID: 8943 RVA: 0x001F7E2D File Offset: 0x001F602D
		public static implicit operator string(SceneField sceneField)
		{
			return sceneField.SceneName;
		}

		// Token: 0x04004BA7 RID: 19367
		[SerializeField]
		private UnityEngine.Object m_SceneAsset;

		// Token: 0x04004BA8 RID: 19368
		[SerializeField]
		private string m_SceneName = "";
	}
}
