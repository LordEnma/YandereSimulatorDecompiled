using System;
using UnityEngine;

// Token: 0x020001FF RID: 511
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Retro/Loading")]
public class CameraFilterPack_Retro_Loading : MonoBehaviour
{
	// Token: 0x17000303 RID: 771
	// (get) Token: 0x060010DC RID: 4316 RVA: 0x00085697 File Offset: 0x00083897
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

	// Token: 0x060010DD RID: 4317 RVA: 0x000856CB File Offset: 0x000838CB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Retro_Loading");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010DE RID: 4318 RVA: 0x000856EC File Offset: 0x000838EC
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

	// Token: 0x060010DF RID: 4319 RVA: 0x000857A2 File Offset: 0x000839A2
	private void Update()
	{
	}

	// Token: 0x060010E0 RID: 4320 RVA: 0x000857A4 File Offset: 0x000839A4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400156C RID: 5484
	public Shader SCShader;

	// Token: 0x0400156D RID: 5485
	private float TimeX = 1f;

	// Token: 0x0400156E RID: 5486
	private Material SCMaterial;

	// Token: 0x0400156F RID: 5487
	[Range(0.1f, 10f)]
	public float Speed = 1f;
}
