using System;
using UnityEngine;

// Token: 0x020001D7 RID: 471
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Tech")]
public class CameraFilterPack_Gradients_Tech : MonoBehaviour
{
	// Token: 0x170002DB RID: 731
	// (get) Token: 0x06000FC9 RID: 4041 RVA: 0x0007FEC4 File Offset: 0x0007E0C4
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

	// Token: 0x06000FCA RID: 4042 RVA: 0x0007FEF8 File Offset: 0x0007E0F8
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FCB RID: 4043 RVA: 0x0007FF1C File Offset: 0x0007E11C
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

	// Token: 0x06000FCC RID: 4044 RVA: 0x0007FFE8 File Offset: 0x0007E1E8
	private void Update()
	{
	}

	// Token: 0x06000FCD RID: 4045 RVA: 0x0007FFEA File Offset: 0x0007E1EA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400143C RID: 5180
	public Shader SCShader;

	// Token: 0x0400143D RID: 5181
	private string ShaderName = "CameraFilterPack/Gradients_Tech";

	// Token: 0x0400143E RID: 5182
	private float TimeX = 1f;

	// Token: 0x0400143F RID: 5183
	private Material SCMaterial;

	// Token: 0x04001440 RID: 5184
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001441 RID: 5185
	[Range(0f, 1f)]
	public float Fade = 1f;
}
