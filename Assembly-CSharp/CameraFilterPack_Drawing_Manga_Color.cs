using System;
using UnityEngine;

// Token: 0x02000195 RID: 405
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga_Color")]
public class CameraFilterPack_Drawing_Manga_Color : MonoBehaviour
{
	// Token: 0x17000299 RID: 665
	// (get) Token: 0x06000E3D RID: 3645 RVA: 0x0007942C File Offset: 0x0007762C
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

	// Token: 0x06000E3E RID: 3646 RVA: 0x00079460 File Offset: 0x00077660
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga_Color");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E3F RID: 3647 RVA: 0x00079484 File Offset: 0x00077684
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

	// Token: 0x06000E40 RID: 3648 RVA: 0x0007950A File Offset: 0x0007770A
	private void Update()
	{
	}

	// Token: 0x06000E41 RID: 3649 RVA: 0x0007950C File Offset: 0x0007770C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001278 RID: 4728
	public Shader SCShader;

	// Token: 0x04001279 RID: 4729
	private float TimeX = 1f;

	// Token: 0x0400127A RID: 4730
	private Material SCMaterial;

	// Token: 0x0400127B RID: 4731
	[Range(1f, 8f)]
	public float DotSize = 1.6f;

	// Token: 0x0400127C RID: 4732
	public static float ChangeDotSize;
}
