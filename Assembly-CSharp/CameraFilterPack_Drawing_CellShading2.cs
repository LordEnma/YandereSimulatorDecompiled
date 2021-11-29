using System;
using UnityEngine;

// Token: 0x02000187 RID: 391
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/CellShading2")]
public class CameraFilterPack_Drawing_CellShading2 : MonoBehaviour
{
	// Token: 0x1700028C RID: 652
	// (get) Token: 0x06000DEB RID: 3563 RVA: 0x00077F0E File Offset: 0x0007610E
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

	// Token: 0x06000DEC RID: 3564 RVA: 0x00077F42 File Offset: 0x00076142
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_CellShading2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DED RID: 3565 RVA: 0x00077F64 File Offset: 0x00076164
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
			this.material.SetFloat("_Distortion", this.Blur);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DEE RID: 3566 RVA: 0x0007803F File Offset: 0x0007623F
	private void Update()
	{
	}

	// Token: 0x06000DEF RID: 3567 RVA: 0x00078041 File Offset: 0x00076241
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001230 RID: 4656
	public Shader SCShader;

	// Token: 0x04001231 RID: 4657
	private float TimeX = 1f;

	// Token: 0x04001232 RID: 4658
	private Material SCMaterial;

	// Token: 0x04001233 RID: 4659
	[Range(0f, 1f)]
	public float EdgeSize = 0.1f;

	// Token: 0x04001234 RID: 4660
	[Range(0f, 10f)]
	public float ColorLevel = 4f;

	// Token: 0x04001235 RID: 4661
	[Range(0f, 1f)]
	public float Blur = 1f;
}
