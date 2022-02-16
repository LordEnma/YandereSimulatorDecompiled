using System;
using UnityEngine;

// Token: 0x02000202 RID: 514
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/50s")]
public class CameraFilterPack_TV_50 : MonoBehaviour
{
	// Token: 0x17000306 RID: 774
	// (get) Token: 0x060010EF RID: 4335 RVA: 0x00085C3F File Offset: 0x00083E3F
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

	// Token: 0x060010F0 RID: 4336 RVA: 0x00085C73 File Offset: 0x00083E73
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_50");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010F1 RID: 4337 RVA: 0x00085C94 File Offset: 0x00083E94
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

	// Token: 0x060010F2 RID: 4338 RVA: 0x00085D4A File Offset: 0x00083F4A
	private void Update()
	{
	}

	// Token: 0x060010F3 RID: 4339 RVA: 0x00085D4C File Offset: 0x00083F4C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400157F RID: 5503
	public Shader SCShader;

	// Token: 0x04001580 RID: 5504
	private float TimeX = 1f;

	// Token: 0x04001581 RID: 5505
	private Material SCMaterial;

	// Token: 0x04001582 RID: 5506
	[Range(0f, 1f)]
	public float Fade = 1f;
}
