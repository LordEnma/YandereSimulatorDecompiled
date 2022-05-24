using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057E RID: 1406
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x060023BF RID: 9151 RVA: 0x001FCC98 File Offset: 0x001FAE98
		// (set) Token: 0x060023C0 RID: 9152 RVA: 0x001FCCA0 File Offset: 0x001FAEA0
		public VignetteModel.Settings settings
		{
			get
			{
				return this.m_Settings;
			}
			set
			{
				this.m_Settings = value;
			}
		}

		// Token: 0x060023C1 RID: 9153 RVA: 0x001FCCA9 File Offset: 0x001FAEA9
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004C22 RID: 19490
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006DF RID: 1759
		public enum Mode
		{
			// Token: 0x04005297 RID: 21143
			Classic,
			// Token: 0x04005298 RID: 21144
			Masked
		}

		// Token: 0x020006E0 RID: 1760
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005AA RID: 1450
			// (get) Token: 0x060027A8 RID: 10152 RVA: 0x0020B7F8 File Offset: 0x002099F8
			public static VignetteModel.Settings defaultSettings
			{
				get
				{
					return new VignetteModel.Settings
					{
						mode = VignetteModel.Mode.Classic,
						color = new Color(0f, 0f, 0f, 1f),
						center = new Vector2(0.5f, 0.5f),
						intensity = 0.45f,
						smoothness = 0.2f,
						roundness = 1f,
						mask = null,
						opacity = 1f,
						rounded = false
					};
				}
			}

			// Token: 0x04005299 RID: 21145
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x0400529A RID: 21146
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x0400529B RID: 21147
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x0400529C RID: 21148
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x0400529D RID: 21149
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x0400529E RID: 21150
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x0400529F RID: 21151
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x040052A0 RID: 21152
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x040052A1 RID: 21153
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
