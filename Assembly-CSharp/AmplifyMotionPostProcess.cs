using UnityEngine;

[AddComponentMenu("")]
[RequireComponent(typeof(Camera))]
public sealed class AmplifyMotionPostProcess : MonoBehaviour
{
	private AmplifyMotionEffectBase m_instance;

	public AmplifyMotionEffectBase Instance
	{
		get
		{
			return m_instance;
		}
		set
		{
			m_instance = value;
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (m_instance != null)
		{
			m_instance.PostProcess(source, destination);
		}
	}
}
