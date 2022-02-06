using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000563 RID: 1379
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06002326 RID: 8998 RVA: 0x001F36C2 File Offset: 0x001F18C2
		// (set) Token: 0x06002327 RID: 8999 RVA: 0x001F36CA File Offset: 0x001F18CA
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

		// Token: 0x06002328 RID: 9000 RVA: 0x001F36D3 File Offset: 0x001F18D3
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004AF1 RID: 19185
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006AD RID: 1709
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x1700058C RID: 1420
			// (get) Token: 0x06002725 RID: 10021 RVA: 0x002018A4 File Offset: 0x001FFAA4
			// (set) Token: 0x06002724 RID: 10020 RVA: 0x00201896 File Offset: 0x001FFA96
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

			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x06002726 RID: 10022 RVA: 0x002018B4 File Offset: 0x001FFAB4
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

			// Token: 0x040050DB RID: 20699
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x040050DC RID: 20700
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x040050DD RID: 20701
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x040050DE RID: 20702
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x040050DF RID: 20703
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006AE RID: 1710
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x06002727 RID: 10023 RVA: 0x00201904 File Offset: 0x001FFB04
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

			// Token: 0x040050E0 RID: 20704
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x040050E1 RID: 20705
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006AF RID: 1711
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06002728 RID: 10024 RVA: 0x00201930 File Offset: 0x001FFB30
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

			// Token: 0x040050E2 RID: 20706
			public BloomModel.BloomSettings bloom;

			// Token: 0x040050E3 RID: 20707
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
