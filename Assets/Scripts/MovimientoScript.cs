using UnityEngine;
using System.Collections;

public class MovimientoScript : MonoBehaviour {
    //public GameObject playerObject = null; // will be populated when bullet create
    //public float bulletSpeed = 15.0f;

    //  public Rigidbody rb;
    //void Start()
    //{
    //    rb = GetComponent<Rigidbody>();
    //}

    /// La velocidad
    public Vector2 velocidad = new Vector2(5, 5);

    // Guardamos el movimiento
    private Vector2 movimiento;

    // Colocamos la velocidad
    public Vector2 direccion = new Vector2(-1, 0);

    /// <summary>
    /// Se ejecuta en cada frame del juego (fps)
    /// </summary>
    void Update()
    {

        // Movemos segun la direccion
        movimiento = new Vector2(
        velocidad.x * direccion.x,
        velocidad.y * direccion.y);

    }

    /// <summary>
    /// Igual que update pero se ejectua por cada frame fijo, se utiliza cuando trabajas con fisicas
    /// </summary>
 
    void FixedUpdate()
    {
        //Movemos el cohete en el juego
        GetComponent<Rigidbody2D>().velocity = movimiento;
    }
}
