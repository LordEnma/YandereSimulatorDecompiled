using System;
using UnityEngine;

// Token: 0x020001BF RID: 447
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Screens")]
public class CameraFilterPack_FX_Screens : MonoBehaviour
{
	// Token: 0x170002C3 RID: 707
	// (get) Token: 0x06000F3A RID: 3898 RVA: 0x0007D54B File Offset: 0x0007B74B
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

	// Token: 0x06000F3B RID: 3899 RVA: 0x0007D57F File Offset: 0x0007B77F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Screens");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F3C RID: 3900 RVA: 0x0007D5A0 File Offset: 0x0007B7A0
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
			this.material.SetFloat("_Value", this.Tiles);
			this.material.SetFloat("_Value2", this.Speed);
			this.material.SetFloat("_Value3", this.PosX);
			this.material.SetFloat("_Value4", this.PosY);
			this.material.SetColor("_color", this.color);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F3D RID: 3901 RVA: 0x0007D6AE File Offset: 0x0007B8AE
	private void Update()
	{
	}

	// Token: 0x06000F3E RID: 3902 RVA: 0x0007D6B0 File Offset: 0x0007B8B0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001385 RID: 4997
	public Shader SCShader;

	// Token: 0x04001386 RID: 4998
	private float TimeX = 1f;

	// Token: 0x04001387 RID: 4999
	private Material SCMaterial;

	// Token: 0x04001388 RID: 5000
	[Range(0f, 256f)]
	public float Tiles = 8f;

	// Token: 0x04001389 RID: 5001
	[Range(0f, 5f)]
	public float Speed = 0.25f;

	// Token: 0x0400138A RID: 5002
	public Color color = new Color(0f, 1f, 1f, 1f);

	// Token: 0x0400138B RID: 5003
	[Range(-1f, 1f)]
	public float PosX;

	// Token: 0x0400138C RID: 5004
	[Range(-1f, 1f)]
	public float PosY;
}
