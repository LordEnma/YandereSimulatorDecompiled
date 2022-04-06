using System;
using UnityEngine;

// Token: 0x02000187 RID: 391
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/CellShading")]
public class CameraFilterPack_Drawing_CellShading : MonoBehaviour
{
	// Token: 0x1700028B RID: 651
	// (get) Token: 0x06000DEB RID: 3563 RVA: 0x000787CD File Offset: 0x000769CD
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

	// Token: 0x06000DEC RID: 3564 RVA: 0x00078801 File Offset: 0x00076A01
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_CellShading");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DED RID: 3565 RVA: 0x00078824 File Offset: 0x00076A24
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

	// Token: 0x06000DEE RID: 3566 RVA: 0x000788E9 File Offset: 0x00076AE9
	private void Update()
	{
	}

	// Token: 0x06000DEF RID: 3567 RVA: 0x000788EB File Offset: 0x00076AEB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001243 RID: 4675
	public Shader SCShader;

	// Token: 0x04001244 RID: 4676
	private float TimeX = 1f;

	// Token: 0x04001245 RID: 4677
	private Material SCMaterial;

	// Token: 0x04001246 RID: 4678
	[Range(0f, 1f)]
	public float EdgeSize = 0.1f;

	// Token: 0x04001247 RID: 4679
	[Range(0f, 10f)]
	public float ColorLevel = 4f;
}
