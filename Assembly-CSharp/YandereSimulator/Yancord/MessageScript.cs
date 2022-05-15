using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000529 RID: 1321
	public class MessageScript : MonoBehaviour
	{
		// Token: 0x060021BB RID: 8635 RVA: 0x001F1F00 File Offset: 0x001F0100
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

		// Token: 0x04004A33 RID: 18995
		[Header("== Partner Informations ==")]
		public Profile MyProfile;

		// Token: 0x04004A34 RID: 18996
		[Space(20f)]
		public UILabel NameLabel;

		// Token: 0x04004A35 RID: 18997
		public UILabel MessageLabel;

		// Token: 0x04004A36 RID: 18998
		public UITexture ProfilPictureTexture;
	}
}
