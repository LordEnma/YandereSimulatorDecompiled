using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000033 RID: 51
[AddComponentMenu("NGUI/Examples/Load Level On Click")]
public class LoadLevelOnClick : MonoBehaviour
{
	// Token: 0x060000D9 RID: 217 RVA: 0x0001286A File Offset: 0x00010A6A
	private void OnClick()
	{
		if (!string.IsNullOrEmpty(this.levelName))
		{
			SceneManager.LoadScene(this.levelName);
		}
	}

	// Token: 0x040002A9 RID: 681
	public string levelName;
}
