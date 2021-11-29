using System;
using UnityEngine;

// Token: 0x0200020A RID: 522
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Chromatical2")]
public class CameraFilterPack_TV_Chromatical2 : MonoBehaviour
{
	// Token: 0x1700030F RID: 783
	// (get) Token: 0x06001121 RID: 4385 RVA: 0x0008699D File Offset: 0x00084B9D
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

	// Token: 0x06001122 RID: 4386 RVA: 0x000869D1 File Offset: 0x00084BD1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Chromatical2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001123 RID: 4387 RVA: 0x000869F4 File Offset: 0x00084BF4
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

	// Token: 0x06001124 RID: 4388 RVA: 0x00086AEC File Offset: 0x00084CEC
	private void Update()
	{
	}

	// Token: 0x06001125 RID: 4389 RVA: 0x00086AEE File Offset: 0x00084CEE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015B8 RID: 5560
	public Shader SCShader;

	// Token: 0x040015B9 RID: 5561
	private float TimeX = 1f;

	// Token: 0x040015BA RID: 5562
	private Material SCMaterial;

	// Token: 0x040015BB RID: 5563
	[Range(0f, 10f)]
	public float Aberration = 2f;

	// Token: 0x040015BC RID: 5564
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x040015BD RID: 5565
	[Range(0f, 1f)]
	public float ZoomFade = 1f;

	// Token: 0x040015BE RID: 5566
	[Range(0f, 8f)]
	public float ZoomSpeed = 1f;
}
