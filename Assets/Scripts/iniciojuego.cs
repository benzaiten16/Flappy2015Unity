using UnityEngine;
using System.Collections;

public class iniciojuego : MonoBehaviour {

	public Animator BotonJugar;
	public Animator BotonOpnciones;
	public Animator BotonCreditos;
	public Animator BotonSalir;
	public Animator panelOpciones;

	public void CambiarEscena (string Main)
	{
		Application.LoadLevel (Main); 
	}

	public void EsconderMenu (bool esconder){
	
		BotonJugar.SetBool ("esconder", esconder);
		BotonOpnciones.SetBool ("esconder", esconder);
		BotonCreditos.SetBool ("esconder", esconder);
		BotonSalir.SetBool ("esconder", esconder);
	}

	public void EsconderOpciones (bool esconder){
	
		panelOpciones.enabled = true;
		panelOpciones.SetBool ("esconder", esconder);
	}

}

