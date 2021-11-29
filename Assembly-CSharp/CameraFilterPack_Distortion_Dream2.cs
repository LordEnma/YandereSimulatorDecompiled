using System;
using UnityEngine;

// Token: 0x02000177 RID: 375
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Dream2")]
public class CameraFilterPack_Distortion_Dream2 : MonoBehaviour
{
	// Token: 0x1700027C RID: 636
	// (get) Token: 0x06000D8B RID: 3467 RVA: 0x00076714 File Offset: 0x00074914
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

	// Token: 0x06000D8C RID: 3468 RVA: 0x00076748 File Offset: 0x00074948
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Dream2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x0007676C File Offset: 0x0007496C
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
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D8E RID: 3470 RVA: 0x00076838 File Offset: 0x00074A38
	private void Update()
	{
	}

	// Token: 0x06000D8F RID: 3471 RVA: 0x0007683A File Offset: 0x00074A3A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011D0 RID: 4560
	public Shader SCShader;

	// Token: 0x040011D1 RID: 4561
	private float TimeX = 1f;

	// Token: 0x040011D2 RID: 4562
	private Material SCMaterial;

	// Token: 0x040011D3 RID: 4563
	[Range(0f, 100f)]
	public float Distortion = 6f;

	// Token: 0x040011D4 RID: 4564
	[Range(0f, 32f)]
	public float Speed = 5f;
}
