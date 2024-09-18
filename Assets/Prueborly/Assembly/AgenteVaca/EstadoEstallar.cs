using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoEstallar : State<AgenteVaca>
{
    public static EstadoEstallar instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //Debug.Log("Estallido ya no nulo");
        }

        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void Enter(AgenteVaca entidad)
    {
        Debug.Log("Explotar");

        entidad.estadoActual = "Estallar";
    }

    public override void Excute(AgenteVaca entidad)
    {
        //Hacer explotar la vaca
        Destroy(entidad.gameObject, 3f);
        Debug.Log("Destruir vaca");
    }

    public override void Exit(AgenteVaca entidad)
    {

    }
}
