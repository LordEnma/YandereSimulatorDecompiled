using System;
using UnityEngine;

// Token: 0x020001B7 RID: 439
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Hexagon_Black")]
public class CameraFilterPack_FX_Hexagon_Black : MonoBehaviour
{
	// Token: 0x170002BC RID: 700
	// (get) Token: 0x06000F0C RID: 3852 RVA: 0x0007C66C File Offset: 0x0007A86C
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

	// Token: 0x06000F0D RID: 3853 RVA: 0x0007C6A0 File Offset: 0x0007A8A0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Hexagon_Black");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F0E RID: 3854 RVA: 0x0007C6C4 File Offset: 0x0007A8C4
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

	// Token: 0x06000F0F RID: 3855 RVA: 0x0007C77A File Offset: 0x0007A97A
	private void Update()
	{
	}

	// Token: 0x06000F10 RID: 3856 RVA: 0x0007C77C File Offset: 0x0007A97C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001354 RID: 4948
	public Shader SCShader;

	// Token: 0x04001355 RID: 4949
	private float TimeX = 1f;

	// Token: 0x04001356 RID: 4950
	private Material SCMaterial;

	// Token: 0x04001357 RID: 4951
	[Range(0.2f, 10f)]
	public float Value = 1f;
}
