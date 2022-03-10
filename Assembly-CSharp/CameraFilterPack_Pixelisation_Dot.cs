using System;
using UnityEngine;

// Token: 0x020001F9 RID: 505
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/Dot")]
public class CameraFilterPack_Pixelisation_Dot : MonoBehaviour
{
	// Token: 0x170002FD RID: 765
	// (get) Token: 0x060010B8 RID: 4280 RVA: 0x00084EF1 File Offset: 0x000830F1
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

	// Token: 0x060010B9 RID: 4281 RVA: 0x00084F25 File Offset: 0x00083125
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_Dot");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010BA RID: 4282 RVA: 0x00084F48 File Offset: 0x00083148
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.LightBackGround);
			this.material.SetFloat("_Value3", this.Speed);
			this.material.SetFloat("_Value4", this.Size2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010BB RID: 4283 RVA: 0x00085040 File Offset: 0x00083240
	private void Update()
	{
	}

	// Token: 0x060010BC RID: 4284 RVA: 0x00085042 File Offset: 0x00083242
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400154E RID: 5454
	public Shader SCShader;

	// Token: 0x0400154F RID: 5455
	private float TimeX = 1f;

	// Token: 0x04001550 RID: 5456
	private Material SCMaterial;

	// Token: 0x04001551 RID: 5457
	[Range(0.0001f, 0.5f)]
	public float Size = 0.005f;

	// Token: 0x04001552 RID: 5458
	[Range(0f, 1f)]
	public float LightBackGround = 0.3f;

	// Token: 0x04001553 RID: 5459
	[Range(0f, 10f)]
	private float Speed = 1f;

	// Token: 0x04001554 RID: 5460
	[Range(0f, 10f)]
	private float Size2 = 1f;
}
