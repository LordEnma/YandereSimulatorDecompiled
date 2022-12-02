using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Super Computer")]
public class CameraFilterPack_AAA_SuperComputer : MonoBehaviour
{
	public Shader SCShader;

	[Range(0f, 1f)]
	public float _AlphaHexa = 1f;

	private float TimeX = 1f;

	private Material SCMaterial;

	[Range(-20f, 20f)]
	public float ShapeFormula = 10f;

	[Range(0f, 6f)]
	public float Shape = 1f;

	[Range(-4f, 4f)]
	public float _BorderSize = 1f;

	public Color _BorderColor = new Color(0f, 0.2f, 1f, 1f);

	public float _SpotSize = 2.5f;

	public Vector2 center = new Vector2(0f, 0f);

	public float Radius = 0.77f;

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
		SCShader = Shader.Find("CameraFilterPack/AAA_Super_Computer");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
		}
	}

	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (SCShader != null)
		{
			TimeX += Time.deltaTime / 4f;
			if (TimeX > 100f)
			{
				TimeX = 0f;
			}
			material.SetFloat("_TimeX", TimeX);
			material.SetFloat("_Value", ShapeFormula);
			material.SetFloat("_Value2", Shape);
			material.SetFloat("_PositionX", center.x);
			material.SetFloat("_PositionY", center.y);
			material.SetFloat("_Radius", Radius);
			material.SetFloat("_BorderSize", _BorderSize);
			material.SetColor("_BorderColor", _BorderColor);
			material.SetFloat("_AlphaHexa", _AlphaHexa);
			material.SetFloat("_SpotSize", _SpotSize);
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
