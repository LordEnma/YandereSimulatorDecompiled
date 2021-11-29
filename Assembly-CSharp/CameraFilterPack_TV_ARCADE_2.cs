using System;
using UnityEngine;

// Token: 0x02000204 RID: 516
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/ARCADE_2")]
public class CameraFilterPack_TV_ARCADE_2 : MonoBehaviour
{
	// Token: 0x17000309 RID: 777
	// (get) Token: 0x060010FD RID: 4349 RVA: 0x00085CCC File Offset: 0x00083ECC
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

	// Token: 0x060010FE RID: 4350 RVA: 0x00085D00 File Offset: 0x00083F00
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_ARCADE_2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010FF RID: 4351 RVA: 0x00085D24 File Offset: 0x00083F24
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
			this.material.SetFloat("_Value", this.Interferance_Size);
			this.material.SetFloat("_Value2", this.Interferance_Speed);
			this.material.SetFloat("_Value3", this.Contrast);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001100 RID: 4352 RVA: 0x00085E1C File Offset: 0x0008401C
	private void Update()
	{
	}

	// Token: 0x06001101 RID: 4353 RVA: 0x00085E1E File Offset: 0x0008401E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001583 RID: 5507
	public Shader SCShader;

	// Token: 0x04001584 RID: 5508
	private float TimeX = 1f;

	// Token: 0x04001585 RID: 5509
	private Material SCMaterial;

	// Token: 0x04001586 RID: 5510
	[Range(0f, 10f)]
	public float Interferance_Size = 1f;

	// Token: 0x04001587 RID: 5511
	[Range(0f, 10f)]
	public float Interferance_Speed = 0.5f;

	// Token: 0x04001588 RID: 5512
	[Range(0f, 10f)]
	public float Contrast = 1f;

	// Token: 0x04001589 RID: 5513
	[Range(0f, 1f)]
	public float Fade = 1f;
}
