using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000570 RID: 1392
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06002364 RID: 9060 RVA: 0x001F3E3C File Offset: 0x001F203C
		// (set) Token: 0x06002365 RID: 9061 RVA: 0x001F3E44 File Offset: 0x001F2044
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

		// Token: 0x06002366 RID: 9062 RVA: 0x001F3E4D File Offset: 0x001F204D
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004B08 RID: 19208
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006CF RID: 1743
		public enum Mode
		{
			// Token: 0x04005170 RID: 20848
			Classic,
			// Token: 0x04005171 RID: 20849
			Masked
		}

		// Token: 0x020006D0 RID: 1744
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A5 RID: 1445
			// (get) Token: 0x06002744 RID: 10052 RVA: 0x00202648 File Offset: 0x00200848
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

			// Token: 0x04005172 RID: 20850
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x04005173 RID: 20851
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x04005174 RID: 20852
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x04005175 RID: 20853
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x04005176 RID: 20854
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x04005177 RID: 20855
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x04005178 RID: 20856
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x04005179 RID: 20857
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x0400517A RID: 20858
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
