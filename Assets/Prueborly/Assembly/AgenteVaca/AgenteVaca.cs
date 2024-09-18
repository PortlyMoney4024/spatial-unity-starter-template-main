using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgenteVaca : MonoBehaviour
{
    public StateMachine<AgenteVaca> mEstados;

    //public float incremento;

    public float comida;
    public float resistencia;
    public float lactancia;
    public float estres;

    public static AgenteVaca instanciaV;

    public float velocidadMovimiento = 5f;

    public bool zonaS;
    public bool zonaP;
    public bool zonaL;
    public bool asustada;

    public string estadoActual;

    public TMP_Text indicadorEstados;

    private void Awake()
    {
        if (instanciaV == null)
        {
            instanciaV = this;
        }

        else if (instanciaV != this)
        {
            Destroy(this.gameObject);
        }

        zonaS = false;
        zonaP = false;
        zonaL = false;
        asustada = false;
    }

    void Start()
    {
        mEstados = new StateMachine<AgenteVaca>(this);
        //incremento = 0;

        mEstados.SetCurrentState(EstadoIdle.instance);

        comida = 100;
        resistencia = 100;
        lactancia = 30;
        estres = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mEstados.Updating();

        indicadorEstados.text = estadoActual;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ZonaSegura"))
        {
            zonaS = true;
            zonaP = false;
            zonaL = false;
            asustada = false;
        }
        if (other.CompareTag("ZonaOrdena"))
        {
            zonaS = false;
            zonaP = false;
            zonaL = true;
        }
        if (other.CompareTag("ZonaPasto"))
        {
            zonaS = false;
            zonaP = true;
            zonaL = false;
        }
        if (other.CompareTag("Lobo"))
        {
            asustada = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ZonaSegura"))
        {
            zonaS = false;
        }
        if (other.CompareTag("ZonaOrdena"))
        {
            zonaL = false;
        }
        if (other.CompareTag("ZonaPasto"))
        {
            zonaP = false;
        }
    }
}

