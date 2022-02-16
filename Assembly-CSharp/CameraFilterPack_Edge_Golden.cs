using System;
using UnityEngine;

// Token: 0x020001A2 RID: 418
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Golden")]
public class CameraFilterPack_Edge_Golden : MonoBehaviour
{
	// Token: 0x170002A6 RID: 678
	// (get) Token: 0x06000E8C RID: 3724 RVA: 0x0007A9E9 File Offset: 0x00078BE9
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

	// Token: 0x06000E8D RID: 3725 RVA: 0x0007AA1D File Offset: 0x00078C1D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Golden");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E8E RID: 3726 RVA: 0x0007AA40 File Offset: 0x00078C40
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

	// Token: 0x06000E8F RID: 3727 RVA: 0x0007AAD6 File Offset: 0x00078CD6
	private void Update()
	{
	}

	// Token: 0x06000E90 RID: 3728 RVA: 0x0007AAD8 File Offset: 0x00078CD8
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
