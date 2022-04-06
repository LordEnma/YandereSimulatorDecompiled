using System;
using UnityEngine;

// Token: 0x020001A8 RID: 424
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/8bits")]
public class CameraFilterPack_FX_8bits : MonoBehaviour
{
	// Token: 0x170002AC RID: 684
	// (get) Token: 0x06000EB2 RID: 3762 RVA: 0x0007B8D0 File Offset: 0x00079AD0
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

	// Token: 0x06000EB3 RID: 3763 RVA: 0x0007B904 File Offset: 0x00079B04
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_8bits");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EB4 RID: 3764 RVA: 0x0007B928 File Offset: 0x00079B28
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

	// Token: 0x06000EB5 RID: 3765 RVA: 0x0007B9F0 File Offset: 0x00079BF0
	private void Update()
	{
	}

	// Token: 0x06000EB6 RID: 3766 RVA: 0x0007B9F2 File Offset: 0x00079BF2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400130E RID: 4878
	public Shader SCShader;

	// Token: 0x0400130F RID: 4879
	private float TimeX = 1f;

	// Token: 0x04001310 RID: 4880
	private Material SCMaterial;

	// Token: 0x04001311 RID: 4881
	[Range(-1f, 1f)]
	public float Brightness;

	// Token: 0x04001312 RID: 4882
	[Range(80f, 640f)]
	public int ResolutionX = 160;

	// Token: 0x04001313 RID: 4883
	[Range(60f, 480f)]
	public int ResolutionY = 240;
}
