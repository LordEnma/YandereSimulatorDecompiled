using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000526 RID: 1318
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x06002198 RID: 8600 RVA: 0x001EE39C File Offset: 0x001EC59C
		public void Awake()
		{
			if (this.MyProfile != null)
			{
				if (this.NameLabel != null)
				{
					this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
				}
				if (this.ProfilPictureTexture != null)
				{
					this.ProfilPictureTexture.mainTexture = this.MyProfile.ProfilePicture;
				}
				base.gameObject.name = this.MyProfile.FirstName + "_Message";
			}
		}

		// Token: 0x040049E0 RID: 18912
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x040049E1 RID: 18913
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x040049E2 RID: 18914
		public UILabel MessageLabel;

		// Token: 0x040049E3 RID: 18915
		public UITexture ProfilPictureTexture;
	}
}
