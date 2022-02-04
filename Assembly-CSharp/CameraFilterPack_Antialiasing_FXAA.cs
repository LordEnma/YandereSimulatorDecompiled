using System;
using UnityEngine;

// Token: 0x02000120 RID: 288
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Antialiasing/FXAA")]
public class CameraFilterPack_Antialiasing_FXAA : MonoBehaviour
{
	// Token: 0x17000224 RID: 548
	// (get) Token: 0x06000B3D RID: 2877 RVA: 0x0006BA24 File Offset: 0x00069C24
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

	// Token: 0x06000B3E RID: 2878 RVA: 0x0006BA58 File Offset: 0x00069C58
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Antialiasing_FXAA");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B3F RID: 2879 RVA: 0x0006BA7C File Offset: 0x00069C7C
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
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B40 RID: 2880 RVA: 0x0006BB12 File Offset: 0x00069D12
	private void Update()
	{
	}

	// Token: 0x06000B41 RID: 2881 RVA: 0x0006BB14 File Offset: 0x00069D14
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F43 RID: 3907
	public Shader SCShader;

	// Token: 0x04000F44 RID: 3908
	private float TimeX = 1f;

	// Token: 0x04000F45 RID: 3909
	private Material SCMaterial;
}
