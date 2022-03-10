using System;
using UnityEngine;

// Token: 0x020001D8 RID: 472
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Thermal")]
public class CameraFilterPack_Gradients_Therma : MonoBehaviour
{
	// Token: 0x170002DC RID: 732
	// (get) Token: 0x06000FD0 RID: 4048 RVA: 0x000803E4 File Offset: 0x0007E5E4
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

	// Token: 0x06000FD1 RID: 4049 RVA: 0x00080418 File Offset: 0x0007E618
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FD2 RID: 4050 RVA: 0x0008043C File Offset: 0x0007E63C
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

	// Token: 0x06000FD3 RID: 4051 RVA: 0x00080508 File Offset: 0x0007E708
	private void Update()
	{
	}

	// Token: 0x06000FD4 RID: 4052 RVA: 0x0008050A File Offset: 0x0007E70A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400144E RID: 5198
	public Shader SCShader;

	// Token: 0x0400144F RID: 5199
	private string ShaderName = "CameraFilterPack/Gradients_Therma";

	// Token: 0x04001450 RID: 5200
	private float TimeX = 1f;

	// Token: 0x04001451 RID: 5201
	private Material SCMaterial;

	// Token: 0x04001452 RID: 5202
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001453 RID: 5203
	[Range(0f, 1f)]
	public float Fade = 1f;
}
