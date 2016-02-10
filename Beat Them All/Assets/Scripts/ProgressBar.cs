using UnityEngine;
using System.Collections;

public class ProgressBar : MonoBehaviour 
{

	UnityEngine.UI.Slider slider;
	void Start () {
		slider = GetComponent<UnityEngine.UI.Slider>();
	}
	
	void Update () {
		// Use the property Progress to get the load percentage!
		slider.value = DPLoadScreen.Instance.Progress;
	}
}
