using System;
using UnityEngine;

// Token: 0x02000177 RID: 375
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Dream")]
public class CameraFilterPack_Distortion_Dream : MonoBehaviour
{
	// Token: 0x1700027B RID: 635
	// (get) Token: 0x06000D8B RID: 3467 RVA: 0x0007701F File Offset: 0x0007521F
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

	// Token: 0x06000D8C RID: 3468 RVA: 0x00077053 File Offset: 0x00075253
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Dream");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x00077074 File Offset: 0x00075274
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
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D8E RID: 3470 RVA: 0x000770FA File Offset: 0x000752FA
	private void Update()
	{
	}

	// Token: 0x06000D8F RID: 3471 RVA: 0x000770FC File Offset: 0x000752FC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011E4 RID: 4580
	public Shader SCShader;

	// Token: 0x040011E5 RID: 4581
	private float TimeX = 1f;

	// Token: 0x040011E6 RID: 4582
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040011E7 RID: 4583
	private Material SCMaterial;
}
