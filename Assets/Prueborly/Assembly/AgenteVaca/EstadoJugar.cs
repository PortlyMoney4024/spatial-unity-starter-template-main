using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoJugar : State<AgenteVaca>
{
    public static EstadoJugar instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Debug.Log("Jugar ya no nulo");
        }

        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void Enter(AgenteVaca entidad)
    {
        Debug.Log("Jugar");

        /*if (entidad.comida < 40)
        {
            entidad.mEstados.ChangeState(EstadoPastar.instance);
        }
        if (entidad.estres > 80)
        {
            entidad.mEstados.ChangeState(EstadoIdle.instance);
        }
        if (entidad.resistencia < 30)
        {
            entidad.mEstados.ChangeState(EstadoDescanso.instance);
        }
        if (entidad.asustada)
        {
            entidad.mEstados.ChangeState(EstadoEscapar.instance);
        }*/

        entidad.estadoActual = "Jugar";
    }

    public override void Excute(AgenteVaca entidad)
    {
        entidad.comida -= 3 * Time.deltaTime;
        entidad.estres -= 5 * Time.deltaTime;
        entidad.resistencia -= Time.deltaTime;
        if (entidad.comida > 77)
        {
            entidad.lactancia += 3 * Time.deltaTime;
        }
        else if (entidad.comida > 40)
        {
            entidad.lactancia += Time.deltaTime;
        }

        //Cambio de estado
        if (entidad.comida < 40)
        {
            entidad.mEstados.ChangeState(EstadoPastar.instance);
        }
        if (entidad.estres > 80)
        {
            entidad.mEstados.ChangeState(EstadoIdle.instance);
        }
        if (entidad.resistencia < 30)
        {
            entidad.mEstados.ChangeState(EstadoDescanso.instance);
        }
        if (entidad.asustada)
        {
            entidad.mEstados.ChangeState(EstadoEscapar.instance);
        }
    }

    public override void Exit(AgenteVaca entidad)
    {

    }
}
