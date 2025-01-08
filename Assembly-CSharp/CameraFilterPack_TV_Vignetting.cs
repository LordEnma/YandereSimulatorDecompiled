using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Vignetting")]
public class CameraFilterPack_TV_Vignetting : MonoBehaviour
{
	public Shader SCShader;

	private Material SCMaterial;

	private Texture2D Vignette;

	[Range(0f, 1f)]
	public float Vignetting = 1f;

	[Range(0f, 1f)]
	public float VignettingFull;

	[Range(0f, 1f)]
	public float VignettingDirt;

	public Color VignettingColor = new Color(0f, 0f, 0f, 1f);

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
		SCShader = Shader.Find("CameraFilterPack/TV_Vignetting");
		Vignette = Resources.Load("CameraFilterPack_TV_Vignetting2") as Texture2D;
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
		}
	}

	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (SCShader != null)
		{
			material.SetTexture("Vignette", Vignette);
			material.SetFloat("_Vignetting", Vignetting);
			material.SetFloat("_Vignetting2", VignettingFull);
			material.SetColor("_VignettingColor", VignettingColor);
			material.SetFloat("_VignettingDirt", VignettingDirt);
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
