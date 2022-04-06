using System;
using UnityEngine;

// Token: 0x020001BF RID: 447
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Screens")]
public class CameraFilterPack_FX_Screens : MonoBehaviour
{
	// Token: 0x170002C3 RID: 707
	// (get) Token: 0x06000F3C RID: 3900 RVA: 0x0007D9C7 File Offset: 0x0007BBC7
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

	// Token: 0x06000F3D RID: 3901 RVA: 0x0007D9FB File Offset: 0x0007BBFB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Screens");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F3E RID: 3902 RVA: 0x0007DA1C File Offset: 0x0007BC1C
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

	// Token: 0x06000F3F RID: 3903 RVA: 0x0007DB2A File Offset: 0x0007BD2A
	private void Update()
	{
	}

	// Token: 0x06000F40 RID: 3904 RVA: 0x0007DB2C File Offset: 0x0007BD2C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400138C RID: 5004
	public Shader SCShader;

	// Token: 0x0400138D RID: 5005
	private float TimeX = 1f;

	// Token: 0x0400138E RID: 5006
	private Material SCMaterial;

	// Token: 0x0400138F RID: 5007
	[Range(0f, 256f)]
	public float Tiles = 8f;

	// Token: 0x04001390 RID: 5008
	[Range(0f, 5f)]
	public float Speed = 0.25f;

	// Token: 0x04001391 RID: 5009
	public Color color = new Color(0f, 1f, 1f, 1f);

	// Token: 0x04001392 RID: 5010
	[Range(-1f, 1f)]
	public float PosX;

	// Token: 0x04001393 RID: 5011
	[Range(-1f, 1f)]
	public float PosY;
}
