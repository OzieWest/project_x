using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    public GameObject Inst(UnityEngine.Object prefab, Vector3 position, Quaternion rotation)
	{
		return (GameObject)Instantiate(prefab, position, rotation);
	}

	public U Inst<U>(UnityEngine.Object prefab, Vector3 position, Quaternion rotation) where U : Component
	{
		var newObj = (GameObject)Instantiate(prefab, position, rotation);
		return newObj.GetComponent<U>();
	}
}