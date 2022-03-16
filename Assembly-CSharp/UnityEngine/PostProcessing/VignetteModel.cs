using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000576 RID: 1398
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x0600238B RID: 9099 RVA: 0x001F735C File Offset: 0x001F555C
		// (set) Token: 0x0600238C RID: 9100 RVA: 0x001F7364 File Offset: 0x001F5564
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

		// Token: 0x0600238D RID: 9101 RVA: 0x001F736D File Offset: 0x001F556D
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004B94 RID: 19348
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006D7 RID: 1751
		public enum Mode
		{
			// Token: 0x04005201 RID: 20993
			Classic,
			// Token: 0x04005202 RID: 20994
			Masked
		}

		// Token: 0x020006D8 RID: 1752
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A8 RID: 1448
			// (get) Token: 0x06002774 RID: 10100 RVA: 0x00205C30 File Offset: 0x00203E30
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

			// Token: 0x04005203 RID: 20995
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x04005204 RID: 20996
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x04005205 RID: 20997
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x04005206 RID: 20998
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x04005207 RID: 20999
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x04005208 RID: 21000
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x04005209 RID: 21001
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x0400520A RID: 21002
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x0400520B RID: 21003
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
