using System;
using UnityEngine;

// Token: 0x020001A2 RID: 418
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Neon")]
public class CameraFilterPack_Edge_Neon : MonoBehaviour
{
	// Token: 0x170002A7 RID: 679
	// (get) Token: 0x06000E8E RID: 3726 RVA: 0x0007A7BD File Offset: 0x000789BD
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

	// Token: 0x06000E8F RID: 3727 RVA: 0x0007A7F1 File Offset: 0x000789F1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Neon");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E90 RID: 3728 RVA: 0x0007A814 File Offset: 0x00078A14
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

	// Token: 0x06000E91 RID: 3729 RVA: 0x0007A8C3 File Offset: 0x00078AC3
	private void Update()
	{
	}

	// Token: 0x06000E92 RID: 3730 RVA: 0x0007A8C5 File Offset: 0x00078AC5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012DB RID: 4827
	public Shader SCShader;

	// Token: 0x040012DC RID: 4828
	private float TimeX = 1f;

	// Token: 0x040012DD RID: 4829
	private Material SCMaterial;

	// Token: 0x040012DE RID: 4830
	[Range(1f, 10f)]
	public float EdgeWeight = 1f;
}
