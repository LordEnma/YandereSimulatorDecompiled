using System;
using UnityEngine;

// Token: 0x020001B1 RID: 433
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Funk")]
public class CameraFilterPack_FX_Funk : MonoBehaviour
{
	// Token: 0x170002B6 RID: 694
	// (get) Token: 0x06000EE8 RID: 3816 RVA: 0x0007BF17 File Offset: 0x0007A117
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

	// Token: 0x06000EE9 RID: 3817 RVA: 0x0007BF4B File Offset: 0x0007A14B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Funk");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EEA RID: 3818 RVA: 0x0007BF6C File Offset: 0x0007A16C
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EEB RID: 3819 RVA: 0x0007C009 File Offset: 0x0007A209
	private void Update()
	{
	}

	// Token: 0x06000EEC RID: 3820 RVA: 0x0007C00B File Offset: 0x0007A20B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400133C RID: 4924
	public Shader SCShader;

	// Token: 0x0400133D RID: 4925
	private float TimeX = 1f;

	// Token: 0x0400133E RID: 4926
	private Material SCMaterial;
}
