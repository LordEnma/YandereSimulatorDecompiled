using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000563 RID: 1379
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x0600231D RID: 8989 RVA: 0x001F2906 File Offset: 0x001F0B06
		// (set) Token: 0x0600231E RID: 8990 RVA: 0x001F290E File Offset: 0x001F0B0E
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

		// Token: 0x0600231F RID: 8991 RVA: 0x001F2917 File Offset: 0x001F0B17
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004ADD RID: 19165
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006B3 RID: 1715
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x06002730 RID: 10032 RVA: 0x002011CC File Offset: 0x001FF3CC
			// (set) Token: 0x0600272F RID: 10031 RVA: 0x002011BE File Offset: 0x001FF3BE
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

			// Token: 0x1700058C RID: 1420
			// (get) Token: 0x06002731 RID: 10033 RVA: 0x002011DC File Offset: 0x001FF3DC
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

			// Token: 0x040050F5 RID: 20725
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x040050F6 RID: 20726
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x040050F7 RID: 20727
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x040050F8 RID: 20728
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x040050F9 RID: 20729
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006B4 RID: 1716
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x06002732 RID: 10034 RVA: 0x0020122C File Offset: 0x001FF42C
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

			// Token: 0x040050FA RID: 20730
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x040050FB RID: 20731
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006B5 RID: 1717
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x06002733 RID: 10035 RVA: 0x00201258 File Offset: 0x001FF458
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

			// Token: 0x040050FC RID: 20732
			public BloomModel.BloomSettings bloom;

			// Token: 0x040050FD RID: 20733
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
