using System;
using UnityEngine;

// Token: 0x020001E3 RID: 483
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/TestMode")]
public class CameraFilterPack_Lut_TestMode : MonoBehaviour
{
	// Token: 0x170002E7 RID: 743
	// (get) Token: 0x0600102C RID: 4140 RVA: 0x0008263D File Offset: 0x0008083D
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

	// Token: 0x0600102D RID: 4141 RVA: 0x00082671 File Offset: 0x00080871
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Lut_TestMode");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600102E RID: 4142 RVA: 0x00082694 File Offset: 0x00080894
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

	// Token: 0x0600102F RID: 4143 RVA: 0x0008276C File Offset: 0x0008096C
	public bool ValidDimensions(Texture2D tex2d)
	{
		return tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width));
	}

	// Token: 0x06001030 RID: 4144 RVA: 0x00082794 File Offset: 0x00080994
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

	// Token: 0x06001031 RID: 4145 RVA: 0x00082898 File Offset: 0x00080A98
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

	// Token: 0x06001032 RID: 4146 RVA: 0x000829B2 File Offset: 0x00080BB2
	private void OnValidate()
	{
	}

	// Token: 0x06001033 RID: 4147 RVA: 0x000829B4 File Offset: 0x00080BB4
	private void Update()
	{
	}

	// Token: 0x06001034 RID: 4148 RVA: 0x000829B6 File Offset: 0x00080BB6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014AD RID: 5293
	public Shader SCShader;

	// Token: 0x040014AE RID: 5294
	private float TimeX = 1f;

	// Token: 0x040014AF RID: 5295
	private Material SCMaterial;

	// Token: 0x040014B0 RID: 5296
	public Texture2D LutTexture;

	// Token: 0x040014B1 RID: 5297
	private Texture3D converted3DLut;

	// Token: 0x040014B2 RID: 5298
	[Range(0f, 1f)]
	public float Blend = 1f;

	// Token: 0x040014B3 RID: 5299
	[Range(0f, 3f)]
	public float OriginalIntensity = 1f;

	// Token: 0x040014B4 RID: 5300
	[Range(-1f, 1f)]
	public float ResultIntensity;

	// Token: 0x040014B5 RID: 5301
	[Range(-1f, 1f)]
	public float FinalIntensity;

	// Token: 0x040014B6 RID: 5302
	[Range(0f, 1f)]
	public float TestMode = 0.5f;

	// Token: 0x040014B7 RID: 5303
	private string MemoPath;
}
