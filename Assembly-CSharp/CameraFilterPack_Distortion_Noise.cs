using System;
using UnityEngine;

// Token: 0x0200017F RID: 383
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Noise")]
public class CameraFilterPack_Distortion_Noise : MonoBehaviour
{
	// Token: 0x17000283 RID: 643
	// (get) Token: 0x06000DBB RID: 3515 RVA: 0x00077AAD File Offset: 0x00075CAD
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

	// Token: 0x06000DBC RID: 3516 RVA: 0x00077AE1 File Offset: 0x00075CE1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DBD RID: 3517 RVA: 0x00077B04 File Offset: 0x00075D04
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DBE RID: 3518 RVA: 0x00077BB3 File Offset: 0x00075DB3
	private void Update()
	{
	}

	// Token: 0x06000DBF RID: 3519 RVA: 0x00077BB5 File Offset: 0x00075DB5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400120B RID: 4619
	public Shader SCShader;

	// Token: 0x0400120C RID: 4620
	private float TimeX = 1f;

	// Token: 0x0400120D RID: 4621
	private Material SCMaterial;

	// Token: 0x0400120E RID: 4622
	[Range(0f, 3f)]
	public float Distortion = 1f;
}
