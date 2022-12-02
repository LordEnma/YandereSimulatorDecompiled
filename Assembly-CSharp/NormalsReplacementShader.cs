using UnityEngine;

public class NormalsReplacementShader : MonoBehaviour
{
	[SerializeField]
	private Shader normalsShader;

	private RenderTexture renderTexture;

	private Camera camera;

	private void Start()
	{
		Camera component = GetComponent<Camera>();
		renderTexture = new RenderTexture(component.pixelWidth, component.pixelHeight, 24);
		Shader.SetGlobalTexture("_CameraNormalsTexture", renderTexture);
		GameObject gameObject = new GameObject("Normals camera");
		camera = gameObject.AddComponent<Camera>();
		camera.CopyFrom(component);
		camera.transform.SetParent(base.transform);
		camera.targetTexture = renderTexture;
		camera.SetReplacementShader(normalsShader, "RenderType");
		camera.depth = component.depth - 1f;
	}
}
