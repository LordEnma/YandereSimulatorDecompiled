using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056A RID: 1386
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06002333 RID: 9011 RVA: 0x001EF838 File Offset: 0x001EDA38
		// (set) Token: 0x06002334 RID: 9012 RVA: 0x001EF840 File Offset: 0x001EDA40
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

		// Token: 0x06002335 RID: 9013 RVA: 0x001EF849 File Offset: 0x001EDA49
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004A88 RID: 19080
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006CE RID: 1742
		public enum Mode
		{
			// Token: 0x04005112 RID: 20754
			Classic,
			// Token: 0x04005113 RID: 20755
			Masked
		}

		// Token: 0x020006CF RID: 1743
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A2 RID: 1442
			// (get) Token: 0x06002727 RID: 10023 RVA: 0x001FE704 File Offset: 0x001FC904
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

			// Token: 0x04005114 RID: 20756
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x04005115 RID: 20757
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x04005116 RID: 20758
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x04005117 RID: 20759
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x04005118 RID: 20760
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x04005119 RID: 20761
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x0400511A RID: 20762
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x0400511B RID: 20763
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x0400511C RID: 20764
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
