using System;
using UnityEngine;

// Token: 0x02000192 RID: 402
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga3")]
public class CameraFilterPack_Drawing_Manga3 : MonoBehaviour
{
	// Token: 0x17000296 RID: 662
	// (get) Token: 0x06000E2B RID: 3627 RVA: 0x0007922C File Offset: 0x0007742C
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

	// Token: 0x06000E2C RID: 3628 RVA: 0x00079260 File Offset: 0x00077460
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E2D RID: 3629 RVA: 0x00079284 File Offset: 0x00077484
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

	// Token: 0x06000E2E RID: 3630 RVA: 0x0007930A File Offset: 0x0007750A
	private void Update()
	{
	}

	// Token: 0x06000E2F RID: 3631 RVA: 0x0007930C File Offset: 0x0007750C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001275 RID: 4725
	public Shader SCShader;

	// Token: 0x04001276 RID: 4726
	private float TimeX = 1f;

	// Token: 0x04001277 RID: 4727
	private Material SCMaterial;

	// Token: 0x04001278 RID: 4728
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
