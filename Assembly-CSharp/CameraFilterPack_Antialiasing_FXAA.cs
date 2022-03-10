using System;
using UnityEngine;

// Token: 0x02000120 RID: 288
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Antialiasing/FXAA")]
public class CameraFilterPack_Antialiasing_FXAA : MonoBehaviour
{
	// Token: 0x17000224 RID: 548
	// (get) Token: 0x06000B3E RID: 2878 RVA: 0x0006BDD0 File Offset: 0x00069FD0
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

	// Token: 0x06000B3F RID: 2879 RVA: 0x0006BE04 File Offset: 0x0006A004
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Antialiasing_FXAA");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B40 RID: 2880 RVA: 0x0006BE28 File Offset: 0x0006A028
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

	// Token: 0x06000B41 RID: 2881 RVA: 0x0006BEBE File Offset: 0x0006A0BE
	private void Update()
	{
	}

	// Token: 0x06000B42 RID: 2882 RVA: 0x0006BEC0 File Offset: 0x0006A0C0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F4F RID: 3919
	public Shader SCShader;

	// Token: 0x04000F50 RID: 3920
	private float TimeX = 1f;

	// Token: 0x04000F51 RID: 3921
	private Material SCMaterial;
}
