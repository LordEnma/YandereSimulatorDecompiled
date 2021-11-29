using System;
using UnityEngine;

// Token: 0x02000176 RID: 374
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Dream")]
public class CameraFilterPack_Distortion_Dream : MonoBehaviour
{
	// Token: 0x1700027B RID: 635
	// (get) Token: 0x06000D85 RID: 3461 RVA: 0x000765FF File Offset: 0x000747FF
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

	// Token: 0x06000D86 RID: 3462 RVA: 0x00076633 File Offset: 0x00074833
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Dream");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D87 RID: 3463 RVA: 0x00076654 File Offset: 0x00074854
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

	// Token: 0x06000D88 RID: 3464 RVA: 0x000766DA File Offset: 0x000748DA
	private void Update()
	{
	}

	// Token: 0x06000D89 RID: 3465 RVA: 0x000766DC File Offset: 0x000748DC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011CC RID: 4556
	public Shader SCShader;

	// Token: 0x040011CD RID: 4557
	private float TimeX = 1f;

	// Token: 0x040011CE RID: 4558
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040011CF RID: 4559
	private Material SCMaterial;
}
