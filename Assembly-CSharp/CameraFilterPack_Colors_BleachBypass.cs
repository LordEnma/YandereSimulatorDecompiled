using System;
using UnityEngine;

// Token: 0x02000169 RID: 361
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/BleachBypass")]
public class CameraFilterPack_Colors_BleachBypass : MonoBehaviour
{
	// Token: 0x1700026E RID: 622
	// (get) Token: 0x06000D37 RID: 3383 RVA: 0x0007541E File Offset: 0x0007361E
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

	// Token: 0x06000D38 RID: 3384 RVA: 0x00075452 File Offset: 0x00073652
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_BleachBypass");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D39 RID: 3385 RVA: 0x00075474 File Offset: 0x00073674
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

	// Token: 0x06000D3A RID: 3386 RVA: 0x0007552A File Offset: 0x0007372A
	private void Update()
	{
	}

	// Token: 0x06000D3B RID: 3387 RVA: 0x0007552C File Offset: 0x0007372C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001181 RID: 4481
	public Shader SCShader;

	// Token: 0x04001182 RID: 4482
	private float TimeX = 1f;

	// Token: 0x04001183 RID: 4483
	private Material SCMaterial;

	// Token: 0x04001184 RID: 4484
	[Range(-1f, 2f)]
	public float Value = 1f;
}
