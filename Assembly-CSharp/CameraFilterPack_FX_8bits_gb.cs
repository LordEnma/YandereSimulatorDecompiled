using System;
using UnityEngine;

// Token: 0x020001A9 RID: 425
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/8bits_gb")]
public class CameraFilterPack_FX_8bits_gb : MonoBehaviour
{
	// Token: 0x170002AD RID: 685
	// (get) Token: 0x06000EB6 RID: 3766 RVA: 0x0007B5B9 File Offset: 0x000797B9
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

	// Token: 0x06000EB7 RID: 3767 RVA: 0x0007B5ED File Offset: 0x000797ED
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_8bits_gb");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EB8 RID: 3768 RVA: 0x0007B610 File Offset: 0x00079810
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
			if (this.Brightness == 0f)
			{
				this.Brightness = 0.001f;
			}
			this.material.SetFloat("_Distortion", this.Brightness);
			RenderTexture temporary = RenderTexture.GetTemporary(160, 144, 0);
			Graphics.Blit(sourceTexture, temporary, this.material);
			temporary.filterMode = FilterMode.Point;
			Graphics.Blit(temporary, destTexture);
			RenderTexture.ReleaseTemporary(temporary);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EB9 RID: 3769 RVA: 0x0007B6D6 File Offset: 0x000798D6
	private void Update()
	{
	}

	// Token: 0x06000EBA RID: 3770 RVA: 0x0007B6D8 File Offset: 0x000798D8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400130D RID: 4877
	public Shader SCShader;

	// Token: 0x0400130E RID: 4878
	private float TimeX = 1f;

	// Token: 0x0400130F RID: 4879
	private Material SCMaterial;

	// Token: 0x04001310 RID: 4880
	[Range(-1f, 1f)]
	public float Brightness;
}
