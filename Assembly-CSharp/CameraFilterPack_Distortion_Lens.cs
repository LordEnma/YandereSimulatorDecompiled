using System;
using UnityEngine;

// Token: 0x0200017E RID: 382
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Lens")]
public class CameraFilterPack_Distortion_Lens : MonoBehaviour
{
	// Token: 0x17000282 RID: 642
	// (get) Token: 0x06000DB5 RID: 3509 RVA: 0x00077940 File Offset: 0x00075B40
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

	// Token: 0x06000DB6 RID: 3510 RVA: 0x00077974 File Offset: 0x00075B74
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Lens");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DB7 RID: 3511 RVA: 0x00077998 File Offset: 0x00075B98
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
			this.material.SetFloat("_CenterX", this.CenterX);
			this.material.SetFloat("_CenterY", this.CenterY);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DB8 RID: 3512 RVA: 0x00077A73 File Offset: 0x00075C73
	private void Update()
	{
	}

	// Token: 0x06000DB9 RID: 3513 RVA: 0x00077A75 File Offset: 0x00075C75
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001205 RID: 4613
	public Shader SCShader;

	// Token: 0x04001206 RID: 4614
	private float TimeX = 1f;

	// Token: 0x04001207 RID: 4615
	private Material SCMaterial;

	// Token: 0x04001208 RID: 4616
	[Range(-1f, 1f)]
	public float CenterX;

	// Token: 0x04001209 RID: 4617
	[Range(-1f, 1f)]
	public float CenterY;

	// Token: 0x0400120A RID: 4618
	[Range(0f, 3f)]
	public float Distortion = 1f;
}
