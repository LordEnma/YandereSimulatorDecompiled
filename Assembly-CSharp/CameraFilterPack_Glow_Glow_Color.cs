using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glow/Glow_Color")]
public class CameraFilterPack_Glow_Glow_Color : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	private Material SCMaterial;

	[Range(0f, 20f)]
	public float Amount = 4f;

	[Range(2f, 16f)]
	public int FastFilter = 4;

	[Range(0f, 1f)]
	public float Threshold = 0.5f;

	[Range(0f, 3f)]
	public float Intensity = 2.25f;

	[Range(-1f, 1f)]
	public float Precision = 0.56f;

	public Color GlowColor = new Color(0f, 0.7f, 1f, 1f);

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
		SCShader = Shader.Find("CameraFilterPack/Glow_Glow_Color");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
		}
	}

	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (SCShader != null)
		{
			int fastFilter = FastFilter;
			TimeX += Time.deltaTime;
			if (TimeX > 100f)
			{
				TimeX = 0f;
			}
			material.SetFloat("_TimeX", TimeX);
			material.SetFloat("_Amount", Amount);
			material.SetFloat("_Value1", Threshold);
			material.SetFloat("_Value2", Intensity);
			material.SetFloat("_Value3", Precision);
			material.SetColor("_GlowColor", GlowColor);
			material.SetVector("_ScreenResolution", new Vector2(Screen.width / fastFilter, Screen.height / fastFilter));
			int width = sourceTexture.width / fastFilter;
			int height = sourceTexture.height / fastFilter;
			if (FastFilter > 1)
			{
				RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
				RenderTexture temporary2 = RenderTexture.GetTemporary(width, height, 0);
				temporary.filterMode = FilterMode.Trilinear;
				Graphics.Blit(sourceTexture, temporary, material, 3);
				Graphics.Blit(temporary, temporary2, material, 2);
				Graphics.Blit(temporary2, temporary, material, 0);
				material.SetFloat("_Amount", Amount * 2f);
				Graphics.Blit(temporary, temporary2, material, 2);
				Graphics.Blit(temporary2, temporary, material, 0);
				material.SetTexture("_MainTex2", temporary);
				RenderTexture.ReleaseTemporary(temporary);
				RenderTexture.ReleaseTemporary(temporary2);
				Graphics.Blit(sourceTexture, destTexture, material, 1);
			}
			else
			{
				Graphics.Blit(sourceTexture, destTexture, material, 0);
			}
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
