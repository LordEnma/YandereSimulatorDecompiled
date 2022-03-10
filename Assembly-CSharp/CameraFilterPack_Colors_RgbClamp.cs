using System;
using UnityEngine;

// Token: 0x02000170 RID: 368
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/RgbClamp")]
public class CameraFilterPack_Colors_RgbClamp : MonoBehaviour
{
	// Token: 0x17000274 RID: 628
	// (get) Token: 0x06000D5F RID: 3423 RVA: 0x00076153 File Offset: 0x00074353
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

	// Token: 0x06000D60 RID: 3424 RVA: 0x00076187 File Offset: 0x00074387
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_RgbClamp");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D61 RID: 3425 RVA: 0x000761A8 File Offset: 0x000743A8
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.Red_Start);
			this.material.SetFloat("_Value2", this.Red_End);
			this.material.SetFloat("_Value3", this.Green_Start);
			this.material.SetFloat("_Value4", this.Green_End);
			this.material.SetFloat("_Value5", this.Blue_Start);
			this.material.SetFloat("_Value6", this.Blue_End);
			this.material.SetFloat("_Value7", this.RGB_Start);
			this.material.SetFloat("_Value8", this.RGB_End);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D62 RID: 3426 RVA: 0x000762F8 File Offset: 0x000744F8
	private void Update()
	{
	}

	// Token: 0x06000D63 RID: 3427 RVA: 0x000762FA File Offset: 0x000744FA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011B0 RID: 4528
	public Shader SCShader;

	// Token: 0x040011B1 RID: 4529
	private float TimeX = 1f;

	// Token: 0x040011B2 RID: 4530
	private Material SCMaterial;

	// Token: 0x040011B3 RID: 4531
	[Range(0f, 1f)]
	public float Red_Start;

	// Token: 0x040011B4 RID: 4532
	[Range(0f, 1f)]
	public float Red_End = 1f;

	// Token: 0x040011B5 RID: 4533
	[Range(0f, 1f)]
	public float Green_Start;

	// Token: 0x040011B6 RID: 4534
	[Range(0f, 1f)]
	public float Green_End = 1f;

	// Token: 0x040011B7 RID: 4535
	[Range(0f, 1f)]
	public float Blue_Start;

	// Token: 0x040011B8 RID: 4536
	[Range(0f, 1f)]
	public float Blue_End = 1f;

	// Token: 0x040011B9 RID: 4537
	[Range(0f, 1f)]
	public float RGB_Start;

	// Token: 0x040011BA RID: 4538
	[Range(0f, 1f)]
	public float RGB_End = 1f;
}
