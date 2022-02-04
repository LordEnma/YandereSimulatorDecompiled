using System;
using UnityEngine;

// Token: 0x020001B8 RID: 440
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Hexagon_Black")]
public class CameraFilterPack_FX_Hexagon_Black : MonoBehaviour
{
	// Token: 0x170002BC RID: 700
	// (get) Token: 0x06000F0F RID: 3855 RVA: 0x0007C864 File Offset: 0x0007AA64
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

	// Token: 0x06000F10 RID: 3856 RVA: 0x0007C898 File Offset: 0x0007AA98
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Hexagon_Black");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F11 RID: 3857 RVA: 0x0007C8BC File Offset: 0x0007AABC
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

	// Token: 0x06000F12 RID: 3858 RVA: 0x0007C972 File Offset: 0x0007AB72
	private void Update()
	{
	}

	// Token: 0x06000F13 RID: 3859 RVA: 0x0007C974 File Offset: 0x0007AB74
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001359 RID: 4953
	public Shader SCShader;

	// Token: 0x0400135A RID: 4954
	private float TimeX = 1f;

	// Token: 0x0400135B RID: 4955
	private Material SCMaterial;

	// Token: 0x0400135C RID: 4956
	[Range(0.2f, 10f)]
	public float Value = 1f;
}
