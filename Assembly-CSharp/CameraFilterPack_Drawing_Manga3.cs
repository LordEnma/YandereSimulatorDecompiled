using System;
using UnityEngine;

// Token: 0x02000191 RID: 401
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga3")]
public class CameraFilterPack_Drawing_Manga3 : MonoBehaviour
{
	// Token: 0x17000296 RID: 662
	// (get) Token: 0x06000E27 RID: 3623 RVA: 0x00078C88 File Offset: 0x00076E88
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

	// Token: 0x06000E28 RID: 3624 RVA: 0x00078CBC File Offset: 0x00076EBC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E29 RID: 3625 RVA: 0x00078CE0 File Offset: 0x00076EE0
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

	// Token: 0x06000E2A RID: 3626 RVA: 0x00078D66 File Offset: 0x00076F66
	private void Update()
	{
	}

	// Token: 0x06000E2B RID: 3627 RVA: 0x00078D68 File Offset: 0x00076F68
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001264 RID: 4708
	public Shader SCShader;

	// Token: 0x04001265 RID: 4709
	private float TimeX = 1f;

	// Token: 0x04001266 RID: 4710
	private Material SCMaterial;

	// Token: 0x04001267 RID: 4711
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
