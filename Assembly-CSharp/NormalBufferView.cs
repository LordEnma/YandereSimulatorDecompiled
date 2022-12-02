using UnityEngine;

public class NormalBufferView : MonoBehaviour
{
	[SerializeField]
	private Camera camera;

	[SerializeField]
	private Shader normalShader;

	public void ApplyNormalView()
	{
		camera.SetReplacementShader(normalShader, "RenderType");
	}

	public void DisableNormalView()
	{
		camera.ResetReplacementShader();
	}
}
