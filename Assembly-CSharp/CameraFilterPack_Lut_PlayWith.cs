using System;
using UnityEngine;

// Token: 0x020001E0 RID: 480
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/PlayWith")]
public class CameraFilterPack_Lut_PlayWith : MonoBehaviour
{
	// Token: 0x170002E4 RID: 740
	// (get) Token: 0x0600100C RID: 4108 RVA: 0x0008178D File Offset: 0x0007F98D
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

	// Token: 0x0600100D RID: 4109 RVA: 0x000817C1 File Offset: 0x0007F9C1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Lut_PlayWith");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600100E RID: 4110 RVA: 0x000817E4 File Offset: 0x0007F9E4
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

	// Token: 0x0600100F RID: 4111 RVA: 0x000818BC File Offset: 0x0007FABC
	public bool ValidDimensions(Texture2D tex2d)
	{
		return tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width));
	}

	// Token: 0x06001010 RID: 4112 RVA: 0x000818E4 File Offset: 0x0007FAE4
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

	// Token: 0x06001011 RID: 4113 RVA: 0x000819E8 File Offset: 0x0007FBE8
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
			Graphics.Blit(sourceTexture, destTexture, this.material, (QualitySettings.activeColorSpace == ColorSpace.Linear) ? 1 : 0);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001012 RID: 4114 RVA: 0x00081AEC File Offset: 0x0007FCEC
	private void OnValidate()
	{
	}

	// Token: 0x06001013 RID: 4115 RVA: 0x00081AEE File Offset: 0x0007FCEE
	private void Update()
	{
	}

	// Token: 0x06001014 RID: 4116 RVA: 0x00081AF0 File Offset: 0x0007FCF0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400148E RID: 5262
	public Shader SCShader;

	// Token: 0x0400148F RID: 5263
	private float TimeX = 1f;

	// Token: 0x04001490 RID: 5264
	private Material SCMaterial;

	// Token: 0x04001491 RID: 5265
	public Texture2D LutTexture;

	// Token: 0x04001492 RID: 5266
	private Texture3D converted3DLut;

	// Token: 0x04001493 RID: 5267
	[Range(0f, 1f)]
	public float Blend = 1f;

	// Token: 0x04001494 RID: 5268
	[Range(0f, 3f)]
	public float OriginalIntensity = 1f;

	// Token: 0x04001495 RID: 5269
	[Range(-1f, 1f)]
	public float ResultIntensity;

	// Token: 0x04001496 RID: 5270
	[Range(-1f, 1f)]
	public float FinalIntensity;

	// Token: 0x04001497 RID: 5271
	private string MemoPath;
}
