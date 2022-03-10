using System;
using UnityEngine;

// Token: 0x0200022E RID: 558
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Rainbow")]
public class CameraFilterPack_Vision_Rainbow : MonoBehaviour
{
	// Token: 0x17000332 RID: 818
	// (get) Token: 0x060011F7 RID: 4599 RVA: 0x0008A3B7 File Offset: 0x000885B7
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

	// Token: 0x060011F8 RID: 4600 RVA: 0x0008A3EB File Offset: 0x000885EB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Rainbow");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011F9 RID: 4601 RVA: 0x0008A40C File Offset: 0x0008860C
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
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetFloat("_Value2", this.PosX);
			this.material.SetFloat("_Value3", this.PosY);
			this.material.SetFloat("_Value4", this.Colors);
			this.material.SetFloat("_Value5", this.Vision);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011FA RID: 4602 RVA: 0x0008A51A File Offset: 0x0008871A
	private void Update()
	{
	}

	// Token: 0x060011FB RID: 4603 RVA: 0x0008A51C File Offset: 0x0008871C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400169B RID: 5787
	public Shader SCShader;

	// Token: 0x0400169C RID: 5788
	private float TimeX = 1f;

	// Token: 0x0400169D RID: 5789
	private Material SCMaterial;

	// Token: 0x0400169E RID: 5790
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x0400169F RID: 5791
	[Range(0f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x040016A0 RID: 5792
	[Range(0f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x040016A1 RID: 5793
	[Range(0f, 5f)]
	public float Colors = 0.5f;

	// Token: 0x040016A2 RID: 5794
	[Range(0f, 1f)]
	public float Vision = 0.5f;
}
