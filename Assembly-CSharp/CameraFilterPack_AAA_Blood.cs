using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/AAA/Blood")]
public class CameraFilterPack_AAA_Blood : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	[Range(0f, 128f)]
	public float Blood1;

	[Range(0f, 128f)]
	public float Blood2;

	[Range(0f, 128f)]
	public float Blood3;

	[Range(0f, 128f)]
	public float Blood4 = 1f;

	[Range(0f, 0.004f)]
	public float LightReflect = 0.002f;

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
		Texture2 = Resources.Load("CameraFilterPack_AAA_Blood1") as Texture2D;
		SCShader = Shader.Find("CameraFilterPack/AAA_Blood");
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
			material.SetFloat("_Value2", Blood1);
			material.SetFloat("_Value3", Blood2);
			material.SetFloat("_Value4", Blood3);
			material.SetFloat("_Value5", Blood4);
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
