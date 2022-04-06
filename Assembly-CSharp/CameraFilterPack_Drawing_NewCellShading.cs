using System;
using UnityEngine;

// Token: 0x02000199 RID: 409
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/NewCellShading")]
public class CameraFilterPack_Drawing_NewCellShading : MonoBehaviour
{
	// Token: 0x1700029D RID: 669
	// (get) Token: 0x06000E57 RID: 3671 RVA: 0x0007A0BC File Offset: 0x000782BC
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

	// Token: 0x06000E58 RID: 3672 RVA: 0x0007A0F0 File Offset: 0x000782F0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_NewCellShading");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E59 RID: 3673 RVA: 0x0007A114 File Offset: 0x00078314
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
			this.material.SetFloat("_Threshold", this.Threshold);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E5A RID: 3674 RVA: 0x0007A1C3 File Offset: 0x000783C3
	private void Update()
	{
	}

	// Token: 0x06000E5B RID: 3675 RVA: 0x0007A1C5 File Offset: 0x000783C5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012A6 RID: 4774
	public Shader SCShader;

	// Token: 0x040012A7 RID: 4775
	private float TimeX = 1f;

	// Token: 0x040012A8 RID: 4776
	private Material SCMaterial;

	// Token: 0x040012A9 RID: 4777
	[Range(0f, 1f)]
	public float Threshold = 0.2f;
}
