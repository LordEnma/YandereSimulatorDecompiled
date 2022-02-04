using System;
using UnityEngine;

// Token: 0x020001DE RID: 478
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/Lut 2 Lut Extra")]
public class CameraFilterPack_Lut_2_Lut_Extra : MonoBehaviour
{
	// Token: 0x170002E2 RID: 738
	// (get) Token: 0x06000FF7 RID: 4087 RVA: 0x00080BCD File Offset: 0x0007EDCD
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

	// Token: 0x06000FF8 RID: 4088 RVA: 0x00080C01 File Offset: 0x0007EE01
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Lut_2_lut_Extra");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FF9 RID: 4089 RVA: 0x00080C24 File Offset: 0x0007EE24
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
		if (this.converted3DLut2)
		{
			UnityEngine.Object.DestroyImmediate(this.converted3DLut2);
		}
		this.converted3DLut2 = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
		this.converted3DLut2.SetPixels(array);
		this.converted3DLut2.Apply();
	}

	// Token: 0x06000FFA RID: 4090 RVA: 0x00080D3B File Offset: 0x0007EF3B
	public bool ValidDimensions(Texture2D tex2d)
	{
		return tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width));
	}

	// Token: 0x06000FFB RID: 4091 RVA: 0x00080D64 File Offset: 0x0007EF64
	public Texture3D Convert(Texture2D temp2DTex, Texture3D cv3D)
	{
		int num = 4096;
		if (temp2DTex)
		{
			num = temp2DTex.width * temp2DTex.height;
			num = temp2DTex.height;
			if (!this.ValidDimensions(temp2DTex))
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
		if (cv3D)
		{
			UnityEngine.Object.DestroyImmediate(cv3D);
		}
		cv3D = new Texture3D(num, num, num, TextureFormat.ARGB32, false);
		cv3D.SetPixels(array);
		cv3D.Apply();
		return cv3D;
	}

	// Token: 0x06000FFC RID: 4092 RVA: 0x00080E4C File Offset: 0x0007F04C
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
				if (!this.LutTexture)
				{
					this.SetIdentityLut();
				}
				if (this.LutTexture)
				{
					this.converted3DLut = this.Convert(this.LutTexture, this.converted3DLut);
				}
			}
			if (this.converted3DLut2 == null)
			{
				if (!this.LutTexture2)
				{
					this.SetIdentityLut();
				}
				if (this.LutTexture2)
				{
					this.converted3DLut2 = this.Convert(this.LutTexture2, this.converted3DLut2);
				}
			}
			if (this.LutTexture)
			{
				this.converted3DLut.wrapMode = TextureWrapMode.Clamp;
			}
			if (this.LutTexture2)
			{
				this.converted3DLut2.wrapMode = TextureWrapMode.Clamp;
			}
			this.material.SetFloat("_Fade", this.FadeLut1);
			this.material.SetFloat("_Fade2", this.FadeLut2);
			this.material.SetFloat("_Pos", this.Pos);
			this.material.SetFloat("_Smooth", this.Smooth);
			this.material.SetTexture("_LutTex", this.converted3DLut);
			this.material.SetTexture("_LutTex2", this.converted3DLut2);
			Graphics.Blit(sourceTexture, destTexture, this.material, (QualitySettings.activeColorSpace == ColorSpace.Linear) ? 1 : 0);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FFD RID: 4093 RVA: 0x00080FFE File Offset: 0x0007F1FE
	private void OnValidate()
	{
	}

	// Token: 0x06000FFE RID: 4094 RVA: 0x00081000 File Offset: 0x0007F200
	private void Update()
	{
	}

	// Token: 0x06000FFF RID: 4095 RVA: 0x00081002 File Offset: 0x0007F202
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400146A RID: 5226
	public Shader SCShader;

	// Token: 0x0400146B RID: 5227
	private float TimeX = 1f;

	// Token: 0x0400146C RID: 5228
	private Vector4 ScreenResolution;

	// Token: 0x0400146D RID: 5229
	private Material SCMaterial;

	// Token: 0x0400146E RID: 5230
	public Texture2D LutTexture;

	// Token: 0x0400146F RID: 5231
	public Texture2D LutTexture2;

	// Token: 0x04001470 RID: 5232
	private Texture3D converted3DLut;

	// Token: 0x04001471 RID: 5233
	private Texture3D converted3DLut2;

	// Token: 0x04001472 RID: 5234
	[Range(0f, 1f)]
	public float FadeLut1 = 1f;

	// Token: 0x04001473 RID: 5235
	[Range(0f, 1f)]
	public float FadeLut2 = 1f;

	// Token: 0x04001474 RID: 5236
	[Range(0f, 1f)]
	public float Pos;

	// Token: 0x04001475 RID: 5237
	[Range(0f, 1f)]
	public float Smooth = 1f;

	// Token: 0x04001476 RID: 5238
	private string MemoPath;

	// Token: 0x04001477 RID: 5239
	private string MemoPath2;
}
