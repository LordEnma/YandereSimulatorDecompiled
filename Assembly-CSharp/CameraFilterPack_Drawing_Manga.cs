using System;
using UnityEngine;

// Token: 0x02000190 RID: 400
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga")]
public class CameraFilterPack_Drawing_Manga : MonoBehaviour
{
	// Token: 0x17000294 RID: 660
	// (get) Token: 0x06000E1E RID: 3614 RVA: 0x00078C53 File Offset: 0x00076E53
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

	// Token: 0x06000E1F RID: 3615 RVA: 0x00078C87 File Offset: 0x00076E87
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E20 RID: 3616 RVA: 0x00078CA8 File Offset: 0x00076EA8
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

	// Token: 0x06000E21 RID: 3617 RVA: 0x00078D2E File Offset: 0x00076F2E
	private void Update()
	{
	}

	// Token: 0x06000E22 RID: 3618 RVA: 0x00078D30 File Offset: 0x00076F30
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001261 RID: 4705
	public Shader SCShader;

	// Token: 0x04001262 RID: 4706
	private float TimeX = 1f;

	// Token: 0x04001263 RID: 4707
	private Material SCMaterial;

	// Token: 0x04001264 RID: 4708
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
