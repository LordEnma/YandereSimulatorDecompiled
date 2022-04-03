using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056F RID: 1391
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06002364 RID: 9060 RVA: 0x001F8906 File Offset: 0x001F6B06
		// (set) Token: 0x06002365 RID: 9061 RVA: 0x001F890E File Offset: 0x001F6B0E
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

		// Token: 0x06002366 RID: 9062 RVA: 0x001F8917 File Offset: 0x001F6B17
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004BB8 RID: 19384
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006BB RID: 1723
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x0600276C RID: 10092 RVA: 0x00206D00 File Offset: 0x00204F00
			// (set) Token: 0x0600276B RID: 10091 RVA: 0x00206CF2 File Offset: 0x00204EF2
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
			// (get) Token: 0x0600276D RID: 10093 RVA: 0x00206D10 File Offset: 0x00204F10
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

			// Token: 0x040051A7 RID: 20903
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x040051A8 RID: 20904
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x040051A9 RID: 20905
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x040051AA RID: 20906
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x040051AB RID: 20907
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006BC RID: 1724
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x0600276E RID: 10094 RVA: 0x00206D60 File Offset: 0x00204F60
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

			// Token: 0x040051AC RID: 20908
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x040051AD RID: 20909
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006BD RID: 1725
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x0600276F RID: 10095 RVA: 0x00206D8C File Offset: 0x00204F8C
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

			// Token: 0x040051AE RID: 20910
			public BloomModel.BloomSettings bloom;

			// Token: 0x040051AF RID: 20911
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
