using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000570 RID: 1392
	[Serializable]
	public class ScreenSpaceReflectionModel : PostProcessingModel
	{
		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x0600236B RID: 9067 RVA: 0x001F5392 File Offset: 0x001F3592
		// (set) Token: 0x0600236C RID: 9068 RVA: 0x001F539A File Offset: 0x001F359A
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

		// Token: 0x0600236D RID: 9069 RVA: 0x001F53A3 File Offset: 0x001F35A3
		public override void Reset()
		{
			this.m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;
		}

		// Token: 0x04004B33 RID: 19251
		[SerializeField]
		private ScreenSpaceReflectionModel.Settings m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;

		// Token: 0x020006CC RID: 1740
		public enum SSRResolution
		{
			// Token: 0x0400518A RID: 20874
			High,
			// Token: 0x0400518B RID: 20875
			Low = 2
		}

		// Token: 0x020006CD RID: 1741
		public enum SSRReflectionBlendType
		{
			// Token: 0x0400518D RID: 20877
			PhysicallyBased,
			// Token: 0x0400518E RID: 20878
			Additive
		}

		// Token: 0x020006CE RID: 1742
		[Serializable]
		public struct IntensitySettings
		{
			// Token: 0x0400518F RID: 20879
			[Tooltip("Nonphysical multiplier for the SSR reflections. 1.0 is physically based.")]
			[Range(0f, 2f)]
			public float reflectionMultiplier;

			// Token: 0x04005190 RID: 20880
			[Tooltip("How far away from the maxDistance to begin fading SSR.")]
			[Range(0f, 1000f)]
			public float fadeDistance;

			// Token: 0x04005191 RID: 20881
			[Tooltip("Amplify Fresnel fade out. Increase if floor reflections look good close to the surface and bad farther 'under' the floor.")]
			[Range(0f, 1f)]
			public float fresnelFade;

			// Token: 0x04005192 RID: 20882
			[Tooltip("Higher values correspond to a faster Fresnel fade as the reflection changes from the grazing angle.")]
			[Range(0.1f, 10f)]
			public float fresnelFadePower;
		}

		// Token: 0x020006CF RID: 1743
		[Serializable]
		public struct ReflectionSettings
		{
			// Token: 0x04005193 RID: 20883
			[Tooltip("How the reflections are blended into the render.")]
			public ScreenSpaceReflectionModel.SSRReflectionBlendType blendType;

			// Token: 0x04005194 RID: 20884
			[Tooltip("Half resolution SSRR is much faster, but less accurate.")]
			public ScreenSpaceReflectionModel.SSRResolution reflectionQuality;

			// Token: 0x04005195 RID: 20885
			[Tooltip("Maximum reflection distance in world units.")]
			[Range(0.1f, 300f)]
			public float maxDistance;

			// Token: 0x04005196 RID: 20886
			[Tooltip("Max raytracing length.")]
			[Range(16f, 1024f)]
			public int iterationCount;

			// Token: 0x04005197 RID: 20887
			[Tooltip("Log base 2 of ray tracing coarse step size. Higher traces farther, lower gives better quality silhouettes.")]
			[Range(1f, 16f)]
			public int stepSize;

			// Token: 0x04005198 RID: 20888
			[Tooltip("Typical thickness of columns, walls, furniture, and other objects that reflection rays might pass behind.")]
			[Range(0.01f, 10f)]
			public float widthModifier;

			// Token: 0x04005199 RID: 20889
			[Tooltip("Blurriness of reflections.")]
			[Range(0.1f, 8f)]
			public float reflectionBlur;

			// Token: 0x0400519A RID: 20890
			[Tooltip("Disable for a performance gain in scenes where most glossy objects are horizontal, like floors, water, and tables. Leave on for scenes with glossy vertical objects.")]
			public bool reflectBackfaces;
		}

		// Token: 0x020006D0 RID: 1744
		[Serializable]
		public struct ScreenEdgeMask
		{
			// Token: 0x0400519B RID: 20891
			[Tooltip("Higher = fade out SSRR near the edge of the screen so that reflections don't pop under camera motion.")]
			[Range(0f, 1f)]
			public float intensity;
		}

		// Token: 0x020006D1 RID: 1745
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A5 RID: 1445
			// (get) Token: 0x0600275A RID: 10074 RVA: 0x00203BC8 File Offset: 0x00201DC8
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

			// Token: 0x0400519C RID: 20892
			public ScreenSpaceReflectionModel.ReflectionSettings reflection;

			// Token: 0x0400519D RID: 20893
			public ScreenSpaceReflectionModel.IntensitySettings intensity;

			// Token: 0x0400519E RID: 20894
			public ScreenSpaceReflectionModel.ScreenEdgeMask screenEdgeMask;
		}
	}
}
