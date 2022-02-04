using System;
using UnityEngine;

// Token: 0x020001AD RID: 429
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/DigitalMatrixDistortion")]
public class CameraFilterPack_FX_DigitalMatrixDistortion : MonoBehaviour
{
	// Token: 0x170002B1 RID: 689
	// (get) Token: 0x06000ECD RID: 3789 RVA: 0x0007B891 File Offset: 0x00079A91
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

	// Token: 0x06000ECE RID: 3790 RVA: 0x0007B8C5 File Offset: 0x00079AC5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_DigitalMatrixDistortion");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ECF RID: 3791 RVA: 0x0007B8E8 File Offset: 0x00079AE8
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
			this.material.SetFloat("_Value2", this.Distortion);
			this.material.SetFloat("_Value5", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000ED0 RID: 3792 RVA: 0x0007B9CA File Offset: 0x00079BCA
	private void Update()
	{
	}

	// Token: 0x06000ED1 RID: 3793 RVA: 0x0007B9CC File Offset: 0x00079BCC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400131B RID: 4891
	public Shader SCShader;

	// Token: 0x0400131C RID: 4892
	private float TimeX = 1f;

	// Token: 0x0400131D RID: 4893
	private Material SCMaterial;

	// Token: 0x0400131E RID: 4894
	[Range(0.4f, 5f)]
	public float Size = 1.4f;

	// Token: 0x0400131F RID: 4895
	[Range(-2f, 2f)]
	public float Speed = 0.5f;

	// Token: 0x04001320 RID: 4896
	[Range(-5f, 5f)]
	public float Distortion = 2.3f;
}
