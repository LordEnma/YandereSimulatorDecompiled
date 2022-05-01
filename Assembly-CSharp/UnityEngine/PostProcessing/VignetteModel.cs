using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057D RID: 1405
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x060023B3 RID: 9139 RVA: 0x001FAFE4 File Offset: 0x001F91E4
		// (set) Token: 0x060023B4 RID: 9140 RVA: 0x001FAFEC File Offset: 0x001F91EC
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

		// Token: 0x060023B5 RID: 9141 RVA: 0x001FAFF5 File Offset: 0x001F91F5
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004BF2 RID: 19442
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006DE RID: 1758
		public enum Mode
		{
			// Token: 0x04005267 RID: 21095
			Classic,
			// Token: 0x04005268 RID: 21096
			Masked
		}

		// Token: 0x020006DF RID: 1759
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A9 RID: 1449
			// (get) Token: 0x0600279C RID: 10140 RVA: 0x00209B1C File Offset: 0x00207D1C
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

			// Token: 0x04005269 RID: 21097
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x0400526A RID: 21098
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x0400526B RID: 21099
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x0400526C RID: 21100
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x0400526D RID: 21101
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x0400526E RID: 21102
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x0400526F RID: 21103
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x04005270 RID: 21104
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x04005271 RID: 21105
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
