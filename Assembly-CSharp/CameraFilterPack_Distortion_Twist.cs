using System;
using UnityEngine;

// Token: 0x02000181 RID: 385
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Twist")]
public class CameraFilterPack_Distortion_Twist : MonoBehaviour
{
	// Token: 0x17000286 RID: 646
	// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x0007751F File Offset: 0x0007571F
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

	// Token: 0x06000DC8 RID: 3528 RVA: 0x00077553 File Offset: 0x00075753
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Twist");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DC9 RID: 3529 RVA: 0x00077574 File Offset: 0x00075774
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
			this.material.SetFloat("_CenterX", this.CenterX);
			this.material.SetFloat("_CenterY", this.CenterY);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetFloat("_Size", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DCA RID: 3530 RVA: 0x00077665 File Offset: 0x00075865
	private void Update()
	{
	}

	// Token: 0x06000DCB RID: 3531 RVA: 0x00077667 File Offset: 0x00075867
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001205 RID: 4613
	public Shader SCShader;

	// Token: 0x04001206 RID: 4614
	private float TimeX = 1f;

	// Token: 0x04001207 RID: 4615
	private Material SCMaterial;

	// Token: 0x04001208 RID: 4616
	[Range(-2f, 2f)]
	public float CenterX = 0.5f;

	// Token: 0x04001209 RID: 4617
	[Range(-2f, 2f)]
	public float CenterY = 0.5f;

	// Token: 0x0400120A RID: 4618
	[Range(-3.14f, 3.14f)]
	public float Distortion = 1f;

	// Token: 0x0400120B RID: 4619
	[Range(-2f, 2f)]
	public float Size = 1f;
}
