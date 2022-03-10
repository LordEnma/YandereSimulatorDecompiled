using System;
using UnityEngine;

// Token: 0x020001A0 RID: 416
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/BlackLine")]
public class CameraFilterPack_Edge_BlackLine : MonoBehaviour
{
	// Token: 0x170002A4 RID: 676
	// (get) Token: 0x06000E80 RID: 3712 RVA: 0x0007A9BD File Offset: 0x00078BBD
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

	// Token: 0x06000E81 RID: 3713 RVA: 0x0007A9F1 File Offset: 0x00078BF1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_BlackLine");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E82 RID: 3714 RVA: 0x0007AA14 File Offset: 0x00078C14
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
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E83 RID: 3715 RVA: 0x0007AAAA File Offset: 0x00078CAA
	private void Update()
	{
	}

	// Token: 0x06000E84 RID: 3716 RVA: 0x0007AAAC File Offset: 0x00078CAC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012E0 RID: 4832
	public Shader SCShader;

	// Token: 0x040012E1 RID: 4833
	private float TimeX = 1f;

	// Token: 0x040012E2 RID: 4834
	private Material SCMaterial;
}
