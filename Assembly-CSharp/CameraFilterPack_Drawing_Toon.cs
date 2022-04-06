using System;
using UnityEngine;

// Token: 0x0200019D RID: 413
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Toon")]
public class CameraFilterPack_Drawing_Toon : MonoBehaviour
{
	// Token: 0x170002A1 RID: 673
	// (get) Token: 0x06000E6F RID: 3695 RVA: 0x0007A95A File Offset: 0x00078B5A
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

	// Token: 0x06000E70 RID: 3696 RVA: 0x0007A98E File Offset: 0x00078B8E
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Toon");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E71 RID: 3697 RVA: 0x0007A9B0 File Offset: 0x00078BB0
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
			this.material.SetFloat("_Distortion", this.Threshold);
			this.material.SetFloat("_DotSize", this.DotSize);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E72 RID: 3698 RVA: 0x0007AA4C File Offset: 0x00078C4C
	private void Update()
	{
	}

	// Token: 0x06000E73 RID: 3699 RVA: 0x0007AA4E File Offset: 0x00078C4E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012D1 RID: 4817
	public Shader SCShader;

	// Token: 0x040012D2 RID: 4818
	private Material SCMaterial;

	// Token: 0x040012D3 RID: 4819
	private float TimeX = 1f;

	// Token: 0x040012D4 RID: 4820
	[Range(0f, 2f)]
	public float Threshold = 1f;

	// Token: 0x040012D5 RID: 4821
	[Range(0f, 8f)]
	public float DotSize = 1f;
}
