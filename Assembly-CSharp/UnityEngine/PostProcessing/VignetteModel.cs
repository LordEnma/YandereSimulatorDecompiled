using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056F RID: 1391
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06002358 RID: 9048 RVA: 0x001F346C File Offset: 0x001F166C
		// (set) Token: 0x06002359 RID: 9049 RVA: 0x001F3474 File Offset: 0x001F1674
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

		// Token: 0x0600235A RID: 9050 RVA: 0x001F347D File Offset: 0x001F167D
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004AF6 RID: 19190
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006CE RID: 1742
		public enum Mode
		{
			// Token: 0x0400515E RID: 20830
			Classic,
			// Token: 0x0400515F RID: 20831
			Masked
		}

		// Token: 0x020006CF RID: 1743
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A3 RID: 1443
			// (get) Token: 0x06002738 RID: 10040 RVA: 0x00201C78 File Offset: 0x001FFE78
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

			// Token: 0x04005160 RID: 20832
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x04005161 RID: 20833
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x04005162 RID: 20834
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x04005163 RID: 20835
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x04005164 RID: 20836
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x04005165 RID: 20837
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x04005166 RID: 20838
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x04005167 RID: 20839
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x04005168 RID: 20840
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
