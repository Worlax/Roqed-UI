using UnityEngine;
using TMPro;

public class LicenseView : View<LicenseData>
{
	[SerializeField] TMP_Text key;
	[SerializeField] TMP_Text userName;
	[SerializeField] TMP_Text activationDate;
	[SerializeField] TMP_Text expireDate;

	protected override void Init()
	{
		string yearFormat = "d-MMM-yyyy";

		key.text = Data.Key;
		userName.text = Data.UserName;
		activationDate.text = Data.ActivationDate.ToString(yearFormat);
		expireDate.text = Data.ActivationDate.AddDays(Data.ValidityDays).ToString(yearFormat);
	}
}