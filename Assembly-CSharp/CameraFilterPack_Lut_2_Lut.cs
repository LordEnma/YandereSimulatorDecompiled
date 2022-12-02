using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/Lut 2 Lut")]
public class CameraFilterPack_Lut_2_Lut : MonoBehaviour
{
	public Shader SCShader;

	private float TimeX = 1f;

	private Vector4 ScreenResolution;

	private Material SCMaterial;

	public Texture2D LutTexture;

	public Texture2D LutTexture2;

	private Texture3D converted3DLut;

	private Texture3D converted3DLut2;

	[Range(0f, 1f)]
	public float Blend = 1f;

	[Range(0f, 1f)]
	public float Fade = 1f;

	private string MemoPath;

	private string MemoPath2;

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
		SCShader = Shader.Find("CameraFilterPack/Lut_2_lut");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
		}
	}

	public void SetIdentityLut()
	{
		int num = 16;
		Color[] array = new Color[num * num * num];
		float num2 = 1f / (1f * (float)num - 1f);
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				for (int k = 0; k < num; k++)
				{
					array[i + j * num + k * num * num] = new Color((float)i * 1f * num2, (float)j * 1f * num2, (float)k * 1f * num2, 1f);
				}
			}
		}
		if ((bool)converted3DLut)
		{
			Object.DestroyImmediate(converted3DLut);
		}
		converted3DLut = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
		converted3DLut.SetPixels(array);
		converted3DLut.Apply();
		if ((bool)converted3DLut2)
		{
			Object.DestroyImmediate(converted3DLut2);
		}
		converted3DLut2 = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
		converted3DLut2.SetPixels(array);
		converted3DLut2.Apply();
	}

	public bool ValidDimensions(Texture2D tex2d)
	{
		if (!tex2d)
		{
			return false;
		}
		if (tex2d.height != Mathf.FloorToInt(Mathf.Sqrt(tex2d.width)))
		{
			return false;
		}
		return true;
	}

	public Texture3D Convert(Texture2D temp2DTex, Texture3D cv3D)
	{
		int num = 4096;
		if ((bool)temp2DTex)
		{
			num = temp2DTex.width * temp2DTex.height;
			num = temp2DTex.height;
			if (!ValidDimensions(temp2DTex))
			{
				Debug.LogWarning("The given 2D texture " + temp2DTex.name + " cannot be used as a 3D LUT.");
				return cv3D;
			}
		}
		Color[] pixels = temp2DTex.GetPixels();
		Color[] array = new Color[pixels.Length];
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num; j++)
			{
				for (int k = 0; k < num; k++)
				{
					int num2 = num - j - 1;
					array[i + j * num + k * num * num] = pixels[k * num + i + num2 * num * num];
				}
			}
		}
		if ((bool)cv3D)
		{
			Object.DestroyImmediate(cv3D);
		}
		cv3D = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
		cv3D.SetPixels(array);
		cv3D.Apply();
		return cv3D;
	}

	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (SCShader != null || !SystemInfo.supports3DTextures)
		{
			TimeX += Time.deltaTime;
			if (TimeX > 100f)
			{
				TimeX = 0f;
			}
			if (converted3DLut == null)
			{
				if (!LutTexture)
				{
					SetIdentityLut();
				}
				if ((bool)LutTexture)
				{
					converted3DLut = Convert(LutTexture, converted3DLut);
				}
			}
			if (converted3DLut2 == null)
			{
				if (!LutTexture2)
				{
					SetIdentityLut();
				}
				if ((bool)LutTexture2)
				{
					converted3DLut2 = Convert(LutTexture2, converted3DLut2);
				}
			}
			if ((bool)LutTexture)
			{
				converted3DLut.wrapMode = TextureWrapMode.Clamp;
			}
			if ((bool)LutTexture2)
			{
				converted3DLut2.wrapMode = TextureWrapMode.Clamp;
			}
			material.SetFloat("_Blend", Blend);
			material.SetFloat("_Fade", Fade);
			material.SetTexture("_LutTex", converted3DLut);
			material.SetTexture("_LutTex2", converted3DLut2);
			Graphics.Blit(sourceTexture, destTexture, material, (QualitySettings.activeColorSpace == ColorSpace.Linear) ? 1 : 0);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);
		}
	}

	private void OnValidate()
	{
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
