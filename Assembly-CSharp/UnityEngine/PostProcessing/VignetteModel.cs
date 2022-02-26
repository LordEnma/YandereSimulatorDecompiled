using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x0600236D RID: 9069 RVA: 0x001F4A1C File Offset: 0x001F2C1C
		// (set) Token: 0x0600236E RID: 9070 RVA: 0x001F4A24 File Offset: 0x001F2C24
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

		// Token: 0x0600236F RID: 9071 RVA: 0x001F4A2D File Offset: 0x001F2C2D
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004B18 RID: 19224
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006D2 RID: 1746
		public enum Mode
		{
			// Token: 0x04005185 RID: 20869
			Classic,
			// Token: 0x04005186 RID: 20870
			Masked
		}

		// Token: 0x020006D3 RID: 1747
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A7 RID: 1447
			// (get) Token: 0x06002756 RID: 10070 RVA: 0x002032F0 File Offset: 0x002014F0
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

			// Token: 0x04005187 RID: 20871
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x04005188 RID: 20872
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x04005189 RID: 20873
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x0400518A RID: 20874
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x0400518B RID: 20875
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x0400518C RID: 20876
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x0400518D RID: 20877
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x0400518E RID: 20878
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x0400518F RID: 20879
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
