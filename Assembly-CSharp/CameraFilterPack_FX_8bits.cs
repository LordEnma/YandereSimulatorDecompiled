using System;
using UnityEngine;

// Token: 0x020001A8 RID: 424
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/8bits")]
public class CameraFilterPack_FX_8bits : MonoBehaviour
{
	// Token: 0x170002AC RID: 684
	// (get) Token: 0x06000EAF RID: 3759 RVA: 0x0007B0A8 File Offset: 0x000792A8
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

	// Token: 0x06000EB0 RID: 3760 RVA: 0x0007B0DC File Offset: 0x000792DC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_8bits");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EB1 RID: 3761 RVA: 0x0007B100 File Offset: 0x00079300
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

	// Token: 0x06000EB2 RID: 3762 RVA: 0x0007B1C8 File Offset: 0x000793C8
	private void Update()
	{
	}

	// Token: 0x06000EB3 RID: 3763 RVA: 0x0007B1CA File Offset: 0x000793CA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012FB RID: 4859
	public Shader SCShader;

	// Token: 0x040012FC RID: 4860
	private float TimeX = 1f;

	// Token: 0x040012FD RID: 4861
	private Material SCMaterial;

	// Token: 0x040012FE RID: 4862
	[Range(-1f, 1f)]
	public float Brightness;

	// Token: 0x040012FF RID: 4863
	[Range(80f, 640f)]
	public int ResolutionX = 160;

	// Token: 0x04001300 RID: 4864
	[Range(60f, 480f)]
	public int ResolutionY = 240;
}
