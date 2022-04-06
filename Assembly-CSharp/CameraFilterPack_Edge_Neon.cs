using System;
using UnityEngine;

// Token: 0x020001A3 RID: 419
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Neon")]
public class CameraFilterPack_Edge_Neon : MonoBehaviour
{
	// Token: 0x170002A7 RID: 679
	// (get) Token: 0x06000E94 RID: 3732 RVA: 0x0007B1DD File Offset: 0x000793DD
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

	// Token: 0x06000E95 RID: 3733 RVA: 0x0007B211 File Offset: 0x00079411
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Neon");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E96 RID: 3734 RVA: 0x0007B234 File Offset: 0x00079434
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
			this.material.SetFloat("_EdgeWeight", this.EdgeWeight);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E97 RID: 3735 RVA: 0x0007B2E3 File Offset: 0x000794E3
	private void Update()
	{
	}

	// Token: 0x06000E98 RID: 3736 RVA: 0x0007B2E5 File Offset: 0x000794E5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012F3 RID: 4851
	public Shader SCShader;

	// Token: 0x040012F4 RID: 4852
	private float TimeX = 1f;

	// Token: 0x040012F5 RID: 4853
	private Material SCMaterial;

	// Token: 0x040012F6 RID: 4854
	[Range(1f, 10f)]
	public float EdgeWeight = 1f;
}
