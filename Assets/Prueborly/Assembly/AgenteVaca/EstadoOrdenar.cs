using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoOrdenar : State<AgenteVaca>
{
    public static EstadoOrdenar instance;

    GameObject zonaOrde�a;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Debug.Log("Orde�ar ya no nulo");
        }

        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void Enter(AgenteVaca entidad)
    {
        Debug.Log("Orde�ar");

        /*if (entidad.lactancia < 30)
        {
            entidad.mEstados.ChangeState(EstadoIdle.instance);
        }
        if (entidad.asustada)
        {
            entidad.mEstados.ChangeState(EstadoEscapar.instance);
        }
        if (entidad.comida < 40)
        {
            entidad.mEstados.ChangeState(EstadoPastar.instance);
        }*/

        zonaOrde�a = GameObject.FindGameObjectWithTag("ZonaOrdena");

        entidad.estadoActual = "Orde�ar";
    }

    public override void Excute(AgenteVaca entidad)
    {
        if (entidad.zonaL)
        {
            entidad.lactancia -= Time.deltaTime;
        }
        entidad.comida -= 2 * Time.deltaTime;

        Vector3 posicionZonaPastar = zonaOrde�a.transform.position;
        Vector3 direccion = (posicionZonaPastar - entidad.transform.position).normalized;
        entidad.transform.Translate(direccion * entidad.velocidadMovimiento * Time.deltaTime);

        //Cambio de estado
        if (entidad.lactancia < 30)
        {
            entidad.mEstados.ChangeState(EstadoIdle.instance);
        }
        if (entidad.asustada)
        {
            entidad.mEstados.ChangeState(EstadoEscapar.instance);
        }
        if (entidad.comida < 40)
        {
            entidad.mEstados.ChangeState(EstadoPastar.instance);
        }
    }

    public override void Exit(AgenteVaca entidad)
    {

    }
}
