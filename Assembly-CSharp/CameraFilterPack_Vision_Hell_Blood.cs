using System;
using UnityEngine;

// Token: 0x0200022B RID: 555
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Hell_Blood")]
public class CameraFilterPack_Vision_Hell_Blood : MonoBehaviour
{
	// Token: 0x1700032F RID: 815
	// (get) Token: 0x060011E7 RID: 4583 RVA: 0x0008A2A3 File Offset: 0x000884A3
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

	// Token: 0x060011E8 RID: 4584 RVA: 0x0008A2D7 File Offset: 0x000884D7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Hell_Blood");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011E9 RID: 4585 RVA: 0x0008A2F8 File Offset: 0x000884F8
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
			this.material.SetFloat("_Value", this.Hole_Size);
			this.material.SetFloat("_Value2", this.Hole_Smooth);
			this.material.SetFloat("_Value3", this.Hole_Speed * 15f);
			this.material.SetColor("ColorBlood", this.ColorBlood);
			this.material.SetFloat("_Value4", this.Intensity);
			this.material.SetFloat("BloodAlternative1", this.BloodAlternative1);
			this.material.SetFloat("BloodAlternative2", this.BloodAlternative2);
			this.material.SetFloat("BloodAlternative3", this.BloodAlternative3);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011EA RID: 4586 RVA: 0x0008A44E File Offset: 0x0008864E
	private void Update()
	{
	}

	// Token: 0x060011EB RID: 4587 RVA: 0x0008A450 File Offset: 0x00088650
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001689 RID: 5769
	public Shader SCShader;

	// Token: 0x0400168A RID: 5770
	private float TimeX = 1f;

	// Token: 0x0400168B RID: 5771
	private Material SCMaterial;

	// Token: 0x0400168C RID: 5772
	[Range(0f, 1f)]
	public float Hole_Size = 0.57f;

	// Token: 0x0400168D RID: 5773
	[Range(0f, 0.5f)]
	public float Hole_Smooth = 0.362f;

	// Token: 0x0400168E RID: 5774
	[Range(-2f, 2f)]
	public float Hole_Speed = 0.85f;

	// Token: 0x0400168F RID: 5775
	[Range(-10f, 10f)]
	public float Intensity = 0.24f;

	// Token: 0x04001690 RID: 5776
	public Color ColorBlood = new Color(1f, 0f, 0f, 1f);

	// Token: 0x04001691 RID: 5777
	[Range(-1f, 1f)]
	public float BloodAlternative1;

	// Token: 0x04001692 RID: 5778
	[Range(-1f, 1f)]
	public float BloodAlternative2;

	// Token: 0x04001693 RID: 5779
	[Range(-1f, 1f)]
	public float BloodAlternative3 = -1f;
}
