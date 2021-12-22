using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056D RID: 1389
	[ImageEffectAllowedInSceneView]
	[RequireComponent(typeof(Camera))]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[AddComponentMenu("Effects/Post-Processing Behaviour", -1)]
	public class PostProcessingBehaviour : MonoBehaviour
	{
		// Token: 0x06002348 RID: 9032 RVA: 0x001F0FA0 File Offset: 0x001EF1A0
		private void OnEnable()
		{
			this.m_CommandBuffers = new Dictionary<Type, KeyValuePair<CameraEvent, CommandBuffer>>();
			this.m_MaterialFactory = new MaterialFactory();
			this.m_RenderTextureFactory = new RenderTextureFactory();
			this.m_Context = new PostProcessingContext();
			this.m_Components = new List<PostProcessingComponentBase>();
			this.m_DebugViews = this.AddComponent<BuiltinDebugViewsComponent>(new BuiltinDebugViewsComponent());
			this.m_AmbientOcclusion = this.AddComponent<AmbientOcclusionComponent>(new AmbientOcclusionComponent());
			this.m_ScreenSpaceReflection = this.AddComponent<ScreenSpaceReflectionComponent>(new ScreenSpaceReflectionComponent());
			this.m_FogComponent = this.AddComponent<FogComponent>(new FogComponent());
			this.m_MotionBlur = this.AddComponent<MotionBlurComponent>(new MotionBlurComponent());
			this.m_Taa = this.AddComponent<TaaComponent>(new TaaComponent());
			this.m_EyeAdaptation = this.AddComponent<EyeAdaptationComponent>(new EyeAdaptationComponent());
			this.m_DepthOfField = this.AddComponent<DepthOfFieldComponent>(new DepthOfFieldComponent());
			this.m_Bloom = this.AddComponent<BloomComponent>(new BloomComponent());
			this.m_ChromaticAberration = this.AddComponent<ChromaticAberrationComponent>(new ChromaticAberrationComponent());
			this.m_ColorGrading = this.AddComponent<ColorGradingComponent>(new ColorGradingComponent());
			this.m_UserLut = this.AddComponent<UserLutComponent>(new UserLutComponent());
			this.m_Grain = this.AddComponent<GrainComponent>(new GrainComponent());
			this.m_Vignette = this.AddComponent<VignetteComponent>(new VignetteComponent());
			this.m_Dithering = this.AddComponent<DitheringComponent>(new DitheringComponent());
			this.m_Fxaa = this.AddComponent<FxaaComponent>(new FxaaComponent());
			this.m_ComponentStates = new Dictionary<PostProcessingComponentBase, bool>();
			foreach (PostProcessingComponentBase key in this.m_Components)
			{
				this.m_ComponentStates.Add(key, false);
			}
			base.useGUILayout = false;
		}

		// Token: 0x06002349 RID: 9033 RVA: 0x001F1154 File Offset: 0x001EF354
		private void OnPreCull()
		{
			this.m_Camera = base.GetComponent<Camera>();
			if (this.profile == null || this.m_Camera == null)
			{
				return;
			}
			PostProcessingContext postProcessingContext = this.m_Context.Reset();
			postProcessingContext.profile = this.profile;
			postProcessingContext.renderTextureFactory = this.m_RenderTextureFactory;
			postProcessingContext.materialFactory = this.m_MaterialFactory;
			postProcessingContext.camera = this.m_Camera;
			this.m_DebugViews.Init(postProcessingContext, this.profile.debugViews);
			this.m_AmbientOcclusion.Init(postProcessingContext, this.profile.ambientOcclusion);
			this.m_ScreenSpaceReflection.Init(postProcessingContext, this.profile.screenSpaceReflection);
			this.m_FogComponent.Init(postProcessingContext, this.profile.fog);
			this.m_MotionBlur.Init(postProcessingContext, this.profile.motionBlur);
			this.m_Taa.Init(postProcessingContext, this.profile.antialiasing);
			this.m_EyeAdaptation.Init(postProcessingContext, this.profile.eyeAdaptation);
			this.m_DepthOfField.Init(postProcessingContext, this.profile.depthOfField);
			this.m_Bloom.Init(postProcessingContext, this.profile.bloom);
			this.m_ChromaticAberration.Init(postProcessingContext, this.profile.chromaticAberration);
			this.m_ColorGrading.Init(postProcessingContext, this.profile.colorGrading);
			this.m_UserLut.Init(postProcessingContext, this.profile.userLut);
			this.m_Grain.Init(postProcessingContext, this.profile.grain);
			this.m_Vignette.Init(postProcessingContext, this.profile.vignette);
			this.m_Dithering.Init(postProcessingContext, this.profile.dithering);
			this.m_Fxaa.Init(postProcessingContext, this.profile.antialiasing);
			if (this.m_PreviousProfile != this.profile)
			{
				this.DisableComponents();
				this.m_PreviousProfile = this.profile;
			}
			this.CheckObservers();
			DepthTextureMode depthTextureMode = postProcessingContext.camera.depthTextureMode;
			foreach (PostProcessingComponentBase postProcessingComponentBase in this.m_Components)
			{
				if (postProcessingComponentBase.active)
				{
					depthTextureMode |= postProcessingComponentBase.GetCameraFlags();
				}
			}
			postProcessingContext.camera.depthTextureMode = depthTextureMode;
			if (!this.m_RenderingInSceneView && this.m_Taa.active && !this.profile.debugViews.willInterrupt)
			{
				this.m_Taa.SetProjectionMatrix(this.jitteredMatrixFunc);
			}
		}

		// Token: 0x0600234A RID: 9034 RVA: 0x001F1404 File Offset: 0x001EF604
		private void OnPreRender()
		{
			if (this.profile == null)
			{
				return;
			}
			this.TryExecuteCommandBuffer<BuiltinDebugViewsModel>(this.m_DebugViews);
			this.TryExecuteCommandBuffer<AmbientOcclusionModel>(this.m_AmbientOcclusion);
			this.TryExecuteCommandBuffer<ScreenSpaceReflectionModel>(this.m_ScreenSpaceReflection);
			this.TryExecuteCommandBuffer<FogModel>(this.m_FogComponent);
			if (!this.m_RenderingInSceneView)
			{
				this.TryExecuteCommandBuffer<MotionBlurModel>(this.m_MotionBlur);
			}
		}

		// Token: 0x0600234B RID: 9035 RVA: 0x001F1464 File Offset: 0x001EF664
		private void OnPostRender()
		{
			if (this.profile == null || this.m_Camera == null)
			{
				return;
			}
			if (!this.m_RenderingInSceneView && this.m_Taa.active && !this.profile.debugViews.willInterrupt)
			{
				this.m_Context.camera.ResetProjectionMatrix();
			}
		}

		// Token: 0x0600234C RID: 9036 RVA: 0x001F14C8 File Offset: 0x001EF6C8
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (this.profile == null || this.m_Camera == null)
			{
				Graphics.Blit(source, destination);
				return;
			}
			bool flag = false;
			bool active = this.m_Fxaa.active;
			bool flag2 = this.m_Taa.active && !this.m_RenderingInSceneView;
			bool flag3 = this.m_DepthOfField.active && !this.m_RenderingInSceneView;
			Material material = this.m_MaterialFactory.Get("Hidden/Post FX/Uber Shader");
			material.shaderKeywords = null;
			RenderTexture renderTexture = source;
			if (flag2)
			{
				RenderTexture renderTexture2 = this.m_RenderTextureFactory.Get(renderTexture);
				this.m_Taa.Render(renderTexture, renderTexture2);
				renderTexture = renderTexture2;
			}
			Texture texture = GraphicsUtils.whiteTexture;
			if (this.m_EyeAdaptation.active)
			{
				flag = true;
				texture = this.m_EyeAdaptation.Prepare(renderTexture, material);
			}
			material.SetTexture("_AutoExposure", texture);
			if (flag3)
			{
				flag = true;
				this.m_DepthOfField.Prepare(renderTexture, material, flag2, this.m_Taa.jitterVector, this.m_Taa.model.settings.taaSettings.motionBlending);
			}
			if (this.m_Bloom.active)
			{
				flag = true;
				this.m_Bloom.Prepare(renderTexture, material, texture);
			}
			flag |= this.TryPrepareUberImageEffect<ChromaticAberrationModel>(this.m_ChromaticAberration, material);
			flag |= this.TryPrepareUberImageEffect<ColorGradingModel>(this.m_ColorGrading, material);
			flag |= this.TryPrepareUberImageEffect<VignetteModel>(this.m_Vignette, material);
			flag |= this.TryPrepareUberImageEffect<UserLutModel>(this.m_UserLut, material);
			Material material2 = active ? this.m_MaterialFactory.Get("Hidden/Post FX/FXAA") : null;
			if (active)
			{
				material2.shaderKeywords = null;
				this.TryPrepareUberImageEffect<GrainModel>(this.m_Grain, material2);
				this.TryPrepareUberImageEffect<DitheringModel>(this.m_Dithering, material2);
				if (flag)
				{
					RenderTexture renderTexture3 = this.m_RenderTextureFactory.Get(renderTexture);
					Graphics.Blit(renderTexture, renderTexture3, material, 0);
					renderTexture = renderTexture3;
				}
				this.m_Fxaa.Render(renderTexture, destination);
			}
			else
			{
				flag |= this.TryPrepareUberImageEffect<GrainModel>(this.m_Grain, material);
				flag |= this.TryPrepareUberImageEffect<DitheringModel>(this.m_Dithering, material);
				if (flag)
				{
					if (!GraphicsUtils.isLinearColorSpace)
					{
						material.EnableKeyword("UNITY_COLORSPACE_GAMMA");
					}
					Graphics.Blit(renderTexture, destination, material, 0);
				}
			}
			if (!flag && !active)
			{
				Graphics.Blit(renderTexture, destination);
			}
			this.m_RenderTextureFactory.ReleaseAll();
		}

		// Token: 0x0600234D RID: 9037 RVA: 0x001F1714 File Offset: 0x001EF914
		private void OnGUI()
		{
			if (Event.current.type != EventType.Repaint)
			{
				return;
			}
			if (this.profile == null || this.m_Camera == null)
			{
				return;
			}
			if (this.m_EyeAdaptation.active && this.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation))
			{
				this.m_EyeAdaptation.OnGUI();
				return;
			}
			if (this.m_ColorGrading.active && this.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut))
			{
				this.m_ColorGrading.OnGUI();
				return;
			}
			if (this.m_UserLut.active && this.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut))
			{
				this.m_UserLut.OnGUI();
			}
		}

		// Token: 0x0600234E RID: 9038 RVA: 0x001F17D0 File Offset: 0x001EF9D0
		private void OnDisable()
		{
			foreach (KeyValuePair<CameraEvent, CommandBuffer> keyValuePair in this.m_CommandBuffers.Values)
			{
				this.m_Camera.RemoveCommandBuffer(keyValuePair.Key, keyValuePair.Value);
				keyValuePair.Value.Dispose();
			}
			this.m_CommandBuffers.Clear();
			if (this.profile != null)
			{
				this.DisableComponents();
			}
			this.m_Components.Clear();
			this.m_MaterialFactory.Dispose();
			this.m_RenderTextureFactory.Dispose();
			GraphicsUtils.Dispose();
		}

		// Token: 0x0600234F RID: 9039 RVA: 0x001F188C File Offset: 0x001EFA8C
		public void ResetTemporalEffects()
		{
			this.m_Taa.ResetHistory();
			this.m_MotionBlur.ResetHistory();
			this.m_EyeAdaptation.ResetHistory();
		}

		// Token: 0x06002350 RID: 9040 RVA: 0x001F18B0 File Offset: 0x001EFAB0
		private void CheckObservers()
		{
			foreach (KeyValuePair<PostProcessingComponentBase, bool> keyValuePair in this.m_ComponentStates)
			{
				PostProcessingComponentBase key = keyValuePair.Key;
				bool enabled = key.GetModel().enabled;
				if (enabled != keyValuePair.Value)
				{
					if (enabled)
					{
						this.m_ComponentsToEnable.Add(key);
					}
					else
					{
						this.m_ComponentsToDisable.Add(key);
					}
				}
			}
			for (int i = 0; i < this.m_ComponentsToDisable.Count; i++)
			{
				PostProcessingComponentBase postProcessingComponentBase = this.m_ComponentsToDisable[i];
				this.m_ComponentStates[postProcessingComponentBase] = false;
				postProcessingComponentBase.OnDisable();
			}
			for (int j = 0; j < this.m_ComponentsToEnable.Count; j++)
			{
				PostProcessingComponentBase postProcessingComponentBase2 = this.m_ComponentsToEnable[j];
				this.m_ComponentStates[postProcessingComponentBase2] = true;
				postProcessingComponentBase2.OnEnable();
			}
			this.m_ComponentsToDisable.Clear();
			this.m_ComponentsToEnable.Clear();
		}

		// Token: 0x06002351 RID: 9041 RVA: 0x001F19CC File Offset: 0x001EFBCC
		private void DisableComponents()
		{
			foreach (PostProcessingComponentBase postProcessingComponentBase in this.m_Components)
			{
				PostProcessingModel model = postProcessingComponentBase.GetModel();
				if (model != null && model.enabled)
				{
					postProcessingComponentBase.OnDisable();
				}
			}
		}

		// Token: 0x06002352 RID: 9042 RVA: 0x001F1A30 File Offset: 0x001EFC30
		private CommandBuffer AddCommandBuffer<T>(CameraEvent evt, string name) where T : PostProcessingModel
		{
			CommandBuffer value = new CommandBuffer
			{
				name = name
			};
			KeyValuePair<CameraEvent, CommandBuffer> value2 = new KeyValuePair<CameraEvent, CommandBuffer>(evt, value);
			this.m_CommandBuffers.Add(typeof(T), value2);
			this.m_Camera.AddCommandBuffer(evt, value2.Value);
			return value2.Value;
		}

		// Token: 0x06002353 RID: 9043 RVA: 0x001F1A84 File Offset: 0x001EFC84
		private void RemoveCommandBuffer<T>() where T : PostProcessingModel
		{
			Type typeFromHandle = typeof(T);
			KeyValuePair<CameraEvent, CommandBuffer> keyValuePair;
			if (!this.m_CommandBuffers.TryGetValue(typeFromHandle, out keyValuePair))
			{
				return;
			}
			this.m_Camera.RemoveCommandBuffer(keyValuePair.Key, keyValuePair.Value);
			this.m_CommandBuffers.Remove(typeFromHandle);
			keyValuePair.Value.Dispose();
		}

		// Token: 0x06002354 RID: 9044 RVA: 0x001F1AE0 File Offset: 0x001EFCE0
		private CommandBuffer GetCommandBuffer<T>(CameraEvent evt, string name) where T : PostProcessingModel
		{
			KeyValuePair<CameraEvent, CommandBuffer> keyValuePair;
			CommandBuffer result;
			if (!this.m_CommandBuffers.TryGetValue(typeof(T), out keyValuePair))
			{
				result = this.AddCommandBuffer<T>(evt, name);
			}
			else if (keyValuePair.Key != evt)
			{
				this.RemoveCommandBuffer<T>();
				result = this.AddCommandBuffer<T>(evt, name);
			}
			else
			{
				result = keyValuePair.Value;
			}
			return result;
		}

		// Token: 0x06002355 RID: 9045 RVA: 0x001F1B38 File Offset: 0x001EFD38
		private void TryExecuteCommandBuffer<T>(PostProcessingComponentCommandBuffer<T> component) where T : PostProcessingModel
		{
			if (component.active)
			{
				CommandBuffer commandBuffer = this.GetCommandBuffer<T>(component.GetCameraEvent(), component.GetName());
				commandBuffer.Clear();
				component.PopulateCommandBuffer(commandBuffer);
				return;
			}
			this.RemoveCommandBuffer<T>();
		}

		// Token: 0x06002356 RID: 9046 RVA: 0x001F1B74 File Offset: 0x001EFD74
		private bool TryPrepareUberImageEffect<T>(PostProcessingComponentRenderTexture<T> component, Material material) where T : PostProcessingModel
		{
			if (!component.active)
			{
				return false;
			}
			component.Prepare(material);
			return true;
		}

		// Token: 0x06002357 RID: 9047 RVA: 0x001F1B88 File Offset: 0x001EFD88
		private T AddComponent<T>(T component) where T : PostProcessingComponentBase
		{
			this.m_Components.Add(component);
			return component;
		}

		// Token: 0x04004AC8 RID: 19144
		public PostProcessingProfile profile;

		// Token: 0x04004AC9 RID: 19145
		public Func<Vector2, Matrix4x4> jitteredMatrixFunc;

		// Token: 0x04004ACA RID: 19146
		private Dictionary<Type, KeyValuePair<CameraEvent, CommandBuffer>> m_CommandBuffers;

		// Token: 0x04004ACB RID: 19147
		private List<PostProcessingComponentBase> m_Components;

		// Token: 0x04004ACC RID: 19148
		private Dictionary<PostProcessingComponentBase, bool> m_ComponentStates;

		// Token: 0x04004ACD RID: 19149
		private MaterialFactory m_MaterialFactory;

		// Token: 0x04004ACE RID: 19150
		private RenderTextureFactory m_RenderTextureFactory;

		// Token: 0x04004ACF RID: 19151
		private PostProcessingContext m_Context;

		// Token: 0x04004AD0 RID: 19152
		private Camera m_Camera;

		// Token: 0x04004AD1 RID: 19153
		private PostProcessingProfile m_PreviousProfile;

		// Token: 0x04004AD2 RID: 19154
		private bool m_RenderingInSceneView;

		// Token: 0x04004AD3 RID: 19155
		private BuiltinDebugViewsComponent m_DebugViews;

		// Token: 0x04004AD4 RID: 19156
		private AmbientOcclusionComponent m_AmbientOcclusion;

		// Token: 0x04004AD5 RID: 19157
		private ScreenSpaceReflectionComponent m_ScreenSpaceReflection;

		// Token: 0x04004AD6 RID: 19158
		private FogComponent m_FogComponent;

		// Token: 0x04004AD7 RID: 19159
		private MotionBlurComponent m_MotionBlur;

		// Token: 0x04004AD8 RID: 19160
		private TaaComponent m_Taa;

		// Token: 0x04004AD9 RID: 19161
		private EyeAdaptationComponent m_EyeAdaptation;

		// Token: 0x04004ADA RID: 19162
		private DepthOfFieldComponent m_DepthOfField;

		// Token: 0x04004ADB RID: 19163
		private BloomComponent m_Bloom;

		// Token: 0x04004ADC RID: 19164
		private ChromaticAberrationComponent m_ChromaticAberration;

		// Token: 0x04004ADD RID: 19165
		private ColorGradingComponent m_ColorGrading;

		// Token: 0x04004ADE RID: 19166
		private UserLutComponent m_UserLut;

		// Token: 0x04004ADF RID: 19167
		private GrainComponent m_Grain;

		// Token: 0x04004AE0 RID: 19168
		private VignetteComponent m_Vignette;

		// Token: 0x04004AE1 RID: 19169
		private DitheringComponent m_Dithering;

		// Token: 0x04004AE2 RID: 19170
		private FxaaComponent m_Fxaa;

		// Token: 0x04004AE3 RID: 19171
		private List<PostProcessingComponentBase> m_ComponentsToEnable = new List<PostProcessingComponentBase>();

		// Token: 0x04004AE4 RID: 19172
		private List<PostProcessingComponentBase> m_ComponentsToDisable = new List<PostProcessingComponentBase>();
	}
}
