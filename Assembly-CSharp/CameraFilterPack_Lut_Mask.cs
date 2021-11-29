using System;
using UnityEngine;

// Token: 0x020001DE RID: 478
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/Mask")]
public class CameraFilterPack_Lut_Mask : MonoBehaviour
{
	// Token: 0x170002E3 RID: 739
	// (get) Token: 0x06000FFE RID: 4094 RVA: 0x00080E58 File Offset: 0x0007F058
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x06000FFF RID: 4095 RVA: 0x00080E8C File Offset: 0x0007F08C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Lut_Mask");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001000 RID: 4096 RVA: 0x00080EB0 File Offset: 0x0007F0B0
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
		if (this.converted3DLut)
		{
			UnityEngine.Object.DestroyImmediate(this.converted3DLut);
		}
		this.converted3DLut = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
		this.converted3DLut.SetPixels(array);
		this.converted3DLut.Apply();
	}

	// Token: 0x06001001 RID: 4097 RVA: 0x00080F88 File Offset: 0x0007F188
	public bool ValidDimensions(Texture2D tex2d)
	{
		return tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width));
	}

	// Token: 0x06001002 RID: 4098 RVA: 0x00080FB0 File Offset: 0x0007F1B0
	public void Convert(Texture2D temp2DTex)
	{
		if (!temp2DTex)
		{
			this.SetIdentityLut();
			return;
		}
		int num = temp2DTex.width * temp2DTex.height;
		num = temp2DTex.height;
		if (!this.ValidDimensions(temp2DTex))
		{
			Debug.LogWarning("The given 2D texture " + temp2DTex.name + " cannot be used as a 3D LUT.");
			return;
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
		if (this.converted3DLut)
		{
			UnityEngine.Object.DestroyImmediate(this.converted3DLut);
		}
		this.converted3DLut = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
		this.converted3DLut.SetPixels(array);
		this.converted3DLut.Apply();
	}

	// Token: 0x06001003 RID: 4099 RVA: 0x000810B4 File Offset: 0x0007F2B4
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null || !SystemInfo.supports3DTextures)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.converted3DLut == null)
			{
				this.Convert(this.LutTexture);
			}
			this.converted3DLut.wrapMode = TextureWrapMode.Clamp;
			this.material.SetFloat("_Blend", this.Blend);
			this.material.SetTexture("_LutTex", this.converted3DLut);
			this.material.SetTexture("_MaskTex", this.Mask);
			this.material.SetFloat("_Inverse", this.Inverse);
			Graphics.Blit(sourceTexture, destTexture, this.material, (QualitySettings.activeColorSpace == ColorSpace.Linear) ? 1 : 0);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001004 RID: 4100 RVA: 0x000811A2 File Offset: 0x0007F3A2
	private void OnValidate()
	{
	}

	// Token: 0x06001005 RID: 4101 RVA: 0x000811A4 File Offset: 0x0007F3A4
	private void Update()
	{
	}

	// Token: 0x06001006 RID: 4102 RVA: 0x000811A6 File Offset: 0x0007F3A6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001473 RID: 5235
	public Shader SCShader;

	// Token: 0x04001474 RID: 5236
	private float TimeX = 1f;

	// Token: 0x04001475 RID: 5237
	private Vector4 ScreenResolution;

	// Token: 0x04001476 RID: 5238
	private Material SCMaterial;

	// Token: 0x04001477 RID: 5239
	public Texture2D LutTexture;

	// Token: 0x04001478 RID: 5240
	private Texture3D converted3DLut;

	// Token: 0x04001479 RID: 5241
	[Range(0f, 1f)]
	public float Blend = 1f;

	// Token: 0x0400147A RID: 5242
	public Texture2D Mask;

	// Token: 0x0400147B RID: 5243
	[Range(0f, 1f)]
	public float Inverse = 1f;

	// Token: 0x0400147C RID: 5244
	private string MemoPath;
}
