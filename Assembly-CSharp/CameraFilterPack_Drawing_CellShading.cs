using System;
using UnityEngine;

// Token: 0x02000187 RID: 391
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/CellShading")]
public class CameraFilterPack_Drawing_CellShading : MonoBehaviour
{
	// Token: 0x1700028B RID: 651
	// (get) Token: 0x06000DE9 RID: 3561 RVA: 0x000780F5 File Offset: 0x000762F5
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

	// Token: 0x06000DEA RID: 3562 RVA: 0x00078129 File Offset: 0x00076329
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_CellShading");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DEB RID: 3563 RVA: 0x0007814C File Offset: 0x0007634C
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
			this.material.SetFloat("_EdgeSize", this.EdgeSize);
			this.material.SetFloat("_ColorLevel", this.ColorLevel);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DEC RID: 3564 RVA: 0x00078211 File Offset: 0x00076411
	private void Update()
	{
	}

	// Token: 0x06000DED RID: 3565 RVA: 0x00078213 File Offset: 0x00076413
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001233 RID: 4659
	public Shader SCShader;

	// Token: 0x04001234 RID: 4660
	private float TimeX = 1f;

	// Token: 0x04001235 RID: 4661
	private Material SCMaterial;

	// Token: 0x04001236 RID: 4662
	[Range(0f, 1f)]
	public float EdgeSize = 0.1f;

	// Token: 0x04001237 RID: 4663
	[Range(0f, 10f)]
	public float ColorLevel = 4f;
}
