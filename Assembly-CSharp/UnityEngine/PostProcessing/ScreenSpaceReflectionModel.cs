using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200057A RID: 1402
	[Serializable]
	public class ScreenSpaceReflectionModel : PostProcessingModel
	{
		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x060023A2 RID: 9122 RVA: 0x001F9AF6 File Offset: 0x001F7CF6
		// (set) Token: 0x060023A3 RID: 9123 RVA: 0x001F9AFE File Offset: 0x001F7CFE
		public ScreenSpaceReflectionModel.Settings settings
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

		// Token: 0x060023A4 RID: 9124 RVA: 0x001F9B07 File Offset: 0x001F7D07
		public override void Reset()
		{
			this.m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;
		}

		// Token: 0x04004BDA RID: 19418
		[SerializeField]
		private ScreenSpaceReflectionModel.Settings m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;

		// Token: 0x020006D6 RID: 1750
		public enum SSRResolution
		{
			// Token: 0x04005231 RID: 21041
			High,
			// Token: 0x04005232 RID: 21042
			Low = 2
		}

		// Token: 0x020006D7 RID: 1751
		public enum SSRReflectionBlendType
		{
			// Token: 0x04005234 RID: 21044
			PhysicallyBased,
			// Token: 0x04005235 RID: 21045
			Additive
		}

		// Token: 0x020006D8 RID: 1752
		[Serializable]
		public struct IntensitySettings
		{
			// Token: 0x04005236 RID: 21046
			[Tooltip("Nonphysical multiplier for the SSR reflections. 1.0 is physically based.")]
			[Range(0f, 2f)]
			public float reflectionMultiplier;

			// Token: 0x04005237 RID: 21047
			[Tooltip("How far away from the maxDistance to begin fading SSR.")]
			[Range(0f, 1000f)]
			public float fadeDistance;

			// Token: 0x04005238 RID: 21048
			[Tooltip("Amplify Fresnel fade out. Increase if floor reflections look good close to the surface and bad farther 'under' the floor.")]
			[Range(0f, 1f)]
			public float fresnelFade;

			// Token: 0x04005239 RID: 21049
			[Tooltip("Higher values correspond to a faster Fresnel fade as the reflection changes from the grazing angle.")]
			[Range(0.1f, 10f)]
			public float fresnelFadePower;
		}

		// Token: 0x020006D9 RID: 1753
		[Serializable]
		public struct ReflectionSettings
		{
			// Token: 0x0400523A RID: 21050
			[Tooltip("How the reflections are blended into the render.")]
			public ScreenSpaceReflectionModel.SSRReflectionBlendType blendType;

			// Token: 0x0400523B RID: 21051
			[Tooltip("Half resolution SSRR is much faster, but less accurate.")]
			public ScreenSpaceReflectionModel.SSRResolution reflectionQuality;

			// Token: 0x0400523C RID: 21052
			[Tooltip("Maximum reflection distance in world units.")]
			[Range(0.1f, 300f)]
			public float maxDistance;

			// Token: 0x0400523D RID: 21053
			[Tooltip("Max raytracing length.")]
			[Range(16f, 1024f)]
			public int iterationCount;

			// Token: 0x0400523E RID: 21054
			[Tooltip("Log base 2 of ray tracing coarse step size. Higher traces farther, lower gives better quality silhouettes.")]
			[Range(1f, 16f)]
			public int stepSize;

			// Token: 0x0400523F RID: 21055
			[Tooltip("Typical thickness of columns, walls, furniture, and other objects that reflection rays might pass behind.")]
			[Range(0.01f, 10f)]
			public float widthModifier;

			// Token: 0x04005240 RID: 21056
			[Tooltip("Blurriness of reflections.")]
			[Range(0.1f, 8f)]
			public float reflectionBlur;

			// Token: 0x04005241 RID: 21057
			[Tooltip("Disable for a performance gain in scenes where most glossy objects are horizontal, like floors, water, and tables. Leave on for scenes with glossy vertical objects.")]
			public bool reflectBackfaces;
		}

		// Token: 0x020006DA RID: 1754
		[Serializable]
		public struct ScreenEdgeMask
		{
			// Token: 0x04005242 RID: 21058
			[Tooltip("Higher = fade out SSRR near the edge of the screen so that reflections don't pop under camera motion.")]
			[Range(0f, 1f)]
			public float intensity;
		}

		// Token: 0x020006DB RID: 1755
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A7 RID: 1447
			// (get) Token: 0x06002791 RID: 10129 RVA: 0x0020847C File Offset: 0x0020667C
			public static ScreenSpaceReflectionModel.Settings defaultSettings
			{
				get
				{
					return new ScreenSpaceReflectionModel.Settings
					{
						reflection = new ScreenSpaceReflectionModel.ReflectionSettings
						{
							blendType = ScreenSpaceReflectionModel.SSRReflectionBlendType.PhysicallyBased,
							reflectionQuality = ScreenSpaceReflectionModel.SSRResolution.Low,
							maxDistance = 100f,
							iterationCount = 256,
							stepSize = 3,
							widthModifier = 0.5f,
							reflectionBlur = 1f,
							reflectBackfaces = false
						},
						intensity = new ScreenSpaceReflectionModel.IntensitySettings
						{
							reflectionMultiplier = 1f,
							fadeDistance = 100f,
							fresnelFade = 1f,
							fresnelFadePower = 1f
						},
						screenEdgeMask = new ScreenSpaceReflectionModel.ScreenEdgeMask
						{
							intensity = 0.03f
						}
					};
				}
			}

			// Token: 0x04005243 RID: 21059
			public ScreenSpaceReflectionModel.ReflectionSettings reflection;

			// Token: 0x04005244 RID: 21060
			public ScreenSpaceReflectionModel.IntensitySettings intensity;

			// Token: 0x04005245 RID: 21061
			public ScreenSpaceReflectionModel.ScreenEdgeMask screenEdgeMask;
		}
	}
}
