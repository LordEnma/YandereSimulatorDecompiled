using System;
using UnityEngine;

// Token: 0x020001C2 RID: 450
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Film/ColorPerfection")]
public class CameraFilterPack_Film_ColorPerfection : MonoBehaviour
{
	// Token: 0x170002C7 RID: 711
	// (get) Token: 0x06000F4E RID: 3918 RVA: 0x0007D574 File Offset: 0x0007B774
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

	// Token: 0x06000F4F RID: 3919 RVA: 0x0007D5A8 File Offset: 0x0007B7A8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Film_ColorPerfection");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F50 RID: 3920 RVA: 0x0007D5CC File Offset: 0x0007B7CC
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
			this.material.SetFloat("_Value", this.Gamma);
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F51 RID: 3921 RVA: 0x0007D6C4 File Offset: 0x0007B8C4
	private void Update()
	{
	}

	// Token: 0x06000F52 RID: 3922 RVA: 0x0007D6C6 File Offset: 0x0007B8C6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001388 RID: 5000
	public Shader SCShader;

	// Token: 0x04001389 RID: 5001
	private float TimeX = 1f;

	// Token: 0x0400138A RID: 5002
	private Material SCMaterial;

	// Token: 0x0400138B RID: 5003
	[Range(0f, 4f)]
	public float Gamma = 0.55f;

	// Token: 0x0400138C RID: 5004
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x0400138D RID: 5005
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x0400138E RID: 5006
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
