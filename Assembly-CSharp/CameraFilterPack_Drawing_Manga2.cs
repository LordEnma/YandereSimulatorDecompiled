using System;
using UnityEngine;

// Token: 0x02000191 RID: 401
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga2")]
public class CameraFilterPack_Drawing_Manga2 : MonoBehaviour
{
	// Token: 0x17000295 RID: 661
	// (get) Token: 0x06000E25 RID: 3621 RVA: 0x00079114 File Offset: 0x00077314
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

	// Token: 0x06000E26 RID: 3622 RVA: 0x00079148 File Offset: 0x00077348
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E27 RID: 3623 RVA: 0x0007916C File Offset: 0x0007736C
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

	// Token: 0x06000E28 RID: 3624 RVA: 0x000791F2 File Offset: 0x000773F2
	private void Update()
	{
	}

	// Token: 0x06000E29 RID: 3625 RVA: 0x000791F4 File Offset: 0x000773F4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001271 RID: 4721
	public Shader SCShader;

	// Token: 0x04001272 RID: 4722
	private float TimeX = 1f;

	// Token: 0x04001273 RID: 4723
	private Material SCMaterial;

	// Token: 0x04001274 RID: 4724
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
