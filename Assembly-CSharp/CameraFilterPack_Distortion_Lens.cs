using System;
using UnityEngine;

// Token: 0x0200017D RID: 381
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Lens")]
public class CameraFilterPack_Distortion_Lens : MonoBehaviour
{
	// Token: 0x17000282 RID: 642
	// (get) Token: 0x06000DAF RID: 3503 RVA: 0x00076F20 File Offset: 0x00075120
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

	// Token: 0x06000DB0 RID: 3504 RVA: 0x00076F54 File Offset: 0x00075154
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Lens");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DB1 RID: 3505 RVA: 0x00076F78 File Offset: 0x00075178
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

	// Token: 0x06000DB2 RID: 3506 RVA: 0x00077053 File Offset: 0x00075253
	private void Update()
	{
	}

	// Token: 0x06000DB3 RID: 3507 RVA: 0x00077055 File Offset: 0x00075255
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011ED RID: 4589
	public Shader SCShader;

	// Token: 0x040011EE RID: 4590
	private float TimeX = 1f;

	// Token: 0x040011EF RID: 4591
	private Material SCMaterial;

	// Token: 0x040011F0 RID: 4592
	[Range(-1f, 1f)]
	public float CenterX;

	// Token: 0x040011F1 RID: 4593
	[Range(-1f, 1f)]
	public float CenterY;

	// Token: 0x040011F2 RID: 4594
	[Range(0f, 3f)]
	public float Distortion = 1f;
}
