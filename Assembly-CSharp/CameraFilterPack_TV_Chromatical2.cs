using System;
using UnityEngine;

// Token: 0x0200020B RID: 523
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Chromatical2")]
public class CameraFilterPack_TV_Chromatical2 : MonoBehaviour
{
	// Token: 0x1700030F RID: 783
	// (get) Token: 0x06001125 RID: 4389 RVA: 0x00086CE5 File Offset: 0x00084EE5
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

	// Token: 0x06001126 RID: 4390 RVA: 0x00086D19 File Offset: 0x00084F19
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Chromatical2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001127 RID: 4391 RVA: 0x00086D3C File Offset: 0x00084F3C
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

	// Token: 0x06001128 RID: 4392 RVA: 0x00086E34 File Offset: 0x00085034
	private void Update()
	{
	}

	// Token: 0x06001129 RID: 4393 RVA: 0x00086E36 File Offset: 0x00085036
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015C0 RID: 5568
	public Shader SCShader;

	// Token: 0x040015C1 RID: 5569
	private float TimeX = 1f;

	// Token: 0x040015C2 RID: 5570
	private Material SCMaterial;

	// Token: 0x040015C3 RID: 5571
	[Range(0f, 10f)]
	public float Aberration = 2f;

	// Token: 0x040015C4 RID: 5572
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015C5 RID: 5573
	[Range(0f, 1f)]
	public float ZoomFade = 1f;

	// Token: 0x040015C6 RID: 5574
	[Range(0f, 8f)]
	public float ZoomSpeed = 1f;
}
