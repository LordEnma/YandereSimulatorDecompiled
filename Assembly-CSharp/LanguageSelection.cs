using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(UIPopupList))]
[AddComponentMenu("NGUI/Interaction/Language Selection")]
public class LanguageSelection : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static EventDelegate.Callback _003C_003E9__3_0;

		internal void _003CStart_003Eb__3_0()
		{
			Localization.language = UIPopupList.current.value;
		}
	}

	private UIPopupList mList;

	private bool mStarted;

	private void Awake()
	{
		mList = GetComponent<UIPopupList>();
	}

	private void Start()
	{
		mStarted = true;
		Refresh();
		EventDelegate.Add(mList.onChange, _003C_003Ec._003C_003E9__3_0 ?? (_003C_003Ec._003C_003E9__3_0 = _003C_003Ec._003C_003E9._003CStart_003Eb__3_0));
	}

	private void OnEnable()
	{
		if (mStarted)
		{
			Refresh();
		}
	}

	public void Refresh()
	{
		if (mList != null && Localization.knownLanguages != null)
		{
			mList.Clear();
			int i = 0;
			for (int num = Localization.knownLanguages.Length; i < num; i++)
			{
				mList.items.Add(Localization.knownLanguages[i]);
			}
			mList.value = Localization.language;
		}
	}

	private void OnLocalize()
	{
		Refresh();
	}
}
