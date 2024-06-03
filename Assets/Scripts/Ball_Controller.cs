using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BallController : MonoBehaviour
{
    public float jumpForce;

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;
    public Color[] colors;
    public string[] colorNames = { "Cyan", "Yellow", "Pink", "Purple" };

    public int star;
    public TextMeshProUGUI starText;

    void Start()
    {
        
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }

        
        sr.enabled = true;

        
        Color initialColor = sr.color;
        initialColor.a = 1f;
        sr.color = initialColor;

        
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        
        transform.localScale = new Vector3(2, 2, 1);

        RandomColor();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Fall")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (col.tag == "Star")
        {
            star++;
            starText.text = star.ToString();
            Destroy(col.gameObject);
            return;
        }
        if (col.tag == "ColorChanger")
        {
            RandomColor();
            Destroy(col.gameObject);
            return;
        }
        if (col.tag != currentColor)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void RandomColor()
    {
        int index = Random.Range(0, colors.Length);

        currentColor = colorNames[index];
        Color selectedColor = colors[index];
        selectedColor.a = 1f; 
        sr.color = selectedColor;
    }
}
