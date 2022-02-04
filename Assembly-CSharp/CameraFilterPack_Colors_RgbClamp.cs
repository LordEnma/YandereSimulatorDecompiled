using System;
using UnityEngine;

// Token: 0x02000170 RID: 368
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/RgbClamp")]
public class CameraFilterPack_Colors_RgbClamp : MonoBehaviour
{
	// Token: 0x17000274 RID: 628
	// (get) Token: 0x06000D5E RID: 3422 RVA: 0x00075DA7 File Offset: 0x00073FA7
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

	// Token: 0x06000D5F RID: 3423 RVA: 0x00075DDB File Offset: 0x00073FDB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_RgbClamp");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D60 RID: 3424 RVA: 0x00075DFC File Offset: 0x00073FFC
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

	// Token: 0x06000D61 RID: 3425 RVA: 0x00075F4C File Offset: 0x0007414C
	private void Update()
	{
	}

	// Token: 0x06000D62 RID: 3426 RVA: 0x00075F4E File Offset: 0x0007414E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011A4 RID: 4516
	public Shader SCShader;

	// Token: 0x040011A5 RID: 4517
	private float TimeX = 1f;

	// Token: 0x040011A6 RID: 4518
	private Material SCMaterial;

	// Token: 0x040011A7 RID: 4519
	[Range(0f, 1f)]
	public float Red_Start;

	// Token: 0x040011A8 RID: 4520
	[Range(0f, 1f)]
	public float Red_End = 1f;

	// Token: 0x040011A9 RID: 4521
	[Range(0f, 1f)]
	public float Green_Start;

	// Token: 0x040011AA RID: 4522
	[Range(0f, 1f)]
	public float Green_End = 1f;

	// Token: 0x040011AB RID: 4523
	[Range(0f, 1f)]
	public float Blue_Start;

	// Token: 0x040011AC RID: 4524
	[Range(0f, 1f)]
	public float Blue_End = 1f;

	// Token: 0x040011AD RID: 4525
	[Range(0f, 1f)]
	public float RGB_Start;

	// Token: 0x040011AE RID: 4526
	[Range(0f, 1f)]
	public float RGB_End = 1f;
}
