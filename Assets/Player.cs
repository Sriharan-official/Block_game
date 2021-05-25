using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed = 15f;
    private Rigidbody2D rb;
    public float maplength = 5f;
    public float Restartdelay = 1f;
    public float slow = 10f;
    public GameObject panel;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        //float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        //Vector2 newpos = rb.position + Vector2.right * x;

        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * speed, 0f * Time.fixedDeltaTime) ;
        Vector2 newpos = rb.position + movement ;
        Debug.Log(movement);
        Debug.Log(newpos);

        newpos.x = Mathf.Clamp(newpos.x, -maplength, maplength);
        rb.MovePosition(newpos);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        load();

    }

    void load()
    {
        StartCoroutine(restart());
    }

    IEnumerator restart()
    {
        Time.timeScale = 1f / slow;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slow;
        yield return new WaitForSeconds(1f/ slow);
        Time.timeScale = 1f ;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slow;
        panel.SetActive(true);
        Destroy(gameObject);    }
}
