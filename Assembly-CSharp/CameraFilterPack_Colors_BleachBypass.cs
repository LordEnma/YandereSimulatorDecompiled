using System;
using UnityEngine;

// Token: 0x0200016A RID: 362
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/BleachBypass")]
public class CameraFilterPack_Colors_BleachBypass : MonoBehaviour
{
	// Token: 0x1700026E RID: 622
	// (get) Token: 0x06000D3A RID: 3386 RVA: 0x00075616 File Offset: 0x00073816
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

	// Token: 0x06000D3B RID: 3387 RVA: 0x0007564A File Offset: 0x0007384A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_BleachBypass");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D3C RID: 3388 RVA: 0x0007566C File Offset: 0x0007386C
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D3D RID: 3389 RVA: 0x00075722 File Offset: 0x00073922
	private void Update()
	{
	}

	// Token: 0x06000D3E RID: 3390 RVA: 0x00075724 File Offset: 0x00073924
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001186 RID: 4486
	public Shader SCShader;

	// Token: 0x04001187 RID: 4487
	private float TimeX = 1f;

	// Token: 0x04001188 RID: 4488
	private Material SCMaterial;

	// Token: 0x04001189 RID: 4489
	[Range(-1f, 2f)]
	public float Value = 1f;
}
