using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPastar : State<AgenteVaca>
{
    public static EstadoPastar instance;

    GameObject zonaPastar;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Debug.Log("Pastar ya no nulo");
        }

        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void Enter(AgenteVaca entidad)
    {
        Debug.Log("Pastar");

        /*if (entidad.comida > 95)
        {
            entidad.mEstados.ChangeState(EstadoIdle.instance);
        }
        if (entidad.asustada)
        {
            entidad.mEstados.ChangeState(EstadoEscapar.instance);
        }
        if (entidad.lactancia > 80)
        {
            entidad.mEstados.ChangeState(EstadoOrdenar.instance);
        }*/

        zonaPastar = GameObject.FindGameObjectWithTag("ZonaPasto");

        entidad.estadoActual = "Pastar";
    }

    public override void Excute(AgenteVaca entidad)
    {
        if (entidad.zonaP)
        {
            entidad.comida += 7 * Time.deltaTime;
        }
        entidad.estres -= 0.3f * Time.deltaTime;
        if (entidad.comida > 77)
        {
            entidad.lactancia += 3 * Time.deltaTime;
        }
        else if (entidad.comida > 40)
        {
            entidad.lactancia += Time.deltaTime;
        }

        Vector3 posicionZonaPastar = zonaPastar.transform.position;
        Vector3 direccion = (posicionZonaPastar - entidad.transform.position).normalized;
        entidad.transform.Translate(direccion * entidad.velocidadMovimiento * Time.deltaTime);

        //Cambio de estado
        if (entidad.comida > 95)
        {
            entidad.mEstados.ChangeState(EstadoIdle.instance);
        }
        if (entidad.asustada)
        {
            entidad.mEstados.ChangeState(EstadoEscapar.instance);
        }
        if (entidad.lactancia > 80)
        {
            entidad.mEstados.ChangeState(EstadoOrdenar.instance);
        }
    }

    public override void Exit(AgenteVaca entidad)
    {

    }
}
