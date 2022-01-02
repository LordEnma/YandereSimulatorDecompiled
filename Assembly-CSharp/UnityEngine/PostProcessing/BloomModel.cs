using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000560 RID: 1376
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06002310 RID: 8976 RVA: 0x001F1296 File Offset: 0x001EF496
		// (set) Token: 0x06002311 RID: 8977 RVA: 0x001F129E File Offset: 0x001EF49E
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

		// Token: 0x06002312 RID: 8978 RVA: 0x001F12A7 File Offset: 0x001EF4A7
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004AC2 RID: 19138
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006B0 RID: 1712
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x06002723 RID: 10019 RVA: 0x001FFB5C File Offset: 0x001FDD5C
			// (set) Token: 0x06002722 RID: 10018 RVA: 0x001FFB4E File Offset: 0x001FDD4E
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
			// (get) Token: 0x06002724 RID: 10020 RVA: 0x001FFB6C File Offset: 0x001FDD6C
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

			// Token: 0x040050DA RID: 20698
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x040050DB RID: 20699
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x040050DC RID: 20700
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x040050DD RID: 20701
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x040050DE RID: 20702
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006B1 RID: 1713
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x06002725 RID: 10021 RVA: 0x001FFBBC File Offset: 0x001FDDBC
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

			// Token: 0x040050DF RID: 20703
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x040050E0 RID: 20704
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006B2 RID: 1714
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x06002726 RID: 10022 RVA: 0x001FFBE8 File Offset: 0x001FDDE8
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

			// Token: 0x040050E1 RID: 20705
			public BloomModel.BloomSettings bloom;

			// Token: 0x040050E2 RID: 20706
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
