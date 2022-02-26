using System;
using UnityEngine;

// Token: 0x02000182 RID: 386
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Twist")]
public class CameraFilterPack_Distortion_Twist : MonoBehaviour
{
	// Token: 0x17000286 RID: 646
	// (get) Token: 0x06000DCB RID: 3531 RVA: 0x0007797B File Offset: 0x00075B7B
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

	// Token: 0x06000DCC RID: 3532 RVA: 0x000779AF File Offset: 0x00075BAF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Twist");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DCD RID: 3533 RVA: 0x000779D0 File Offset: 0x00075BD0
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

	// Token: 0x06000DCE RID: 3534 RVA: 0x00077AC1 File Offset: 0x00075CC1
	private void Update()
	{
	}

	// Token: 0x06000DCF RID: 3535 RVA: 0x00077AC3 File Offset: 0x00075CC3
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400120D RID: 4621
	public Shader SCShader;

	// Token: 0x0400120E RID: 4622
	private float TimeX = 1f;

	// Token: 0x0400120F RID: 4623
	private Material SCMaterial;

	// Token: 0x04001210 RID: 4624
	[Range(-2f, 2f)]
	public float CenterX = 0.5f;

	// Token: 0x04001211 RID: 4625
	[Range(-2f, 2f)]
	public float CenterY = 0.5f;

	// Token: 0x04001212 RID: 4626
	[Range(-3.14f, 3.14f)]
	public float Distortion = 1f;

	// Token: 0x04001213 RID: 4627
	[Range(-2f, 2f)]
	public float Size = 1f;
}
