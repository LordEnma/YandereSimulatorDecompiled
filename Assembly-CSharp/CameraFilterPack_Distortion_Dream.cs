using System;
using UnityEngine;

// Token: 0x02000177 RID: 375
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Dream")]
public class CameraFilterPack_Distortion_Dream : MonoBehaviour
{
	// Token: 0x1700027B RID: 635
	// (get) Token: 0x06000D88 RID: 3464 RVA: 0x000767F7 File Offset: 0x000749F7
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

	// Token: 0x06000D89 RID: 3465 RVA: 0x0007682B File Offset: 0x00074A2B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Dream");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D8A RID: 3466 RVA: 0x0007684C File Offset: 0x00074A4C
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

	// Token: 0x06000D8B RID: 3467 RVA: 0x000768D2 File Offset: 0x00074AD2
	private void Update()
	{
	}

	// Token: 0x06000D8C RID: 3468 RVA: 0x000768D4 File Offset: 0x00074AD4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011D1 RID: 4561
	public Shader SCShader;

	// Token: 0x040011D2 RID: 4562
	private float TimeX = 1f;

	// Token: 0x040011D3 RID: 4563
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040011D4 RID: 4564
	private Material SCMaterial;
}
