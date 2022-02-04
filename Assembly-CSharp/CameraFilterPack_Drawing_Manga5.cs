using System;
using UnityEngine;

// Token: 0x02000194 RID: 404
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga5")]
public class CameraFilterPack_Drawing_Manga5 : MonoBehaviour
{
	// Token: 0x17000298 RID: 664
	// (get) Token: 0x06000E36 RID: 3638 RVA: 0x000790B0 File Offset: 0x000772B0
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

	// Token: 0x06000E37 RID: 3639 RVA: 0x000790E4 File Offset: 0x000772E4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga5");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E38 RID: 3640 RVA: 0x00079108 File Offset: 0x00077308
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

	// Token: 0x06000E39 RID: 3641 RVA: 0x0007918E File Offset: 0x0007738E
	private void Update()
	{
	}

	// Token: 0x06000E3A RID: 3642 RVA: 0x00079190 File Offset: 0x00077390
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001271 RID: 4721
	public Shader SCShader;

	// Token: 0x04001272 RID: 4722
	private float TimeX = 1f;

	// Token: 0x04001273 RID: 4723
	private Material SCMaterial;

	// Token: 0x04001274 RID: 4724
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
