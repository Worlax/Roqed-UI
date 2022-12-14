using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsWindow : Window
{
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

	protected override void Init()
	{
		ISettingsData settingsData = data as ISettingsData;

		language.AddOptions(settingsData.Languages.ToList());
		language.value = language.options.FindIndex(x => x.text == settingsData.ActiveLanguage);

		savePath.text = settingsData.SavePath;
		email.text = settingsData.Email;

		interactive.isOn = settingsData.Interactive;
		betaFeatures.isOn = settingsData.BetaFeatures;
		offlineMode.isOn = settingsData.OfflineMode;
	}
}
