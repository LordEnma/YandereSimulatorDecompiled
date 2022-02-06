using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000562 RID: 1378
	[Serializable]
	public class AntialiasingModel : PostProcessingModel
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06002322 RID: 8994 RVA: 0x001F3691 File Offset: 0x001F1891
		// (set) Token: 0x06002323 RID: 8995 RVA: 0x001F3699 File Offset: 0x001F1899
		public AntialiasingModel.Settings settings
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

		// Token: 0x06002324 RID: 8996 RVA: 0x001F36A2 File Offset: 0x001F18A2
		public override void Reset()
		{
			this.m_Settings = AntialiasingModel.Settings.defaultSettings;
		}

		// Token: 0x04004AF0 RID: 19184
		[SerializeField]
		private AntialiasingModel.Settings m_Settings = AntialiasingModel.Settings.defaultSettings;

		// Token: 0x020006A6 RID: 1702
		public enum Method
		{
			// Token: 0x040050C2 RID: 20674
			Fxaa,
			// Token: 0x040050C3 RID: 20675
			Taa
		}

		// Token: 0x020006A7 RID: 1703
		public enum FxaaPreset
		{
			// Token: 0x040050C5 RID: 20677
			ExtremePerformance,
			// Token: 0x040050C6 RID: 20678
			Performance,
			// Token: 0x040050C7 RID: 20679
			Default,
			// Token: 0x040050C8 RID: 20680
			Quality,
			// Token: 0x040050C9 RID: 20681
			ExtremeQuality
		}

		// Token: 0x020006A8 RID: 1704
		[Serializable]
		public struct FxaaQualitySettings
		{
			// Token: 0x040050CA RID: 20682
			[Tooltip("The amount of desired sub-pixel aliasing removal. Effects the sharpeness of the output.")]
			[Range(0f, 1f)]
			public float subpixelAliasingRemovalAmount;

			// Token: 0x040050CB RID: 20683
			[Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			[Range(0.063f, 0.333f)]
			public float edgeDetectionThreshold;

			// Token: 0x040050CC RID: 20684
			[Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			[Range(0f, 0.0833f)]
			public float minimumRequiredLuminance;

			// Token: 0x040050CD RID: 20685
			public static AntialiasingModel.FxaaQualitySettings[] presets = new AntialiasingModel.FxaaQualitySettings[]
			{
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 0f,
					edgeDetectionThreshold = 0.333f,
					minimumRequiredLuminance = 0.0833f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 0.25f,
					edgeDetectionThreshold = 0.25f,
					minimumRequiredLuminance = 0.0833f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 0.75f,
					edgeDetectionThreshold = 0.166f,
					minimumRequiredLuminance = 0.0833f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 1f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.0625f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 1f,
					edgeDetectionThreshold = 0.063f,
					minimumRequiredLuminance = 0.0312f
				}
			};
		}

		// Token: 0x020006A9 RID: 1705
		[Serializable]
		public struct FxaaConsoleSettings
		{
			// Token: 0x040050CE RID: 20686
			[Tooltip("The amount of spread applied to the sampling coordinates while sampling for subpixel information.")]
			[Range(0.33f, 0.5f)]
			public float subpixelSpreadAmount;

			// Token: 0x040050CF RID: 20687
			[Tooltip("This value dictates how sharp the edges in the image are kept; a higher value implies sharper edges.")]
			[Range(2f, 8f)]
			public float edgeSharpnessAmount;

			// Token: 0x040050D0 RID: 20688
			[Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			[Range(0.125f, 0.25f)]
			public float edgeDetectionThreshold;

			// Token: 0x040050D1 RID: 20689
			[Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			[Range(0.04f, 0.06f)]
			public float minimumRequiredLuminance;

			// Token: 0x040050D2 RID: 20690
			public static AntialiasingModel.FxaaConsoleSettings[] presets = new AntialiasingModel.FxaaConsoleSettings[]
			{
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.33f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.25f,
					minimumRequiredLuminance = 0.06f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.33f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.06f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.05f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 4f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.04f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 2f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.04f
				}
			};
		}

		// Token: 0x020006AA RID: 1706
		[Serializable]
		public struct FxaaSettings
		{
			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x06002721 RID: 10017 RVA: 0x002017F8 File Offset: 0x001FF9F8
			public static AntialiasingModel.FxaaSettings defaultSettings
			{
				get
				{
					return new AntialiasingModel.FxaaSettings
					{
						preset = AntialiasingModel.FxaaPreset.Default
					};
				}
			}

			// Token: 0x040050D3 RID: 20691
			public AntialiasingModel.FxaaPreset preset;
		}

		// Token: 0x020006AB RID: 1707
		[Serializable]
		public struct TaaSettings
		{
			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x06002722 RID: 10018 RVA: 0x00201818 File Offset: 0x001FFA18
			public static AntialiasingModel.TaaSettings defaultSettings
			{
				get
				{
					return new AntialiasingModel.TaaSettings
					{
						jitterSpread = 0.75f,
						sharpen = 0.3f,
						stationaryBlending = 0.95f,
						motionBlending = 0.85f
					};
				}
			}

			// Token: 0x040050D4 RID: 20692
			[Tooltip("The diameter (in texels) inside which jitter samples are spread. Smaller values result in crisper but more aliased output, while larger values result in more stable but blurrier output.")]
			[Range(0.1f, 1f)]
			public float jitterSpread;

			// Token: 0x040050D5 RID: 20693
			[Tooltip("Controls the amount of sharpening applied to the color buffer.")]
			[Range(0f, 3f)]
			public float sharpen;

			// Token: 0x040050D6 RID: 20694
			[Tooltip("The blend coefficient for a stationary fragment. Controls the percentage of history sample blended into the final color.")]
			[Range(0f, 0.99f)]
			public float stationaryBlending;

			// Token: 0x040050D7 RID: 20695
			[Tooltip("The blend coefficient for a fragment with significant motion. Controls the percentage of history sample blended into the final color.")]
			[Range(0f, 0.99f)]
			public float motionBlending;
		}

		// Token: 0x020006AC RID: 1708
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x06002723 RID: 10019 RVA: 0x00201860 File Offset: 0x001FFA60
			public static AntialiasingModel.Settings defaultSettings
			{
				get
				{
					return new AntialiasingModel.Settings
					{
						method = AntialiasingModel.Method.Fxaa,
						fxaaSettings = AntialiasingModel.FxaaSettings.defaultSettings,
						taaSettings = AntialiasingModel.TaaSettings.defaultSettings
					};
				}
			}

			// Token: 0x040050D8 RID: 20696
			public AntialiasingModel.Method method;

			// Token: 0x040050D9 RID: 20697
			public AntialiasingModel.FxaaSettings fxaaSettings;

			// Token: 0x040050DA RID: 20698
			public AntialiasingModel.TaaSettings taaSettings;
		}
	}
}
