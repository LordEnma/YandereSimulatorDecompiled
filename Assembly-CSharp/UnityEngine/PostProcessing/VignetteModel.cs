using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057C RID: 1404
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060023AA RID: 9130 RVA: 0x001F9B58 File Offset: 0x001F7D58
		// (set) Token: 0x060023AB RID: 9131 RVA: 0x001F9B60 File Offset: 0x001F7D60
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

		// Token: 0x060023AC RID: 9132 RVA: 0x001F9B69 File Offset: 0x001F7D69
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004BDC RID: 19420
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006DD RID: 1757
		public enum Mode
		{
			// Token: 0x04005249 RID: 21065
			Classic,
			// Token: 0x0400524A RID: 21066
			Masked
		}

		// Token: 0x020006DE RID: 1758
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A9 RID: 1449
			// (get) Token: 0x06002793 RID: 10131 RVA: 0x0020857C File Offset: 0x0020677C
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

			// Token: 0x0400524B RID: 21067
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x0400524C RID: 21068
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x0400524D RID: 21069
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x0400524E RID: 21070
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x0400524F RID: 21071
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x04005250 RID: 21072
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x04005251 RID: 21073
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x04005252 RID: 21074
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x04005253 RID: 21075
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
