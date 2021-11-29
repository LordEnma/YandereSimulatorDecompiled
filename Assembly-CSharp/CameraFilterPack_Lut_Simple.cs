using System;
using UnityEngine;

// Token: 0x020001E1 RID: 481
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/Simple")]
public class CameraFilterPack_Lut_Simple : MonoBehaviour
{
	// Token: 0x170002E6 RID: 742
	// (get) Token: 0x0600101C RID: 4124 RVA: 0x000818E6 File Offset: 0x0007FAE6
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

	// Token: 0x0600101D RID: 4125 RVA: 0x0008191A File Offset: 0x0007FB1A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Lut_Simple");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600101E RID: 4126 RVA: 0x0008193C File Offset: 0x0007FB3C
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

	// Token: 0x0600101F RID: 4127 RVA: 0x00081A14 File Offset: 0x0007FC14
	public bool ValidDimensions(Texture2D tex2d)
	{
		return tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width));
	}

	// Token: 0x06001020 RID: 4128 RVA: 0x00081A3C File Offset: 0x0007FC3C
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

	// Token: 0x06001021 RID: 4129 RVA: 0x00081B40 File Offset: 0x0007FD40
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
			Graphics.Blit(sourceTexture, destTexture, this.material, (QualitySettings.activeColorSpace == ColorSpace.Linear) ? 1 : 0);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001022 RID: 4130 RVA: 0x00081BEC File Offset: 0x0007FDEC
	private void OnValidate()
	{
	}

	// Token: 0x06001023 RID: 4131 RVA: 0x00081BEE File Offset: 0x0007FDEE
	private void Update()
	{
	}

	// Token: 0x06001024 RID: 4132 RVA: 0x00081BF0 File Offset: 0x0007FDF0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400148F RID: 5263
	public Shader SCShader;

	// Token: 0x04001490 RID: 5264
	private float TimeX = 1f;

	// Token: 0x04001491 RID: 5265
	private Material SCMaterial;

	// Token: 0x04001492 RID: 5266
	public Texture2D LutTexture;

	// Token: 0x04001493 RID: 5267
	private Texture3D converted3DLut;

	// Token: 0x04001494 RID: 5268
	private string MemoPath;
}
