using System;
using UnityEngine;

// Token: 0x020001E2 RID: 482
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Lut/Simple")]
public class CameraFilterPack_Lut_Simple : MonoBehaviour
{
	// Token: 0x170002E6 RID: 742
	// (get) Token: 0x06001020 RID: 4128 RVA: 0x00081E8A File Offset: 0x0008008A
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

	// Token: 0x06001021 RID: 4129 RVA: 0x00081EBE File Offset: 0x000800BE
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Lut_Simple");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001022 RID: 4130 RVA: 0x00081EE0 File Offset: 0x000800E0
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

	// Token: 0x06001023 RID: 4131 RVA: 0x00081FB8 File Offset: 0x000801B8
	public bool ValidDimensions(Texture2D tex2d)
	{
		return tex2d && tex2d.height == Mathf.FloorToInt(Mathf.Sqrt((float)tex2d.width));
	}

	// Token: 0x06001024 RID: 4132 RVA: 0x00081FE0 File Offset: 0x000801E0
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

	// Token: 0x06001025 RID: 4133 RVA: 0x000820E4 File Offset: 0x000802E4
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

	// Token: 0x06001026 RID: 4134 RVA: 0x00082190 File Offset: 0x00080390
	private void OnValidate()
	{
	}

	// Token: 0x06001027 RID: 4135 RVA: 0x00082192 File Offset: 0x00080392
	private void Update()
	{
	}

	// Token: 0x06001028 RID: 4136 RVA: 0x00082194 File Offset: 0x00080394
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014A0 RID: 5280
	public Shader SCShader;

	// Token: 0x040014A1 RID: 5281
	private float TimeX = 1f;

	// Token: 0x040014A2 RID: 5282
	private Material SCMaterial;

	// Token: 0x040014A3 RID: 5283
	public Texture2D LutTexture;

	// Token: 0x040014A4 RID: 5284
	private Texture3D converted3DLut;

	// Token: 0x040014A5 RID: 5285
	private string MemoPath;
}
