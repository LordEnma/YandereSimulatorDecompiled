using System;
using UnityEngine;

// Token: 0x020001BF RID: 447
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Screens")]
public class CameraFilterPack_FX_Screens : MonoBehaviour
{
	// Token: 0x170002C3 RID: 707
	// (get) Token: 0x06000F3A RID: 3898 RVA: 0x0007D2EF File Offset: 0x0007B4EF
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

	// Token: 0x06000F3B RID: 3899 RVA: 0x0007D323 File Offset: 0x0007B523
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Screens");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F3C RID: 3900 RVA: 0x0007D344 File Offset: 0x0007B544
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

	// Token: 0x06000F3D RID: 3901 RVA: 0x0007D452 File Offset: 0x0007B652
	private void Update()
	{
	}

	// Token: 0x06000F3E RID: 3902 RVA: 0x0007D454 File Offset: 0x0007B654
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
	[Range(0f, 256f)]
	public float Tiles = 8f;

	// Token: 0x04001380 RID: 4992
	[Range(0f, 5f)]
	public float Speed = 0.25f;

	// Token: 0x04001381 RID: 4993
	public Color color = new Color(0f, 1f, 1f, 1f);

	// Token: 0x04001382 RID: 4994
	[Range(-1f, 1f)]
	public float PosX;

	// Token: 0x04001383 RID: 4995
	[Range(-1f, 1f)]
	public float PosY;
}
