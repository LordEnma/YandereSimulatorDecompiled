using System;
using UnityEngine;

// Token: 0x02000182 RID: 386
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Twist")]
public class CameraFilterPack_Distortion_Twist : MonoBehaviour
{
	// Token: 0x17000286 RID: 646
	// (get) Token: 0x06000DCB RID: 3531 RVA: 0x00077AC3 File Offset: 0x00075CC3
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

	// Token: 0x06000DCC RID: 3532 RVA: 0x00077AF7 File Offset: 0x00075CF7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Twist");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DCD RID: 3533 RVA: 0x00077B18 File Offset: 0x00075D18
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

	// Token: 0x06000DCE RID: 3534 RVA: 0x00077C09 File Offset: 0x00075E09
	private void Update()
	{
	}

	// Token: 0x06000DCF RID: 3535 RVA: 0x00077C0B File Offset: 0x00075E0B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001216 RID: 4630
	public Shader SCShader;

	// Token: 0x04001217 RID: 4631
	private float TimeX = 1f;

	// Token: 0x04001218 RID: 4632
	private Material SCMaterial;

	// Token: 0x04001219 RID: 4633
	[Range(-2f, 2f)]
	public float CenterX = 0.5f;

	// Token: 0x0400121A RID: 4634
	[Range(-2f, 2f)]
	public float CenterY = 0.5f;

	// Token: 0x0400121B RID: 4635
	[Range(-3.14f, 3.14f)]
	public float Distortion = 1f;

	// Token: 0x0400121C RID: 4636
	[Range(-2f, 2f)]
	public float Size = 1f;
}
