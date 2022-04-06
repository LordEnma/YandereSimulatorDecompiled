using System;
using UnityEngine;

// Token: 0x020001FF RID: 511
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Retro/Loading")]
public class CameraFilterPack_Retro_Loading : MonoBehaviour
{
	// Token: 0x17000303 RID: 771
	// (get) Token: 0x060010DF RID: 4319 RVA: 0x00085EBF File Offset: 0x000840BF
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

	// Token: 0x060010E0 RID: 4320 RVA: 0x00085EF3 File Offset: 0x000840F3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Retro_Loading");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010E1 RID: 4321 RVA: 0x00085F14 File Offset: 0x00084114
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
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010E2 RID: 4322 RVA: 0x00085FCA File Offset: 0x000841CA
	private void Update()
	{
	}

	// Token: 0x060010E3 RID: 4323 RVA: 0x00085FCC File Offset: 0x000841CC
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
	[Range(0.1f, 10f)]
	public float Speed = 1f;
}
