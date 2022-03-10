using System;
using UnityEngine;

// Token: 0x02000164 RID: 356
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Sepia")]
public class CameraFilterPack_Color_Sepia : MonoBehaviour
{
	// Token: 0x17000268 RID: 616
	// (get) Token: 0x06000D15 RID: 3349 RVA: 0x00074AA7 File Offset: 0x00072CA7
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

	// Token: 0x06000D16 RID: 3350 RVA: 0x00074ADB File Offset: 0x00072CDB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Sepia");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D17 RID: 3351 RVA: 0x00074AFC File Offset: 0x00072CFC
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

	// Token: 0x06000D18 RID: 3352 RVA: 0x00074BB2 File Offset: 0x00072DB2
	private void Update()
	{
	}

	// Token: 0x06000D19 RID: 3353 RVA: 0x00074BB4 File Offset: 0x00072DB4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001167 RID: 4455
	public Shader SCShader;

	// Token: 0x04001168 RID: 4456
	private float TimeX = 1f;

	// Token: 0x04001169 RID: 4457
	[Range(0f, 1f)]
	public float _Fade = 1f;

	// Token: 0x0400116A RID: 4458
	private Material SCMaterial;
}
