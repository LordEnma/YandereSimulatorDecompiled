using System;
using UnityEngine;

// Token: 0x02000190 RID: 400
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga")]
public class CameraFilterPack_Drawing_Manga : MonoBehaviour
{
	// Token: 0x17000294 RID: 660
	// (get) Token: 0x06000E21 RID: 3617 RVA: 0x0007947B File Offset: 0x0007767B
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

	// Token: 0x06000E22 RID: 3618 RVA: 0x000794AF File Offset: 0x000776AF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E23 RID: 3619 RVA: 0x000794D0 File Offset: 0x000776D0
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

	// Token: 0x06000E24 RID: 3620 RVA: 0x00079556 File Offset: 0x00077756
	private void Update()
	{
	}

	// Token: 0x06000E25 RID: 3621 RVA: 0x00079558 File Offset: 0x00077758
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001274 RID: 4724
	public Shader SCShader;

	// Token: 0x04001275 RID: 4725
	private float TimeX = 1f;

	// Token: 0x04001276 RID: 4726
	private Material SCMaterial;

	// Token: 0x04001277 RID: 4727
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
