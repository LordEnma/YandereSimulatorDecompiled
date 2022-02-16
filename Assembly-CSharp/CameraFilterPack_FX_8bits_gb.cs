using System;
using UnityEngine;

// Token: 0x020001A9 RID: 425
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/8bits_gb")]
public class CameraFilterPack_FX_8bits_gb : MonoBehaviour
{
	// Token: 0x170002AD RID: 685
	// (get) Token: 0x06000EB6 RID: 3766 RVA: 0x0007B35D File Offset: 0x0007955D
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

	// Token: 0x06000EB7 RID: 3767 RVA: 0x0007B391 File Offset: 0x00079591
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_8bits_gb");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EB8 RID: 3768 RVA: 0x0007B3B4 File Offset: 0x000795B4
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

	// Token: 0x06000EB9 RID: 3769 RVA: 0x0007B47A File Offset: 0x0007967A
	private void Update()
	{
	}

	// Token: 0x06000EBA RID: 3770 RVA: 0x0007B47C File Offset: 0x0007967C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001304 RID: 4868
	public Shader SCShader;

	// Token: 0x04001305 RID: 4869
	private float TimeX = 1f;

	// Token: 0x04001306 RID: 4870
	private Material SCMaterial;

	// Token: 0x04001307 RID: 4871
	[Range(-1f, 1f)]
	public float Brightness;
}
