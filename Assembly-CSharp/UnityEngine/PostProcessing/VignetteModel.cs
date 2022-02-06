using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056F RID: 1391
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x0600235D RID: 9053 RVA: 0x001F3988 File Offset: 0x001F1B88
		// (set) Token: 0x0600235E RID: 9054 RVA: 0x001F3990 File Offset: 0x001F1B90
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

		// Token: 0x0600235F RID: 9055 RVA: 0x001F3999 File Offset: 0x001F1B99
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004AFF RID: 19199
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006CE RID: 1742
		public enum Mode
		{
			// Token: 0x04005167 RID: 20839
			Classic,
			// Token: 0x04005168 RID: 20840
			Masked
		}

		// Token: 0x020006CF RID: 1743
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A4 RID: 1444
			// (get) Token: 0x0600273D RID: 10045 RVA: 0x00202194 File Offset: 0x00200394
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

			// Token: 0x04005169 RID: 20841
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x0400516A RID: 20842
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x0400516B RID: 20843
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x0400516C RID: 20844
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x0400516D RID: 20845
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x0400516E RID: 20846
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x0400516F RID: 20847
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x04005170 RID: 20848
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x04005171 RID: 20849
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
