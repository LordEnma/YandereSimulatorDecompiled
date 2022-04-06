using System;
using UnityEngine;

// Token: 0x02000188 RID: 392
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/CellShading2")]
public class CameraFilterPack_Drawing_CellShading2 : MonoBehaviour
{
	// Token: 0x1700028C RID: 652
	// (get) Token: 0x06000DF1 RID: 3569 RVA: 0x0007892E File Offset: 0x00076B2E
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

	// Token: 0x06000DF2 RID: 3570 RVA: 0x00078962 File Offset: 0x00076B62
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_CellShading2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DF3 RID: 3571 RVA: 0x00078984 File Offset: 0x00076B84
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

	// Token: 0x06000DF4 RID: 3572 RVA: 0x00078A5F File Offset: 0x00076C5F
	private void Update()
	{
	}

	// Token: 0x06000DF5 RID: 3573 RVA: 0x00078A61 File Offset: 0x00076C61
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001248 RID: 4680
	public Shader SCShader;

	// Token: 0x04001249 RID: 4681
	private float TimeX = 1f;

	// Token: 0x0400124A RID: 4682
	private Material SCMaterial;

	// Token: 0x0400124B RID: 4683
	[Range(0f, 1f)]
	public float EdgeSize = 0.1f;

	// Token: 0x0400124C RID: 4684
	[Range(0f, 10f)]
	public float ColorLevel = 4f;

	// Token: 0x0400124D RID: 4685
	[Range(0f, 1f)]
	public float Blur = 1f;
}
