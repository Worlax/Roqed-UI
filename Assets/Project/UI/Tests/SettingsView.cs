using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SettingsView : Window
{
	[SerializeField] Button closeButton;

	// System
	[SerializeField] TMP_Dropdown language;
	[SerializeField] TMP_Text savePath;
	[SerializeField] TMP_InputField email;

	[SerializeField] Toggle interactive;
	[SerializeField] Toggle betaFeatures;
	[SerializeField] Toggle offlineMode;

	// Display
	[SerializeField] TMP_Dropdown resolution;
	[SerializeField] TMP_Dropdown graphicQuality;

	[SerializeField] Toggle showFps;

	// Volume
	[SerializeField] Slider generalVolume;
	[SerializeField] Slider effectsVolume;
	[SerializeField] Slider musicVolume;
	[SerializeField] Slider voiceVolume;

	[SerializeField] Toggle enableVoice;

	SettingsData data;

	public override void Init<T>(T initData)
	{
		data = initData as SettingsData;

		language.AddOptions(data.Languages.ToList());
		language.value = language.options.FindIndex(x => x.text == data.ActiveLanguage);

		savePath.text = data.SavePath;
		email.text = data.Email;

		interactive.isOn = data.Interactive;
		betaFeatures.isOn = data.BetaFeatures;
		offlineMode.isOn = data.OfflineMode;
	}

	// Unity
	private void Start()
	{
		closeButton.onClick.AddListener(Close);
	}
}
