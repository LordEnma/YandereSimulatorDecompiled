using System;
using UnityEngine;

// Token: 0x02000177 RID: 375
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Dream")]
public class CameraFilterPack_Distortion_Dream : MonoBehaviour
{
	// Token: 0x1700027B RID: 635
	// (get) Token: 0x06000D89 RID: 3465 RVA: 0x00076A5B File Offset: 0x00074C5B
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

	// Token: 0x06000D8A RID: 3466 RVA: 0x00076A8F File Offset: 0x00074C8F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Dream");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D8B RID: 3467 RVA: 0x00076AB0 File Offset: 0x00074CB0
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

	// Token: 0x06000D8C RID: 3468 RVA: 0x00076B36 File Offset: 0x00074D36
	private void Update()
	{
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x00076B38 File Offset: 0x00074D38
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011D4 RID: 4564
	public Shader SCShader;

	// Token: 0x040011D5 RID: 4565
	private float TimeX = 1f;

	// Token: 0x040011D6 RID: 4566
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040011D7 RID: 4567
	private Material SCMaterial;
}
