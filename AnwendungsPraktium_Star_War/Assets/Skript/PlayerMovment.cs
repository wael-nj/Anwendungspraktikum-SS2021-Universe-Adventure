using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovment : MonoBehaviour
{

   
       
    [Header("Input Setup Setting")]
    [SerializeField] InputAction movmentplayer;
    [SerializeField] InputAction fire;
    [SerializeField] InputAction mausMovmentplayer;


    [Header("Playermovment Setting")]
    [SerializeField] float controlspeed = 10f;
    [SerializeField] float playerspeed = 30f;

    [Header("Screen Position")]
    [SerializeField] float xRang = 60f;
    [SerializeField] float yRang = 40f;


    [Header("Lasers Objects")]
    [SerializeField] GameObject[] lasers;
  

    float horizontal, vertical;
 
    private void Awake()
    {

    }
    void Start()
    {
        
    }
   
    /*
        Enable Input Setting

    */
    private void OnEnable()
    {

        movmentplayer.Enable();
        mausMovmentplayer.Enable();
        fire.Enable();
    }

     /*
        Disable Input Setting

    */
    private void OnDisable()
    {

        movmentplayer.Disable();
        mausMovmentplayer.Disable();
        fire.Disable();
    }
    // Update is called once per frame

    void Update()
    {
        Translation();
        firing();

    }


    /*
            Translation() Diese Methode wird verwendet, um die Bewegung der Spieler auf der X-, Y- und Z-Achse  mit dem Maus und Keyborad zu ermöglichen.
            Clamped wird verwendet, um den Bereich der Spieler zu begrenzen
            
    */

    void Translation()
    {

        /*
            lesen die Input von den Maus und Keyborad

        */

        float mouseY = Input.GetAxis("Mouse Y");
         horizontal  = movmentplayer.ReadValue<Vector2>().x * Time.deltaTime * playerspeed;
        vertical     = movmentplayer.ReadValue<Vector2>().y * Time.deltaTime * playerspeed;

        /*
            Clamped wird verwendet, um den Bereich der Spieler auf X-Achse zu begrenzen
            
        */
        float xOffset = horizontal * controlspeed; ;
        float rowXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rowXPos, -xRang, xRang);

        /*
             Clamped wird verwendet, um den Bereich der Spieler auf Y-Achse zu begrenzen
            
        */

        float yOffset = mouseY * controlspeed;
        float rowYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rowYPos, -yRang, yRang);

        /*

           Die Koordinate für den Bereich der Spieler, die gehen dürfen, festlegen
            
        */

        transform.localPosition = new Vector3(clampedXPos , clampedYPos,  transform.localPosition.z);

        /*

           Die Translate-Koordinate für den Bereich der Spieler mit Maus und Keyborad
            
        */
        
        transform.Translate(horizontal, mouseY, vertical);
    }


    /*

        Lesen der Mauseingabe beim Klicken wenn die Maustaste gedrückt wird,
        wird die Methode SetLesser aktiviert 

    */
    void firing()
    {    
        if (fire.ReadValue<float>() > 0.5)
        {
            setlaserON(true);
           
        }
        else
        {
            setlaserON(false);

        }

    }

        /*
            Alle Leser Element wird aktiviert.
            Leser sind Partkielsystem die Haben eine Emission-Attrubite, die für genierung der anzahl der Partiekle verantowrlich ist .
            wenn die Wert True ist wird Emission akktiveirt.
            wenn die Wert False ist wird Emission deaktiviert.

        */
    void setlaserON(bool isActive)
    {
         
        foreach (GameObject item in lasers)
        {
           
            var emissionModule = item.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }

    }

}
