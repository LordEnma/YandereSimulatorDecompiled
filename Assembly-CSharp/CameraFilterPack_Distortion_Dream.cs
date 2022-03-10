using System;
using UnityEngine;

// Token: 0x02000177 RID: 375
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Dream")]
public class CameraFilterPack_Distortion_Dream : MonoBehaviour
{
	// Token: 0x1700027B RID: 635
	// (get) Token: 0x06000D89 RID: 3465 RVA: 0x00076BA3 File Offset: 0x00074DA3
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

	// Token: 0x06000D8A RID: 3466 RVA: 0x00076BD7 File Offset: 0x00074DD7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Dream");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D8B RID: 3467 RVA: 0x00076BF8 File Offset: 0x00074DF8
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

	// Token: 0x06000D8C RID: 3468 RVA: 0x00076C7E File Offset: 0x00074E7E
	private void Update()
	{
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x00076C80 File Offset: 0x00074E80
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011DD RID: 4573
	public Shader SCShader;

	// Token: 0x040011DE RID: 4574
	private float TimeX = 1f;

	// Token: 0x040011DF RID: 4575
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040011E0 RID: 4576
	private Material SCMaterial;
}
