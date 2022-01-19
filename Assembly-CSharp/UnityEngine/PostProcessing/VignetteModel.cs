using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056F RID: 1391
	[Serializable]
	public class VignetteModel : PostProcessingModel
	{
		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06002354 RID: 9044 RVA: 0x001F2BCC File Offset: 0x001F0DCC
		// (set) Token: 0x06002355 RID: 9045 RVA: 0x001F2BD4 File Offset: 0x001F0DD4
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

		// Token: 0x06002356 RID: 9046 RVA: 0x001F2BDD File Offset: 0x001F0DDD
		public override void Reset()
		{
			this.m_Settings = VignetteModel.Settings.defaultSettings;
		}

		// Token: 0x04004AEB RID: 19179
		[SerializeField]
		private VignetteModel.Settings m_Settings = VignetteModel.Settings.defaultSettings;

		// Token: 0x020006D4 RID: 1748
		public enum Mode
		{
			// Token: 0x04005181 RID: 20865
			Classic,
			// Token: 0x04005182 RID: 20866
			Masked
		}

		// Token: 0x020006D5 RID: 1749
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A3 RID: 1443
			// (get) Token: 0x06002748 RID: 10056 RVA: 0x00201ABC File Offset: 0x001FFCBC
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

			// Token: 0x04005183 RID: 20867
			[Tooltip("Use the \"Classic\" mode for parametric controls. Use the \"Masked\" mode to use your own texture mask.")]
			public VignetteModel.Mode mode;

			// Token: 0x04005184 RID: 20868
			[ColorUsage(false)]
			[Tooltip("Vignette color. Use the alpha channel for transparency.")]
			public Color color;

			// Token: 0x04005185 RID: 20869
			[Tooltip("Sets the vignette center point (screen center is [0.5,0.5]).")]
			public Vector2 center;

			// Token: 0x04005186 RID: 20870
			[Range(0f, 1f)]
			[Tooltip("Amount of vignetting on screen.")]
			public float intensity;

			// Token: 0x04005187 RID: 20871
			[Range(0.01f, 1f)]
			[Tooltip("Smoothness of the vignette borders.")]
			public float smoothness;

			// Token: 0x04005188 RID: 20872
			[Range(0f, 1f)]
			[Tooltip("Lower values will make a square-ish vignette.")]
			public float roundness;

			// Token: 0x04005189 RID: 20873
			[Tooltip("A black and white mask to use as a vignette.")]
			public Texture mask;

			// Token: 0x0400518A RID: 20874
			[Range(0f, 1f)]
			[Tooltip("Mask opacity.")]
			public float opacity;

			// Token: 0x0400518B RID: 20875
			[Tooltip("Should the vignette be perfectly round or be dependent on the current aspect ratio?")]
			public bool rounded;
		}
	}
}
