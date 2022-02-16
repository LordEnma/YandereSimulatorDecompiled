using System;
using UnityEngine;

// Token: 0x020001A3 RID: 419
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Neon")]
public class CameraFilterPack_Edge_Neon : MonoBehaviour
{
	// Token: 0x170002A7 RID: 679
	// (get) Token: 0x06000E92 RID: 3730 RVA: 0x0007AB05 File Offset: 0x00078D05
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

	// Token: 0x06000E93 RID: 3731 RVA: 0x0007AB39 File Offset: 0x00078D39
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Neon");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E94 RID: 3732 RVA: 0x0007AB5C File Offset: 0x00078D5C
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

	// Token: 0x06000E95 RID: 3733 RVA: 0x0007AC0B File Offset: 0x00078E0B
	private void Update()
	{
	}

	// Token: 0x06000E96 RID: 3734 RVA: 0x0007AC0D File Offset: 0x00078E0D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012E3 RID: 4835
	public Shader SCShader;

	// Token: 0x040012E4 RID: 4836
	private float TimeX = 1f;

	// Token: 0x040012E5 RID: 4837
	private Material SCMaterial;

	// Token: 0x040012E6 RID: 4838
	[Range(1f, 10f)]
	public float EdgeWeight = 1f;
}
