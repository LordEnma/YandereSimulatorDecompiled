using System;
using UnityEngine;

// Token: 0x02000193 RID: 403
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga4")]
public class CameraFilterPack_Drawing_Manga4 : MonoBehaviour
{
	// Token: 0x17000297 RID: 663
	// (get) Token: 0x06000E33 RID: 3635 RVA: 0x000797C0 File Offset: 0x000779C0
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

	// Token: 0x06000E34 RID: 3636 RVA: 0x000797F4 File Offset: 0x000779F4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga4");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E35 RID: 3637 RVA: 0x00079818 File Offset: 0x00077A18
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

	// Token: 0x06000E36 RID: 3638 RVA: 0x0007989E File Offset: 0x00077A9E
	private void Update()
	{
	}

	// Token: 0x06000E37 RID: 3639 RVA: 0x000798A0 File Offset: 0x00077AA0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001280 RID: 4736
	public Shader SCShader;

	// Token: 0x04001281 RID: 4737
	private float TimeX = 1f;

	// Token: 0x04001282 RID: 4738
	private Material SCMaterial;

	// Token: 0x04001283 RID: 4739
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
