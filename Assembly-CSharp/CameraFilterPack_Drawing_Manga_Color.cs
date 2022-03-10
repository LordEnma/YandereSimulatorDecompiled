using System;
using UnityEngine;

// Token: 0x02000195 RID: 405
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga_Color")]
public class CameraFilterPack_Drawing_Manga_Color : MonoBehaviour
{
	// Token: 0x17000299 RID: 665
	// (get) Token: 0x06000E3D RID: 3645 RVA: 0x00079574 File Offset: 0x00077774
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

	// Token: 0x06000E3E RID: 3646 RVA: 0x000795A8 File Offset: 0x000777A8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga_Color");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E3F RID: 3647 RVA: 0x000795CC File Offset: 0x000777CC
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

	// Token: 0x06000E40 RID: 3648 RVA: 0x00079652 File Offset: 0x00077852
	private void Update()
	{
	}

	// Token: 0x06000E41 RID: 3649 RVA: 0x00079654 File Offset: 0x00077854
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001281 RID: 4737
	public Shader SCShader;

	// Token: 0x04001282 RID: 4738
	private float TimeX = 1f;

	// Token: 0x04001283 RID: 4739
	private Material SCMaterial;

	// Token: 0x04001284 RID: 4740
	[Range(1f, 8f)]
	public float DotSize = 1.6f;

	// Token: 0x04001285 RID: 4741
	public static float ChangeDotSize;
}
