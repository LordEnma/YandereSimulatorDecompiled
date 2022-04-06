using System;
using UnityEngine;

// Token: 0x02000165 RID: 357
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Switching")]
public class CameraFilterPack_Color_Switching : MonoBehaviour
{
	// Token: 0x17000269 RID: 617
	// (get) Token: 0x06000D1D RID: 3357 RVA: 0x00075068 File Offset: 0x00073268
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

	// Token: 0x06000D1E RID: 3358 RVA: 0x0007509C File Offset: 0x0007329C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Switching");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D1F RID: 3359 RVA: 0x000750C0 File Offset: 0x000732C0
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

	// Token: 0x06000D20 RID: 3360 RVA: 0x00075177 File Offset: 0x00073377
	private void Update()
	{
	}

	// Token: 0x06000D21 RID: 3361 RVA: 0x00075179 File Offset: 0x00073379
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001172 RID: 4466
	public Shader SCShader;

	// Token: 0x04001173 RID: 4467
	private float TimeX = 1f;

	// Token: 0x04001174 RID: 4468
	private Material SCMaterial;

	// Token: 0x04001175 RID: 4469
	[Range(0f, 5f)]
	public int Color = 1;
}
