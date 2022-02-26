using System;
using UnityEngine;

// Token: 0x02000191 RID: 401
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga2")]
public class CameraFilterPack_Drawing_Manga2 : MonoBehaviour
{
	// Token: 0x17000295 RID: 661
	// (get) Token: 0x06000E25 RID: 3621 RVA: 0x00078FCC File Offset: 0x000771CC
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

	// Token: 0x06000E26 RID: 3622 RVA: 0x00079000 File Offset: 0x00077200
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E27 RID: 3623 RVA: 0x00079024 File Offset: 0x00077224
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

	// Token: 0x06000E28 RID: 3624 RVA: 0x000790AA File Offset: 0x000772AA
	private void Update()
	{
	}

	// Token: 0x06000E29 RID: 3625 RVA: 0x000790AC File Offset: 0x000772AC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001268 RID: 4712
	public Shader SCShader;

	// Token: 0x04001269 RID: 4713
	private float TimeX = 1f;

	// Token: 0x0400126A RID: 4714
	private Material SCMaterial;

	// Token: 0x0400126B RID: 4715
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
