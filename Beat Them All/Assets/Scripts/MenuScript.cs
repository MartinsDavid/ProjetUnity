using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class MenuScript : MonoBehaviour {

	public Canvas quitMenu;
	public Button startText;
	public Button exitText;

	public Canvas optionsMenu;
	public Button test;

	public Toggle toggle;

	public AudioClip playGameSound;
	public AudioClip quitSound;
	
	public string scene;






	
	public Animator initiallyOpen;
	
	private int m_OpenParameterId;
	private Animator m_Open;
	private GameObject m_PreviouslySelected;
	
	const string k_OpenTransitionName = "Open";
	const string k_ClosedStateName = "Closed";



	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;

		optionsMenu = optionsMenu.GetComponent<Canvas> ();
		test = test.GetComponent<Button>();


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("escape"))
			Application.Quit ();



	}

	public void LoadScene()
	{
		AudioSource.PlayClipAtPoint (playGameSound, transform.position);
		Application.LoadLevel (scene);
	}

	public void ExitPress()
	{
		quitMenu.enabled = true;
		startText.enabled = false;
		exitText.enabled = false;
	}

	public void NoPress()
	{
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
	}

	public void ExitGame()
	{
		AudioSource.PlayClipAtPoint (quitSound, transform.position);
		Application.Quit ();
	}

	public void OptionsPress()
	{
		quitMenu.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;
		//optionsMenu.enabled = true;
	}










	
	public void OnEnable()
	{
		m_OpenParameterId = Animator.StringToHash (k_OpenTransitionName);
		
		if (initiallyOpen == null)
			return;
		
		OpenPanel(initiallyOpen);
	}
	
	public void OpenPanel (Animator anim)
	{
		if (m_Open == anim)
			return;
		
		anim.gameObject.SetActive(true);
		var newPreviouslySelected = EventSystem.current.currentSelectedGameObject;
		
		anim.transform.SetAsLastSibling();
		
		CloseCurrent();
		
		m_PreviouslySelected = newPreviouslySelected;
		
		m_Open = anim;
		m_Open.SetBool(m_OpenParameterId, true);
		
		GameObject go = FindFirstEnabledSelectable(anim.gameObject);
		
		SetSelected(go);
	}
	
	static GameObject FindFirstEnabledSelectable (GameObject gameObject)
	{
		GameObject go = null;
		var selectables = gameObject.GetComponentsInChildren<Selectable> (true);
		foreach (var selectable in selectables) {
			if (selectable.IsActive () && selectable.IsInteractable ()) {
				go = selectable.gameObject;
				break;
			}
		}
		return go;
	}
	
	public void CloseCurrent()
	{
		if (m_Open == null)
			return;
		
		m_Open.SetBool(m_OpenParameterId, false);
		SetSelected(m_PreviouslySelected);
		StartCoroutine(DisablePanelDeleyed(m_Open));
		m_Open = null;
	}
	
	IEnumerator DisablePanelDeleyed(Animator anim)
	{
		bool closedStateReached = false;
		bool wantToClose = true;
		while (!closedStateReached && wantToClose)
		{
			if (!anim.IsInTransition(0))
				closedStateReached = anim.GetCurrentAnimatorStateInfo(0).IsName(k_ClosedStateName);
			
			wantToClose = !anim.GetBool(m_OpenParameterId);
			
			yield return new WaitForEndOfFrame();
		}
		
		if (wantToClose)
			anim.gameObject.SetActive(false);
	}
	
	private void SetSelected(GameObject go)
	{
		EventSystem.current.SetSelectedGameObject(go);
	}








}
