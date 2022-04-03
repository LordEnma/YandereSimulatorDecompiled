using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056E RID: 1390
	[Serializable]
	public class AntialiasingModel : PostProcessingModel
	{
		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06002360 RID: 9056 RVA: 0x001F88D5 File Offset: 0x001F6AD5
		// (set) Token: 0x06002361 RID: 9057 RVA: 0x001F88DD File Offset: 0x001F6ADD
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

		// Token: 0x06002362 RID: 9058 RVA: 0x001F88E6 File Offset: 0x001F6AE6
		public override void Reset()
		{
			this.m_Settings = AntialiasingModel.Settings.defaultSettings;
		}

		// Token: 0x04004BB7 RID: 19383
		[SerializeField]
		private AntialiasingModel.Settings m_Settings = AntialiasingModel.Settings.defaultSettings;

		// Token: 0x020006B4 RID: 1716
		public enum Method
		{
			// Token: 0x0400518E RID: 20878
			Fxaa,
			// Token: 0x0400518F RID: 20879
			Taa
		}

		// Token: 0x020006B5 RID: 1717
		public enum FxaaPreset
		{
			// Token: 0x04005191 RID: 20881
			ExtremePerformance,
			// Token: 0x04005192 RID: 20882
			Performance,
			// Token: 0x04005193 RID: 20883
			Default,
			// Token: 0x04005194 RID: 20884
			Quality,
			// Token: 0x04005195 RID: 20885
			ExtremeQuality
		}

		// Token: 0x020006B6 RID: 1718
		[Serializable]
		public struct FxaaQualitySettings
		{
			// Token: 0x04005196 RID: 20886
			[Tooltip("The amount of desired sub-pixel aliasing removal. Effects the sharpeness of the output.")]
			[Range(0f, 1f)]
			public float subpixelAliasingRemovalAmount;

			// Token: 0x04005197 RID: 20887
			[Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			[Range(0.063f, 0.333f)]
			public float edgeDetectionThreshold;

			// Token: 0x04005198 RID: 20888
			[Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			[Range(0f, 0.0833f)]
			public float minimumRequiredLuminance;

			// Token: 0x04005199 RID: 20889
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

		// Token: 0x020006B7 RID: 1719
		[Serializable]
		public struct FxaaConsoleSettings
		{
			// Token: 0x0400519A RID: 20890
			[Tooltip("The amount of spread applied to the sampling coordinates while sampling for subpixel information.")]
			[Range(0.33f, 0.5f)]
			public float subpixelSpreadAmount;

			// Token: 0x0400519B RID: 20891
			[Tooltip("This value dictates how sharp the edges in the image are kept; a higher value implies sharper edges.")]
			[Range(2f, 8f)]
			public float edgeSharpnessAmount;

			// Token: 0x0400519C RID: 20892
			[Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			[Range(0.125f, 0.25f)]
			public float edgeDetectionThreshold;

			// Token: 0x0400519D RID: 20893
			[Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			[Range(0.04f, 0.06f)]
			public float minimumRequiredLuminance;

			// Token: 0x0400519E RID: 20894
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

		// Token: 0x020006B8 RID: 1720
		[Serializable]
		public struct FxaaSettings
		{
			// Token: 0x1700058D RID: 1421
			// (get) Token: 0x06002768 RID: 10088 RVA: 0x00206C54 File Offset: 0x00204E54
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

			// Token: 0x0400519F RID: 20895
			public AntialiasingModel.FxaaPreset preset;
		}

		// Token: 0x020006B9 RID: 1721
		[Serializable]
		public struct TaaSettings
		{
			// Token: 0x1700058E RID: 1422
			// (get) Token: 0x06002769 RID: 10089 RVA: 0x00206C74 File Offset: 0x00204E74
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

			// Token: 0x040051A0 RID: 20896
			[Tooltip("The diameter (in texels) inside which jitter samples are spread. Smaller values result in crisper but more aliased output, while larger values result in more stable but blurrier output.")]
			[Range(0.1f, 1f)]
			public float jitterSpread;

			// Token: 0x040051A1 RID: 20897
			[Tooltip("Controls the amount of sharpening applied to the color buffer.")]
			[Range(0f, 3f)]
			public float sharpen;

			// Token: 0x040051A2 RID: 20898
			[Tooltip("The blend coefficient for a stationary fragment. Controls the percentage of history sample blended into the final color.")]
			[Range(0f, 0.99f)]
			public float stationaryBlending;

			// Token: 0x040051A3 RID: 20899
			[Tooltip("The blend coefficient for a fragment with significant motion. Controls the percentage of history sample blended into the final color.")]
			[Range(0f, 0.99f)]
			public float motionBlending;
		}

		// Token: 0x020006BA RID: 1722
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x0600276A RID: 10090 RVA: 0x00206CBC File Offset: 0x00204EBC
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

			// Token: 0x040051A4 RID: 20900
			public AntialiasingModel.Method method;

			// Token: 0x040051A5 RID: 20901
			public AntialiasingModel.FxaaSettings fxaaSettings;

			// Token: 0x040051A6 RID: 20902
			public AntialiasingModel.TaaSettings taaSettings;
		}
	}
}
