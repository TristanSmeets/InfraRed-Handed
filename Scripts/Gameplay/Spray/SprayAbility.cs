using UnityEngine;

public class SprayAbility : MonoBehaviour
{
	Transform playerLocation;

	private void Start()
	{
		playerLocation = GameObject.FindGameObjectWithTag(GeneralVariables.PlayerTag).transform;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.GetComponent<ShaderFadeOut>())
		{
			Material material = other.gameObject.GetComponent<Renderer>().material;
			material.SetVector(
				"_PlayerPosVector",
				new Vector4(transform.position.x,
				transform.position.y,
				transform.position.z,
				0));
			other.gameObject.GetComponent<ShaderFadeOut>().StartFadeOut();
		}
	}
}
