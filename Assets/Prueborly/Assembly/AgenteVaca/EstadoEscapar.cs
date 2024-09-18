using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoEscapar : State<AgenteVaca>
{
    public static EstadoEscapar instance;

    GameObject zonaSegura;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Debug.Log("Escapar ya no nulo");
        }

        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void Enter(AgenteVaca entidad)
    {
        Debug.Log("Escapar");

        /*if (entidad.estres > 90)
        {
            entidad.mEstados.ChangeState(EstadoEstallar.instance);
        }
        else if (entidad.estres > 60 && entidad.comida < 50)
        {
            entidad.mEstados.ChangeState(EstadoEstallar.instance);
        }
        else if (entidad.zonaS)
        {
            entidad.mEstados.ChangeState(EstadoDescanso.instance);
        }*/

        zonaSegura = GameObject.FindGameObjectWithTag("ZonaSegura");

        entidad.estadoActual = "Escapar";
    }

    public override void Excute(AgenteVaca entidad)
    {
        entidad.estres += 5 * Time.deltaTime;
        entidad.resistencia -= 5 * Time.deltaTime;
        entidad.comida -= 2 * Time.deltaTime;

        Vector3 posicionZonaSegura = zonaSegura.transform.position;
        Vector3 direccion = (posicionZonaSegura - entidad.transform.position).normalized;
        entidad.transform.Translate(direccion * entidad.velocidadMovimiento * Time.deltaTime);

        //Cambio de estado
        if (entidad.estres > 90)
        {
            entidad.mEstados.ChangeState(EstadoEstallar.instance);
        }
        if (entidad.estres > 60 && entidad.comida < 50)
        {
            entidad.mEstados.ChangeState(EstadoEstallar.instance);
        }
        if (entidad.zonaS)
        {
            entidad.mEstados.ChangeState(EstadoDescanso.instance);
        }
    }

    public override void Exit(AgenteVaca entidad)
    {

    }
}
