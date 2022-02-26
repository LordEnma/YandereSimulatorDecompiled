using System;
using UnityEngine;

// Token: 0x020001A8 RID: 424
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/8bits")]
public class CameraFilterPack_FX_8bits : MonoBehaviour
{
	// Token: 0x170002AC RID: 684
	// (get) Token: 0x06000EB0 RID: 3760 RVA: 0x0007B30C File Offset: 0x0007950C
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

	// Token: 0x06000EB1 RID: 3761 RVA: 0x0007B340 File Offset: 0x00079540
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_8bits");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EB2 RID: 3762 RVA: 0x0007B364 File Offset: 0x00079564
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

	// Token: 0x06000EB3 RID: 3763 RVA: 0x0007B42C File Offset: 0x0007962C
	private void Update()
	{
	}

	// Token: 0x06000EB4 RID: 3764 RVA: 0x0007B42E File Offset: 0x0007962E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012FE RID: 4862
	public Shader SCShader;

	// Token: 0x040012FF RID: 4863
	private float TimeX = 1f;

	// Token: 0x04001300 RID: 4864
	private Material SCMaterial;

	// Token: 0x04001301 RID: 4865
	[Range(-1f, 1f)]
	public float Brightness;

	// Token: 0x04001302 RID: 4866
	[Range(80f, 640f)]
	public int ResolutionX = 160;

	// Token: 0x04001303 RID: 4867
	[Range(60f, 480f)]
	public int ResolutionY = 240;
}
