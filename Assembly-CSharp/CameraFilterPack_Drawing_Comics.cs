using System;
using UnityEngine;

// Token: 0x02000189 RID: 393
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Comics")]
public class CameraFilterPack_Drawing_Comics : MonoBehaviour
{
	// Token: 0x1700028D RID: 653
	// (get) Token: 0x06000DF7 RID: 3575 RVA: 0x00078AAF File Offset: 0x00076CAF
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

	// Token: 0x06000DF8 RID: 3576 RVA: 0x00078AE3 File Offset: 0x00076CE3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Comics");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DF9 RID: 3577 RVA: 0x00078B04 File Offset: 0x00076D04
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

	// Token: 0x06000DFA RID: 3578 RVA: 0x00078B8A File Offset: 0x00076D8A
	private void Update()
	{
	}

	// Token: 0x06000DFB RID: 3579 RVA: 0x00078B8C File Offset: 0x00076D8C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400124E RID: 4686
	public Shader SCShader;

	// Token: 0x0400124F RID: 4687
	private float TimeX = 1f;

	// Token: 0x04001250 RID: 4688
	private Material SCMaterial;

	// Token: 0x04001251 RID: 4689
	[Range(0f, 1f)]
	public float DotSize = 0.5f;
}
