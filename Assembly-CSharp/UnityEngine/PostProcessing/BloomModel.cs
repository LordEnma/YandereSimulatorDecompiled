using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056A RID: 1386
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06002354 RID: 9044 RVA: 0x001F7096 File Offset: 0x001F5296
		// (set) Token: 0x06002355 RID: 9045 RVA: 0x001F709E File Offset: 0x001F529E
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

		// Token: 0x06002356 RID: 9046 RVA: 0x001F70A7 File Offset: 0x001F52A7
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004B86 RID: 19334
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006B6 RID: 1718
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x0600275C RID: 10076 RVA: 0x00205340 File Offset: 0x00203540
			// (set) Token: 0x0600275B RID: 10075 RVA: 0x00205332 File Offset: 0x00203532
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

			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x0600275D RID: 10077 RVA: 0x00205350 File Offset: 0x00203550
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

			// Token: 0x04005175 RID: 20853
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x04005176 RID: 20854
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x04005177 RID: 20855
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x04005178 RID: 20856
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x04005179 RID: 20857
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006B7 RID: 1719
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x0600275E RID: 10078 RVA: 0x002053A0 File Offset: 0x002035A0
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

			// Token: 0x0400517A RID: 20858
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x0400517B RID: 20859
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006B8 RID: 1720
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x0600275F RID: 10079 RVA: 0x002053CC File Offset: 0x002035CC
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

			// Token: 0x0400517C RID: 20860
			public BloomModel.BloomSettings bloom;

			// Token: 0x0400517D RID: 20861
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
