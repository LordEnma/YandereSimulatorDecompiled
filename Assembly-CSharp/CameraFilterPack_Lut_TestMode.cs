using System;
using UnityEngine;

// Token: 0x020001E3 RID: 483
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/TestMode")]
public class CameraFilterPack_Lut_TestMode : MonoBehaviour
{
	// Token: 0x170002E7 RID: 743
	// (get) Token: 0x0600102A RID: 4138 RVA: 0x00081F65 File Offset: 0x00080165
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

	// Token: 0x0600102B RID: 4139 RVA: 0x00081F99 File Offset: 0x00080199
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Lut_TestMode");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600102C RID: 4140 RVA: 0x00081FBC File Offset: 0x000801BC
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

	// Token: 0x0600102D RID: 4141 RVA: 0x00082094 File Offset: 0x00080294
	public bool ValidDimensions(Texture2D tex2d)
	{
		return tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width));
	}

	// Token: 0x0600102E RID: 4142 RVA: 0x000820BC File Offset: 0x000802BC
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

	// Token: 0x0600102F RID: 4143 RVA: 0x000821C0 File Offset: 0x000803C0
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

	// Token: 0x06001030 RID: 4144 RVA: 0x000822DA File Offset: 0x000804DA
	private void OnValidate()
	{
	}

	// Token: 0x06001031 RID: 4145 RVA: 0x000822DC File Offset: 0x000804DC
	private void Update()
	{
	}

	// Token: 0x06001032 RID: 4146 RVA: 0x000822DE File Offset: 0x000804DE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400149D RID: 5277
	public Shader SCShader;

	// Token: 0x0400149E RID: 5278
	private float TimeX = 1f;

	// Token: 0x0400149F RID: 5279
	private Material SCMaterial;

	// Token: 0x040014A0 RID: 5280
	public Texture2D LutTexture;

	// Token: 0x040014A1 RID: 5281
	private Texture3D converted3DLut;

	// Token: 0x040014A2 RID: 5282
	[Range(0f, 1f)]
	public float Blend = 1f;

	// Token: 0x040014A3 RID: 5283
	[Range(0f, 3f)]
	public float OriginalIntensity = 1f;

	// Token: 0x040014A4 RID: 5284
	[Range(-1f, 1f)]
	public float ResultIntensity;

	// Token: 0x040014A5 RID: 5285
	[Range(-1f, 1f)]
	public float FinalIntensity;

	// Token: 0x040014A6 RID: 5286
	[Range(0f, 1f)]
	public float TestMode = 0.5f;

	// Token: 0x040014A7 RID: 5287
	private string MemoPath;
}
