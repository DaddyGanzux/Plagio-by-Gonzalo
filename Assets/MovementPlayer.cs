//Librerias - Funciones prestadas de otros scripts 
using UnityEngine;


// Public - Da permiso de usar su informacion 
// Class - Forma de declarar 
// MovementPlayer - Nombre del script
// : Herencia - permite usar las funciones y variables de MonoBehavior 
public class MovementPlayer : MonoBehaviour
{

    public Transform transformPlayer;
    public Rigidbody2D rigidBody2DPlayer;

    /*Variables

    float
    int
    string
    bool
    char*/

    private int VidaPersonaje = 0;
    public float numero = 15f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Debug.Log("Start empieza aqui");

        rigidBody2DPlayer = GetComponent<Rigidbody2D>();   //Jala el rb del objeto 

    }//End Start

    // Update is called once per frame
    void Update()
    {

        //Moverse a la izquierda
        if (Input.GetKey(KeyCode.A))
        {
            //transformPlayer.position += new Vector3(-5, 0, 0) * Time.deltaTime;
            Debug.Log("Vamos a la izquierda");

            //rigidBody2DPlayer
        }

        //Moverse a la Derecha
        if (Input.GetKey(KeyCode.D))
        {
            transformPlayer.position += new Vector3(5, 0, 0) * Time.deltaTime;
            Debug.Log("Vamos a la Derecha");
        }

        //Saltar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transformPlayer.position += new Vector3(0, 500, 0) * Time.deltaTime;
            Debug.Log("Saltemos");
        }



       /* Debug.Log("Update empieza aqui");

        if (VidaPersonaje <= 0)
        {
            Debug.Log("Mamaste");
        }*/

    }//End Update 

    //Da una taza fija de frames 
    private void FixedUpdate()
    {
        
    }

}//End class
