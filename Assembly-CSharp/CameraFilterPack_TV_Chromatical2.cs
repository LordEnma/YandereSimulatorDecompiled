using System;
using UnityEngine;

// Token: 0x0200020B RID: 523
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Chromatical2")]
public class CameraFilterPack_TV_Chromatical2 : MonoBehaviour
{
	// Token: 0x1700030F RID: 783
	// (get) Token: 0x06001125 RID: 4389 RVA: 0x00086F41 File Offset: 0x00085141
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

	// Token: 0x06001126 RID: 4390 RVA: 0x00086F75 File Offset: 0x00085175
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Chromatical2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001127 RID: 4391 RVA: 0x00086F98 File Offset: 0x00085198
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
			this.material.SetFloat("_Value", this.Aberration);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("ZoomFade", this.ZoomFade);
			this.material.SetFloat("ZoomSpeed", this.ZoomSpeed);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001128 RID: 4392 RVA: 0x00087090 File Offset: 0x00085290
	private void Update()
	{
	}

	// Token: 0x06001129 RID: 4393 RVA: 0x00087092 File Offset: 0x00085292
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015C9 RID: 5577
	public Shader SCShader;

	// Token: 0x040015CA RID: 5578
	private float TimeX = 1f;

	// Token: 0x040015CB RID: 5579
	private Material SCMaterial;

	// Token: 0x040015CC RID: 5580
	[Range(0f, 10f)]
	public float Aberration = 2f;

	// Token: 0x040015CD RID: 5581
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015CE RID: 5582
	[Range(0f, 1f)]
	public float ZoomFade = 1f;

	// Token: 0x040015CF RID: 5583
	[Range(0f, 8f)]
	public float ZoomSpeed = 1f;
}
