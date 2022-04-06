using System;
using UnityEngine;

// Token: 0x0200022E RID: 558
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Rainbow")]
public class CameraFilterPack_Vision_Rainbow : MonoBehaviour
{
	// Token: 0x17000332 RID: 818
	// (get) Token: 0x060011F9 RID: 4601 RVA: 0x0008A833 File Offset: 0x00088A33
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

	// Token: 0x060011FA RID: 4602 RVA: 0x0008A867 File Offset: 0x00088A67
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Rainbow");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011FB RID: 4603 RVA: 0x0008A888 File Offset: 0x00088A88
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

	// Token: 0x060011FC RID: 4604 RVA: 0x0008A996 File Offset: 0x00088B96
	private void Update()
	{
	}

	// Token: 0x060011FD RID: 4605 RVA: 0x0008A998 File Offset: 0x00088B98
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040016A2 RID: 5794
	public Shader SCShader;

	// Token: 0x040016A3 RID: 5795
	private float TimeX = 1f;

	// Token: 0x040016A4 RID: 5796
	private Material SCMaterial;

	// Token: 0x040016A5 RID: 5797
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x040016A6 RID: 5798
	[Range(0f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x040016A7 RID: 5799
	[Range(0f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x040016A8 RID: 5800
	[Range(0f, 5f)]
	public float Colors = 0.5f;

	// Token: 0x040016A9 RID: 5801
	[Range(0f, 1f)]
	public float Vision = 0.5f;
}
