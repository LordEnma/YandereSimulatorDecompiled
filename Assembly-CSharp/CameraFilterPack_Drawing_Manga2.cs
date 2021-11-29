using System;
using UnityEngine;

// Token: 0x02000190 RID: 400
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga2")]
public class CameraFilterPack_Drawing_Manga2 : MonoBehaviour
{
	// Token: 0x17000295 RID: 661
	// (get) Token: 0x06000E21 RID: 3617 RVA: 0x00078B70 File Offset: 0x00076D70
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

	// Token: 0x06000E22 RID: 3618 RVA: 0x00078BA4 File Offset: 0x00076DA4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E23 RID: 3619 RVA: 0x00078BC8 File Offset: 0x00076DC8
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

	// Token: 0x06000E24 RID: 3620 RVA: 0x00078C4E File Offset: 0x00076E4E
	private void Update()
	{
	}

	// Token: 0x06000E25 RID: 3621 RVA: 0x00078C50 File Offset: 0x00076E50
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001260 RID: 4704
	public Shader SCShader;

	// Token: 0x04001261 RID: 4705
	private float TimeX = 1f;

	// Token: 0x04001262 RID: 4706
	private Material SCMaterial;

	// Token: 0x04001263 RID: 4707
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
