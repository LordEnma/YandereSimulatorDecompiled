using System;
using UnityEngine;

// Token: 0x0200014A RID: 330
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/DitherOffset")]
public class CameraFilterPack_Blur_DitherOffset : MonoBehaviour
{
	// Token: 0x1700024E RID: 590
	// (get) Token: 0x06000C79 RID: 3193 RVA: 0x00071EA1 File Offset: 0x000700A1
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

	// Token: 0x06000C7A RID: 3194 RVA: 0x00071ED5 File Offset: 0x000700D5
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_DitherOffset");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C7B RID: 3195 RVA: 0x00071EF8 File Offset: 0x000700F8
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
			this.material.SetFloat("_Level", (float)this.Level);
			this.material.SetVector("_Distance", this.Distance);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C7C RID: 3196 RVA: 0x00071FCA File Offset: 0x000701CA
	private void Update()
	{
	}

	// Token: 0x06000C7D RID: 3197 RVA: 0x00071FCC File Offset: 0x000701CC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010C3 RID: 4291
	public Shader SCShader;

	// Token: 0x040010C4 RID: 4292
	private float TimeX = 1f;

	// Token: 0x040010C5 RID: 4293
	private Material SCMaterial;

	// Token: 0x040010C6 RID: 4294
	[Range(1f, 16f)]
	public int Level = 4;

	// Token: 0x040010C7 RID: 4295
	public Vector2 Distance = new Vector2(30f, 0f);
}
