using System;
using UnityEngine;

// Token: 0x020001B3 RID: 435
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch1")]
public class CameraFilterPack_FX_Glitch1 : MonoBehaviour
{
	// Token: 0x170002B7 RID: 695
	// (get) Token: 0x06000EF2 RID: 3826 RVA: 0x0007C494 File Offset: 0x0007A694
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

	// Token: 0x06000EF3 RID: 3827 RVA: 0x0007C4C8 File Offset: 0x0007A6C8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Glitch1");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EF4 RID: 3828 RVA: 0x0007C4EC File Offset: 0x0007A6EC
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
			this.material.SetFloat("_Glitch", this.Glitch);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EF5 RID: 3829 RVA: 0x0007C5A2 File Offset: 0x0007A7A2
	private void Update()
	{
	}

	// Token: 0x06000EF6 RID: 3830 RVA: 0x0007C5A4 File Offset: 0x0007A7A4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001347 RID: 4935
	public Shader SCShader;

	// Token: 0x04001348 RID: 4936
	private float TimeX = 1f;

	// Token: 0x04001349 RID: 4937
	private Material SCMaterial;

	// Token: 0x0400134A RID: 4938
	[Range(0f, 1f)]
	public float Glitch = 1f;
}
