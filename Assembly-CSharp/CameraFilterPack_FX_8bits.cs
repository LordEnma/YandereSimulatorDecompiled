using System;
using UnityEngine;

// Token: 0x020001A8 RID: 424
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/8bits")]
public class CameraFilterPack_FX_8bits : MonoBehaviour
{
	// Token: 0x170002AC RID: 684
	// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x0007B454 File Offset: 0x00079654
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

	// Token: 0x06000EB1 RID: 3761 RVA: 0x0007B488 File Offset: 0x00079688
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_8bits");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EB2 RID: 3762 RVA: 0x0007B4AC File Offset: 0x000796AC
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
			RenderTexture temporary = RenderTexture.GetTemporary(this.ResolutionX, this.ResolutionY, 0);
			Graphics.Blit(sourceTexture, temporary, this.material);
			temporary.filterMode = FilterMode.Point;
			Graphics.Blit(temporary, destTexture);
			RenderTexture.ReleaseTemporary(temporary);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EB3 RID: 3763 RVA: 0x0007B574 File Offset: 0x00079774
	private void Update()
	{
	}

	// Token: 0x06000EB4 RID: 3764 RVA: 0x0007B576 File Offset: 0x00079776
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001307 RID: 4871
	public Shader SCShader;

	// Token: 0x04001308 RID: 4872
	private float TimeX = 1f;

	// Token: 0x04001309 RID: 4873
	private Material SCMaterial;

	// Token: 0x0400130A RID: 4874
	[Range(-1f, 1f)]
	public float Brightness;

	// Token: 0x0400130B RID: 4875
	[Range(80f, 640f)]
	public int ResolutionX = 160;

	// Token: 0x0400130C RID: 4876
	[Range(60f, 480f)]
	public int ResolutionY = 240;
}
