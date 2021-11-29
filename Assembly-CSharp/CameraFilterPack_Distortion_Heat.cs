using System;
using UnityEngine;

// Token: 0x0200017C RID: 380
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Heat")]
public class CameraFilterPack_Distortion_Heat : MonoBehaviour
{
	// Token: 0x17000281 RID: 641
	// (get) Token: 0x06000DA9 RID: 3497 RVA: 0x00076DDA File Offset: 0x00074FDA
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

	// Token: 0x06000DAA RID: 3498 RVA: 0x00076E0E File Offset: 0x0007500E
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Heat");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DAB RID: 3499 RVA: 0x00076E30 File Offset: 0x00075030
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DAC RID: 3500 RVA: 0x00076EE6 File Offset: 0x000750E6
	private void Update()
	{
	}

	// Token: 0x06000DAD RID: 3501 RVA: 0x00076EE8 File Offset: 0x000750E8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011E9 RID: 4585
	public Shader SCShader;

	// Token: 0x040011EA RID: 4586
	private float TimeX = 1f;

	// Token: 0x040011EB RID: 4587
	private Material SCMaterial;

	// Token: 0x040011EC RID: 4588
	[Range(1f, 100f)]
	public float Distortion = 35f;
}
