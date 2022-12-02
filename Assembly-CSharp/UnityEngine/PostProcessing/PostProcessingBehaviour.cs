using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	[ImageEffectAllowedInSceneView]
	[RequireComponent(typeof(Camera))]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	[AddComponentMenu("Effects/Post-Processing Behaviour", -1)]
	public class PostProcessingBehaviour : MonoBehaviour
	{
		public PostProcessingProfile profile;

		public Func<Vector2, Matrix4x4> jitteredMatrixFunc;

		private Dictionary<Type, KeyValuePair<CameraEvent, CommandBuffer>> m_CommandBuffers;

		private List<PostProcessingComponentBase> m_Components;

		private Dictionary<PostProcessingComponentBase, bool> m_ComponentStates;

		private MaterialFactory m_MaterialFactory;

		private RenderTextureFactory m_RenderTextureFactory;

		private PostProcessingContext m_Context;

		private Camera m_Camera;

		private PostProcessingProfile m_PreviousProfile;

		private bool m_RenderingInSceneView;

		private BuiltinDebugViewsComponent m_DebugViews;

		private AmbientOcclusionComponent m_AmbientOcclusion;

		private ScreenSpaceReflectionComponent m_ScreenSpaceReflection;

		private FogComponent m_FogComponent;

		private MotionBlurComponent m_MotionBlur;

		private TaaComponent m_Taa;

		private EyeAdaptationComponent m_EyeAdaptation;

		private DepthOfFieldComponent m_DepthOfField;

		private BloomComponent m_Bloom;

		private ChromaticAberrationComponent m_ChromaticAberration;

		private ColorGradingComponent m_ColorGrading;

		private UserLutComponent m_UserLut;

		private GrainComponent m_Grain;

		private VignetteComponent m_Vignette;

		private DitheringComponent m_Dithering;

		private FxaaComponent m_Fxaa;

		private List<PostProcessingComponentBase> m_ComponentsToEnable = new List<PostProcessingComponentBase>();

		private List<PostProcessingComponentBase> m_ComponentsToDisable = new List<PostProcessingComponentBase>();

		private void OnEnable()
		{
			m_CommandBuffers = new Dictionary<Type, KeyValuePair<CameraEvent, CommandBuffer>>();
			m_MaterialFactory = new MaterialFactory();
			m_RenderTextureFactory = new RenderTextureFactory();
			m_Context = new PostProcessingContext();
			m_Components = new List<PostProcessingComponentBase>();
			m_DebugViews = AddComponent(new BuiltinDebugViewsComponent());
			m_AmbientOcclusion = AddComponent(new AmbientOcclusionComponent());
			m_ScreenSpaceReflection = AddComponent(new ScreenSpaceReflectionComponent());
			m_FogComponent = AddComponent(new FogComponent());
			m_MotionBlur = AddComponent(new MotionBlurComponent());
			m_Taa = AddComponent(new TaaComponent());
			m_EyeAdaptation = AddComponent(new EyeAdaptationComponent());
			m_DepthOfField = AddComponent(new DepthOfFieldComponent());
			m_Bloom = AddComponent(new BloomComponent());
			m_ChromaticAberration = AddComponent(new ChromaticAberrationComponent());
			m_ColorGrading = AddComponent(new ColorGradingComponent());
			m_UserLut = AddComponent(new UserLutComponent());
			m_Grain = AddComponent(new GrainComponent());
			m_Vignette = AddComponent(new VignetteComponent());
			m_Dithering = AddComponent(new DitheringComponent());
			m_Fxaa = AddComponent(new FxaaComponent());
			m_ComponentStates = new Dictionary<PostProcessingComponentBase, bool>();
			foreach (PostProcessingComponentBase component in m_Components)
			{
				m_ComponentStates.Add(component, false);
			}
			base.useGUILayout = false;
		}

		private void OnPreCull()
		{
			m_Camera = GetComponent<Camera>();
			if (profile == null || m_Camera == null)
			{
				return;
			}
			PostProcessingContext postProcessingContext = m_Context.Reset();
			postProcessingContext.profile = profile;
			postProcessingContext.renderTextureFactory = m_RenderTextureFactory;
			postProcessingContext.materialFactory = m_MaterialFactory;
			postProcessingContext.camera = m_Camera;
			m_DebugViews.Init(postProcessingContext, profile.debugViews);
			m_AmbientOcclusion.Init(postProcessingContext, profile.ambientOcclusion);
			m_ScreenSpaceReflection.Init(postProcessingContext, profile.screenSpaceReflection);
			m_FogComponent.Init(postProcessingContext, profile.fog);
			m_MotionBlur.Init(postProcessingContext, profile.motionBlur);
			m_Taa.Init(postProcessingContext, profile.antialiasing);
			m_EyeAdaptation.Init(postProcessingContext, profile.eyeAdaptation);
			m_DepthOfField.Init(postProcessingContext, profile.depthOfField);
			m_Bloom.Init(postProcessingContext, profile.bloom);
			m_ChromaticAberration.Init(postProcessingContext, profile.chromaticAberration);
			m_ColorGrading.Init(postProcessingContext, profile.colorGrading);
			m_UserLut.Init(postProcessingContext, profile.userLut);
			m_Grain.Init(postProcessingContext, profile.grain);
			m_Vignette.Init(postProcessingContext, profile.vignette);
			m_Dithering.Init(postProcessingContext, profile.dithering);
			m_Fxaa.Init(postProcessingContext, profile.antialiasing);
			if (m_PreviousProfile != profile)
			{
				DisableComponents();
				m_PreviousProfile = profile;
			}
			CheckObservers();
			DepthTextureMode depthTextureMode = postProcessingContext.camera.depthTextureMode;
			foreach (PostProcessingComponentBase component in m_Components)
			{
				if (component.active)
				{
					depthTextureMode |= component.GetCameraFlags();
				}
			}
			postProcessingContext.camera.depthTextureMode = depthTextureMode;
			if (!m_RenderingInSceneView && m_Taa.active && !profile.debugViews.willInterrupt)
			{
				m_Taa.SetProjectionMatrix(jitteredMatrixFunc);
			}
		}

		private void OnPreRender()
		{
			if (!(profile == null))
			{
				TryExecuteCommandBuffer(m_DebugViews);
				TryExecuteCommandBuffer(m_AmbientOcclusion);
				TryExecuteCommandBuffer(m_ScreenSpaceReflection);
				TryExecuteCommandBuffer(m_FogComponent);
				if (!m_RenderingInSceneView)
				{
					TryExecuteCommandBuffer(m_MotionBlur);
				}
			}
		}

		private void OnPostRender()
		{
			if (!(profile == null) && !(m_Camera == null) && !m_RenderingInSceneView && m_Taa.active && !profile.debugViews.willInterrupt)
			{
				m_Context.camera.ResetProjectionMatrix();
			}
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			if (profile == null || m_Camera == null)
			{
				Graphics.Blit(source, destination);
				return;
			}
			bool flag = false;
			bool active = m_Fxaa.active;
			bool flag2 = m_Taa.active && !m_RenderingInSceneView;
			bool num = m_DepthOfField.active && !m_RenderingInSceneView;
			Material material = m_MaterialFactory.Get("Hidden/Post FX/Uber Shader");
			material.shaderKeywords = null;
			RenderTexture renderTexture = source;
			if (flag2)
			{
				RenderTexture renderTexture2 = m_RenderTextureFactory.Get(renderTexture);
				m_Taa.Render(renderTexture, renderTexture2);
				renderTexture = renderTexture2;
			}
			Texture texture = GraphicsUtils.whiteTexture;
			if (m_EyeAdaptation.active)
			{
				flag = true;
				texture = m_EyeAdaptation.Prepare(renderTexture, material);
			}
			material.SetTexture("_AutoExposure", texture);
			if (num)
			{
				flag = true;
				m_DepthOfField.Prepare(renderTexture, material, flag2, m_Taa.jitterVector, m_Taa.model.settings.taaSettings.motionBlending);
			}
			if (m_Bloom.active)
			{
				flag = true;
				m_Bloom.Prepare(renderTexture, material, texture);
			}
			flag |= TryPrepareUberImageEffect(m_ChromaticAberration, material);
			flag |= TryPrepareUberImageEffect(m_ColorGrading, material);
			flag |= TryPrepareUberImageEffect(m_Vignette, material);
			flag |= TryPrepareUberImageEffect(m_UserLut, material);
			Material material2 = (active ? m_MaterialFactory.Get("Hidden/Post FX/FXAA") : null);
			if (active)
			{
				material2.shaderKeywords = null;
				TryPrepareUberImageEffect(m_Grain, material2);
				TryPrepareUberImageEffect(m_Dithering, material2);
				if (flag)
				{
					RenderTexture renderTexture3 = m_RenderTextureFactory.Get(renderTexture);
					Graphics.Blit(renderTexture, renderTexture3, material, 0);
					renderTexture = renderTexture3;
				}
				m_Fxaa.Render(renderTexture, destination);
			}
			else
			{
				flag |= TryPrepareUberImageEffect(m_Grain, material);
				flag |= TryPrepareUberImageEffect(m_Dithering, material);
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
			m_RenderTextureFactory.ReleaseAll();
		}

		private void OnGUI()
		{
			if (Event.current.type == EventType.Repaint && !(profile == null) && !(m_Camera == null))
			{
				if (m_EyeAdaptation.active && profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation))
				{
					m_EyeAdaptation.OnGUI();
				}
				else if (m_ColorGrading.active && profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.LogLut))
				{
					m_ColorGrading.OnGUI();
				}
				else if (m_UserLut.active && profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.UserLut))
				{
					m_UserLut.OnGUI();
				}
			}
		}

		private void OnDisable()
		{
			foreach (KeyValuePair<CameraEvent, CommandBuffer> value in m_CommandBuffers.Values)
			{
				m_Camera.RemoveCommandBuffer(value.Key, value.Value);
				value.Value.Dispose();
			}
			m_CommandBuffers.Clear();
			if (profile != null)
			{
				DisableComponents();
			}
			m_Components.Clear();
			m_MaterialFactory.Dispose();
			m_RenderTextureFactory.Dispose();
			GraphicsUtils.Dispose();
		}

		public void ResetTemporalEffects()
		{
			m_Taa.ResetHistory();
			m_MotionBlur.ResetHistory();
			m_EyeAdaptation.ResetHistory();
		}

		private void CheckObservers()
		{
			foreach (KeyValuePair<PostProcessingComponentBase, bool> componentState in m_ComponentStates)
			{
				PostProcessingComponentBase key = componentState.Key;
				bool flag = key.GetModel().enabled;
				if (flag != componentState.Value)
				{
					if (flag)
					{
						m_ComponentsToEnable.Add(key);
					}
					else
					{
						m_ComponentsToDisable.Add(key);
					}
				}
			}
			for (int i = 0; i < m_ComponentsToDisable.Count; i++)
			{
				PostProcessingComponentBase postProcessingComponentBase = m_ComponentsToDisable[i];
				m_ComponentStates[postProcessingComponentBase] = false;
				postProcessingComponentBase.OnDisable();
			}
			for (int j = 0; j < m_ComponentsToEnable.Count; j++)
			{
				PostProcessingComponentBase postProcessingComponentBase2 = m_ComponentsToEnable[j];
				m_ComponentStates[postProcessingComponentBase2] = true;
				postProcessingComponentBase2.OnEnable();
			}
			m_ComponentsToDisable.Clear();
			m_ComponentsToEnable.Clear();
		}

		private void DisableComponents()
		{
			foreach (PostProcessingComponentBase component in m_Components)
			{
				PostProcessingModel model = component.GetModel();
				if (model != null && model.enabled)
				{
					component.OnDisable();
				}
			}
		}

		private CommandBuffer AddCommandBuffer<T>(CameraEvent evt, string name) where T : PostProcessingModel
		{
			CommandBuffer value = new CommandBuffer
			{
				name = name
			};
			KeyValuePair<CameraEvent, CommandBuffer> value2 = new KeyValuePair<CameraEvent, CommandBuffer>(evt, value);
			m_CommandBuffers.Add(typeof(T), value2);
			m_Camera.AddCommandBuffer(evt, value2.Value);
			return value2.Value;
		}

		private void RemoveCommandBuffer<T>() where T : PostProcessingModel
		{
			Type typeFromHandle = typeof(T);
			KeyValuePair<CameraEvent, CommandBuffer> value;
			if (m_CommandBuffers.TryGetValue(typeFromHandle, out value))
			{
				m_Camera.RemoveCommandBuffer(value.Key, value.Value);
				m_CommandBuffers.Remove(typeFromHandle);
				value.Value.Dispose();
			}
		}

		private CommandBuffer GetCommandBuffer<T>(CameraEvent evt, string name) where T : PostProcessingModel
		{
			KeyValuePair<CameraEvent, CommandBuffer> value;
			if (!m_CommandBuffers.TryGetValue(typeof(T), out value))
			{
				return AddCommandBuffer<T>(evt, name);
			}
			if (value.Key != evt)
			{
				RemoveCommandBuffer<T>();
				return AddCommandBuffer<T>(evt, name);
			}
			return value.Value;
		}

		private void TryExecuteCommandBuffer<T>(PostProcessingComponentCommandBuffer<T> component) where T : PostProcessingModel
		{
			if (component.active)
			{
				CommandBuffer commandBuffer = GetCommandBuffer<T>(component.GetCameraEvent(), component.GetName());
				commandBuffer.Clear();
				component.PopulateCommandBuffer(commandBuffer);
			}
			else
			{
				RemoveCommandBuffer<T>();
			}
		}

		private bool TryPrepareUberImageEffect<T>(PostProcessingComponentRenderTexture<T> component, Material material) where T : PostProcessingModel
		{
			if (!component.active)
			{
				return false;
			}
			component.Prepare(material);
			return true;
		}

		private T AddComponent<T>(T component) where T : PostProcessingComponentBase
		{
			m_Components.Add(component);
			return component;
		}
	}
}
