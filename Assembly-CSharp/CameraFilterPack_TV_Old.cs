using System;
using UnityEngine;

// Token: 0x02000212 RID: 530
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Old Film/Old")]
public class CameraFilterPack_TV_Old : MonoBehaviour
{
	// Token: 0x17000316 RID: 790
	// (get) Token: 0x0600114F RID: 4431 RVA: 0x000877BC File Offset: 0x000859BC
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

	// Token: 0x06001150 RID: 4432 RVA: 0x000877F0 File Offset: 0x000859F0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Old");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001151 RID: 4433 RVA: 0x00087814 File Offset: 0x00085A14
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

	// Token: 0x06001152 RID: 4434 RVA: 0x0008789A File Offset: 0x00085A9A
	private void Update()
	{
	}

	// Token: 0x06001153 RID: 4435 RVA: 0x0008789C File Offset: 0x00085A9C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015E4 RID: 5604
	public Shader SCShader;

	// Token: 0x040015E5 RID: 5605
	private float TimeX = 1f;

	// Token: 0x040015E6 RID: 5606
	[Range(1f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015E7 RID: 5607
	private Material SCMaterial;
}
