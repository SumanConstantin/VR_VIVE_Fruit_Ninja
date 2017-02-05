using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class KatanaMonoBehaviour : MonoBehaviour
{
    public SteamVR_TrackedObject trackedObj;
    public Material capMaterial;

    void OnCollisionEnter(Collision collision)
    {
        GameObject victim = collision.collider.gameObject;

        GameObject[] pieces = BLINDED_AM_ME.MeshCut.Cut(victim, transform.position, transform.right, capMaterial);

        if (!pieces[1].GetComponent<Rigidbody>())
        {
            pieces[1].AddComponent<Rigidbody>();
            MeshCollider meshColl = pieces[1].AddComponent<MeshCollider>();
            meshColl.convex = true;
        }

        StartCoroutine(LongVibration(.5f, .5f));
    }

    IEnumerator LongVibration(float length, float strength)
    {
        for(float i = 0; i < length; i+= Time.deltaTime)
        {
            SteamVR_Controller.Input((int)trackedObj.index).TriggerHapticPulse((ushort)Mathf.Lerp(0, 3999, strength));
        }
        yield return null;
    }
}
