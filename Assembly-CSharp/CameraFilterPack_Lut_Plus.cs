using System;
using UnityEngine;

// Token: 0x020001E1 RID: 481
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/Plus")]
public class CameraFilterPack_Lut_Plus : MonoBehaviour
{
	// Token: 0x170002E5 RID: 741
	// (get) Token: 0x06001016 RID: 4118 RVA: 0x00081B33 File Offset: 0x0007FD33
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

	// Token: 0x06001017 RID: 4119 RVA: 0x00081B67 File Offset: 0x0007FD67
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Lut_Plus");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001018 RID: 4120 RVA: 0x00081B88 File Offset: 0x0007FD88
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

	// Token: 0x06001019 RID: 4121 RVA: 0x00081C60 File Offset: 0x0007FE60
	public bool ValidDimensions(Texture2D tex2d)
	{
		return tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width));
	}

	// Token: 0x0600101A RID: 4122 RVA: 0x00081C88 File Offset: 0x0007FE88
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

	// Token: 0x0600101B RID: 4123 RVA: 0x00081D8C File Offset: 0x0007FF8C
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
			Graphics.Blit(sourceTexture, destTexture, this.material, (QualitySettings.activeColorSpace == ColorSpace.Linear) ? 1 : 0);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600101C RID: 4124 RVA: 0x00081E4E File Offset: 0x0008004E
	private void OnValidate()
	{
	}

	// Token: 0x0600101D RID: 4125 RVA: 0x00081E50 File Offset: 0x00080050
	private void Update()
	{
	}

	// Token: 0x0600101E RID: 4126 RVA: 0x00081E52 File Offset: 0x00080052
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001498 RID: 5272
	public Shader SCShader;

	// Token: 0x04001499 RID: 5273
	private float TimeX = 1f;

	// Token: 0x0400149A RID: 5274
	private Vector4 ScreenResolution;

	// Token: 0x0400149B RID: 5275
	private Material SCMaterial;

	// Token: 0x0400149C RID: 5276
	public Texture2D LutTexture;

	// Token: 0x0400149D RID: 5277
	private Texture3D converted3DLut;

	// Token: 0x0400149E RID: 5278
	[Range(0f, 1f)]
	public float Blend = 1f;

	// Token: 0x0400149F RID: 5279
	private string MemoPath;
}
