using System;
using UnityEngine;

// Token: 0x0200020D RID: 525
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Distorted")]
public class CameraFilterPack_TV_Distorted : MonoBehaviour
{
	// Token: 0x17000311 RID: 785
	// (get) Token: 0x06001133 RID: 4403 RVA: 0x000876AC File Offset: 0x000858AC
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

	// Token: 0x06001134 RID: 4404 RVA: 0x000876E0 File Offset: 0x000858E0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Distorted");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001135 RID: 4405 RVA: 0x00087704 File Offset: 0x00085904
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

	// Token: 0x06001136 RID: 4406 RVA: 0x000877A0 File Offset: 0x000859A0
	private void Update()
	{
	}

	// Token: 0x06001137 RID: 4407 RVA: 0x000877A2 File Offset: 0x000859A2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015DB RID: 5595
	public Shader SCShader;

	// Token: 0x040015DC RID: 5596
	private float TimeX = 1f;

	// Token: 0x040015DD RID: 5597
	[Range(0f, 10f)]
	public float Distortion = 1f;

	// Token: 0x040015DE RID: 5598
	[Range(-0.01f, 0.01f)]
	public float RGB = 0.002f;

	// Token: 0x040015DF RID: 5599
	private Material SCMaterial;
}
