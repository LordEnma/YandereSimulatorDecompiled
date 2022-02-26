using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000512 RID: 1298
public class YanSaveStaticIdentifier : MonoBehaviour
{
	// Token: 0x0400490F RID: 18703
	[SerializeField]
	public List<string> StaticTypeNames = new List<string>();

	// Token: 0x04004910 RID: 18704
	[SerializeField]
	public List<KeyValuePair<Type, string>> DisabledMembers = new List<KeyValuePair<Type, string>>();

	// Token: 0x04004911 RID: 18705
	[SerializeField]
	public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
