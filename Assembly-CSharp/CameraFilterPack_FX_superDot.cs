using System;
using UnityEngine;

// Token: 0x020001C1 RID: 449
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/SuperDot")]
public class CameraFilterPack_FX_superDot : MonoBehaviour
{
	// Token: 0x170002C6 RID: 710
	// (get) Token: 0x06000F48 RID: 3912 RVA: 0x0007D450 File Offset: 0x0007B650
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

	// Token: 0x06000F49 RID: 3913 RVA: 0x0007D484 File Offset: 0x0007B684
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_superDot");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F4A RID: 3914 RVA: 0x0007D4A8 File Offset: 0x0007B6A8
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F4B RID: 3915 RVA: 0x0007D545 File Offset: 0x0007B745
	private void Update()
	{
	}

	// Token: 0x06000F4C RID: 3916 RVA: 0x0007D547 File Offset: 0x0007B747
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001385 RID: 4997
	public Shader SCShader;

	// Token: 0x04001386 RID: 4998
	private float TimeX = 1f;

	// Token: 0x04001387 RID: 4999
	private Material SCMaterial;
}
