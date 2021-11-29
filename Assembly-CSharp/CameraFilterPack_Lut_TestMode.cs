using System;
using UnityEngine;

// Token: 0x020001E2 RID: 482
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/TestMode")]
public class CameraFilterPack_Lut_TestMode : MonoBehaviour
{
	// Token: 0x170002E7 RID: 743
	// (get) Token: 0x06001026 RID: 4134 RVA: 0x00081C1D File Offset: 0x0007FE1D
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

	// Token: 0x06001027 RID: 4135 RVA: 0x00081C51 File Offset: 0x0007FE51
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Lut_TestMode");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001028 RID: 4136 RVA: 0x00081C74 File Offset: 0x0007FE74
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

	// Token: 0x06001029 RID: 4137 RVA: 0x00081D4C File Offset: 0x0007FF4C
	public bool ValidDimensions(Texture2D tex2d)
	{
		return tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width));
	}

	// Token: 0x0600102A RID: 4138 RVA: 0x00081D74 File Offset: 0x0007FF74
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

	// Token: 0x0600102B RID: 4139 RVA: 0x00081E78 File Offset: 0x00080078
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
			this.material.SetTexture("_LutTex", this.converted3DLut);
			this.material.SetFloat("_Blend", this.Blend);
			this.material.SetFloat("_Intensity", this.OriginalIntensity);
			this.material.SetFloat("_Extra", this.ResultIntensity);
			this.material.SetFloat("_Extra2", this.FinalIntensity);
			this.material.SetFloat("_Extra3", this.TestMode);
			Graphics.Blit(sourceTexture, destTexture, this.material, (QualitySettings.activeColorSpace == ColorSpace.Linear) ? 1 : 0);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600102C RID: 4140 RVA: 0x00081F92 File Offset: 0x00080192
	private void OnValidate()
	{
	}

	// Token: 0x0600102D RID: 4141 RVA: 0x00081F94 File Offset: 0x00080194
	private void Update()
	{
	}

	// Token: 0x0600102E RID: 4142 RVA: 0x00081F96 File Offset: 0x00080196
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001495 RID: 5269
	public Shader SCShader;

	// Token: 0x04001496 RID: 5270
	private float TimeX = 1f;

	// Token: 0x04001497 RID: 5271
	private Material SCMaterial;

	// Token: 0x04001498 RID: 5272
	public Texture2D LutTexture;

	// Token: 0x04001499 RID: 5273
	private Texture3D converted3DLut;

	// Token: 0x0400149A RID: 5274
	[Range(0f, 1f)]
	public float Blend = 1f;

	// Token: 0x0400149B RID: 5275
	[Range(0f, 3f)]
	public float OriginalIntensity = 1f;

	// Token: 0x0400149C RID: 5276
	[Range(-1f, 1f)]
	public float ResultIntensity;

	// Token: 0x0400149D RID: 5277
	[Range(-1f, 1f)]
	public float FinalIntensity;

	// Token: 0x0400149E RID: 5278
	[Range(0f, 1f)]
	public float TestMode = 0.5f;

	// Token: 0x0400149F RID: 5279
	private string MemoPath;
}
