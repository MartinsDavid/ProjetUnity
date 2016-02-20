using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoryScript : MonoBehaviour {

    public GameObject text;
    public GameObject title;
    public int speed = 1;
    public string level;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("escape"))
            SceneManager.LoadScene(level);

        title.transform.Translate(Vector3.forward * Time.deltaTime * speed);
        text.transform.Translate(Vector3.up * Time.deltaTime * speed / 4);


    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(7);
        SceneManager.LoadScene(level);
    }

}
