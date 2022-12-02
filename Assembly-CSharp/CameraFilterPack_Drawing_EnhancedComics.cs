using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/EnhancedComics")]
public class CameraFilterPack_Drawing_EnhancedComics : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	private Material SCMaterial;

	[Range(0f, 1f)]
	public float DotSize = 0.15f;

	[Range(0f, 1f)]
	public float _ColorR = 0.9f;

	[Range(0f, 1f)]
	public float _ColorG = 0.4f;

	[Range(0f, 1f)]
	public float _ColorB = 0.4f;

	[Range(0f, 1f)]
	public float _Blood = 0.5f;

	[Range(0f, 1f)]
	public float _SmoothStart = 0.02f;

	[Range(0f, 1f)]
	public float _SmoothEnd = 0.1f;

	public Color ColorRGB = new Color(1f, 0f, 0f);

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
		SCShader = Shader.Find("CameraFilterPack/Drawing_EnhancedComics");
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
			material.SetFloat("_DotSize", DotSize);
			material.SetFloat("_ColorR", _ColorR);
			material.SetFloat("_ColorG", _ColorG);
			material.SetFloat("_ColorB", _ColorB);
			material.SetFloat("_Blood", _Blood);
			material.SetColor("_ColorRGB", ColorRGB);
			material.SetFloat("_SmoothStart", _SmoothStart);
			material.SetFloat("_SmoothEnd", _SmoothEnd);
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
