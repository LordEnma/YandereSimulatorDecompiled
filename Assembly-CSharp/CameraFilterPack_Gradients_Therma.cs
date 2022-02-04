using System;
using UnityEngine;

// Token: 0x020001D8 RID: 472
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Thermal")]
public class CameraFilterPack_Gradients_Therma : MonoBehaviour
{
	// Token: 0x170002DC RID: 732
	// (get) Token: 0x06000FCF RID: 4047 RVA: 0x00080038 File Offset: 0x0007E238
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

	// Token: 0x06000FD0 RID: 4048 RVA: 0x0008006C File Offset: 0x0007E26C
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FD1 RID: 4049 RVA: 0x00080090 File Offset: 0x0007E290
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

	// Token: 0x06000FD2 RID: 4050 RVA: 0x0008015C File Offset: 0x0007E35C
	private void Update()
	{
	}

	// Token: 0x06000FD3 RID: 4051 RVA: 0x0008015E File Offset: 0x0007E35E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001442 RID: 5186
	public Shader SCShader;

	// Token: 0x04001443 RID: 5187
	private string ShaderName = "CameraFilterPack/Gradients_Therma";

	// Token: 0x04001444 RID: 5188
	private float TimeX = 1f;

	// Token: 0x04001445 RID: 5189
	private Material SCMaterial;

	// Token: 0x04001446 RID: 5190
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001447 RID: 5191
	[Range(0f, 1f)]
	public float Fade = 1f;
}
