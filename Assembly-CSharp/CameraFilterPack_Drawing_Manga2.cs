using System;
using UnityEngine;

// Token: 0x02000191 RID: 401
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga2")]
public class CameraFilterPack_Drawing_Manga2 : MonoBehaviour
{
	// Token: 0x17000295 RID: 661
	// (get) Token: 0x06000E27 RID: 3623 RVA: 0x00079590 File Offset: 0x00077790
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

	// Token: 0x06000E28 RID: 3624 RVA: 0x000795C4 File Offset: 0x000777C4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E29 RID: 3625 RVA: 0x000795E8 File Offset: 0x000777E8
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

	// Token: 0x06000E2A RID: 3626 RVA: 0x0007966E File Offset: 0x0007786E
	private void Update()
	{
	}

	// Token: 0x06000E2B RID: 3627 RVA: 0x00079670 File Offset: 0x00077870
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
	public float DotSize = 4.72f;
}
