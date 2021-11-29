using System;
using UnityEngine;

// Token: 0x020001FE RID: 510
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Retro/Loading")]
public class CameraFilterPack_Retro_Loading : MonoBehaviour
{
	// Token: 0x17000303 RID: 771
	// (get) Token: 0x060010D9 RID: 4313 RVA: 0x0008549F File Offset: 0x0008369F
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

	// Token: 0x060010DA RID: 4314 RVA: 0x000854D3 File Offset: 0x000836D3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Retro_Loading");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010DB RID: 4315 RVA: 0x000854F4 File Offset: 0x000836F4
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

	// Token: 0x060010DC RID: 4316 RVA: 0x000855AA File Offset: 0x000837AA
	private void Update()
	{
	}

	// Token: 0x060010DD RID: 4317 RVA: 0x000855AC File Offset: 0x000837AC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001567 RID: 5479
	public Shader SCShader;

	// Token: 0x04001568 RID: 5480
	private float TimeX = 1f;

	// Token: 0x04001569 RID: 5481
	private Material SCMaterial;

	// Token: 0x0400156A RID: 5482
	[Range(0.1f, 10f)]
	public float Speed = 1f;
}
