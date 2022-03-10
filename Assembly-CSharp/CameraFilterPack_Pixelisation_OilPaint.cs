using System;
using UnityEngine;

// Token: 0x020001FA RID: 506
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixelisation/OilPaint")]
public class CameraFilterPack_Pixelisation_OilPaint : MonoBehaviour
{
	// Token: 0x170002FE RID: 766
	// (get) Token: 0x060010BE RID: 4286 RVA: 0x0008509B File Offset: 0x0008329B
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

	// Token: 0x060010BF RID: 4287 RVA: 0x000850CF File Offset: 0x000832CF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Pixelisation_OilPaint");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010C0 RID: 4288 RVA: 0x000850F0 File Offset: 0x000832F0
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

	// Token: 0x060010C1 RID: 4289 RVA: 0x000851A6 File Offset: 0x000833A6
	private void Update()
	{
	}

	// Token: 0x060010C2 RID: 4290 RVA: 0x000851A8 File Offset: 0x000833A8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001555 RID: 5461
	public Shader SCShader;

	// Token: 0x04001556 RID: 5462
	private float TimeX = 1f;

	// Token: 0x04001557 RID: 5463
	private Material SCMaterial;

	// Token: 0x04001558 RID: 5464
	[Range(0f, 5f)]
	public float Value = 1f;
}
