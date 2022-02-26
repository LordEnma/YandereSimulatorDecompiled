using System;
using UnityEngine;

// Token: 0x02000165 RID: 357
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Switching")]
public class CameraFilterPack_Color_Switching : MonoBehaviour
{
	// Token: 0x17000269 RID: 617
	// (get) Token: 0x06000D1B RID: 3355 RVA: 0x00074AA4 File Offset: 0x00072CA4
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

	// Token: 0x06000D1C RID: 3356 RVA: 0x00074AD8 File Offset: 0x00072CD8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Switching");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D1D RID: 3357 RVA: 0x00074AFC File Offset: 0x00072CFC
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
			this.material.SetFloat("_Distortion", (float)this.Color);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D1E RID: 3358 RVA: 0x00074BB3 File Offset: 0x00072DB3
	private void Update()
	{
	}

	// Token: 0x06000D1F RID: 3359 RVA: 0x00074BB5 File Offset: 0x00072DB5
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001162 RID: 4450
	public Shader SCShader;

	// Token: 0x04001163 RID: 4451
	private float TimeX = 1f;

	// Token: 0x04001164 RID: 4452
	private Material SCMaterial;

	// Token: 0x04001165 RID: 4453
	[Range(0f, 5f)]
	public int Color = 1;
}
