using UnityEngine;
using System.Collections;

/// <summary>
/// Comportamiento del arma
/// </summary>
public class ArmaScript : MonoBehaviour
{

    /// <summary>
    /// Componente transform del disparo
    /// </summary>
    public Transform disparoReutilizado;

    /// <summary>
    /// Esperaremos un tiempo entre un disparo y otro para generarse
    /// </summary>
    public float tiempoEsperaDisparos = 0.25f;

    //--------------------------------
    // Tiempo de espera
    //--------------------------------

    private float tiempoEntreDisparos;

    void Start()
    {
        tiempoEntreDisparos = 0f;
    }

    void Update()
    {
        if (tiempoEntreDisparos > 0)
        {
            tiempoEntreDisparos -= Time.deltaTime;
        }
    }

    //--------------------------------
    // Disparando desde otro Script
    //--------------------------------

    /// <summary>
    /// Crear un nuevo disparo de ser posible
    /// </summary>
    public void Ataque(bool esEnemigo)
    {
        if (PuedeAtacar)
        {
            tiempoEntreDisparos = tiempoEsperaDisparos;

            // Traemos el componente Transform del DisparoReutilizado
            var disparoTransform = Instantiate(disparoReutilizado) as Transform;

            // Asignamos una posicion
            disparoTransform.position = transform.position;

            // Vemos si es fuego enemigo
            DisparoScript disparo = disparoTransform.gameObject.GetComponent<DisparoScript>();
            if (disparo != null)
            {
                disparo.esDisparoEnemigo = esEnemigo;
            }

            // Hacemos que se mueva siempre a la derecha
            MovimientoScript movimiento = disparoTransform.gameObject.GetComponent<MovimientoScript>();
            if (movimiento != null)
            {
                movimiento.direccion = this.transform.right;
            }
        }
    }

    /// <summary>
    /// Listo para lanzar un nuevo disparo?
    /// </summary>
    public bool PuedeAtacar
    {
        get
        {
            return tiempoEntreDisparos <= 0f;
        }
    }
}