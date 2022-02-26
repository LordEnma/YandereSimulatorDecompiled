using System;
using UnityEngine;

// Token: 0x020001B4 RID: 436
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch2")]
public class CameraFilterPack_FX_Glitch2 : MonoBehaviour
{
	// Token: 0x170002B8 RID: 696
	// (get) Token: 0x06000EF8 RID: 3832 RVA: 0x0007C5DC File Offset: 0x0007A7DC
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

	// Token: 0x06000EF9 RID: 3833 RVA: 0x0007C610 File Offset: 0x0007A810
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Glitch2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EFA RID: 3834 RVA: 0x0007C634 File Offset: 0x0007A834
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
			this.material.SetFloat("_Glitch", this.Glitch);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EFB RID: 3835 RVA: 0x0007C6EA File Offset: 0x0007A8EA
	private void Update()
	{
	}

	// Token: 0x06000EFC RID: 3836 RVA: 0x0007C6EC File Offset: 0x0007A8EC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400134B RID: 4939
	public Shader SCShader;

	// Token: 0x0400134C RID: 4940
	private float TimeX = 1f;

	// Token: 0x0400134D RID: 4941
	private Material SCMaterial;

	// Token: 0x0400134E RID: 4942
	[Range(0f, 1f)]
	public float Glitch = 1f;
}
