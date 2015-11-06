using UnityEngine;
using System.Collections;

/// <summary>
/// Comportamiento de la salud de los objetos
/// </summary>
public class SaludScript : MonoBehaviour
{

    /// <summary>
    /// Numero de puntos de salud
    /// </summary>
    public int ps = 2;

    /// <summary>
    /// Es jugador o enemigo?
    /// </summary>
    public bool esEnemigo = true;

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Es un disparo?
        DisparoScript disparo = collider.gameObject.GetComponent<DisparoScript>();
        if (disparo != null)
        {
            // Revisamos si es enemigo o compañero
            if (disparo.esDisparoEnemigo != esEnemigo)
            {
                ps -= disparo.danho;

                // Destruimos el disparo
                // No coloquen solo Destroy()
                //sino eliminaran el Script
                Destroy(disparo.gameObject);

                if (ps <= 0)
                {
                    // Muerto!
                    Destroy(gameObject);
                }
            }
        }
    }
}