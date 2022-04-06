using System;
using UnityEngine;

// Token: 0x02000161 RID: 353
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Invert")]
public class CameraFilterPack_Color_Invert : MonoBehaviour
{
	// Token: 0x17000265 RID: 613
	// (get) Token: 0x06000D05 RID: 3333 RVA: 0x00074B3C File Offset: 0x00072D3C
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

	// Token: 0x06000D06 RID: 3334 RVA: 0x00074B70 File Offset: 0x00072D70
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Invert");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D07 RID: 3335 RVA: 0x00074B94 File Offset: 0x00072D94
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
			this.material.SetFloat("_Fade", this._Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D08 RID: 3336 RVA: 0x00074C4A File Offset: 0x00072E4A
	private void Update()
	{
	}

	// Token: 0x06000D09 RID: 3337 RVA: 0x00074C4C File Offset: 0x00072E4C
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
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x04001165 RID: 4453
	private Material SCMaterial;
}
