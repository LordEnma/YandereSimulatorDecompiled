using System;
using UnityEngine;

// Token: 0x020001C3 RID: 451
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Film/ColorPerfection")]
public class CameraFilterPack_Film_ColorPerfection : MonoBehaviour
{
	// Token: 0x170002C7 RID: 711
	// (get) Token: 0x06000F51 RID: 3921 RVA: 0x0007D76C File Offset: 0x0007B96C
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

	// Token: 0x06000F52 RID: 3922 RVA: 0x0007D7A0 File Offset: 0x0007B9A0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Film_ColorPerfection");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F53 RID: 3923 RVA: 0x0007D7C4 File Offset: 0x0007B9C4
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

	// Token: 0x06000F54 RID: 3924 RVA: 0x0007D8BC File Offset: 0x0007BABC
	private void Update()
	{
	}

	// Token: 0x06000F55 RID: 3925 RVA: 0x0007D8BE File Offset: 0x0007BABE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400138D RID: 5005
	public Shader SCShader;

	// Token: 0x0400138E RID: 5006
	private float TimeX = 1f;

	// Token: 0x0400138F RID: 5007
	private Material SCMaterial;

	// Token: 0x04001390 RID: 5008
	[Range(0f, 4f)]
	public float Gamma = 0.55f;

	// Token: 0x04001391 RID: 5009
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x04001392 RID: 5010
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x04001393 RID: 5011
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
