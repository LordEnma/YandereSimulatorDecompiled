using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000389 RID: 905
public class OsanaWarningScript : MonoBehaviour
{
	// Token: 0x06001A2A RID: 6698 RVA: 0x001157D0 File Offset: 0x001139D0
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		ColorGradingModel.Settings settings = this.Profile.colorGrading.settings;
		settings.basic.saturation = 1f;
		settings.channelMixer.red = new Vector3(1f, 0f, 0f);
		settings.channelMixer.green = new Vector3(0f, 1f, 0f);
		settings.channelMixer.blue = new Vector3(0f, 0f, 1f);
		this.Profile.colorGrading.settings = settings;
		DepthOfFieldModel.Settings settings2 = this.Profile.depthOfField.settings;
		settings2.focusDistance = 10f;
		settings2.aperture = 11.2f;
		this.Profile.depthOfField.settings = settings2;
		BloomModel.Settings settings3 = this.Profile.bloom.settings;
		settings3.bloom.intensity = 1f;
		this.Profile.bloom.settings = settings3;
	}

	// Token: 0x06001A2B RID: 6699 RVA: 0x00115904 File Offset: 0x00113B04
	private void Update()
	{
		if (this.FadeOut)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
		}
		this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
		if (this.Alpha == 0f)
		{
			if (Input.GetButtonDown("A"))
			{
				this.FadeOut = true;
				return;
			}
		}
		else if (this.Alpha == 1f)
		{
			SceneManager.LoadScene("CalendarScene");
		}
	}

	// Token: 0x06001A2C RID: 6700 RVA: 0x001159B0 File Offset: 0x00113BB0
	private void LateUpdate()
	{
		this.RightHand.localEulerAngles += new Vector3(UnityEngine.Random.Range(1f, -1f), UnityEngine.Random.Range(1f, -1f), UnityEngine.Random.Range(1f, -1f));
	}

	// Token: 0x04002AC2 RID: 10946
	public PostProcessingProfile Profile;

	// Token: 0x04002AC3 RID: 10947
	public Transform RightHand;

	// Token: 0x04002AC4 RID: 10948
	public UISprite Darkness;

	// Token: 0x04002AC5 RID: 10949
	public float Alpha = 1f;

	// Token: 0x04002AC6 RID: 10950
	public bool FadeOut;
}
