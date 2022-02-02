using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000563 RID: 1379
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06002321 RID: 8993 RVA: 0x001F31A6 File Offset: 0x001F13A6
		// (set) Token: 0x06002322 RID: 8994 RVA: 0x001F31AE File Offset: 0x001F13AE
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

		// Token: 0x06002323 RID: 8995 RVA: 0x001F31B7 File Offset: 0x001F13B7
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004AE8 RID: 19176
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006AD RID: 1709
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x06002720 RID: 10016 RVA: 0x00201388 File Offset: 0x001FF588
			// (set) Token: 0x0600271F RID: 10015 RVA: 0x0020137A File Offset: 0x001FF57A
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
			// (get) Token: 0x06002721 RID: 10017 RVA: 0x00201398 File Offset: 0x001FF598
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

			// Token: 0x040050D2 RID: 20690
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x040050D3 RID: 20691
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x040050D4 RID: 20692
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x040050D5 RID: 20693
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x040050D6 RID: 20694
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006AE RID: 1710
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x06002722 RID: 10018 RVA: 0x002013E8 File Offset: 0x001FF5E8
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

			// Token: 0x040050D7 RID: 20695
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x040050D8 RID: 20696
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006AF RID: 1711
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x06002723 RID: 10019 RVA: 0x00201414 File Offset: 0x001FF614
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

			// Token: 0x040050D9 RID: 20697
			public BloomModel.BloomSettings bloom;

			// Token: 0x040050DA RID: 20698
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
