using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // UI işlemleri için bu kütüphaneyi ekledik

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public Camera playerCamera; 
    
    public TextMeshProUGUI keyTextUI; 

    private CharacterController controller;
    private float xRotation = 0f;
    public int keyCount = 0;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; 
        
        // Oyun başlarken yazıyı 0 olarak ayarla
        if(keyTextUI != null) keyTextUI.text = "Keys: 0/3"; 
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); 
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX); 

        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical");   
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            keyCount++; 
            Destroy(other.gameObject); 
            
            if(keyTextUI != null) keyTextUI.text = "Keys: " + keyCount + "/3";
            
            if (keyCount >= 3)
            {
                Cursor.lockState = CursorLockMode.None; 
                SceneManager.LoadScene("WinScene"); 
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            Cursor.lockState = CursorLockMode.None; 
            SceneManager.LoadScene("LoseScene"); 
        }
    }
}