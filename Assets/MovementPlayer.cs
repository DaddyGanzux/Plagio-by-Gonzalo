//Librerias - Funciones prestadas de otros scripts 
using UnityEngine;


// Public - Da permiso de usar su informacion 
// Class - Forma de declarar 
// MovementPlayer - Nombre del script
// : Herencia - permite usar las funciones y variables de MonoBehavior 
public class MovementPlayer:MonoBehaviour 
{

    //Variables

    //float
    //int
    //string
    //bool
    //char

    public float numero = 15f;
    private int VidaPersonaje = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Debug.Log("Start empieza aqui");

    }//End Start

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Update empieza aqui");

        if (VidaPersonaje <= 0)
        {
            Debug.Log("Mamaste");
        }

    }//End Update 

    //Da una taza fija de frames 
    private void FixedUpdate()
    {
        
    }

}//End class
