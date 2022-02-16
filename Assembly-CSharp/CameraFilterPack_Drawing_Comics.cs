using System;
using UnityEngine;

// Token: 0x02000189 RID: 393
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Comics")]
public class CameraFilterPack_Drawing_Comics : MonoBehaviour
{
	// Token: 0x1700028D RID: 653
	// (get) Token: 0x06000DF5 RID: 3573 RVA: 0x000783D7 File Offset: 0x000765D7
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

	// Token: 0x06000DF6 RID: 3574 RVA: 0x0007840B File Offset: 0x0007660B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Comics");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DF7 RID: 3575 RVA: 0x0007842C File Offset: 0x0007662C
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
			this.material.SetFloat("_DotSize", this.DotSize);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DF8 RID: 3576 RVA: 0x000784B2 File Offset: 0x000766B2
	private void Update()
	{
	}

	// Token: 0x06000DF9 RID: 3577 RVA: 0x000784B4 File Offset: 0x000766B4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400123E RID: 4670
	public Shader SCShader;

	// Token: 0x0400123F RID: 4671
	private float TimeX = 1f;

	// Token: 0x04001240 RID: 4672
	private Material SCMaterial;

	// Token: 0x04001241 RID: 4673
	[Range(0f, 1f)]
	public float DotSize = 0.5f;
}
