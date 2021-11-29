using System;
using UnityEngine;

// Token: 0x0200019F RID: 415
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/BlackLine")]
public class CameraFilterPack_Edge_BlackLine : MonoBehaviour
{
	// Token: 0x170002A4 RID: 676
	// (get) Token: 0x06000E7C RID: 3708 RVA: 0x0007A419 File Offset: 0x00078619
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

	// Token: 0x06000E7D RID: 3709 RVA: 0x0007A44D File Offset: 0x0007864D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_BlackLine");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E7E RID: 3710 RVA: 0x0007A470 File Offset: 0x00078670
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
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E7F RID: 3711 RVA: 0x0007A506 File Offset: 0x00078706
	private void Update()
	{
	}

	// Token: 0x06000E80 RID: 3712 RVA: 0x0007A508 File Offset: 0x00078708
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012CF RID: 4815
	public Shader SCShader;

	// Token: 0x040012D0 RID: 4816
	private float TimeX = 1f;

	// Token: 0x040012D1 RID: 4817
	private Material SCMaterial;
}
