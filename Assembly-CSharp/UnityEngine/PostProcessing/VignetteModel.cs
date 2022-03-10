using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06002373 RID: 9075 RVA: 0x001F53F4 File Offset: 0x001F35F4
		// (set) Token: 0x06002374 RID: 9076 RVA: 0x001F53FC File Offset: 0x001F35FC
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

		// Token: 0x06002375 RID: 9077 RVA: 0x001F5405 File Offset: 0x001F3605
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004B35 RID: 19253
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006D3 RID: 1747
		public enum Mode
		{
			// Token: 0x040051A2 RID: 20898
			Classic,
			// Token: 0x040051A3 RID: 20899
			Masked
		}

		// Token: 0x020006D4 RID: 1748
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A7 RID: 1447
			// (get) Token: 0x0600275C RID: 10076 RVA: 0x00203CC8 File Offset: 0x00201EC8
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

			// Token: 0x040051A4 RID: 20900
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x040051A5 RID: 20901
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x040051A6 RID: 20902
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x040051A7 RID: 20903
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x040051A8 RID: 20904
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x040051A9 RID: 20905
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x040051AA RID: 20906
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x040051AB RID: 20907
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x040051AC RID: 20908
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
