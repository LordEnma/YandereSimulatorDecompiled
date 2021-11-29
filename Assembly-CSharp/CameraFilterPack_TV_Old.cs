using System;
using UnityEngine;

// Token: 0x02000211 RID: 529
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Old")]
public class CameraFilterPack_TV_Old : MonoBehaviour
{
	// Token: 0x17000316 RID: 790
	// (get) Token: 0x0600114B RID: 4427 RVA: 0x00087360 File Offset: 0x00085560
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

	// Token: 0x0600114C RID: 4428 RVA: 0x00087394 File Offset: 0x00085594
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Old");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600114D RID: 4429 RVA: 0x000873B8 File Offset: 0x000855B8
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

	// Token: 0x0600114E RID: 4430 RVA: 0x0008743E File Offset: 0x0008563E
	private void Update()
	{
	}

	// Token: 0x0600114F RID: 4431 RVA: 0x00087440 File Offset: 0x00085640
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015DC RID: 5596
	public Shader SCShader;

	// Token: 0x040015DD RID: 5597
	private float TimeX = 1f;

	// Token: 0x040015DE RID: 5598
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015DF RID: 5599
	private Material SCMaterial;
}
