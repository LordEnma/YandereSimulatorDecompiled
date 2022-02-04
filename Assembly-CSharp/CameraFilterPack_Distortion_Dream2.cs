using System;
using UnityEngine;

// Token: 0x02000178 RID: 376
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Dream2")]
public class CameraFilterPack_Distortion_Dream2 : MonoBehaviour
{
	// Token: 0x1700027C RID: 636
	// (get) Token: 0x06000D8E RID: 3470 RVA: 0x0007690C File Offset: 0x00074B0C
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

	// Token: 0x06000D8F RID: 3471 RVA: 0x00076940 File Offset: 0x00074B40
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Dream2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D90 RID: 3472 RVA: 0x00076964 File Offset: 0x00074B64
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

	// Token: 0x06000D91 RID: 3473 RVA: 0x00076A30 File Offset: 0x00074C30
	private void Update()
	{
	}

	// Token: 0x06000D92 RID: 3474 RVA: 0x00076A32 File Offset: 0x00074C32
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011D5 RID: 4565
	public Shader SCShader;

	// Token: 0x040011D6 RID: 4566
	private float TimeX = 1f;

	// Token: 0x040011D7 RID: 4567
	private Material SCMaterial;

	// Token: 0x040011D8 RID: 4568
	[Range(0f, 100f)]
	public float Distortion = 6f;

	// Token: 0x040011D9 RID: 4569
	[Range(0f, 32f)]
	public float Speed = 5f;
}
