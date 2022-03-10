using System;
using UnityEngine;

// Token: 0x0200020D RID: 525
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Distorted")]
public class CameraFilterPack_TV_Distorted : MonoBehaviour
{
	// Token: 0x17000311 RID: 785
	// (get) Token: 0x06001131 RID: 4401 RVA: 0x00087230 File Offset: 0x00085430
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

	// Token: 0x06001132 RID: 4402 RVA: 0x00087264 File Offset: 0x00085464
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Distorted");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001133 RID: 4403 RVA: 0x00087288 File Offset: 0x00085488
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetFloat("_RGB", this.RGB);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001134 RID: 4404 RVA: 0x00087324 File Offset: 0x00085524
	private void Update()
	{
	}

	// Token: 0x06001135 RID: 4405 RVA: 0x00087326 File Offset: 0x00085526
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015D4 RID: 5588
	public Shader SCShader;

	// Token: 0x040015D5 RID: 5589
	private float TimeX = 1f;

	// Token: 0x040015D6 RID: 5590
	[Range(0f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015D7 RID: 5591
	[Range(-0.01f, 0.01f)]
	public float RGB = 0.002f;

	// Token: 0x040015D8 RID: 5592
	private Material SCMaterial;
}
