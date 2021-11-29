using System;
using UnityEngine;

// Token: 0x02000164 RID: 356
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Switching")]
public class CameraFilterPack_Color_Switching : MonoBehaviour
{
	// Token: 0x17000269 RID: 617
	// (get) Token: 0x06000D17 RID: 3351 RVA: 0x00074648 File Offset: 0x00072848
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

	// Token: 0x06000D18 RID: 3352 RVA: 0x0007467C File Offset: 0x0007287C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Switching");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D19 RID: 3353 RVA: 0x000746A0 File Offset: 0x000728A0
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

	// Token: 0x06000D1A RID: 3354 RVA: 0x00074757 File Offset: 0x00072957
	private void Update()
	{
	}

	// Token: 0x06000D1B RID: 3355 RVA: 0x00074759 File Offset: 0x00072959
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400115A RID: 4442
	public Shader SCShader;

	// Token: 0x0400115B RID: 4443
	private float TimeX = 1f;

	// Token: 0x0400115C RID: 4444
	private Material SCMaterial;

	// Token: 0x0400115D RID: 4445
	[Range(0f, 5f)]
	public int Color = 1;
}
