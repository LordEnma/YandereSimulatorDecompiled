using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	[ImageEffectAllowedInSceneView]
	[RequireComponent(typeof(Camera))]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[AddComponentMenu("Effects/Post-Processing Behaviour", -1)]
	public class PostProcessingBehaviour : MonoBehaviour
	{
		// Token: 0x06002377 RID: 9079 RVA: 0x001F5428 File Offset: 0x001F3628
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

		// Token: 0x06002378 RID: 9080 RVA: 0x001F55DC File Offset: 0x001F37DC
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

		// Token: 0x06002379 RID: 9081 RVA: 0x001F588C File Offset: 0x001F3A8C
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

		// Token: 0x0600237A RID: 9082 RVA: 0x001F58EC File Offset: 0x001F3AEC
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

		// Token: 0x0600237B RID: 9083 RVA: 0x001F5950 File Offset: 0x001F3B50
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

		// Token: 0x0600237C RID: 9084 RVA: 0x001F5B9C File Offset: 0x001F3D9C
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

		// Token: 0x0600237D RID: 9085 RVA: 0x001F5C58 File Offset: 0x001F3E58
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

		// Token: 0x0600237E RID: 9086 RVA: 0x001F5D14 File Offset: 0x001F3F14
		public void ResetTemporalEffects()
		{
			this.m_Taa.ResetHistory();
			this.m_MotionBlur.ResetHistory();
			this.m_EyeAdaptation.ResetHistory();
		}

		// Token: 0x0600237F RID: 9087 RVA: 0x001F5D38 File Offset: 0x001F3F38
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

		// Token: 0x06002380 RID: 9088 RVA: 0x001F5E54 File Offset: 0x001F4054
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

		// Token: 0x06002381 RID: 9089 RVA: 0x001F5EB8 File Offset: 0x001F40B8
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

		// Token: 0x06002382 RID: 9090 RVA: 0x001F5F0C File Offset: 0x001F410C
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

		// Token: 0x06002383 RID: 9091 RVA: 0x001F5F68 File Offset: 0x001F4168
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

		// Token: 0x06002384 RID: 9092 RVA: 0x001F5FC0 File Offset: 0x001F41C0
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

		// Token: 0x06002385 RID: 9093 RVA: 0x001F5FFC File Offset: 0x001F41FC
		private bool TryPrepareUberImageEffect<T>(PostProcessingComponentRenderTexture<T> component, Material material) where T : PostProcessingModel
		{
			if (!component.active)
			{
				return false;
			}
			component.Prepare(material);
			return true;
		}

		// Token: 0x06002386 RID: 9094 RVA: 0x001F6010 File Offset: 0x001F4210
		private T AddComponent<T>(T component) where T : PostProcessingComponentBase
		{
			this.m_Components.Add(component);
			return component;
		}

		// Token: 0x04004B36 RID: 19254
		public PostProcessingProfile profile;

		// Token: 0x04004B37 RID: 19255
		public Func<Vector2, Matrix4x4> jitteredMatrixFunc;

		// Token: 0x04004B38 RID: 19256
		private Dictionary<Type, KeyValuePair<CameraEvent, CommandBuffer>> m_CommandBuffers;

		// Token: 0x04004B39 RID: 19257
		private List<PostProcessingComponentBase> m_Components;

		// Token: 0x04004B3A RID: 19258
		private Dictionary<PostProcessingComponentBase, bool> m_ComponentStates;

		// Token: 0x04004B3B RID: 19259
		private MaterialFactory m_MaterialFactory;

		// Token: 0x04004B3C RID: 19260
		private RenderTextureFactory m_RenderTextureFactory;

		// Token: 0x04004B3D RID: 19261
		private PostProcessingContext m_Context;

		// Token: 0x04004B3E RID: 19262
		private Camera m_Camera;

		// Token: 0x04004B3F RID: 19263
		private PostProcessingProfile m_PreviousProfile;

		// Token: 0x04004B40 RID: 19264
		private bool m_RenderingInSceneView;

		// Token: 0x04004B41 RID: 19265
		private BuiltinDebugViewsComponent m_DebugViews;

		// Token: 0x04004B42 RID: 19266
		private AmbientOcclusionComponent m_AmbientOcclusion;

		// Token: 0x04004B43 RID: 19267
		private ScreenSpaceReflectionComponent m_ScreenSpaceReflection;

		// Token: 0x04004B44 RID: 19268
		private FogComponent m_FogComponent;

		// Token: 0x04004B45 RID: 19269
		private MotionBlurComponent m_MotionBlur;

		// Token: 0x04004B46 RID: 19270
		private TaaComponent m_Taa;

		// Token: 0x04004B47 RID: 19271
		private EyeAdaptationComponent m_EyeAdaptation;

		// Token: 0x04004B48 RID: 19272
		private DepthOfFieldComponent m_DepthOfField;

		// Token: 0x04004B49 RID: 19273
		private BloomComponent m_Bloom;

		// Token: 0x04004B4A RID: 19274
		private ChromaticAberrationComponent m_ChromaticAberration;

		// Token: 0x04004B4B RID: 19275
		private ColorGradingComponent m_ColorGrading;

		// Token: 0x04004B4C RID: 19276
		private UserLutComponent m_UserLut;

		// Token: 0x04004B4D RID: 19277
		private GrainComponent m_Grain;

		// Token: 0x04004B4E RID: 19278
		private VignetteComponent m_Vignette;

		// Token: 0x04004B4F RID: 19279
		private DitheringComponent m_Dithering;

		// Token: 0x04004B50 RID: 19280
		private FxaaComponent m_Fxaa;

		// Token: 0x04004B51 RID: 19281
		private List<PostProcessingComponentBase> m_ComponentsToEnable = new List<PostProcessingComponentBase>();

		// Token: 0x04004B52 RID: 19282
		private List<PostProcessingComponentBase> m_ComponentsToDisable = new List<PostProcessingComponentBase>();
	}
}
