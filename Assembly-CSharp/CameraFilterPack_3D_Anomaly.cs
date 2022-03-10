using System;
using UnityEngine;

// Token: 0x02000109 RID: 265
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Anomaly")]
public class CameraFilterPack_3D_Anomaly : MonoBehaviour
{
	// Token: 0x1700020D RID: 525
	// (get) Token: 0x06000AB4 RID: 2740 RVA: 0x00068494 File Offset: 0x00066694
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

	// Token: 0x06000AB5 RID: 2741 RVA: 0x000684C8 File Offset: 0x000666C8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Anomaly");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AB6 RID: 2742 RVA: 0x000684EC File Offset: 0x000666EC
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
			this.material.SetFloat("_Value2", this.Intensity);
			this.material.SetFloat("Anomaly_Distortion", this.Anomaly_Distortion);
			this.material.SetFloat("Anomaly_Distortion_Size", this.Anomaly_Distortion_Size);
			this.material.SetFloat("Anomaly_Intensity", this.Anomaly_Intensity);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("Anomaly_Near", this.Anomaly_Near);
			this.material.SetFloat("Anomaly_Far", this.Anomaly_Far);
			this.material.SetFloat("Anomaly_With_Obj", this.AnomalyWithoutObject);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000AB7 RID: 2743 RVA: 0x00068665 File Offset: 0x00066865
	private void Update()
	{
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x00068667 File Offset: 0x00066867
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E38 RID: 3640
	public Shader SCShader;

	// Token: 0x04000E39 RID: 3641
	public bool _Visualize;

	// Token: 0x04000E3A RID: 3642
	private float TimeX = 1f;

	// Token: 0x04000E3B RID: 3643
	private Material SCMaterial;

	// Token: 0x04000E3C RID: 3644
	[Range(0f, 100f)]
	public float _FixDistance = 23f;

	// Token: 0x04000E3D RID: 3645
	[Range(-0.5f, 0.99f)]
	public float Anomaly_Near = 0.045f;

	// Token: 0x04000E3E RID: 3646
	[Range(0f, 1f)]
	public float Anomaly_Far = 0.11f;

	// Token: 0x04000E3F RID: 3647
	[Range(0f, 2f)]
	public float Intensity = 1f;

	// Token: 0x04000E40 RID: 3648
	[Range(0f, 1f)]
	public float AnomalyWithoutObject = 1f;

	// Token: 0x04000E41 RID: 3649
	[Range(0.1f, 1f)]
	public float Anomaly_Distortion = 0.25f;

	// Token: 0x04000E42 RID: 3650
	[Range(4f, 64f)]
	public float Anomaly_Distortion_Size = 12f;

	// Token: 0x04000E43 RID: 3651
	[Range(-4f, 8f)]
	public float Anomaly_Intensity = 2f;
}
