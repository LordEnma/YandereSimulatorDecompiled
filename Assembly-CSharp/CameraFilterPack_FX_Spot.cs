using System;
using UnityEngine;

// Token: 0x020001C0 RID: 448
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Spot")]
public class CameraFilterPack_FX_Spot : MonoBehaviour
{
	// Token: 0x170002C4 RID: 708
	// (get) Token: 0x06000F3F RID: 3903 RVA: 0x0007D373 File Offset: 0x0007B573
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

	// Token: 0x06000F40 RID: 3904 RVA: 0x0007D3A7 File Offset: 0x0007B5A7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Spot");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F41 RID: 3905 RVA: 0x0007D3C8 File Offset: 0x0007B5C8
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
			this.material.SetFloat("_PositionX", this.center.x);
			this.material.SetFloat("_PositionY", this.center.y);
			this.material.SetFloat("_Radius", this.Radius);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F42 RID: 3906 RVA: 0x0007D4B4 File Offset: 0x0007B6B4
	private void Update()
	{
	}

	// Token: 0x06000F43 RID: 3907 RVA: 0x0007D4B6 File Offset: 0x0007B6B6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001381 RID: 4993
	public Shader SCShader;

	// Token: 0x04001382 RID: 4994
	private float TimeX = 1f;

	// Token: 0x04001383 RID: 4995
	private Material SCMaterial;

	// Token: 0x04001384 RID: 4996
	public Vector2 center = new Vector2(0.5f, 0.5f);

	// Token: 0x04001385 RID: 4997
	public float Radius = 0.2f;
}
