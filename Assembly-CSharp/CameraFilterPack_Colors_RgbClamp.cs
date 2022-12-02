using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/RgbClamp")]
public class CameraFilterPack_Colors_RgbClamp : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	private Material SCMaterial;

	[Range(0f, 1f)]
	public float Red_Start;

	[Range(0f, 1f)]
	public float Red_End = 1f;

	[Range(0f, 1f)]
	public float Green_Start;

	[Range(0f, 1f)]
	public float Green_End = 1f;

	[Range(0f, 1f)]
	public float Blue_Start;

	[Range(0f, 1f)]
	public float Blue_End = 1f;

	[Range(0f, 1f)]
	public float RGB_Start;

	[Range(0f, 1f)]
	public float RGB_End = 1f;

	private Material material
	{
		get
		{
			if (SCMaterial == null)
			{
				SCMaterial = new Material(SCShader);
				SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return SCMaterial;
		}
	}

	private void Start()
	{
		SCShader = Shader.Find("CameraFilterPack/Colors_RgbClamp");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
		}
	}

	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (SCShader != null)
		{
			TimeX += Time.deltaTime;
			if (TimeX > 100f)
			{
				TimeX = 0f;
			}
			material.SetFloat("_TimeX", TimeX);
			material.SetFloat("_Value", Red_Start);
			material.SetFloat("_Value2", Red_End);
			material.SetFloat("_Value3", Green_Start);
			material.SetFloat("_Value4", Green_End);
			material.SetFloat("_Value5", Blue_Start);
			material.SetFloat("_Value6", Blue_End);
			material.SetFloat("_Value7", RGB_Start);
			material.SetFloat("_Value8", RGB_End);
			material.SetVector("_ScreenResolution", new Vector4(sourceTexture.width, sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);
		}
	}

	private void Update()
	{
	}

	private void OnDisable()
	{
		if ((bool)SCMaterial)
		{
			Object.DestroyImmediate(SCMaterial);
		}
	}
}
