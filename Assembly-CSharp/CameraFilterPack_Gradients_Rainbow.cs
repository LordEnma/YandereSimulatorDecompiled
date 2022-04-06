using System;
using UnityEngine;

// Token: 0x020001D5 RID: 469
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Rainbow")]
public class CameraFilterPack_Gradients_Rainbow : MonoBehaviour
{
	// Token: 0x170002D9 RID: 729
	// (get) Token: 0x06000FC0 RID: 4032 RVA: 0x00080404 File Offset: 0x0007E604
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

	// Token: 0x06000FC1 RID: 4033 RVA: 0x00080438 File Offset: 0x0007E638
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FC2 RID: 4034 RVA: 0x0008045C File Offset: 0x0007E65C
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

	// Token: 0x06000FC3 RID: 4035 RVA: 0x00080528 File Offset: 0x0007E728
	private void Update()
	{
	}

	// Token: 0x06000FC4 RID: 4036 RVA: 0x0008052A File Offset: 0x0007E72A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001443 RID: 5187
	public Shader SCShader;

	// Token: 0x04001444 RID: 5188
	private string ShaderName = "CameraFilterPack/Gradients_Rainbow";

	// Token: 0x04001445 RID: 5189
	private float TimeX = 1f;

	// Token: 0x04001446 RID: 5190
	private Material SCMaterial;

	// Token: 0x04001447 RID: 5191
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001448 RID: 5192
	[Range(0f, 1f)]
	public float Fade = 1f;
}
