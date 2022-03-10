using System;
using UnityEngine;

// Token: 0x020001D7 RID: 471
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Tech")]
public class CameraFilterPack_Gradients_Tech : MonoBehaviour
{
	// Token: 0x170002DB RID: 731
	// (get) Token: 0x06000FCA RID: 4042 RVA: 0x00080270 File Offset: 0x0007E470
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

	// Token: 0x06000FCB RID: 4043 RVA: 0x000802A4 File Offset: 0x0007E4A4
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FCC RID: 4044 RVA: 0x000802C8 File Offset: 0x0007E4C8
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

	// Token: 0x06000FCD RID: 4045 RVA: 0x00080394 File Offset: 0x0007E594
	private void Update()
	{
	}

	// Token: 0x06000FCE RID: 4046 RVA: 0x00080396 File Offset: 0x0007E596
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001448 RID: 5192
	public Shader SCShader;

	// Token: 0x04001449 RID: 5193
	private string ShaderName = "CameraFilterPack/Gradients_Tech";

	// Token: 0x0400144A RID: 5194
	private float TimeX = 1f;

	// Token: 0x0400144B RID: 5195
	private Material SCMaterial;

	// Token: 0x0400144C RID: 5196
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400144D RID: 5197
	[Range(0f, 1f)]
	public float Fade = 1f;
}
