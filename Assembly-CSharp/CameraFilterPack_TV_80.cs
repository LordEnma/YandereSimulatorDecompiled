using System;
using UnityEngine;

// Token: 0x02000202 RID: 514
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/80s")]
public class CameraFilterPack_TV_80 : MonoBehaviour
{
	// Token: 0x17000307 RID: 775
	// (get) Token: 0x060010F1 RID: 4337 RVA: 0x00085A3C File Offset: 0x00083C3C
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

	// Token: 0x060010F2 RID: 4338 RVA: 0x00085A70 File Offset: 0x00083C70
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_80");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010F3 RID: 4339 RVA: 0x00085A94 File Offset: 0x00083C94
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
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010F4 RID: 4340 RVA: 0x00085B4A File Offset: 0x00083D4A
	private void Update()
	{
	}

	// Token: 0x060010F5 RID: 4341 RVA: 0x00085B4C File Offset: 0x00083D4C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400157B RID: 5499
	public Shader SCShader;

	// Token: 0x0400157C RID: 5500
	private float TimeX = 1f;

	// Token: 0x0400157D RID: 5501
	private Material SCMaterial;

	// Token: 0x0400157E RID: 5502
	[Range(0f, 1f)]
	public float Fade = 1f;
}
