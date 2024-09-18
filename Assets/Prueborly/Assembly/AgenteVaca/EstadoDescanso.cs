using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoDescanso : State<AgenteVaca>
{
    public static EstadoDescanso instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Debug.Log("Descanso ya no nulo");
        }

        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void Enter(AgenteVaca entidad)
    {
        Debug.Log("Descansar");

        /*if (entidad.resistencia > 85)
        {
            entidad.mEstados.ChangeState(EstadoIdle.instance);
        }
        if (entidad.comida < 30)
        {
            entidad.mEstados.ChangeState(EstadoPastar.instance);
        }
        if (entidad.lactancia > 80)
        {
            entidad.mEstados.ChangeState(EstadoOrdenar.instance);
        }
        if (entidad.asustada && entidad.resistencia > 50)
        {
            entidad.mEstados.ChangeState(EstadoEscapar.instance);
        }
        if (entidad.estres > 60)
        {
            entidad.mEstados.ChangeState(EstadoJugar.instance);
        }*/

        entidad.estadoActual = "Descansar";
    }

    public override void Excute(AgenteVaca entidad)
    {
        entidad.resistencia += 7 * Time.deltaTime;
        entidad.estres -= Time.deltaTime;
        entidad.comida -= Time.deltaTime;
        if (entidad.comida > 77)
        {
            entidad.lactancia += 3 * Time.deltaTime;
        }
        else if (entidad.comida > 40)
        {
            entidad.lactancia += Time.deltaTime;
        }

        //Cambio de estado
        if (entidad.resistencia > 85)
        {
            entidad.mEstados.ChangeState(EstadoIdle.instance);
        }
        if (entidad.comida < 30)
        {
            entidad.mEstados.ChangeState(EstadoPastar.instance);
        }
        if (entidad.lactancia > 80)
        {
            entidad.mEstados.ChangeState(EstadoOrdenar.instance);
        }
        if (entidad.asustada && entidad.resistencia > 50)
        {
            entidad.mEstados.ChangeState(EstadoEscapar.instance);
        }
        if (entidad.estres > 60)
        {
            entidad.mEstados.ChangeState(EstadoJugar.instance);
        }
    }

    public override void Exit(AgenteVaca entidad)
    {

    }
}
