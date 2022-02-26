using System;
using UnityEngine;

// Token: 0x020001BC RID: 444
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Plasma")]
public class CameraFilterPack_FX_Plasma : MonoBehaviour
{
	// Token: 0x170002C0 RID: 704
	// (get) Token: 0x06000F28 RID: 3880 RVA: 0x0007CFF8 File Offset: 0x0007B1F8
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

	// Token: 0x06000F29 RID: 3881 RVA: 0x0007D02C File Offset: 0x0007B22C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Plasma");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F2A RID: 3882 RVA: 0x0007D050 File Offset: 0x0007B250
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F2B RID: 3883 RVA: 0x0007D106 File Offset: 0x0007B306
	private void Update()
	{
	}

	// Token: 0x06000F2C RID: 3884 RVA: 0x0007D108 File Offset: 0x0007B308
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400136D RID: 4973
	public Shader SCShader;

	// Token: 0x0400136E RID: 4974
	private float TimeX = 1f;

	// Token: 0x0400136F RID: 4975
	private Material SCMaterial;

	// Token: 0x04001370 RID: 4976
	[Range(0f, 20f)]
	private float Value = 6f;
}
