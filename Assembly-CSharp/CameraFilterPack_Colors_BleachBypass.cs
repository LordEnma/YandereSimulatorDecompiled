using System;
using UnityEngine;

// Token: 0x0200016A RID: 362
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/BleachBypass")]
public class CameraFilterPack_Colors_BleachBypass : MonoBehaviour
{
	// Token: 0x1700026E RID: 622
	// (get) Token: 0x06000D3D RID: 3389 RVA: 0x00075E3E File Offset: 0x0007403E
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

	// Token: 0x06000D3E RID: 3390 RVA: 0x00075E72 File Offset: 0x00074072
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_BleachBypass");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D3F RID: 3391 RVA: 0x00075E94 File Offset: 0x00074094
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

	// Token: 0x06000D40 RID: 3392 RVA: 0x00075F4A File Offset: 0x0007414A
	private void Update()
	{
	}

	// Token: 0x06000D41 RID: 3393 RVA: 0x00075F4C File Offset: 0x0007414C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001199 RID: 4505
	public Shader SCShader;

	// Token: 0x0400119A RID: 4506
	private float TimeX = 1f;

	// Token: 0x0400119B RID: 4507
	private Material SCMaterial;

	// Token: 0x0400119C RID: 4508
	[Range(-1f, 2f)]
	public float Value = 1f;
}
