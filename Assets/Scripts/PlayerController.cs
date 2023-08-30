using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;


    public Rigidbody2D rb;

    public GameObject selectedSkin;
    public GameObject playerPhoto;
    private Sprite playerPhotoSprite;

    public Image healthBar;

    public bool Win1 = false;
    public bool Win2 = false;
    public bool Win3 = false;

    public float moveSpeed;
    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity;

    public Camera viewCam;

    public GameObject bulletImpact;
    public int currentAmmo;

    public Animator gunAnim,aimAnim;


    public float currentHealth;
    public float maxHealth = 100f;

    public GameObject deadScreen;
    public bool hasDied;

    public TMP_Text ammoText;


    public Animator anim;
    [SerializeField] private AudioClip playerFiring;
    [SerializeField] private AudioSource audioMenu;


    float maxAngle = 160;
    float minAngle = 10;


    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = currentHealth;
        ammoText.text = currentAmmo.ToString();
    }


    private void Update()
    {
        //movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * -moveInput.x;

        Vector3 moveVertical = transform.right * moveInput.y;

        rb.velocity = (moveHorizontal + moveVertical) * moveSpeed;

        //player view controll
        mouseInput = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

        Vector3 RotAmount = viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f);


        viewCam.transform.localRotation = Quaternion.Euler(RotAmount.x, Mathf.Clamp(RotAmount.y, minAngle, maxAngle), RotAmount.z);


        //shooting
        if (Input.GetMouseButtonDown(0))
        {
            if (currentAmmo > 0)
            {

                Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Instantiate(bulletImpact, hit.point, transform.rotation);

                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                    }
                    else if (hit.transform.tag == "Boss")
                    {
                        hit.transform.parent.GetComponent<BosController>().TakeDamage();
                    }

                }
                else
                {
                    Debug.Log("I am lookingat nothing");
                }
                currentAmmo--;
                AudioController.instance.PlayGunShoot();
                gunAnim.SetTrigger("Shoot");
                aimAnim.SetTrigger("Aim");
                UpdateAmmo();
            }

        }
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

    }


    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);

        if (currentHealth <= 0)
        {

            if (Win1 == true)
            {
                SceneManager.LoadScene("Game Over");
                hasDied = true;
                currentHealth = 0;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }

            if (Win2 == true)
            {
                SceneManager.LoadScene("Game Over");
                hasDied = true;
                currentHealth = 0;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }


            if (Win3 == true)
            {

                SceneManager.LoadScene("Game Over");
                hasDied = true;
                currentHealth = 0;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }



        }

        healthBar.fillAmount = currentHealth / 100f;


        AudioController.instance.PlayPlayerHurt();
    }

    public void AddHealth(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.fillAmount = currentHealth / 100f;
    }

    public void AddHealth1(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.fillAmount = currentHealth / 100f;
    }


    public void AddHealth2(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.fillAmount = currentHealth / 100f;
    }

    public void AddHealth3(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, 100);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.fillAmount = currentHealth / 100f;
    }


    public void UpdateAmmo()
    {
        ammoText.text = "X " + currentAmmo.ToString();
    }


}
