using UnityEngine;
using UnityEngine.SceneManagement;

public class loadagain : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
