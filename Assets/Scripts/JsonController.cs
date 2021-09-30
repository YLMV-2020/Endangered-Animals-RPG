using System.Collections.Generic;
using UnityEngine;

public class JsonController : MonoBehaviour
{

    public static List<T> getJsonList<T>(string json)
    {
        List<T> lista = new List<T>();
        string[] datos = json.Split('}');

        for (int i = 0; i < datos.Length - 1; i++)
        {
            datos[i] = datos[i].Remove(0, 1);
            datos[i] = datos[i].Insert(datos[i].Length, "}");

            T obj = JsonUtility.FromJson<T>(datos[i]);
            lista.Add(obj);
        }

        return lista;
    }

    public static T[] FromJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }

}
