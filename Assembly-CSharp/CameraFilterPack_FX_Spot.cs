using System;
using UnityEngine;

// Token: 0x020001BF RID: 447
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Spot")]
public class CameraFilterPack_FX_Spot : MonoBehaviour
{
	// Token: 0x170002C4 RID: 708
	// (get) Token: 0x06000F3C RID: 3900 RVA: 0x0007D17B File Offset: 0x0007B37B
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

	// Token: 0x06000F3D RID: 3901 RVA: 0x0007D1AF File Offset: 0x0007B3AF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Spot");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F3E RID: 3902 RVA: 0x0007D1D0 File Offset: 0x0007B3D0
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

	// Token: 0x06000F3F RID: 3903 RVA: 0x0007D2BC File Offset: 0x0007B4BC
	private void Update()
	{
	}

	// Token: 0x06000F40 RID: 3904 RVA: 0x0007D2BE File Offset: 0x0007B4BE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400137C RID: 4988
	public Shader SCShader;

	// Token: 0x0400137D RID: 4989
	private float TimeX = 1f;

	// Token: 0x0400137E RID: 4990
	private Material SCMaterial;

	// Token: 0x0400137F RID: 4991
	public Vector2 center = new Vector2(0.5f, 0.5f);

	// Token: 0x04001380 RID: 4992
	public float Radius = 0.2f;
}
