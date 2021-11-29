using System;
using UnityEngine;

// Token: 0x02000194 RID: 404
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga_Color")]
public class CameraFilterPack_Drawing_Manga_Color : MonoBehaviour
{
	// Token: 0x17000299 RID: 665
	// (get) Token: 0x06000E39 RID: 3641 RVA: 0x00078FD0 File Offset: 0x000771D0
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

	// Token: 0x06000E3A RID: 3642 RVA: 0x00079004 File Offset: 0x00077204
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga_Color");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E3B RID: 3643 RVA: 0x00079028 File Offset: 0x00077228
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

	// Token: 0x06000E3C RID: 3644 RVA: 0x000790AE File Offset: 0x000772AE
	private void Update()
	{
	}

	// Token: 0x06000E3D RID: 3645 RVA: 0x000790B0 File Offset: 0x000772B0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001270 RID: 4720
	public Shader SCShader;

	// Token: 0x04001271 RID: 4721
	private float TimeX = 1f;

	// Token: 0x04001272 RID: 4722
	private Material SCMaterial;

	// Token: 0x04001273 RID: 4723
	[Range(1f, 8f)]
	public float DotSize = 1.6f;

	// Token: 0x04001274 RID: 4724
	public static float ChangeDotSize;
}
