using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055E RID: 1374
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x060022FC RID: 8956 RVA: 0x001EF572 File Offset: 0x001ED772
		// (set) Token: 0x060022FD RID: 8957 RVA: 0x001EF57A File Offset: 0x001ED77A
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

		// Token: 0x060022FE RID: 8958 RVA: 0x001EF583 File Offset: 0x001ED783
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004A7A RID: 19066
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006AD RID: 1709
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x0600270F RID: 9999 RVA: 0x001FDE14 File Offset: 0x001FC014
			// (set) Token: 0x0600270E RID: 9998 RVA: 0x001FDE06 File Offset: 0x001FC006
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

			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x06002710 RID: 10000 RVA: 0x001FDE24 File Offset: 0x001FC024
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

			// Token: 0x04005086 RID: 20614
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x04005087 RID: 20615
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x04005088 RID: 20616
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x04005089 RID: 20617
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x0400508A RID: 20618
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006AE RID: 1710
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x1700058C RID: 1420
			// (get) Token: 0x06002711 RID: 10001 RVA: 0x001FDE74 File Offset: 0x001FC074
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

			// Token: 0x0400508B RID: 20619
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x0400508C RID: 20620
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006AF RID: 1711
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x06002712 RID: 10002 RVA: 0x001FDEA0 File Offset: 0x001FC0A0
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

			// Token: 0x0400508D RID: 20621
			public BloomModel.BloomSettings bloom;

			// Token: 0x0400508E RID: 20622
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
