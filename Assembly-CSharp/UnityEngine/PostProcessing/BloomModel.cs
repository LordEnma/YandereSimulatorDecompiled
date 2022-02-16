using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000564 RID: 1380
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x0600232D RID: 9005 RVA: 0x001F3B76 File Offset: 0x001F1D76
		// (set) Token: 0x0600232E RID: 9006 RVA: 0x001F3B7E File Offset: 0x001F1D7E
		public BloomModel.Settings settings
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

		// Token: 0x0600232F RID: 9007 RVA: 0x001F3B87 File Offset: 0x001F1D87
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004AFA RID: 19194
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006AE RID: 1710
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x0600272C RID: 10028 RVA: 0x00201D58 File Offset: 0x001FFF58
			// (set) Token: 0x0600272B RID: 10027 RVA: 0x00201D4A File Offset: 0x001FFF4A
			public float thresholdLinear
			{
				get
				{
					return Mathf.GammaToLinearSpace(this.threshold);
				}
				set
				{
					this.threshold = Mathf.LinearToGammaSpace(value);
				}
			}

			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x0600272D RID: 10029 RVA: 0x00201D68 File Offset: 0x001FFF68
			public static BloomModel.BloomSettings defaultSettings
			{
				get
				{
					return new BloomModel.BloomSettings
					{
						intensity = 0.5f,
						threshold = 1.1f,
						softKnee = 0.5f,
						radius = 4f,
						antiFlicker = false
					};
				}
			}

			// Token: 0x040050E4 RID: 20708
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x040050E5 RID: 20709
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x040050E6 RID: 20710
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x040050E7 RID: 20711
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x040050E8 RID: 20712
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006AF RID: 1711
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x0600272E RID: 10030 RVA: 0x00201DB8 File Offset: 0x001FFFB8
			public static BloomModel.LensDirtSettings defaultSettings
			{
				get
				{
					return new BloomModel.LensDirtSettings
					{
						texture = null,
						intensity = 3f
					};
				}
			}

			// Token: 0x040050E9 RID: 20713
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x040050EA RID: 20714
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006B0 RID: 1712
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x0600272F RID: 10031 RVA: 0x00201DE4 File Offset: 0x001FFFE4
			public static BloomModel.Settings defaultSettings
			{
				get
				{
					return new BloomModel.Settings
					{
						bloom = BloomModel.BloomSettings.defaultSettings,
						lensDirt = BloomModel.LensDirtSettings.defaultSettings
					};
				}
			}

			// Token: 0x040050EB RID: 20715
			public BloomModel.BloomSettings bloom;

			// Token: 0x040050EC RID: 20716
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
