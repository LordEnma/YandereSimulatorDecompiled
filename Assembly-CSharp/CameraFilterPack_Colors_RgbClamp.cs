using System;
using UnityEngine;

// Token: 0x02000170 RID: 368
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/RgbClamp")]
public class CameraFilterPack_Colors_RgbClamp : MonoBehaviour
{
	// Token: 0x17000274 RID: 628
	// (get) Token: 0x06000D5F RID: 3423 RVA: 0x0007600B File Offset: 0x0007420B
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

	// Token: 0x06000D60 RID: 3424 RVA: 0x0007603F File Offset: 0x0007423F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_RgbClamp");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D61 RID: 3425 RVA: 0x00076060 File Offset: 0x00074260
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

	// Token: 0x06000D62 RID: 3426 RVA: 0x000761B0 File Offset: 0x000743B0
	private void Update()
	{
	}

	// Token: 0x06000D63 RID: 3427 RVA: 0x000761B2 File Offset: 0x000743B2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011A7 RID: 4519
	public Shader SCShader;

	// Token: 0x040011A8 RID: 4520
	private float TimeX = 1f;

	// Token: 0x040011A9 RID: 4521
	private Material SCMaterial;

	// Token: 0x040011AA RID: 4522
	[Range(0f, 1f)]
	public float Red_Start;

	// Token: 0x040011AB RID: 4523
	[Range(0f, 1f)]
	public float Red_End = 1f;

	// Token: 0x040011AC RID: 4524
	[Range(0f, 1f)]
	public float Green_Start;

	// Token: 0x040011AD RID: 4525
	[Range(0f, 1f)]
	public float Green_End = 1f;

	// Token: 0x040011AE RID: 4526
	[Range(0f, 1f)]
	public float Blue_Start;

	// Token: 0x040011AF RID: 4527
	[Range(0f, 1f)]
	public float Blue_End = 1f;

	// Token: 0x040011B0 RID: 4528
	[Range(0f, 1f)]
	public float RGB_Start;

	// Token: 0x040011B1 RID: 4529
	[Range(0f, 1f)]
	public float RGB_End = 1f;
}
