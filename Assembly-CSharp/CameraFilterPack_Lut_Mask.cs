using System;
using UnityEngine;

// Token: 0x020001DF RID: 479
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/Mask")]
public class CameraFilterPack_Lut_Mask : MonoBehaviour
{
	// Token: 0x170002E3 RID: 739
	// (get) Token: 0x06001002 RID: 4098 RVA: 0x000813FC File Offset: 0x0007F5FC
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

	// Token: 0x06001003 RID: 4099 RVA: 0x00081430 File Offset: 0x0007F630
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Lut_Mask");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001004 RID: 4100 RVA: 0x00081454 File Offset: 0x0007F654
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

	// Token: 0x06001005 RID: 4101 RVA: 0x0008152C File Offset: 0x0007F72C
	public bool ValidDimensions(Texture2D tex2d)
	{
		return tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width));
	}

	// Token: 0x06001006 RID: 4102 RVA: 0x00081554 File Offset: 0x0007F754
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

	// Token: 0x06001007 RID: 4103 RVA: 0x00081658 File Offset: 0x0007F858
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

	// Token: 0x06001008 RID: 4104 RVA: 0x00081746 File Offset: 0x0007F946
	private void OnValidate()
	{
	}

	// Token: 0x06001009 RID: 4105 RVA: 0x00081748 File Offset: 0x0007F948
	private void Update()
	{
	}

	// Token: 0x0600100A RID: 4106 RVA: 0x0008174A File Offset: 0x0007F94A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001484 RID: 5252
	public Shader SCShader;

	// Token: 0x04001485 RID: 5253
	private float TimeX = 1f;

	// Token: 0x04001486 RID: 5254
	private Vector4 ScreenResolution;

	// Token: 0x04001487 RID: 5255
	private Material SCMaterial;

	// Token: 0x04001488 RID: 5256
	public Texture2D LutTexture;

	// Token: 0x04001489 RID: 5257
	private Texture3D converted3DLut;

	// Token: 0x0400148A RID: 5258
	[Range(0f, 1f)]
	public float Blend = 1f;

	// Token: 0x0400148B RID: 5259
	public Texture2D Mask;

	// Token: 0x0400148C RID: 5260
	[Range(0f, 1f)]
	public float Inverse = 1f;

	// Token: 0x0400148D RID: 5261
	private string MemoPath;
}
