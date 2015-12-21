using UnityEngine;
using System.Collections;

public class StoryScript : MonoBehaviour {

    public GameObject text;
    public GameObject title;
    public int speed = 1;
    public string level;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("escape"))
            Application.LoadLevel(level);

        title.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        text.transform.Translate(Vector3.up * Time.deltaTime * speed / 4);


    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(7);
        Application.LoadLevel(level);
    }

}
