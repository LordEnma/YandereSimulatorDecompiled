using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Drunk")]
public class CameraFilterPack_FX_Drunk : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	private Material SCMaterial;

	[HideInInspector]
	[Range(0f, 20f)]
	public float Value = 6f;

	[Range(0f, 10f)]
	public float Speed = 1f;

	[Range(0f, 1f)]
	public float Wavy = 1f;

	[Range(0f, 1f)]
	public float Distortion;

	[Range(0f, 1f)]
	public float DistortionWave;

	[Range(0f, 1f)]
	public float Fade = 1f;

	[Range(-2f, 2f)]
	public float ColoredSaturate = 1f;

	[Range(-1f, 2f)]
	public float ColoredChange;

	[Range(-1f, 1f)]
	public float ChangeRed;

	[Range(-1f, 1f)]
	public float ChangeGreen;

	[Range(-1f, 1f)]
	public float ChangeBlue;

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
		SCShader = Shader.Find("CameraFilterPack/FX_Drunk");
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
			material.SetFloat("_Value", Value);
			material.SetFloat("_Speed", Speed);
			material.SetFloat("_Distortion", Distortion);
			material.SetFloat("_DistortionWave", DistortionWave);
			material.SetFloat("_Wavy", Wavy);
			material.SetFloat("_Fade", Fade);
			material.SetFloat("_ColoredChange", ColoredChange);
			material.SetFloat("_ChangeRed", ChangeRed);
			material.SetFloat("_ChangeGreen", ChangeGreen);
			material.SetFloat("_ChangeBlue", ChangeBlue);
			material.SetFloat("_Colored", ColoredSaturate);
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
