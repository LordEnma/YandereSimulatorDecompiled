using System;
using UnityEngine;

// Token: 0x02000188 RID: 392
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Comics")]
public class CameraFilterPack_Drawing_Comics : MonoBehaviour
{
	// Token: 0x1700028D RID: 653
	// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x0007808F File Offset: 0x0007628F
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

	// Token: 0x06000DF2 RID: 3570 RVA: 0x000780C3 File Offset: 0x000762C3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Comics");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DF3 RID: 3571 RVA: 0x000780E4 File Offset: 0x000762E4
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
			this.material.SetFloat("_DotSize", this.DotSize);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DF4 RID: 3572 RVA: 0x0007816A File Offset: 0x0007636A
	private void Update()
	{
	}

	// Token: 0x06000DF5 RID: 3573 RVA: 0x0007816C File Offset: 0x0007636C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001236 RID: 4662
	public Shader SCShader;

	// Token: 0x04001237 RID: 4663
	private float TimeX = 1f;

	// Token: 0x04001238 RID: 4664
	private Material SCMaterial;

	// Token: 0x04001239 RID: 4665
	[Range(0f, 1f)]
	public float DotSize = 0.5f;
}
