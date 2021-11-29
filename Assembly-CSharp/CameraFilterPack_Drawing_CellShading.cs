using System;
using UnityEngine;

// Token: 0x02000186 RID: 390
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/CellShading")]
public class CameraFilterPack_Drawing_CellShading : MonoBehaviour
{
	// Token: 0x1700028B RID: 651
	// (get) Token: 0x06000DE5 RID: 3557 RVA: 0x00077DAD File Offset: 0x00075FAD
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

	// Token: 0x06000DE6 RID: 3558 RVA: 0x00077DE1 File Offset: 0x00075FE1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_CellShading");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DE7 RID: 3559 RVA: 0x00077E04 File Offset: 0x00076004
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

	// Token: 0x06000DE8 RID: 3560 RVA: 0x00077EC9 File Offset: 0x000760C9
	private void Update()
	{
	}

	// Token: 0x06000DE9 RID: 3561 RVA: 0x00077ECB File Offset: 0x000760CB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400122B RID: 4651
	public Shader SCShader;

	// Token: 0x0400122C RID: 4652
	private float TimeX = 1f;

	// Token: 0x0400122D RID: 4653
	private Material SCMaterial;

	// Token: 0x0400122E RID: 4654
	[Range(0f, 1f)]
	public float EdgeSize = 0.1f;

	// Token: 0x0400122F RID: 4655
	[Range(0f, 10f)]
	public float ColorLevel = 4f;
}
