using System;
using UnityEngine;

// Token: 0x02000109 RID: 265
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Anomaly")]
public class CameraFilterPack_3D_Anomaly : MonoBehaviour
{
	// Token: 0x1700020D RID: 525
	// (get) Token: 0x06000AB6 RID: 2742 RVA: 0x00068910 File Offset: 0x00066B10
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

	// Token: 0x06000AB7 RID: 2743 RVA: 0x00068944 File Offset: 0x00066B44
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Anomaly");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x00068968 File Offset: 0x00066B68
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

	// Token: 0x06000AB9 RID: 2745 RVA: 0x00068AE1 File Offset: 0x00066CE1
	private void Update()
	{
	}

	// Token: 0x06000ABA RID: 2746 RVA: 0x00068AE3 File Offset: 0x00066CE3
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E3F RID: 3647
	public Shader SCShader;

	// Token: 0x04000E40 RID: 3648
	public bool _Visualize;

	// Token: 0x04000E41 RID: 3649
	private float TimeX = 1f;

	// Token: 0x04000E42 RID: 3650
	private Material SCMaterial;

	// Token: 0x04000E43 RID: 3651
	[Range(0f, 100f)]
	public float _FixDistance = 23f;

	// Token: 0x04000E44 RID: 3652
	[Range(-0.5f, 0.99f)]
	public float Anomaly_Near = 0.045f;

	// Token: 0x04000E45 RID: 3653
	[Range(0f, 1f)]
	public float Anomaly_Far = 0.11f;

	// Token: 0x04000E46 RID: 3654
	[Range(0f, 2f)]
	public float Intensity = 1f;

	// Token: 0x04000E47 RID: 3655
	[Range(0f, 1f)]
	public float AnomalyWithoutObject = 1f;

	// Token: 0x04000E48 RID: 3656
	[Range(0.1f, 1f)]
	public float Anomaly_Distortion = 0.25f;

	// Token: 0x04000E49 RID: 3657
	[Range(4f, 64f)]
	public float Anomaly_Distortion_Size = 12f;

	// Token: 0x04000E4A RID: 3658
	[Range(-4f, 8f)]
	public float Anomaly_Intensity = 2f;
}
