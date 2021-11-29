using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200050B RID: 1291
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x0400487F RID: 18559
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x04004880 RID: 18560
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x04004881 RID: 18561
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
