using UnityEngine;

public interface ISelector
{
    void Check(Ray ray);
    GameObject GetSelection();

}