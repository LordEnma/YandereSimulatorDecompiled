using System;
using UnityEngine;

// Token: 0x020001A9 RID: 425
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/8bits_gb")]
public class CameraFilterPack_FX_8bits_gb : MonoBehaviour
{
	// Token: 0x170002AD RID: 685
	// (get) Token: 0x06000EB8 RID: 3768 RVA: 0x0007BA35 File Offset: 0x00079C35
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

	// Token: 0x06000EB9 RID: 3769 RVA: 0x0007BA69 File Offset: 0x00079C69
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_8bits_gb");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EBA RID: 3770 RVA: 0x0007BA8C File Offset: 0x00079C8C
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

	// Token: 0x06000EBB RID: 3771 RVA: 0x0007BB52 File Offset: 0x00079D52
	private void Update()
	{
	}

	// Token: 0x06000EBC RID: 3772 RVA: 0x0007BB54 File Offset: 0x00079D54
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001314 RID: 4884
	public Shader SCShader;

	// Token: 0x04001315 RID: 4885
	private float TimeX = 1f;

	// Token: 0x04001316 RID: 4886
	private Material SCMaterial;

	// Token: 0x04001317 RID: 4887
	[Range(-1f, 1f)]
	public float Brightness;
}
