using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoIdle : State<AgenteVaca>
{
    public static EstadoIdle instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Debug.Log("Idle ya no nulo");
        }

        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void Enter(AgenteVaca entidad)
    {
        Debug.Log("Idle");

        /*if (entidad.comida < 30)
        {
            entidad.mEstados.ChangeState(EstadoPastar.instance);
        }
        if (entidad.estres > 70)
        {
            entidad.mEstados.ChangeState(EstadoJugar.instance);
        }
        if (entidad.asustada)
        {
            entidad.mEstados.ChangeState(EstadoEscapar.instance);
        }
        if (entidad.lactancia > 80)
        {
            entidad.mEstados.ChangeState(EstadoOrdenar.instance);
        }*/

        entidad.estadoActual = "Idle";
    }

    public override void Excute(AgenteVaca entidad)
    {
        entidad.comida -= 3 * Time.deltaTime;
        entidad.estres += Time.deltaTime;
        if (entidad.comida > 77)
        {
            entidad.lactancia += 3 * Time.deltaTime;
        }
        else if (entidad.comida > 40)
        {
            entidad.lactancia += Time.deltaTime;
        }

        //Cambio de estado
        if (entidad.comida < 30)
        {
            entidad.mEstados.ChangeState(EstadoPastar.instance);
        }
        if (entidad.estres > 70)
        {
            entidad.mEstados.ChangeState(EstadoJugar.instance);
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
