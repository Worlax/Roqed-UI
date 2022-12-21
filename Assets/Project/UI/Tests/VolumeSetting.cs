using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VolumeSetting : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] Transform volume;
	[SerializeField] Toggle toggle;

	public void OnPointerEnter(PointerEventData eventData)
	{
		CanvasGroup canvasGroup = volume.GetComponent<CanvasGroup>();
		canvasGroup.alpha = 1f;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		CanvasGroup canvasGroup = volume.GetComponent<CanvasGroup>();
		canvasGroup.alpha = 0f;
	}

	// Unity
	private void Start()
	{
		GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;
		toggle.onValueChanged.AddListener(ToggleValueChanged);
	}

	// Events
	void ToggleValueChanged(bool value)
	{

	}
}
