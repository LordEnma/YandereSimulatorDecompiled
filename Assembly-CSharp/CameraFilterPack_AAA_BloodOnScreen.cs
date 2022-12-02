using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood On Screen")]
public class CameraFilterPack_AAA_BloodOnScreen : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	[Range(0.02f, 1.6f)]
	public float Blood_On_Screen = 1f;

	public Color Blood_Color = Color.red;

	[Range(0f, 2f)]
	public float Blood_Intensify = 0.7f;

	[Range(0f, 2f)]
	public float Blood_Darkness = 0.5f;

	[Range(0f, 1f)]
	public float Blood_Distortion_Speed = 0.25f;

	[Range(0f, 1f)]
	public float Blood_Fade = 1f;

	private Material SCMaterial;

	private Texture2D Texture2;

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
		Texture2 = Resources.Load("CameraFilterPack_AAA_BloodOnScreen1") as Texture2D;
		SCShader = Shader.Find("CameraFilterPack/AAA_BloodOnScreen");
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
			material.SetFloat("_Value", Mathf.Clamp(Blood_On_Screen, 0.02f, 1.6f));
			material.SetFloat("_Value2", Mathf.Clamp(Blood_Intensify, 0f, 2f));
			material.SetFloat("_Value3", Mathf.Clamp(Blood_Darkness, 0f, 2f));
			material.SetFloat("_Value4", Mathf.Clamp(Blood_Fade, 0f, 1f));
			material.SetFloat("_Value5", Mathf.Clamp(Blood_Distortion_Speed, 0f, 2f));
			material.SetColor("_Color2", Blood_Color);
			material.SetTexture("_MainTex2", Texture2);
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
