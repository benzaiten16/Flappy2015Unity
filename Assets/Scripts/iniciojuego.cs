using UnityEngine;
using System.Collections;

public class iniciojuego : MonoBehaviour {

	public Animator BotonJugar;
	public Animator BotonOpnciones;
	public Animator BotonCreditos;
	public Animator BotonSalir;
	public Animator panelOpciones;
	public Animator panelCreditos;

	void Start () {
		Time.timeScale = 1;
	}

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

	public void EsconderCreditos (bool esconder){
		
		panelCreditos.enabled = true;
		panelCreditos.SetBool ("esconder", esconder);
	}

}

