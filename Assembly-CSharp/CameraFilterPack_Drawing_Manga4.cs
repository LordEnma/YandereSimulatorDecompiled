using System;
using UnityEngine;

// Token: 0x02000193 RID: 403
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga4")]
public class CameraFilterPack_Drawing_Manga4 : MonoBehaviour
{
	// Token: 0x17000297 RID: 663
	// (get) Token: 0x06000E31 RID: 3633 RVA: 0x000790E8 File Offset: 0x000772E8
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

	// Token: 0x06000E32 RID: 3634 RVA: 0x0007911C File Offset: 0x0007731C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga4");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E33 RID: 3635 RVA: 0x00079140 File Offset: 0x00077340
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

	// Token: 0x06000E34 RID: 3636 RVA: 0x000791C6 File Offset: 0x000773C6
	private void Update()
	{
	}

	// Token: 0x06000E35 RID: 3637 RVA: 0x000791C8 File Offset: 0x000773C8
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
	public float DotSize = 4.72f;
}
