using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057B RID: 1403
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x0600239B RID: 9115 RVA: 0x001F8BCC File Offset: 0x001F6DCC
		// (set) Token: 0x0600239C RID: 9116 RVA: 0x001F8BD4 File Offset: 0x001F6DD4
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

		// Token: 0x0600239D RID: 9117 RVA: 0x001F8BDD File Offset: 0x001F6DDD
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004BC6 RID: 19398
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006DC RID: 1756
		public enum Mode
		{
			// Token: 0x04005233 RID: 21043
			Classic,
			// Token: 0x04005234 RID: 21044
			Masked
		}

		// Token: 0x020006DD RID: 1757
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A8 RID: 1448
			// (get) Token: 0x06002784 RID: 10116 RVA: 0x002075F0 File Offset: 0x002057F0
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

			// Token: 0x04005235 RID: 21045
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x04005236 RID: 21046
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x04005237 RID: 21047
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x04005238 RID: 21048
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x04005239 RID: 21049
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x0400523A RID: 21050
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x0400523B RID: 21051
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x0400523C RID: 21052
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x0400523D RID: 21053
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
