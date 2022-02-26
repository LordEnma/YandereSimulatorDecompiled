using System;
using UnityEngine;

// Token: 0x02000194 RID: 404
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga5")]
public class CameraFilterPack_Drawing_Manga5 : MonoBehaviour
{
	// Token: 0x17000298 RID: 664
	// (get) Token: 0x06000E37 RID: 3639 RVA: 0x00079314 File Offset: 0x00077514
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

	// Token: 0x06000E38 RID: 3640 RVA: 0x00079348 File Offset: 0x00077548
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga5");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E39 RID: 3641 RVA: 0x0007936C File Offset: 0x0007756C
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

	// Token: 0x06000E3A RID: 3642 RVA: 0x000793F2 File Offset: 0x000775F2
	private void Update()
	{
	}

	// Token: 0x06000E3B RID: 3643 RVA: 0x000793F4 File Offset: 0x000775F4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001274 RID: 4724
	public Shader SCShader;

	// Token: 0x04001275 RID: 4725
	private float TimeX = 1f;

	// Token: 0x04001276 RID: 4726
	private Material SCMaterial;

	// Token: 0x04001277 RID: 4727
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
