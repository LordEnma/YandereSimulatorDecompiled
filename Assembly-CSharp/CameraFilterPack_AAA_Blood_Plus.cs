using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood_Plus")]
public class CameraFilterPack_AAA_Blood_Plus : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	[Range(0f, 1f)]
	public float Blood_1 = 1f;

	[Range(0f, 1f)]
	public float Blood_2;

	[Range(0f, 1f)]
	public float Blood_3;

	[Range(0f, 1f)]
	public float Blood_4;

	[Range(0f, 1f)]
	public float Blood_5;

	[Range(0f, 1f)]
	public float Blood_6;

	[Range(0f, 1f)]
	public float Blood_7;

	[Range(0f, 1f)]
	public float Blood_8;

	[Range(0f, 1f)]
	public float Blood_9;

	[Range(0f, 1f)]
	public float Blood_10;

	[Range(0f, 1f)]
	public float Blood_11;

	[Range(0f, 1f)]
	public float Blood_12;

	[Range(0f, 1f)]
	public float LightReflect = 0.5f;

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
		Texture2 = Resources.Load("CameraFilterPack_AAA_Blood2") as Texture2D;
		SCShader = Shader.Find("CameraFilterPack/AAA_Blood_Plus");
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
			material.SetFloat("_Value", LightReflect);
			material.SetFloat("_Value2", Mathf.Clamp(Blood_1, 0f, 1f));
			material.SetFloat("_Value3", Mathf.Clamp(Blood_2, 0f, 1f));
			material.SetFloat("_Value4", Mathf.Clamp(Blood_3, 0f, 1f));
			material.SetFloat("_Value5", Mathf.Clamp(Blood_4, 0f, 1f));
			material.SetFloat("_Value6", Mathf.Clamp(Blood_5, 0f, 1f));
			material.SetFloat("_Value7", Mathf.Clamp(Blood_6, 0f, 1f));
			material.SetFloat("_Value8", Mathf.Clamp(Blood_7, 0f, 1f));
			material.SetFloat("_Value9", Mathf.Clamp(Blood_8, 0f, 1f));
			material.SetFloat("_Value10", Mathf.Clamp(Blood_9, 0f, 1f));
			material.SetFloat("_Value11", Mathf.Clamp(Blood_10, 0f, 1f));
			material.SetFloat("_Value12", Mathf.Clamp(Blood_11, 0f, 1f));
			material.SetFloat("_Value13", Mathf.Clamp(Blood_12, 0f, 1f));
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
