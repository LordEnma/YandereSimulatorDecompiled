using System;
using UnityEngine;

// Token: 0x0200017C RID: 380
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Half_Sphere")]
public class CameraFilterPack_Distortion_Half_Sphere : MonoBehaviour
{
	// Token: 0x17000280 RID: 640
	// (get) Token: 0x06000DA6 RID: 3494 RVA: 0x00076E44 File Offset: 0x00075044
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

	// Token: 0x06000DA7 RID: 3495 RVA: 0x00076E78 File Offset: 0x00075078
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Half_Sphere");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DA8 RID: 3496 RVA: 0x00076E9C File Offset: 0x0007509C
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
			this.material.SetFloat("_SphereSize", this.SphereSize);
			this.material.SetFloat("_SpherePositionX", this.SpherePositionX);
			this.material.SetFloat("_SpherePositionY", this.SpherePositionY);
			this.material.SetFloat("_Strength", this.Strength);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DA9 RID: 3497 RVA: 0x00076F8D File Offset: 0x0007518D
	private void Update()
	{
	}

	// Token: 0x06000DAA RID: 3498 RVA: 0x00076F8F File Offset: 0x0007518F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011E7 RID: 4583
	public Shader SCShader;

	// Token: 0x040011E8 RID: 4584
	private float TimeX = 1f;

	// Token: 0x040011E9 RID: 4585
	[Range(1f, 6f)]
	private Material SCMaterial;

	// Token: 0x040011EA RID: 4586
	public float SphereSize = 2.5f;

	// Token: 0x040011EB RID: 4587
	[Range(-1f, 1f)]
	public float SpherePositionX;

	// Token: 0x040011EC RID: 4588
	[Range(-1f, 1f)]
	public float SpherePositionY;

	// Token: 0x040011ED RID: 4589
	[Range(1f, 10f)]
	public float Strength = 5f;
}
