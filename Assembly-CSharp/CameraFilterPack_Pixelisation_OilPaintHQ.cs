using System;
using UnityEngine;

// Token: 0x020001FA RID: 506
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/OilPaintHQ")]
public class CameraFilterPack_Pixelisation_OilPaintHQ : MonoBehaviour
{
	// Token: 0x170002FF RID: 767
	// (get) Token: 0x060010C0 RID: 4288 RVA: 0x00084C3C File Offset: 0x00082E3C
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

	// Token: 0x060010C1 RID: 4289 RVA: 0x00084C70 File Offset: 0x00082E70
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_OilPaintHQ");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010C2 RID: 4290 RVA: 0x00084C94 File Offset: 0x00082E94
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetFloat("_Value", this.Value);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010C3 RID: 4291 RVA: 0x00084D4A File Offset: 0x00082F4A
	private void Update()
	{
	}

	// Token: 0x060010C4 RID: 4292 RVA: 0x00084D4C File Offset: 0x00082F4C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001548 RID: 5448
	public Shader SCShader;

	// Token: 0x04001549 RID: 5449
	private float TimeX = 1f;

	// Token: 0x0400154A RID: 5450
	private Material SCMaterial;

	// Token: 0x0400154B RID: 5451
	[Range(0f, 5f)]
	public float Value = 2f;
}
