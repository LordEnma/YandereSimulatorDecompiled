using System;
using UnityEngine;

// Token: 0x0200020C RID: 524
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Distorted")]
public class CameraFilterPack_TV_Distorted : MonoBehaviour
{
	// Token: 0x17000311 RID: 785
	// (get) Token: 0x0600112D RID: 4397 RVA: 0x00086C8C File Offset: 0x00084E8C
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

	// Token: 0x0600112E RID: 4398 RVA: 0x00086CC0 File Offset: 0x00084EC0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Distorted");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600112F RID: 4399 RVA: 0x00086CE4 File Offset: 0x00084EE4
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

	// Token: 0x06001130 RID: 4400 RVA: 0x00086D80 File Offset: 0x00084F80
	private void Update()
	{
	}

	// Token: 0x06001131 RID: 4401 RVA: 0x00086D82 File Offset: 0x00084F82
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015C3 RID: 5571
	public Shader SCShader;

	// Token: 0x040015C4 RID: 5572
	private float TimeX = 1f;

	// Token: 0x040015C5 RID: 5573
	[Range(0f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015C6 RID: 5574
	[Range(-0.01f, 0.01f)]
	public float RGB = 0.002f;

	// Token: 0x040015C7 RID: 5575
	private Material SCMaterial;
}
