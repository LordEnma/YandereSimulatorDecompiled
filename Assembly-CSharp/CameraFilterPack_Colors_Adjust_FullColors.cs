using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/FullColors")]
public class CameraFilterPack_Colors_Adjust_FullColors : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	private Material SCMaterial;

	[Range(-200f, 200f)]
	public float Red_R = 100f;

	[Range(-200f, 200f)]
	public float Red_G;

	[Range(-200f, 200f)]
	public float Red_B;

	[Range(-200f, 200f)]
	public float Red_Constant;

	[Range(-200f, 200f)]
	public float Green_R;

	[Range(-200f, 200f)]
	public float Green_G = 100f;

	[Range(-200f, 200f)]
	public float Green_B;

	[Range(-200f, 200f)]
	public float Green_Constant;

	[Range(-200f, 200f)]
	public float Blue_R;

	[Range(-200f, 200f)]
	public float Blue_G;

	[Range(-200f, 200f)]
	public float Blue_B = 100f;

	[Range(-200f, 200f)]
	public float Blue_Constant;

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
		SCShader = Shader.Find("CameraFilterPack/Colors_Adjust_FullColors");
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
			material.SetFloat("_Red_R", Red_R / 100f);
			material.SetFloat("_Red_G", Red_G / 100f);
			material.SetFloat("_Red_B", Red_B / 100f);
			material.SetFloat("_Green_R", Green_R / 100f);
			material.SetFloat("_Green_G", Green_G / 100f);
			material.SetFloat("_Green_B", Green_B / 100f);
			material.SetFloat("_Blue_R", Blue_R / 100f);
			material.SetFloat("_Blue_G", Blue_G / 100f);
			material.SetFloat("_Blue_B", Blue_B / 100f);
			material.SetFloat("_Red_C", Red_Constant / 100f);
			material.SetFloat("_Green_C", Green_Constant / 100f);
			material.SetFloat("_Blue_C", Blue_Constant / 100f);
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
		_ = Application.isPlaying;
	}

	private void OnDisable()
	{
		if ((bool)SCMaterial)
		{
			Object.DestroyImmediate(SCMaterial);
		}
	}
}
