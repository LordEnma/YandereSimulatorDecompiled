using System;
using UnityEngine;

// Token: 0x0200016F RID: 367
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/RgbClamp")]
public class CameraFilterPack_Colors_RgbClamp : MonoBehaviour
{
	// Token: 0x17000274 RID: 628
	// (get) Token: 0x06000D5B RID: 3419 RVA: 0x00075BAF File Offset: 0x00073DAF
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

	// Token: 0x06000D5C RID: 3420 RVA: 0x00075BE3 File Offset: 0x00073DE3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_RgbClamp");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D5D RID: 3421 RVA: 0x00075C04 File Offset: 0x00073E04
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

	// Token: 0x06000D5E RID: 3422 RVA: 0x00075D54 File Offset: 0x00073F54
	private void Update()
	{
	}

	// Token: 0x06000D5F RID: 3423 RVA: 0x00075D56 File Offset: 0x00073F56
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400119F RID: 4511
	public Shader SCShader;

	// Token: 0x040011A0 RID: 4512
	private float TimeX = 1f;

	// Token: 0x040011A1 RID: 4513
	private Material SCMaterial;

	// Token: 0x040011A2 RID: 4514
	[Range(0f, 1f)]
	public float Red_Start;

	// Token: 0x040011A3 RID: 4515
	[Range(0f, 1f)]
	public float Red_End = 1f;

	// Token: 0x040011A4 RID: 4516
	[Range(0f, 1f)]
	public float Green_Start;

	// Token: 0x040011A5 RID: 4517
	[Range(0f, 1f)]
	public float Green_End = 1f;

	// Token: 0x040011A6 RID: 4518
	[Range(0f, 1f)]
	public float Blue_Start;

	// Token: 0x040011A7 RID: 4519
	[Range(0f, 1f)]
	public float Blue_End = 1f;

	// Token: 0x040011A8 RID: 4520
	[Range(0f, 1f)]
	public float RGB_Start;

	// Token: 0x040011A9 RID: 4521
	[Range(0f, 1f)]
	public float RGB_End = 1f;
}
