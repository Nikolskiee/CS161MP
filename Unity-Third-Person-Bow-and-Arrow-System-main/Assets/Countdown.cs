using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public float timeStart = 60;
    public Text timer;

    // Start is called before the first frame update
    public void Start()
    {
        timer = GetComponent<Text>();
        timer.text = timeStart.ToString();
    }

    // Update is called once per frame
    public void Update()
    {
        timeStart -= Time.deltaTime;
        timer.text = "Time: " + Mathf.Round(timeStart).ToString();

        if(timeStart <= 0)
        {
            
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
