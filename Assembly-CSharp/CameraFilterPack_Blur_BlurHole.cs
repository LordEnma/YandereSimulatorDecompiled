using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Blur Hole")]
public class CameraFilterPack_Blur_BlurHole : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	[Range(1f, 16f)]
	public float Size = 10f;

	[Range(-1f, 1f)]
	public float _Radius = 0.25f;

	[Range(-4f, 4f)]
	public float _SpotSize = 1f;

	[Range(0f, 1f)]
	public float _CenterX = 0.5f;

	[Range(0f, 1f)]
	public float _CenterY = 0.5f;

	[Range(0f, 1f)]
	public float _AlphaBlur = 1f;

	[Range(0f, 1f)]
	public float _AlphaBlurInside;

	private Material SCMaterial;

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
		SCShader = Shader.Find("CameraFilterPack/BlurHole");
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
			material.SetFloat("_Distortion", Size);
			material.SetFloat("_Radius", _Radius);
			material.SetFloat("_SpotSize", _SpotSize);
			material.SetFloat("_CenterX", _CenterX);
			material.SetFloat("_CenterY", _CenterY);
			material.SetFloat("_Alpha", _AlphaBlur);
			material.SetFloat("_Alpha2", _AlphaBlurInside);
			material.SetVector("_ScreenResolution", new Vector2(Screen.width, Screen.height));
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
