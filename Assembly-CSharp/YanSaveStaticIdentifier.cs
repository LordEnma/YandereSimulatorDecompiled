using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200051F RID: 1311
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x04004A10 RID: 18960
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x04004A11 RID: 18961
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x04004A12 RID: 18962
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
