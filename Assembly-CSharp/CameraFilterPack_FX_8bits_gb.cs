using System;
using UnityEngine;

// Token: 0x020001A8 RID: 424
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/8bits_gb")]
public class CameraFilterPack_FX_8bits_gb : MonoBehaviour
{
	// Token: 0x170002AD RID: 685
	// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x0007B015 File Offset: 0x00079215
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

	// Token: 0x06000EB3 RID: 3763 RVA: 0x0007B049 File Offset: 0x00079249
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_8bits_gb");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EB4 RID: 3764 RVA: 0x0007B06C File Offset: 0x0007926C
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

	// Token: 0x06000EB5 RID: 3765 RVA: 0x0007B132 File Offset: 0x00079332
	private void Update()
	{
	}

	// Token: 0x06000EB6 RID: 3766 RVA: 0x0007B134 File Offset: 0x00079334
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012FC RID: 4860
	public Shader SCShader;

	// Token: 0x040012FD RID: 4861
	private float TimeX = 1f;

	// Token: 0x040012FE RID: 4862
	private Material SCMaterial;

	// Token: 0x040012FF RID: 4863
	[Range(-1f, 1f)]
	public float Brightness;
}
