//Librerias - Funciones prestadas de otros scripts 
using UnityEngine;


// Public - Da permiso de usar su informacion 
// Class - Forma de declarar 
// MovementPlayer - Nombre del script
// : Herencia - permite usar las funciones y variables de MonoBehavior 
public class MovementPlayer:MonoBehaviour 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Debug.Log("Start empieza aqui");

    }//End Start

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Update empieza aqui");

    }//End Update 

    //Da una taza fija de frames 
    private void FixedUpdate()
    {
        
    }

}//End class
