using System;
using UnityEngine;

// Token: 0x02000224 RID: 548
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/Tracking")]
public class CameraFilterPack_VHS_Tracking : MonoBehaviour
{
	// Token: 0x17000328 RID: 808
	// (get) Token: 0x060011BB RID: 4539 RVA: 0x00089013 File Offset: 0x00087213
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

	// Token: 0x060011BC RID: 4540 RVA: 0x00089047 File Offset: 0x00087247
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/VHS_Tracking");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011BD RID: 4541 RVA: 0x00089068 File Offset: 0x00087268
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
			this.material.SetFloat("_Value", this.Tracking);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011BE RID: 4542 RVA: 0x0008911E File Offset: 0x0008731E
	private void Update()
	{
	}

	// Token: 0x060011BF RID: 4543 RVA: 0x00089120 File Offset: 0x00087320
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001649 RID: 5705
	public Shader SCShader;

	// Token: 0x0400164A RID: 5706
	private float TimeX = 1f;

	// Token: 0x0400164B RID: 5707
	private Material SCMaterial;

	// Token: 0x0400164C RID: 5708
	[Range(0f, 2f)]
	public float Tracking = 1f;
}
