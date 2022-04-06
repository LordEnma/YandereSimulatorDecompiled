using System;
using UnityEngine;

// Token: 0x020001D7 RID: 471
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Tech")]
public class CameraFilterPack_Gradients_Tech : MonoBehaviour
{
	// Token: 0x170002DB RID: 731
	// (get) Token: 0x06000FCC RID: 4044 RVA: 0x000806EC File Offset: 0x0007E8EC
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

	// Token: 0x06000FCD RID: 4045 RVA: 0x00080720 File Offset: 0x0007E920
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FCE RID: 4046 RVA: 0x00080744 File Offset: 0x0007E944
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
			this.material.SetFloat("_Value", this.Switch);
			this.material.SetFloat("_Value2", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FCF RID: 4047 RVA: 0x00080810 File Offset: 0x0007EA10
	private void Update()
	{
	}

	// Token: 0x06000FD0 RID: 4048 RVA: 0x00080812 File Offset: 0x0007EA12
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400144F RID: 5199
	public Shader SCShader;

	// Token: 0x04001450 RID: 5200
	private string ShaderName = "CameraFilterPack/Gradients_Tech";

	// Token: 0x04001451 RID: 5201
	private float TimeX = 1f;

	// Token: 0x04001452 RID: 5202
	private Material SCMaterial;

	// Token: 0x04001453 RID: 5203
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001454 RID: 5204
	[Range(0f, 1f)]
	public float Fade = 1f;
}
