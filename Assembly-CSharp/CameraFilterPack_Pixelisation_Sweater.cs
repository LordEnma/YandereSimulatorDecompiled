using System;
using UnityEngine;

// Token: 0x020001FB RID: 507
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/Pixelisation_Sweater")]
public class CameraFilterPack_Pixelisation_Sweater : MonoBehaviour
{
	// Token: 0x17000300 RID: 768
	// (get) Token: 0x060010C6 RID: 4294 RVA: 0x00084D84 File Offset: 0x00082F84
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

	// Token: 0x060010C7 RID: 4295 RVA: 0x00084DB8 File Offset: 0x00082FB8
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Sweater") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_Sweater");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010C8 RID: 4296 RVA: 0x00084DF0 File Offset: 0x00082FF0
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
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetFloat("_SweaterSize", this.SweaterSize);
			this.material.SetFloat("_Intensity", this._Intensity);
			this.material.SetTexture("Texture2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010C9 RID: 4297 RVA: 0x00084EBB File Offset: 0x000830BB
	private void Update()
	{
	}

	// Token: 0x060010CA RID: 4298 RVA: 0x00084EBD File Offset: 0x000830BD
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400154C RID: 5452
	public Shader SCShader;

	// Token: 0x0400154D RID: 5453
	private float TimeX = 1f;

	// Token: 0x0400154E RID: 5454
	private Material SCMaterial;

	// Token: 0x0400154F RID: 5455
	[Range(16f, 128f)]
	public float SweaterSize = 64f;

	// Token: 0x04001550 RID: 5456
	[Range(0f, 2f)]
	public float _Intensity = 1.4f;

	// Token: 0x04001551 RID: 5457
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001552 RID: 5458
	private Texture2D Texture2;
}
