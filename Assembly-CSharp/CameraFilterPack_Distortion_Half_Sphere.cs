using System;
using UnityEngine;

// Token: 0x0200017B RID: 379
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Half_Sphere")]
public class CameraFilterPack_Distortion_Half_Sphere : MonoBehaviour
{
	// Token: 0x17000280 RID: 640
	// (get) Token: 0x06000DA3 RID: 3491 RVA: 0x00076C4C File Offset: 0x00074E4C
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

	// Token: 0x06000DA4 RID: 3492 RVA: 0x00076C80 File Offset: 0x00074E80
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Half_Sphere");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DA5 RID: 3493 RVA: 0x00076CA4 File Offset: 0x00074EA4
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

	// Token: 0x06000DA6 RID: 3494 RVA: 0x00076D95 File Offset: 0x00074F95
	private void Update()
	{
	}

	// Token: 0x06000DA7 RID: 3495 RVA: 0x00076D97 File Offset: 0x00074F97
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011E2 RID: 4578
	public Shader SCShader;

	// Token: 0x040011E3 RID: 4579
	private float TimeX = 1f;

	// Token: 0x040011E4 RID: 4580
	[Range(1f, 6f)]
	private Material SCMaterial;

	// Token: 0x040011E5 RID: 4581
	public float SphereSize = 2.5f;

	// Token: 0x040011E6 RID: 4582
	[Range(-1f, 1f)]
	public float SpherePositionX;

	// Token: 0x040011E7 RID: 4583
	[Range(-1f, 1f)]
	public float SpherePositionY;

	// Token: 0x040011E8 RID: 4584
	[Range(1f, 10f)]
	public float Strength = 5f;
}
