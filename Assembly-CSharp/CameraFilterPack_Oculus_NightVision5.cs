using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 5")]
public class CameraFilterPack_Oculus_NightVision5 : MonoBehaviour
{
	private string ShaderName = "CameraFilterPack/Oculus_NightVision5";

	public Shader SCShader;

	[Range(0f, 1f)]
	public float FadeFX = 1f;

	[Range(0f, 1f)]
	public float _Size = 0.37f;

	[Range(0f, 1f)]
	public float _Smooth = 0.15f;

	[Range(0f, 1f)]
	public float _Dist = 0.285f;

	private float TimeX = 1f;

	private Material SCMaterial;

	private float[] Matrix9;

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

	private void ChangeFilters()
	{
		Matrix9 = new float[12]
		{
			200f, -200f, -200f, 195f, 4f, -160f, 200f, -200f, -200f, -200f,
			10f, -200f
		};
	}

	private void Start()
	{
		ChangeFilters();
		SCShader = Shader.Find(ShaderName);
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
			material.SetFloat("_Red_R", Matrix9[0] / 100f);
			material.SetFloat("_Red_G", Matrix9[1] / 100f);
			material.SetFloat("_Red_B", Matrix9[2] / 100f);
			material.SetFloat("_Green_R", Matrix9[3] / 100f);
			material.SetFloat("_Green_G", Matrix9[4] / 100f);
			material.SetFloat("_Green_B", Matrix9[5] / 100f);
			material.SetFloat("_Blue_R", Matrix9[6] / 100f);
			material.SetFloat("_Blue_G", Matrix9[7] / 100f);
			material.SetFloat("_Blue_B", Matrix9[8] / 100f);
			material.SetFloat("_Red_C", Matrix9[9] / 100f);
			material.SetFloat("_Green_C", Matrix9[10] / 100f);
			material.SetFloat("_Blue_C", Matrix9[11] / 100f);
			material.SetFloat("_FadeFX", FadeFX);
			material.SetFloat("_Size", _Size);
			material.SetFloat("_Dist", _Dist);
			material.SetFloat("_Smooth", _Smooth);
			material.SetVector("_ScreenResolution", new Vector4(sourceTexture.width, sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);
		}
	}

	private void OnValidate()
	{
		ChangeFilters();
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
