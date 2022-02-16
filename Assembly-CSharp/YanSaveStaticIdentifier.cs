using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000511 RID: 1297
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x040048FF RID: 18687
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x04004900 RID: 18688
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x04004901 RID: 18689
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
