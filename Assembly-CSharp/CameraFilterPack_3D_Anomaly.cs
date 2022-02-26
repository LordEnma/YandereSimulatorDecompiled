using System;
using UnityEngine;

// Token: 0x02000109 RID: 265
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Anomaly")]
public class CameraFilterPack_3D_Anomaly : MonoBehaviour
{
	// Token: 0x1700020D RID: 525
	// (get) Token: 0x06000AB4 RID: 2740 RVA: 0x0006834C File Offset: 0x0006654C
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

	// Token: 0x06000AB5 RID: 2741 RVA: 0x00068380 File Offset: 0x00066580
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Anomaly");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AB6 RID: 2742 RVA: 0x000683A4 File Offset: 0x000665A4
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

	// Token: 0x06000AB7 RID: 2743 RVA: 0x0006851D File Offset: 0x0006671D
	private void Update()
	{
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x0006851F File Offset: 0x0006671F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E2F RID: 3631
	public Shader SCShader;

	// Token: 0x04000E30 RID: 3632
	public bool _Visualize;

	// Token: 0x04000E31 RID: 3633
	private float TimeX = 1f;

	// Token: 0x04000E32 RID: 3634
	private Material SCMaterial;

	// Token: 0x04000E33 RID: 3635
	[Range(0f, 100f)]
	public float _FixDistance = 23f;

	// Token: 0x04000E34 RID: 3636
	[Range(-0.5f, 0.99f)]
	public float Anomaly_Near = 0.045f;

	// Token: 0x04000E35 RID: 3637
	[Range(0f, 1f)]
	public float Anomaly_Far = 0.11f;

	// Token: 0x04000E36 RID: 3638
	[Range(0f, 2f)]
	public float Intensity = 1f;

	// Token: 0x04000E37 RID: 3639
	[Range(0f, 1f)]
	public float AnomalyWithoutObject = 1f;

	// Token: 0x04000E38 RID: 3640
	[Range(0.1f, 1f)]
	public float Anomaly_Distortion = 0.25f;

	// Token: 0x04000E39 RID: 3641
	[Range(4f, 64f)]
	public float Anomaly_Distortion_Size = 12f;

	// Token: 0x04000E3A RID: 3642
	[Range(-4f, 8f)]
	public float Anomaly_Intensity = 2f;
}
