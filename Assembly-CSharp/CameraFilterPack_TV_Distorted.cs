using System;
using UnityEngine;

// Token: 0x0200020D RID: 525
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Distorted")]
public class CameraFilterPack_TV_Distorted : MonoBehaviour
{
	// Token: 0x17000311 RID: 785
	// (get) Token: 0x06001130 RID: 4400 RVA: 0x00086E84 File Offset: 0x00085084
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

	// Token: 0x06001131 RID: 4401 RVA: 0x00086EB8 File Offset: 0x000850B8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Distorted");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001132 RID: 4402 RVA: 0x00086EDC File Offset: 0x000850DC
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
			this.material.SetFloat("_RGB", this.RGB);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001133 RID: 4403 RVA: 0x00086F78 File Offset: 0x00085178
	private void Update()
	{
	}

	// Token: 0x06001134 RID: 4404 RVA: 0x00086F7A File Offset: 0x0008517A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015C8 RID: 5576
	public Shader SCShader;

	// Token: 0x040015C9 RID: 5577
	private float TimeX = 1f;

	// Token: 0x040015CA RID: 5578
	[Range(0f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015CB RID: 5579
	[Range(-0.01f, 0.01f)]
	public float RGB = 0.002f;

	// Token: 0x040015CC RID: 5580
	private Material SCMaterial;
}
